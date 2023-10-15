using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Plak.ArrayFormatManager
{
    class choice
    {
        public void init(string content, int choicelvl, toArrayMain main)
        {
            Random rnd = new Random();
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(content + rnd.Next(10000).ToString());
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource); ;
            string id = BitConverter.ToString(tmpHash);
            main.headers.Add("Choice:" + content.Trim().Substring(2) + " | ChoiceLevel = " + choicelvl + "|ID:" + id);
        }
    }
}
