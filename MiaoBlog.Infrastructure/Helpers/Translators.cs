using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace MiaoBlog.Infrastructure.Helpers
{
    public static class Translators
    {
        public static string ExcerptTranslator(string htmlString, int length)
        {
            //删除脚本
            htmlString = Regex.Replace(htmlString, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //删除HTML
            htmlString = Regex.Replace(htmlString, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"-->", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);

            htmlString.Replace("<", "");
            htmlString.Replace(">", "");
            htmlString.Replace("\r\n", "");
            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            if (htmlString.Length > length)
            {
                return htmlString.Substring(0, length);
            }
            else
            {
                return htmlString;
            }
        }

        public static int GetStrLength(string str)
        {
            bool WINNT_CHINESE = ("中国".Length == 2);
            if (WINNT_CHINESE)
            {
                int L, T, C;
                L = str.Length;
                T = L;
                for (int i = 1; i <= L; i++)
                {
                    Encoding ASCII = Encoding.ASCII;
                    Byte[] EncodedBytes = ASCII.GetBytes(str.Substring(i - 1, 1));
                    C = EncodedBytes[0];
                    if (C < 0)
                        C += 65536;
                    if (C > 255)
                        T += 1;
                }
                return T;
            }
            else
            {
                return str.Length;
            }
        }

        public static string InterceptStr(string str, int length)
        {
            int x, y;
            str = str.Trim();
            x = str.Length;
            y = 0;
            if (x >= 1)
            {
                for (int i = 1; i <= x; i++)
                {
                    Encoding ASCII = Encoding.ASCII;
                    Byte[] EncodedBytes = ASCII.GetBytes(str.Substring(i - 1, 1));
                    if (EncodedBytes[0] < 0 || EncodedBytes[0] > 255)
                    {
                        y += 2;
                    }
                    else
                    {
                        y += 1;
                    }
                    if (y >= length)
                    {
                        str = str.Substring(0, i);
                        break;
                    }
                }
                return str;
            }
            else
            {
                return "";
            }
        }

        public static string WipeOffTableHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<[^>]*?>.*?</>", "", RegexOptions.IgnoreCase);
            //删除表格HTML
            Htmlstring = Regex.Replace(Htmlstring, @"</?table[^>]*>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</?tr[^>]*>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</?td[^>]*>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</?th[^>]*>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</?BLOCKQUOTE[^>]*>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</?tbody[^>]*>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<style[^\s]*", "", RegexOptions.IgnoreCase);

            return Htmlstring;
        }
    }
}
