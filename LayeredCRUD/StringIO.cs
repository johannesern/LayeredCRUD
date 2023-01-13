using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredCRUD
{
    internal class StringIO : IStringIO
    {
        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string output)
        {
            Console.WriteLine(output);
        }
    }
}
