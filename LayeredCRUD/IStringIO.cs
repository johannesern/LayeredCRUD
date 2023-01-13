using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredCRUD
{
    internal interface IStringIO
    {

        public string Input();

        public void Output(string output);

    }
}
