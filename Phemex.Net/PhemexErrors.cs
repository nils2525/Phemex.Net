using CryptoExchange.Net.Objects.Errors;

namespace Phemex.Net
{
    internal static class PhemexErrors
    {
        public static ErrorMapping RestErrors { get; } = new ErrorMapping(
            [
                new ErrorInfo(ErrorType.UnknownSymbol, false, "Invalid symbol", "10001", "10002", "invalid symbol"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Unauthorized", "401", "10500", "invalid api key", "invalid signature"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Forbidden", "403"),
                new ErrorInfo(ErrorType.RateLimitRequest, false, "Rate limit exceeded", "429")
            ]);

        public static ErrorMapping SocketErrors { get; } = new ErrorMapping(
            [
                new ErrorInfo(ErrorType.UnknownSymbol, false, "Invalid symbol", "6001", "invalid symbol"),
                new ErrorInfo(ErrorType.RateLimitRequest, false, "Rate limit exceeded", "rate limit")
            ]);
    }
}