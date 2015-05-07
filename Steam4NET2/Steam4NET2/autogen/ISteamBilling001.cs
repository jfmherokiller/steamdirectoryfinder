// This file is automatically generated.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steam4Net
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SteamBilling001VTable
    {
        public IntPtr SetBillingAddress0;
        public IntPtr GetBillingAddress1;
        public IntPtr SetShippingAddress2;
        public IntPtr GetShippingAddress3;
        public IntPtr GetFinalPrice4;
        public IntPtr SetCardInfo5;
        public IntPtr GetCardInfo6;
        public IntPtr Purchase7;
        private IntPtr DTorISteamBilling0018;
    };

    [InteropHelp.InterfaceVersionAttribute("SteamBilling001")]
    public class SteamBilling001 : InteropHelp.NativeWrapper<SteamBilling001VTable>
    {
        public bool SetBillingAddress(string pchName, string pchAddress1, string pchAddress2, string pchCity,
            string pchPostcode, string pchState, string pchCountry, string pchPhone)
        {
            return GetFunction<NativeSetBillingAddressSsssssss>(Functions.SetBillingAddress0)(ObjectAddress, pchName,
                pchAddress1, pchAddress2, pchCity, pchPostcode, pchState, pchCountry, pchPhone);
        }

        public bool GetBillingAddress(StringBuilder pchName, StringBuilder pchAddress1, StringBuilder pchAddress2,
            StringBuilder pchCity, StringBuilder pchPostcode, StringBuilder pchState, StringBuilder pchCountry,
            StringBuilder pchPhone)
        {
            return GetFunction<NativeGetBillingAddressSsssssss>(Functions.GetBillingAddress1)(ObjectAddress, pchName,
                pchAddress1, pchAddress2, pchCity, pchPostcode, pchState, pchCountry, pchPhone);
        }

        public bool SetShippingAddress(string pchName, string pchAddress1, string pchAddress2, string pchCity,
            string pchPostcode, string pchState, string pchCountry, string pchPhone)
        {
            return GetFunction<NativeSetShippingAddressSsssssss>(Functions.SetShippingAddress2)(ObjectAddress, pchName,
                pchAddress1, pchAddress2, pchCity, pchPostcode, pchState, pchCountry, pchPhone);
        }

        public bool GetShippingAddress(StringBuilder pchName, StringBuilder pchAddress1, StringBuilder pchAddress2,
            StringBuilder pchCity, StringBuilder pchPostcode, StringBuilder pchState, StringBuilder pchCountry,
            StringBuilder pchPhone)
        {
            return GetFunction<NativeGetShippingAddressSsssssss>(Functions.GetShippingAddress3)(ObjectAddress, pchName,
                pchAddress1, pchAddress2, pchCity, pchPostcode, pchState, pchCountry, pchPhone);
        }

        public bool GetFinalPrice(int nPackageId)
        {
            return GetFunction<NativeGetFinalPriceI>(Functions.GetFinalPrice4)(ObjectAddress, nPackageId);
        }

        public bool SetCardInfo(ECreditCardType eCreditCardType, string pchCardNumber, string pchCardHolderName,
            string pchCardExpYear, string pchCardExpMonth, string pchCardCvv2)
        {
            return GetFunction<NativeSetCardInfoEsssss>(Functions.SetCardInfo5)(ObjectAddress, eCreditCardType,
                pchCardNumber, pchCardHolderName, pchCardExpYear, pchCardExpMonth, pchCardCvv2);
        }

        public bool GetCardInfo(ref ECreditCardType eCreditCardType, StringBuilder pchCardNumber,
            StringBuilder pchCardHolderName, StringBuilder pchCardExpYear, StringBuilder pchCardExpMonth,
            StringBuilder pchCardCvv2)
        {
            return GetFunction<NativeGetCardInfoEsssss>(Functions.GetCardInfo6)(ObjectAddress, ref eCreditCardType,
                pchCardNumber, pchCardHolderName, pchCardExpYear, pchCardExpMonth, pchCardCvv2);
        }

        public bool Purchase(int nPackageId, int nExpectedCostCents, ulong gidCardId, bool bStoreCardInfo)
        {
            return GetFunction<NativePurchaseIiub>(Functions.Purchase7)(ObjectAddress, nPackageId, nExpectedCostCents,
                gidCardId, bStoreCardInfo);
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetBillingAddressSsssssss(
            IntPtr thisptr, string pchName, string pchAddress1, string pchAddress2, string pchCity, string pchPostcode,
            string pchState, string pchCountry, string pchPhone);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetBillingAddressSsssssss(
            IntPtr thisptr, StringBuilder pchName, StringBuilder pchAddress1, StringBuilder pchAddress2,
            StringBuilder pchCity, StringBuilder pchPostcode, StringBuilder pchState, StringBuilder pchCountry,
            StringBuilder pchPhone);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetShippingAddressSsssssss(
            IntPtr thisptr, string pchName, string pchAddress1, string pchAddress2, string pchCity, string pchPostcode,
            string pchState, string pchCountry, string pchPhone);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetShippingAddressSsssssss(
            IntPtr thisptr, StringBuilder pchName, StringBuilder pchAddress1, StringBuilder pchAddress2,
            StringBuilder pchCity, StringBuilder pchPostcode, StringBuilder pchState, StringBuilder pchCountry,
            StringBuilder pchPhone);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetFinalPriceI(IntPtr thisptr, int nPackageId);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetCardInfoEsssss(
            IntPtr thisptr, ECreditCardType eCreditCardType, string pchCardNumber, string pchCardHolderName,
            string pchCardExpYear, string pchCardExpMonth, string pchCardCvv2);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetCardInfoEsssss(
            IntPtr thisptr, ref ECreditCardType eCreditCardType, StringBuilder pchCardNumber,
            StringBuilder pchCardHolderName, StringBuilder pchCardExpYear, StringBuilder pchCardExpMonth,
            StringBuilder pchCardCvv2);

        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativePurchaseIiub(
            IntPtr thisptr, int nPackageId, int nExpectedCostCents, ulong gidCardId,
            [MarshalAs(UnmanagedType.I1)] bool bStoreCardInfo);
    };
}