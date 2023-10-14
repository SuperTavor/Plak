using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plak.ArrayFormatManager
{
    class header
    {

        public void init(string content, int choicelvl, toArrayMain main)
        {
            main.headers.Add("Header: " + "Content = " + content.Trim().Substring(1) + " | ChoiceLevel = " + choicelvl);
        }
    }
}
