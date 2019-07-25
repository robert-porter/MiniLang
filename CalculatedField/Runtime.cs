﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatedField
{

    static class Runtime
    {
        public static List<Function> Functions { get; private set; }

        static Runtime()
        {
            Functions = new List<Function>();
            addAll(typeof(LibMath));
            addAll(typeof(LibString));
            addAll(typeof(LibDateTime));
            addAll(typeof(LibConversion));
            void addAll(Type type)
            {
                var methodInfos = type.GetMethods();
                foreach (var methodInfo in methodInfos)
                {
                    Functions.Add(new Function(methodInfo));
                }
            }
        }
    }

    static class LibConversion
    {
        public static decimal? parseInteger(string s)
        {
            if (long.TryParse(s, out var result))
                return result;
            return null;
        }

        public static decimal? parseDecimal(string s)
        {
            if (decimal.TryParse(s, out var result))
                return result;
            return null;
        }

        public static bool? parseBool(string s)
        {
            if (bool.TryParse(s, out var result))
                return result;
            return null;
        }

        public static DateTime? parseDate(string s)
        {
            if (DateTime.TryParse(s, out var result))
                return result;
            return null;
        }

        public static string toString(long x)
        {
            return x.ToString();
        }

        public static string toString(decimal x)
        {
            return x.ToString();
        }

        public static string toString(bool x)
        {
            return x.ToString();
        }

        public static string toString(DateTime x)
        {
            return x.ToString();
        }
    }

    static class LibString
    {
        public static long length(string s)
        {
            if (s == null) return 0;
            return s.Length;
        }

        public static string character(string s, int i)
        {
            if (i < 0 || i >= s.Length) return "";
            return s?.Substring(i, i + 1);
        }

        public static string concat(string a, string b)
        {
            if (a == null && b == null) return null;
            if (a == null) return b;
            if (b == null) return a;
            return a + b;
        }

        public static bool contains(string a, string b)
        {
            if (a == null || b == null) return false;
            return a.Contains(b);
        }

        public static string substring(string s, int startIndex, int length)
        {
            if (s == null) return "";
            if (startIndex < 0 || length < 0) return "";
            if (startIndex >= s.Length) return "";
            if (startIndex + length >= s.Length) length = s.Length - startIndex;
            return s.Substring(startIndex, length);
        }

        public static string trim(string s)
        {
            return s?.Trim();
        }

        public static string trimStart(string s)
        {
            return s?.TrimStart();
        }

        public static string trimEnd(string s)
        {
            return s?.TrimEnd();
        }

        public static string toUpper(string s)
        {
            return s?.ToUpper();
        }

        public static string toLower(string s)
        {
            return s?.ToLower();
        }

    }


    static class LibDateTime
    {
        public static DateTime? date(string s)
        {
            if (DateTime.TryParse(s, out var dt))
                return dt;
            return null;
        }


        public static DateTime Today => DateTime.Today;
        public static DateTime Yesterday => DateTime.Today.AddDays(-1);
        public static DateTime Tomorrow => DateTime.Today.AddDays(1);
        public static DateTime StartOfWeek => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
        public static DateTime EndOfWeek => DateTime.Today.AddDays(6 - (int)DateTime.Today.DayOfWeek);
        public static DateTime StartOfMonth => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        public static DateTime EndOfMonth => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
        public static DateTime StartOfYear => new DateTime(DateTime.Today.Year, 1, 1);
        public static DateTime EndOfYear => new DateTime(DateTime.Today.Year, 12, 31);
        public static DateTime StartOfQuarter => new DateTime(DateTime.Today.Year, DateTime.Today.Month - (DateTime.Today.Month % 3) + 1, 1);
        public static DateTime EndOfQuarter => new DateTime(DateTime.Today.Year, DateTime.Today.Month - (DateTime.Today.Month % 3) + 1, 1).AddMonths(1).AddDays(-1);
        public static DateTime StartOfLastWeek => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek - 7);
        public static DateTime EndOfLastWeek => DateTime.Today.AddDays((int)DateTime.Today.DayOfWeek - 1);
        public static DateTime StartOfLastMonth => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
        public static DateTime EndOfLastMonth => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
        public static DateTime StartOfLastQuarter => new DateTime(DateTime.Today.Year, DateTime.Today.Month - (DateTime.Today.Month % 3) + 1, 1).AddMonths(-3);
        public static DateTime EndOfLastQuarter => new DateTime(DateTime.Today.Year, DateTime.Today.Month - (DateTime.Today.Month % 3) + 1, 1).AddMonths(-2).AddDays(-1);
        public static DateTime StartOfLastYear => new DateTime(DateTime.Today.Year - 1, 1, 1);
        public static DateTime EndOfLastYear => new DateTime(DateTime.Today.Year - 1, 12, 31);
        public static DateTime StartOfNextWeek => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7);
        public static DateTime EndOfNextWeek => DateTime.Today.AddDays((int)DateTime.Today.DayOfWeek + 6);
        public static DateTime StartOfNextMonth => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1);
        public static DateTime EndOfNextMonth => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(2).AddDays(-1);
        public static DateTime StartOfNextQuarter => new DateTime(DateTime.Today.Year, DateTime.Today.Month - (DateTime.Today.Month % 3) + 1, 1).AddMonths(3);
        public static DateTime EndOfNextQuarter => new DateTime(DateTime.Today.Year, DateTime.Today.Month - (DateTime.Today.Month % 3) + 1, 1).AddMonths(5).AddDays(-1);
        public static DateTime StartOfNextYear => new DateTime(DateTime.Today.Year + 1, 1, 1);
        public static DateTime EndOfNextYear => new DateTime(DateTime.Today.Year + 1, 12, 31);
    }

    static class LibMath
    {
        public static decimal? abs(decimal? x)
        {
            if (x == null) return null;
            return Math.Abs(x.Value);
        }

        public static long? abs(long? x)
        {
            if (x == null) return null;
            return Math.Abs(x.Value);
        }

        public static decimal? ceil(decimal? x)
        {
            if (x == null) return null;
            return Math.Ceiling(x.Value);
        }

        public static decimal? exp(decimal? x)
        {
            if (x == null) return null;
            return (decimal)Math.Exp((double)x);
        }

        public static decimal? exp(long? x)
        {
            if (x == null) return null;
            return (decimal)Math.Exp((double)x);
        }

        public static decimal? floor(decimal? x)
        {
            if (x == null) return null;
            return Math.Floor(x.Value);
        }

        public static decimal? log(decimal? x, decimal? b)
        {
            if (x == null || b == null) return null;
            return (decimal)Math.Log((double)x, (double)b);
        }

        public static decimal? log(long? x, decimal? b)
        {
            if (x == null || b == null) return null;
            return (decimal)Math.Log(x.Value, (double)b);
        }

        public static decimal? log(decimal? x, long? b)
        {
            if (x == null || b == null) return null;
            return (decimal)Math.Log((double)x, b.Value);
        }

        public static decimal? log(long? x, long? b)
        {
            if (x == null || b == null) return null;
            return (decimal)Math.Log(x.Value, b.Value);
        }

        public static decimal? log(decimal? x)
        {
            if (x == null) return null;
            return (decimal)Math.Log((double)x);
        }

        public static decimal? log(long? x)
        {
            if (x == null) return null;
            return (decimal)Math.Log(x.Value);
        }

        public static decimal? log10(decimal? x)
        {
            if (x == null) return null;
            return (decimal)Math.Log10((double)x);
        }

        public static decimal? log10(long? x)
        {
            if (x == null) return null;
            return (decimal)Math.Log10(x.Value);
        }

        public static decimal? sqrt(decimal? x)
        {
            if (x == null) return null;
            return (decimal)Math.Sqrt((double)x);
        }

        public static decimal? sqrt(long? x)
        {
            if (x == null) return null;
            return (decimal)Math.Sqrt(x.Value);
        }

        public static long? max(long? x, long? y)
        {
            if (x == null || y == null) return null;
            return Math.Max(x.Value, y.Value);
        }

        public static decimal? max(decimal? x, decimal? y)
        {
            if (x == null) return y;
            if (y == null) return x;
            return Math.Max(x.Value, y.Value);
        }

        public static decimal? max(decimal? x, long? y)
        {
            if (x == null || y == null) return null;
            return Math.Max(x.Value, y.Value);
        }

        public static decimal? max(long? x, decimal? y)
        {
            if (x == null || y == null) return null;
            return Math.Max(x.Value, y.Value);
        }

        public static long? min(long? x, long? y)
        {
            if (x == null || y == null) return null;
            return Math.Min(x.Value, y.Value);
        }

        public static decimal? min(decimal? x, decimal? y)
        {
            if (x == null || y == null) return null;
            return Math.Min(x.Value, y.Value);
        }

        public static decimal? min(decimal? x, long? y)
        {
            if (x == null || y == null) return null;
            return Math.Min(x.Value, y.Value);
        }

        public static decimal? min(long? x, decimal? y)
        {
            if (x == null || y == null) return null;
            return Math.Min(x.Value, y.Value);
        }

        public static long? sign(decimal? x)
        {
            if (x == null) return null;
            return Math.Sign(x.Value);
        }

        public static long? sign(long? x)
        {
            if (x == null) return null;
            return Math.Sign(x.Value);
        }

        public static decimal? trunc(decimal? x)
        {
            if (x == null) return null;
            return Math.Truncate(x.Value);
        }

        public static decimal? round(decimal? x)
        {
            if (x == null) return null;
            return Math.Round(x.Value);
        }
    }
    
}