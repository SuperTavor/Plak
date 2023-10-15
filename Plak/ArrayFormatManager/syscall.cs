using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;

namespace Plak.ArrayFormatManager
{
    class syscall
    {
        public void init(string content, int choicelvl, toArrayMain main,int origLineNum)
        {
            Random rnd = new Random();
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(content + rnd.Next(10000).ToString());
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource); ;
            string id = BitConverter.ToString(tmpHash);
            if (content.Trim() == "[END]" || content.Trim() == "[END]".ToLower())
            {
                main.syscalls.Add("syscall: " + "exit" + " | ChoiceLevel = " + choicelvl + "|ID:" + id + "|OriginalLineNum: " + (origLineNum));
            }
            else
            {
                toArrayMain.throwSyntaxError("Syntax error: Non existent syscall at line " + main.getIndexInFile(content) + ":" + content.Trim());
            }

        }


    }
}
