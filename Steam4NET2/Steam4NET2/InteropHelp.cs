using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Steam4Net
{
    public class InteropHelp
    {
        /// <summary>
        ///     Decodes ANSI encoded return string to UTF-8
        /// </summary>
        public static string DecodeAnsiReturn(string buffer)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(buffer));
        }

        /// <summary>
        ///     Casts an interface from a pointer to a object representing the interface.
        /// </summary>
        /// <typeparam name="TClass">The interface type. ex: ISteamUser013</typeparam>
        /// <param name="address">The address of the interface.</param>
        /// <returns>An instance of an interface object, or null if an error occurred.</returns>
        public static TClass CastInterface<TClass>(IntPtr address)
            where TClass : INativeWrapper, new()
        {
            if (address == IntPtr.Zero)
                return default(TClass);

            var rez = new TClass();
            rez.SetupFunctions(address);
            return rez;
        }

        public interface INativeWrapper
        {
            void SetupFunctions(IntPtr objectAddress);
        }

        public abstract class NativeWrapper<TNativeFunctions> : INativeWrapper
        {
            private readonly Dictionary<IntPtr, Delegate> _functionCache = new Dictionary<IntPtr, Delegate>();
            protected TNativeFunctions Functions;
            protected IntPtr ObjectAddress;

            public IntPtr Interface
            {
                get { return ObjectAddress; }
            }

            public void SetupFunctions(IntPtr objectAddress)
            {
                ObjectAddress = objectAddress;

                var vtableptr = Marshal.ReadIntPtr(ObjectAddress);

                Functions = (TNativeFunctions)Marshal.PtrToStructure(
                    vtableptr, typeof(TNativeFunctions));
            }

            public override string ToString()
            {
                return string.Format(
                    "Steam Interface<{0}> #{1:X8}",
                    typeof(TNativeFunctions),
                    ObjectAddress.ToInt32());
            }

            protected Delegate GetDelegate<TDelegate>(IntPtr pointer)
            {
                Delegate function;

                if (_functionCache.ContainsKey(pointer) == false)
                {
                    function = Marshal.GetDelegateForFunctionPointer(pointer, typeof(TDelegate));
                    _functionCache[pointer] = function;
                }
                else
                {
                    function = _functionCache[pointer];
                }

                return function;
            }

            protected TDelegate GetFunction<TDelegate>(IntPtr pointer)
                where TDelegate : class
            {
                return (TDelegate)((object)GetDelegate<TDelegate>(pointer));
            }

            protected void Call<TDelegate>(IntPtr pointer, params object[] args)
            {
                GetDelegate<TDelegate>(pointer).DynamicInvoke(args);
            }

            protected TReturn Call<TReturn, TDelegate>(IntPtr pointer, params object[] args)
            {
                return (TReturn)GetDelegate<TDelegate>(pointer).DynamicInvoke(args);
            }
        }

        internal class BitVector64
        {
            public BitVector64()
            {
            }

            public BitVector64(ulong value)
            {
                Data = value;
            }

            public ulong Data { get; set; }

            public ulong this[uint bitoffset, ulong valuemask]
            {
                get { return (Data >> (ushort)bitoffset) & valuemask; }
                set
                {
                    Data = (Data & ~(valuemask << (ushort)bitoffset)) | ((value & valuemask) << (ushort)bitoffset);
                }
            }
        }

        [AttributeUsage(AttributeTargets.Class)]
        internal class InterfaceVersionAttribute : Attribute
        {
            public InterfaceVersionAttribute(string versionIdentifier)
            {
                Identifier = versionIdentifier;
            }

            public string Identifier { get; set; }
        }

        [AttributeUsage(AttributeTargets.Struct)]
        internal class CallbackIdentityAttribute : Attribute
        {
            public CallbackIdentityAttribute(int callbackNum)
            {
                Identity = callbackNum;
            }

            public int Identity { get; set; }
        }
    }
}