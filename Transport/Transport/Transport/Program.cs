using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace OT
{
    class Program
    {
        static int FindKeyWord(string[] split, string line, int startiNumber)
        {
            int lineNumber = -1;
            for (int i = startiNumber; i < split.Length; i++)
            {
                int startIndex = split[i].IndexOf(line);
                if (startIndex != -1)
                {
                    lineNumber = i;
                    break;
                }
            }
            return lineNumber;
        }

        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            String downloadedString = client.DownloadString("http://yartr.ru/rasp.php?vt=1&nmar=3&q=0&id=315&view=1");
            Console.WriteLine(downloadedString);

            string outStr = System.Net.WebUtility.HtmlDecode(downloadedString);
            Console.WriteLine(outStr);

            string[] split = outStr.Split(new string[] { "<br>", "<br/>" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i++)
            {
                Console.Write("{0}. ", i);
                Console.WriteLine(split[i]);
            }

            /// TO DO Вынести циклы в функцию
            string startLine = "Табло";
            int startLineNumber = FindKeyWord(split, startLine, 0);

            string endLine = "назад";
            int endLineNumber = FindKeyWord(split, endLine, startLineNumber);
            
            Console.WriteLine("{0}, {1}", startLineNumber, endLineNumber);

            string[] transportTable = new string[endLineNumber - startLineNumber - 1];
            int j = 0;
            for (int i = startLineNumber + 1; i < endLineNumber; i++)
            {
                transportTable[j] = split[i];
                j++;
            }

            for (int i = 0; i < transportTable.Length; i++)
            {
                Console.Write("{0}. ", i);
                Console.WriteLine(transportTable[i]);
            }
        }
    }
}
