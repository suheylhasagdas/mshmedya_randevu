using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Core.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string DateToSqlString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public static string DateToSqlStringDateTime(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string DateToTurkishFormat(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }

        public static string ToTitleCase(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        public static string ToLowerConvertEnglishChar(this string text)
        {
            foreach (var item in TurkishChar)
            {
                text = text.Replace(item.Key, item.Value);
            }

            return text.ToLower();
        }

        public static string ToUpperConvertEnglishChar(this string text)
        {
            foreach (var item in TurkishChar)
            {
                text = text.Replace(item.Key, item.Value);
            }

            return text.ToUpper().Replace("İ","I");
        }

        public static string ReplaceBadCharacter(this string text)
        {

            foreach (var item in BadCharacter)
            {
                text = text.Replace(item.Key, item.Value);
            }

            return text;
        }

        public static Dictionary<char, char> TurkishChar
        {
            get
            {
                Dictionary<char, char> item = new Dictionary<char, char>();

                item.Add('Ç', 'C');
                item.Add('Ğ', 'G');
                item.Add('İ', 'I');
                item.Add('Ö', 'O');
                item.Add('Ş', 'S');
                item.Add('Ü', 'U');

                item.Add('ç', 'c');
                item.Add('ğ', 'g');
                item.Add('ı', 'i');
                item.Add('ö', 'o');
                item.Add('ş', 's');
                item.Add('ü', 'u');

                return item;
            }
        }
        
        public static Dictionary<string, string> BadCharacter
        {
            get
            {
                Dictionary<string, string> item = new Dictionary<string, string>();

                item.Add("/", string.Empty);
                item.Add("!", string.Empty);
                item.Add("\"", string.Empty);
                item.Add("^", string.Empty);
                item.Add("+", string.Empty);
                item.Add("%", string.Empty);
                item.Add("&", string.Empty);
                item.Add("(", string.Empty);
                item.Add(")", string.Empty);
                item.Add("=", string.Empty);
                item.Add("?", string.Empty);
                item.Add("_", string.Empty);
                item.Add("-", string.Empty);
                item.Add("*", string.Empty);
                item.Add(">", string.Empty);
                item.Add("<", string.Empty);
                item.Add("£", string.Empty);
                item.Add("#", string.Empty);
                item.Add("$", string.Empty);
                item.Add("½", string.Empty);
                item.Add("{", string.Empty);
                item.Add("[", string.Empty);
                item.Add("]", string.Empty);
                item.Add("}", string.Empty);
                item.Add("\\", string.Empty);
                item.Add("|", string.Empty);
                item.Add("~", string.Empty);
                item.Add(";", string.Empty);
                item.Add(",", string.Empty);
                item.Add(".", string.Empty);
                item.Add(":", string.Empty);
                item.Add("¨", string.Empty);
                item.Add("'", string.Empty);
                item.Add("é", string.Empty);
                item.Add("ß", string.Empty);
                item.Add("æ", string.Empty);
                item.Add("₺", string.Empty);
                item.Add("€", string.Empty);
                item.Add("@", string.Empty);

                return item;
            }
        }

        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
    }
}
