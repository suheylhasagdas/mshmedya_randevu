using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Core.Utilities.Extensions
{
    public static class ExtensionHelper
    {   
        public static T ToConvert<T>(this object myobj)
        {
            
            string model = JsonConvert.SerializeObject(myobj);

            return JsonConvert.DeserializeObject<T>(model);
        }

        public static T ToConvertFromString<T>(this string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }

        public static string Serialize(this object myobj)
        {
            string model = JsonConvert.SerializeObject(myobj);

            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="money">string veya double</param>
        /// <returns></returns>
        public static string FormatMoney(object money)
        {
            NumberFormatInfo nfi = CultureInfo.CreateSpecificCulture("tr-TR").NumberFormat;

            string m = money.ToString();
            double mn = 0;

            if (m.Contains("."))
            {
                m = m.Replace(".", ",");
            }

            mn = Convert.ToDouble(m);

            string value1 = mn.ToString("C2", nfi);

            value1 = value1.Replace("₺", "");
            value1 = value1 + " ₺";

            return value1;
        }


    }
}
