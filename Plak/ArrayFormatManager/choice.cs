using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plak.ArrayFormatManager
{
    class choice
    {
        public void init(string content, int choicelvl, toArrayMain main)
        {
            main.headers.Add("Choice:" + "Content = " + content.Trim().Substring(2) + " | ChoiceLevel = " + choicelvl);
        }
    }
}
