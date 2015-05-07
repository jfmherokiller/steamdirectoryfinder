using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Steam4Net
{
    public interface ICallback
    {
        void Run(IntPtr param);
    }

    public interface IApiCallback : ICallback
    {
        int GetExpectedSize();

        int GetExpectedCallback();

        void ClearApiCallHandle();
    }

    public class Callback<TCallbackType> : ICallback
    {
        public delegate void DispatchDelegate(TCallbackType param);

        public Callback()
        {
            CallbackDispatcher.RegisterCallback(this, CallbackIdentities.GetCallbackIdentity(typeof(TCallbackType)));
        }

        public Callback(DispatchDelegate myFunc)
            : this()
        {
            OnRun += myFunc;
        }

        public void Run(IntPtr pubParam)
        {
            if (OnRun != null)
                OnRun((TCallbackType)Marshal.PtrToStructure(pubParam, typeof(TCallbackType)));
        }

        public event DispatchDelegate OnRun;

        ~Callback()
        {
            UnRegister();
        }

        public void UnRegister()
        {
            CallbackDispatcher.UnRegisterCallback(this, CallbackIdentities.GetCallbackIdentity(typeof(TCallbackType)));
        }
    }

    public class ApiCallCallback<TCallbackType> : IApiCallback
    {
        public delegate void ApiDispatchDelegate(ulong callHandle, TCallbackType param);

        private readonly int _callback;
        private readonly int _size;
        private ulong _callhandle;

        public ApiCallCallback()
        {
            _callback = CallbackIdentities.GetCallbackIdentity(typeof(TCallbackType));
            _size = Marshal.SizeOf(typeof(TCallbackType));
        }

        public ApiCallCallback(ApiDispatchDelegate myFunc)
            : this()
        {
            OnRun += myFunc;
        }

        public ApiCallCallback(ApiDispatchDelegate myFunc, ulong apicallhandle)
            : this(myFunc)
        {
            SetApiCallHandle(apicallhandle);
        }

        public void ClearApiCallHandle()
        {
            CallbackDispatcher.ClearApiCallCallback(this, _callhandle);
        }

        public void Run(IntPtr pubParam)
        {
            if (OnRun != null)
                OnRun(_callhandle, (TCallbackType)Marshal.PtrToStructure(pubParam, typeof(TCallbackType)));
        }

        public int GetExpectedSize()
        {
            return _size;
        }

        public int GetExpectedCallback()
        {
            return _callback;
        }

        public event ApiDispatchDelegate OnRun;

        ~ApiCallCallback()
        {
            ClearApiCallHandle();
        }

        public void SetApiCallHandle(ulong newcallhandle)
        {
            if (_callhandle != 0)
                ClearApiCallHandle();

            _callhandle = newcallhandle;
            CallbackDispatcher.RegisterApiCallCallback(this, newcallhandle);
        }
    }

    public class CallbackUnhandled
    {
        public delegate void DispatchDelegate(CallbackMsgT msg);

        public CallbackUnhandled()
        {
            CallbackDispatcher.SetUnhandledCallback(this);
        }

        public CallbackUnhandled(DispatchDelegate myFunc)
            : this()
        {
            OnRun += myFunc;
        }

        public event DispatchDelegate OnRun;

        public void Run(CallbackMsgT msg)
        {
            if (OnRun != null)
                OnRun(msg);
        }
    }

    public class CallbackDispatcher
    {
        private static readonly Dictionary<int, ICallback> RegisteredCallbacks = new Dictionary<int, ICallback>();

        private static readonly Dictionary<ulong, IApiCallback> RegisteredApiCallbacks =
            new Dictionary<ulong, IApiCallback>();

        private static CallbackUnhandled _unhandledCallback;
        private static readonly Dictionary<int, Thread> ManagedThreads = new Dictionary<int, Thread>();

        public static Callback<SteamApiCallCompletedT> ApiCallbackCompleted =
            new Callback<SteamApiCallCompletedT>(RunApiCallback);

        public static int LastActivePipe { get; private set; }

        public static void RegisterCallback(ICallback callback, int iCallback)
        {
            RegisteredCallbacks.Add(iCallback, callback);
        }

        public static void UnRegisterCallback(ICallback callback, int iCallback)
        {
            if (RegisteredCallbacks[iCallback] == callback)
            {
                RegisteredCallbacks.Remove(iCallback);
            }
        }

        public static void RegisterApiCallCallback(IApiCallback callback, ulong callhandle)
        {
            RegisteredApiCallbacks.Add(callhandle, callback);
        }

        public static void ClearApiCallCallback(IApiCallback callback, ulong callhandle)
        {
            RegisteredApiCallbacks.Remove(callhandle);
        }

        public static void SetUnhandledCallback(CallbackUnhandled callback)
        {
            _unhandledCallback = callback;
        }

        public static void RunCallbacks(int pipe)
        {
            var callbackmsg = new CallbackMsgT();

            if (Steamworks.GetCallback(pipe, ref callbackmsg))
            {
                LastActivePipe = pipe;

                ICallback callback;
                if (RegisteredCallbacks.TryGetValue(callbackmsg.m_iCallback, out callback))
                {
                    callback.Run(callbackmsg.m_pubParam);
                }
                else if (_unhandledCallback != null)
                {
                    _unhandledCallback.Run(callbackmsg);
                }

                Steamworks.FreeLastCallback(pipe);
            }
        }

        public static void RunApiCallback(SteamApiCallCompletedT apicall)
        {
            IApiCallback apiCallback;

            if (!RegisteredApiCallbacks.TryGetValue(apicall.m_hAsyncCall, out apiCallback))
                return;

            var pData = IntPtr.Zero;

            try
            {
                var bFailed = false;
                pData = Marshal.AllocHGlobal(apiCallback.GetExpectedSize());

                if (
                    !Steamworks.GetApiCallResult(LastActivePipe, apicall.m_hAsyncCall, pData,
                        apiCallback.GetExpectedSize(), apiCallback.GetExpectedCallback(), ref bFailed))
                    return;

                if (bFailed)
                    return;

                apiCallback.Run(pData);
            }
            finally
            {
                apiCallback.ClearApiCallHandle();

                Marshal.FreeHGlobal(pData);
            }
        }

        private static void DispatchThread(object param)
        {
            var pipe = (int)param;

            while (true)
            {
                RunCallbacks(pipe);
                Thread.Sleep(1);
            }
        }

        public static void SpawnDispatchThread(int pipe)
        {
            if (ManagedThreads.ContainsKey(pipe))
                return;

            var dispatchThread = new Thread(DispatchThread);
            dispatchThread.Start(pipe);

            ManagedThreads[pipe] = dispatchThread;
        }

        public static void StopDispatchThread(int pipe)
        {
            Thread dispatchThread;

            if (ManagedThreads.TryGetValue(pipe, out dispatchThread))
            {
                dispatchThread.Abort();
                dispatchThread.Join(2500);

                ManagedThreads.Remove(pipe);
            }
        }
    }
}