using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XML_Analysis.Models;

namespace XML_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var Ebhsdata_Count = findOpenData();
            ShowOpenData(Ebhsdata_Count);
            Console.ReadKey();
        }

        static List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();

            var xml = XElement.Load(@"F:\github\Messages.xml");

            var Ebhsdata_count = xml.Descendants("item").ToList();
            Ebhsdata_count.ToList()
               .ForEach(Ebhsdata =>
            {
                OpenData item = new OpenData();

                item.標題 = getValue(Ebhsdata, "title");
                item.位置 = getValue(Ebhsdata, "link");
                result.Add(item);
            });
        
            /*for (var i = 0; i < Ebhsdata_count.Count; i++)
            {
                var Ebhsdata = Ebhsdata_count[i];
                OpenData item = new OpenData();

                item.標題 = getValue(Ebhsdata, "title");
                item.位置 = getValue(Ebhsdata, "link");
                result.Add(item);
            };*/


            return result;
        }

        private static string getValue(XElement Ebhsdata, string propertyName)
        {
            return Ebhsdata.Element(propertyName)?.Value?.Trim();
        }

        public static void ShowOpenData(List<OpenData> Ebhsdata_count)
        {
            Console.WriteLine(string.Format("共收到{0}筆的資料 ", Ebhsdata_count.Count));

            for (var i = 0; i < Ebhsdata_count.Count; i++)
            {
                var Ebhsdata = Ebhsdata_count[i];
                Console.WriteLine(string.Format("{0}.{1} ", i + 1, Ebhsdata.標題));
                Console.WriteLine(string.Format("\n{0}", Ebhsdata.位置));
            }
        }
        }
    }