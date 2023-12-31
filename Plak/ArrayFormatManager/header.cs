﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Plak.ArrayFormatManager
{
    class header
    {

        public void init(string content, int choicelvl, toArrayMain main, int origLineNum)
        {
            Random rnd = new Random();
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(content + rnd.Next(10000).ToString());
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource); ;
            string id = BitConverter.ToString(tmpHash);
            main.headers.Add("Header: " + content.Trim().Substring(1) + " | ChoiceLevel = " + choicelvl + "|ID:" + id + "|OriginalLineNum: " + origLineNum);
        }
    }
}
