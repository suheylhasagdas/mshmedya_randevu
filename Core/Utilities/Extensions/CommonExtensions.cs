using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.Utilities.Extensions
{
    public static class CommonExtensions
    {
        public static string FirstCharacterToLower(this string text)
        {
            return Char.ToLowerInvariant(text[0]) + text.Substring(1);
        }

        public static string FormatMoney(double money)
        {
            NumberFormatInfo nfi = CultureInfo.CreateSpecificCulture("tr-TR").NumberFormat;

            string value1 = money.ToString("C2", nfi);

            return value1;
        }

        public static T ToConvert<T>(this object myobj)
        {
            string model = JsonConvert.SerializeObject(myobj);

            return JsonConvert.DeserializeObject<T>(model);
        }

        public static T ThisJsonToConvert<T>(this string myobj)
        {
            return JsonConvert.DeserializeObject<T>(myobj);
        }

        public static int DateToInt(DateTime date)
        {
            string year = date.ToString("yyyy");
            string month = date.ToString("MM");
            string day = date.ToString("dd");

            string strDate = string.Format("{0}{1}{2}", year, month, day);

            return Convert.ToInt32(strDate);
        }
    }
}
