using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace PlaygroundWForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          Dochadzka.Check(this);


        }

        public void FillTextbox(string s)
        {
            textBox1.Text = s;
        }
    }

    public static class Dochadzka
    {
        public static void Check(Form1 form)
        {
            var dochadzkaCU = new List<CasUsek>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\tmi\Desktop\dochadzka.xml");


            foreach (XmlNode node in doc.SelectNodes("//tbody/tr"))
            {
                var tdNodes = node.ChildNodes;

                var start = tdNodes[1].InnerText.Split(' ');
                var datum = start[1].Split('.');
                var cas = start[2].Split(':');
                var casDo = tdNodes[2].InnerText.Trim().Split(':');
                if (casDo.Length == 1 && string.IsNullOrEmpty(casDo[0]))
                {
                    casDo = cas;
                }

                var cu = new CasUsek()
                {
                    Od = new DateTime(DateTime.Now.Year, int.Parse(datum[1]), int.Parse(datum[0]), int.Parse(cas[0]),
                        int.Parse(cas[1]), 0),
                    Do = new DateTime(DateTime.Now.Year, int.Parse(datum[1]), int.Parse(datum[0]), int.Parse(casDo[0]),
                        int.Parse(casDo[1]), 0),
                };
                dochadzkaCU.Add(cu);
            }

            var timetrackerData = new List<CasUsek>();
            var doctt = new HtmlDocument();
            doctt.Load(@"C:\Users\tmi\Desktop\timetracker.xml");
            foreach (HtmlNode node in doctt.DocumentNode.SelectNodes("//*[@id='content']/descendant::div/*[@class='time-info']"))
            {
                var datumStart = node.ChildNodes[5].ChildNodes[3].InnerText.Split('.')
                    .Select(_ => _.Replace('(', ' ').Replace(')', ' ').Trim()).ToArray();
                var casStart = node.ChildNodes[5].ChildNodes[1].InnerText.Split(':');

                var datumEnd = node.ChildNodes[7].ChildNodes[3].InnerText.Split('.')
                    .Select(_ => _.Replace('(', ' ').Replace(')', ' ').Trim()).ToArray();
                var casEnd = node.ChildNodes[7].ChildNodes[1].InnerText.Split(':');

                var cu = new CasUsek()
                {
                    Od = new DateTime(int.Parse(datumStart[2]), int.Parse(datumStart[1]), int.Parse(datumStart[0]), int.Parse(casStart[0]),
                        int.Parse(casStart[1]), 0),
                    Do = new DateTime(int.Parse(datumEnd[2]), int.Parse(datumEnd[1]), int.Parse(datumEnd[0]), int.Parse(casEnd[0]),
                        int.Parse(casEnd[1]), 0),
                };
                timetrackerData.Add(cu);
            }

            StringBuilder sb = new StringBuilder();
            foreach (DateTime datum in dochadzkaCU.Select(_ => _.Od.Date).Distinct())
            {
                sb.Append($"{datum.Day:00}.{datum.Month:00}.{datum.Year} [");

                var doSum = dochadzkaCU.Where(_ => _.Od.Date == datum).Sum(_ => (_.Do - _.Od).TotalMinutes);
                var ttSum = timetrackerData.Where(_ => _.Od.Date == datum).Sum(_ => (_.Do - _.Od).TotalMinutes);
                var doDuration = $"{((doSum - (doSum % 60)) / 60):00}:{(doSum % 60):00}:00";
                var ttDuration = $"{((ttSum - (ttSum % 60)) / 60):00}:{(ttSum % 60):00}:00";


                var timesAreDifferent = doSum != ttSum || doDuration != ttDuration;


                sb.Append($"DO:[{doDuration}|{(doSum / 60):F2}]  TT:[{ttDuration}|{(ttSum/60):F2}]{(timesAreDifferent ? "!!!BAAAAAAD!!!": "OK")}");


                sb.AppendLine("]");
            }

            sb.AppendLine();
            var tt = timetrackerData.Sum(_ => (_.Do - _.Od).TotalMinutes) - timetrackerData.Select(_ => _.Od.Date).Distinct().Count() * 8 * 60;
            var @do = dochadzkaCU.Sum(_ => (_.Do - _.Od).TotalMinutes) - dochadzkaCU.Select(_ => _.Od.Date).Distinct().Count() * 8 * 60;
            sb.AppendLine($"Nadrobene podla timetracker {tt} minut a podla dochadzky {@do} minut.");


            //MessageBox.Show(sb.ToString());
            form.FillTextbox(sb.ToString());
        }


        private class CasUsek
        {
            public DateTime Od;
            public DateTime Do;
        }



    }
}
