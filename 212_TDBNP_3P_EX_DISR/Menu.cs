using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _212_TDBNP_3P_EX_DISR
{
    class Menu
    {
        public string image { get; set; }
        public string describ { get; set; }

        public Menu(string _img, string _desc)
        {
            image = _img;
            describ = _desc;
        }
    }
}
