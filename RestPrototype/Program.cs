using DataModel;
using Juke.External.Lookup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RestPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://ws.audioscrobbler.com/2.0/");
            var result = client.GetAsync("?method=album.getinfo&api_key=002b10709790581ecb6897234c53c875&artist=Cher&album=Believe").Result;
            var doc = new XmlDocument();
            doc.Load(result.Content.ReadAsStreamAsync().Result);
            Console.WriteLine(doc.ToString());*/

            var service = new LookupService();
            var result = service.LookupCover(new Song("Pink Floyd", "The Wall", "Another brick"));
            Console.WriteLine(result.SmallUrl);
            Console.WriteLine(result.MediumUrl);
            Console.WriteLine(result.LargeUrl);

        }
    }
}
