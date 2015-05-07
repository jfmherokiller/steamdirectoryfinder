using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;

/*
 Steamworks and NativeWrapper classes provided by Rick - http://gib.me/
*/

namespace Steam4Net
{
    public class Steamworks
    {
        private static IntPtr _steamClientHandle = IntPtr.Zero;
        private static IntPtr _steamHandle = IntPtr.Zero;
        private static Native.CreateInterface _callCreateInterface;
        private static Native.F _callCreateSteamInterface;
        private static Native.SteamBGetCallback _callSteamBGetCallback;
        private static Native.SteamFreeLastCallback _callSteamFreeLastCallback;
        private static Native.SteamGetApiCallResult _callSteamGetApiCallResult;

        /// <summary>
        ///     Gets the steam installation path.
        /// </summary>
        /// <returns>A string representing the steam installation directory, or an empty string if steam is not installed</returns>
        public static string GetInstallPath()
        {
            var installPath = "";

            try
            {
                installPath = (string)Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\Software\Valve\Steam",
                    "InstallPath",
                    null);
            }
            catch
            {
            }

            return installPath;
        }

        /// <summary>
        ///     Creates an interface from steamclient.
        /// </summary>
        /// <typeparam name="TClass">The interface type. ex: ISteamClient009</typeparam>
        /// <param name="version">The interface version.</param>
        /// <returns>An instance of an interface object, or null if an error occurred.</returns>
        public static TClass CreateInterface<TClass>() where TClass : InteropHelp.INativeWrapper, new()
        {
            if (_callCreateInterface == null)
                throw new InvalidOperationException("Steam4NET library has not been initialized.");

            var address = _callCreateInterface(InterfaceVersions.GetInterfaceIdentifier(typeof(TClass)), IntPtr.Zero);

            if (address == IntPtr.Zero)
                return default(TClass);

            var rez = new TClass();
            rez.SetupFunctions(address);

            return rez;
        }

        /// <summary>
        ///     Creates an interface from steam.
        /// </summary>
        /// <typeparam name="TClass">The interface type. ex: ISteam006</typeparam>
        /// <param name="version">The interface version.</param>
        /// <returns>An instance of an interface object, or null if an error occurred.</returns>
        public static TClass CreateSteamInterface<TClass>() where TClass : InteropHelp.INativeWrapper, new()
        {
            if (_callCreateSteamInterface == null)
                throw new InvalidOperationException("Steam4NET library has not been initialized.");

            var address = _callCreateSteamInterface(InterfaceVersions.GetInterfaceIdentifier(typeof(TClass)));

            if (address == IntPtr.Zero)
                return default(TClass);

            var rez = new TClass();
            rez.SetupFunctions(address);

            return rez;
        }

        /// <summary>
        ///     Gets the last callback in steamclient's callback queue.
        /// </summary>
        /// <param name="pipe">The steam pipe.</param>
        /// <param name="message">A reference to a callback object to copy the callback to.</param>
        /// <returns>True if a callback was copied, or false if no callback was waiting, or an error occured.</returns>
        public static bool GetCallback(int pipe, ref CallbackMsgT message)
        {
            if (_callSteamBGetCallback == null)
                throw new InvalidOperationException("Steam4NET library has not been initialized.");

            try
            {
                return _callSteamBGetCallback(pipe, ref message);
            }
            catch
            {
                message = new CallbackMsgT();
                return false;
            }
        }

        /// <summary>
        ///     Frees the last callback in steamclient's callback queue.
        /// </summary>
        /// <param name="pipe">The steam pipe.</param>
        /// <returns>True if the callback was freed; otherwise, false.</returns>
        public static bool FreeLastCallback(int pipe)
        {
            if (_callSteamFreeLastCallback == null)
                throw new InvalidOperationException("Steam4NET library has not been initialized.");

            return _callSteamFreeLastCallback(pipe);
        }

        public static bool GetApiCallResult(int hSteamPipe, ulong hSteamApiCall, IntPtr pCallback, int cubCallback,
            int iCallbackExpected, ref bool pbFailed)
        {
            if (_callSteamGetApiCallResult == null)
                throw new InvalidOperationException("Steam4NET library has not been initialized.");

            return _callSteamGetApiCallResult(hSteamPipe, hSteamApiCall, pCallback, cubCallback, iCallbackExpected,
                ref pbFailed);
        }

        /// <summary>
        ///     Loads the steamclient library. This does not load the steam library. Please use the overload to do so.
        /// </summary>
        /// <returns>A value indicating if the load was successful.</returns>
        public static bool Load()
        {
            return Load(false);
        }

        /// <summary>
        ///     Loads the steamclient library and, optionally, the steam library.
        /// </summary>
        /// <param name="steam">if set to <c>true</c> the steam library is also loaded.</param>
        /// <returns>A value indicating if the load was successful.</returns>
        public static bool Load(bool steam)
        {
            if (steam && !LoadSteam())
                return false;

            return LoadSteamClient();
        }

        /// <summary>
        ///     Loads the steam library.
        /// </summary>
        /// <returns>A value indicating if the load was successful.</returns>
        public static bool LoadSteamF(string loadpath)
        {
            if (_steamHandle != IntPtr.Zero)
                return true;

            var path = loadpath;

            if (!string.IsNullOrEmpty(path))
                Native.SetDllDirectory(path + ";" + Path.Combine(path, "bin"));

            path = Path.Combine(path, "steam.dll");

            var module = Native.LoadLibraryEx(path, IntPtr.Zero, Native.LoadWithAlteredSearchPath);

            if (module == IntPtr.Zero)
                return false;

            _callCreateSteamInterface = Native.GetExportFunction<Native.F>(module, "_f");

            if (_callCreateSteamInterface == null)
                return false;

            _steamHandle = module;

            return true;
        }

        public static bool LoadSteam()
        {
            if (_steamHandle != IntPtr.Zero)
                return true;

            var path = GetInstallPath();

            if (!string.IsNullOrEmpty(path))
                Native.SetDllDirectory(path + ";" + Path.Combine(path, "bin"));

            path = Path.Combine(path, "steam.dll");

            var module = Native.LoadLibraryEx(path, IntPtr.Zero, Native.LoadWithAlteredSearchPath);

            if (module == IntPtr.Zero)
                return false;

            _callCreateSteamInterface = Native.GetExportFunction<Native.F>(module, "_f");

            if (_callCreateSteamInterface == null)
                return false;

            _steamHandle = module;

            return true;
        }

        /// <summary>
        ///     Loads the steamclient library.
        /// </summary>
        /// <returns>A value indicating if the load was successful.</returns>
        public static bool LoadSteamClientF(string loadpath)
        {
            if (_steamClientHandle != IntPtr.Zero)
                return true;

            var path = loadpath;

            if (!string.IsNullOrEmpty(path))
                Native.SetDllDirectory(path + ";" + Path.Combine(path, "bin"));

            path = Path.Combine(path, "steamclient.dll");

            var module = Native.LoadLibraryEx(path, IntPtr.Zero, Native.LoadWithAlteredSearchPath);

            if (module == IntPtr.Zero)
                return false;

            _callCreateInterface = Native.GetExportFunction<Native.CreateInterface>(module, "CreateInterface");
            if (_callCreateInterface == null)
                return false;

            _callSteamBGetCallback = Native.GetExportFunction<Native.SteamBGetCallback>(module, "Steam_BGetCallback");
            if (_callSteamBGetCallback == null)
                return false;

            _callSteamFreeLastCallback = Native.GetExportFunction<Native.SteamFreeLastCallback>(module,
                "Steam_FreeLastCallback");
            if (_callSteamFreeLastCallback == null)
                return false;

            _callSteamGetApiCallResult = Native.GetExportFunction<Native.SteamGetApiCallResult>(module,
                "Steam_GetAPICallResult");
            if (_callSteamGetApiCallResult == null)
                return false;

            _steamClientHandle = module;

            return true;
        }

        public static bool LoadSteamClient()
        {
            if (_steamClientHandle != IntPtr.Zero)
                return true;

            var path = GetInstallPath();

            if (!string.IsNullOrEmpty(path))
                Native.SetDllDirectory(path + ";" + Path.Combine(path, "bin"));

            path = Path.Combine(path, "steamclient.dll");

            var module = Native.LoadLibraryEx(path, IntPtr.Zero, Native.LoadWithAlteredSearchPath);

            if (module == IntPtr.Zero)
                return false;

            _callCreateInterface = Native.GetExportFunction<Native.CreateInterface>(module, "CreateInterface");
            if (_callCreateInterface == null)
                return false;

            _callSteamBGetCallback = Native.GetExportFunction<Native.SteamBGetCallback>(module, "Steam_BGetCallback");
            if (_callSteamBGetCallback == null)
                return false;

            _callSteamFreeLastCallback = Native.GetExportFunction<Native.SteamFreeLastCallback>(module,
                "Steam_FreeLastCallback");
            if (_callSteamFreeLastCallback == null)
                return false;

            _callSteamGetApiCallResult = Native.GetExportFunction<Native.SteamGetApiCallResult>(module,
                "Steam_GetAPICallResult");
            if (_callSteamGetApiCallResult == null)
                return false;

            _steamClientHandle = module;

            return true;
        }

        private struct Native
        {
            internal const uint LoadWithAlteredSearchPath = 8;

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr LoadLibraryEx(string lpszLib, IntPtr hFile, uint dwFlags);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr SetDllDirectory(string lpPathName);

            // helper
            internal static TDelegate GetExportFunction<TDelegate>(IntPtr module, string name) where TDelegate : class
            {
                var address = GetProcAddress(module, name);

                if (address == IntPtr.Zero)
                    return null;

                return (TDelegate)(object)Marshal.GetDelegateForFunctionPointer(address, typeof(TDelegate));
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            internal delegate IntPtr F(string version);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            internal delegate IntPtr CreateInterface(string version, IntPtr returnCode);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.I1)]
            internal delegate bool SteamBGetCallback(int pipe, ref CallbackMsgT message);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.I1)]
            internal delegate bool SteamGetApiCallResult(
                int hSteamPipe, ulong hSteamApiCall, IntPtr pCallback, int cubCallback, int iCallbackExpected,
                ref bool pbFailed);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.I1)]
            internal delegate bool SteamFreeLastCallback(int pipe);
        }
    }
}