

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
            int[] x = new int[3];
            x[0] = 2;
            var q = x.Length;
            var qq = x[2];

        }

        public static IEnumerable q()
        {
            return new XmlDocument().CreateNavigator().Select("//rendition") ;
        }

       
    }
}
