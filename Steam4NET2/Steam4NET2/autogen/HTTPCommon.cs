// This file is automatically generated.

using System.Runtime.InteropServices;

namespace Steam4Net
{
    public enum EhttpMethod
    {
        KEhttpMethodInvalid = 0,
        KEhttpMethodGet = 1,
        KEhttpMethodHead = 2,
        KEhttpMethodPost = 3,
        KEhttpMethodPut = 4,
        KEhttpMethodDelete = 5,
        KEhttpMethodOptions = 6
    };

    public enum EhttpStatusCode
    {
        KEhttpStatusCodeInvalid = 0,
        KEhttpStatusCode100Continue = 100,
        KEhttpStatusCode101SwitchingProtocols = 101,
        KEhttpStatusCode200Ok = 200,
        KEhttpStatusCode201Created = 201,
        KEhttpStatusCode202Accepted = 202,
        KEhttpStatusCode203NonAuthoritative = 203,
        KEhttpStatusCode204NoContent = 204,
        KEhttpStatusCode205ResetContent = 205,
        KEhttpStatusCode206PartialContent = 206,
        KEhttpStatusCode300MultipleChoices = 300,
        KEhttpStatusCode301MovedPermanently = 301,
        KEhttpStatusCode302Found = 302,
        KEhttpStatusCode303SeeOther = 303,
        KEhttpStatusCode304NotModified = 304,
        KEhttpStatusCode305UseProxy = 305,
        KEhttpStatusCode307TemporaryRedirect = 307,
        KEhttpStatusCode400BadRequest = 400,
        KEhttpStatusCode401Unauthorized = 401,
        KEhttpStatusCode402PaymentRequired = 402,
        KEhttpStatusCode403Forbidden = 403,
        KEhttpStatusCode404NotFound = 404,
        KEhttpStatusCode405MethodNotAllowed = 405,
        KEhttpStatusCode406NotAcceptable = 406,
        KEhttpStatusCode407ProxyAuthRequired = 407,
        KEhttpStatusCode408RequestTimeout = 408,
        KEhttpStatusCode409Conflict = 409,
        KEhttpStatusCode410Gone = 410,
        KEhttpStatusCode411LengthRequired = 411,
        KEhttpStatusCode412PreconditionFailed = 412,
        KEhttpStatusCode413RequestEntityTooLarge = 413,
        KEhttpStatusCode414RequestUriTooLong = 414,
        KEhttpStatusCode415UnsupportedMediaType = 415,
        KEhttpStatusCode416RequestedRangeNotSatisfiable = 416,
        KEhttpStatusCode417ExpectationFailed = 417,
        KEhttpStatusCode500InternalServerError = 500,
        KEhttpStatusCode501NotImplemented = 501,
        KEhttpStatusCode502BadGateway = 502,
        KEhttpStatusCode503ServiceUnavailable = 503,
        KEhttpStatusCode504GatewayTimeout = 504,
        KEhttpStatusCode505HttpVersionNotSupported = 505
    };

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [InteropHelp.CallbackIdentityAttribute(2101)]
    public struct HttpRequestCompletedT
    {
        public const int KiCallback = 2101;
        public uint m_hRequest;
        public ulong m_ulContextValue;

        [MarshalAs(UnmanagedType.I1)]
        public bool m_bRequestSuccessful;

        public EhttpStatusCode m_eStatusCode;
    };
}