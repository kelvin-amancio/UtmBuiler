﻿using System.Net;
using System.Text.RegularExpressions;

namespace UtmBuiler.Core.ValueObjects.Exceptions
{
    public partial class InvalidUrlException : Exception
    {
        private const string DefaultErrorMessage = "Invalid URL";
        public  InvalidUrlException(string message = DefaultErrorMessage) : base(message)
        {
        }

        public static void ThrowIfInvalidUrl(string url, string message = DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(url))
                throw new InvalidUrlException(message);

            if (!UrlRegex().IsMatch(url))
                throw new InvalidUrlException();
        }

        [GeneratedRegex("^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$")]
        private static partial Regex UrlRegex();
    }
}
