﻿namespace Crosscuting.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string value) => string.IsNullOrEmpty(value);
    }
}
