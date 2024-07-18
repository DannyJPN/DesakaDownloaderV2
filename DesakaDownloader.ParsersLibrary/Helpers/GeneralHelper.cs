using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesakaDownloader.ParsersLibrary.Helpers
{
    public class GeneralHelper
    {
        public static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, "_");
        }

        public static bool ListCompare(ICollection listX, ICollection listY, bool ignoreOrder = false)
        {
            if (listX.Count != listY.Count) { return false; }
            string[] strArrayX = StringifyListAsArray(listX);
            string[] strArrayY = StringifyListAsArray(listY);

            if (ignoreOrder)
            {
                Array.Sort(strArrayX);
                Array.Sort(strArrayY);
            }

            for (int i = 0; i < strArrayX.Count(); i++)
            {
                if (strArrayX[i] != strArrayY[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static string[] StringifyListAsArray(ICollection list)
        {
            List<string> result = new List<string>();
            foreach (object item in list)
            {
                if (item == null)
                {
                    result.Add("");
                }
                else
                {
                    result.Add(item.ToString());
                }
            }
            return result.ToArray();
        }

        public static string ExtractIntegerString(string text)
        {
            return Regex.Replace(text, "[^0-9]", String.Empty);
        }


    }
}
