

using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            var qq = q();
           var q1= qq.Cast<XmlNode>();

            var e = qq.GetEnumerator();
            while(e.MoveNext())
            {
                Console.Write($"{e.Current}");
            }

        }

        public static IEnumerable q()
        {
            return new XmlDocument().CreateNavigator().Select("//rendition") ;
        }

       
    }
}
