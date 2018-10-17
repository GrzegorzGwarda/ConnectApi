using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            HttpGet httpGet = new HttpGet();
            httpGet.DeserializeObjectJson();

            Console.ReadKey();


        }
    }
}
