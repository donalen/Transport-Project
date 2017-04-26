using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace TransportProject
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
            // Читаем данные со страницы в строку
            WebClient client = new WebClient();
            String downloadedString = client.DownloadString("http://yartr.ru/rasp.php?vt=1&nmar=3&q=0&id=315&view=1");
            Console.WriteLine(downloadedString);

            // Представляем строку в виде html кода
            string outStr = System.Net.WebUtility.HtmlDecode(downloadedString);
            Console.WriteLine(outStr);

            // Сплитим по <br>", "<br/>
            string[] split = outStr.Split(new string[] { "<br>", "<br/>" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i++)
            {
                Console.Write("{0}. ", i);
                Console.WriteLine(split[i]);
            }

            string startLine = "Табло";
            int startLineNumber = FindKeyWord(split, startLine, 0);

            string endLine = "назад";
            int endLineNumber = FindKeyWord(split, endLine, startLineNumber);

            // Оставляем только те строчки, где есть номера и расписание транспорта
            Console.WriteLine("{0}, {1}", startLineNumber, endLineNumber);

            // В transportTable содержится массив строк - строка для каждого транспорта и его расписания
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

            Transport[] transport = new Transport[transportTable.Length];


            for (int i = 0; i < transportTable.Length; i++)
            {
                int spaceIndex = transportTable[i].IndexOf(' ');
                transport[i] = new Transport();
                transport[i].Name = transportTable[i].Substring(0, spaceIndex);
                transportTable[i] = transportTable[i].Substring(spaceIndex + 1);
                spaceIndex = transportTable[i].IndexOf(':');
                transport[i].Number = transportTable[i].Substring(0, spaceIndex);
                transportTable[i] = transportTable[i].Substring(spaceIndex + 2);
            }

            foreach (Transport tr in transport)
                tr.PrintTransport();
        }
    }
}
