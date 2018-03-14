using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFFind
{
    class Program
    {
        static void Main(string[] args)
        {
            PFFind pf = new PFFind();
            string searchFor = "Roth IRA";
            foreach (PFFind.data d in pf.Find(searchFor))
            {
                Console.WriteLine("Contains {0} : {1}", searchFor, d.title);
            }

        }
    }
}
