using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plak.ArrayFormatManager
{
    class syscall
    {
        public void init(string content, int choicelvl, toArrayMain main)
        {

            if (content.Trim() == "[END]" || content.Trim() == "[END]".ToLower())
            {
                main.syscalls.Add("syscall: " + "exit" + " | ChoiceLevel = " + choicelvl);
            }
            else
            {
                toArrayMain.throwSyntaxError("Syntax error: Non existent syscall at line " + main.getIndexInFile(content) + ":" + content.Trim());
            }

        }


    }
}
