using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace TEST
{
    public class Program
    {
        static void Main(string[] args)
        {
            Voyageur voy1 = new Voyageur();
            Console.WriteLine(voy1.getAge());
            Console.ReadKey();
        }
    }
}
