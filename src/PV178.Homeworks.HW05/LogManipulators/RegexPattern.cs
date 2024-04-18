using System;
using HW5.Enums;

namespace HW5.LogManipulators
{
	public static class RegexPattern
	{
        private static readonly string httpMethod =
            $"({HttpMethod.Get}|" +
            $"{HttpMethod.Head}|" +
            $"{HttpMethod.Post}|" +
            $"{HttpMethod.Put}|" +
            $"{HttpMethod.Delete}|" +
            $"{HttpMethod.Trace}|" +
            $"{HttpMethod.Options}|" +
            $"{HttpMethod.Connect}|" +
            $"{HttpMethod.Patch})";

        public static string IpAddress { get; } = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";
        public static string ClientIdentity { get; } = "-";
        public static string UserId { get; } = @"\b\S+\b";
        public static string Date { get; } =
            @"\b\d{2}/\d{2}/\d{4}:\d{2}:\d{2}:\d{2} [+-]\d{4}\b";
        public static string Request { get; } = $@"""{httpMethod} /\S+ HTTP/1.0""";
        public static string StatusCode { get; } = @"\b[1-5]\d{2}\b";
        public static string Size { get; } = @"\b[1-9]\d{3,}\b";

        public static string GetStatusCode(HttpStatusClass statusClass)
        {
            return $@"\b{(int)statusClass}\d{{2}}\b";
        }
    }
}

