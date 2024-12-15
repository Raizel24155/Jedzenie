using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Jedzenie
    {
        public float hajs;
        public string Nazwa;
        public string skladniki;
        public string kraj;
        public override string ToString()
        {
            return "hajs: "+hajs+" nazwa: "+Nazwa+" sk: "+skladniki+" kraj: "+kraj;
        }
    }
}
