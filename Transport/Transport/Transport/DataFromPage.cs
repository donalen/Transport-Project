using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class DataFromPage
    {
        private string pageAddress;

        public string PageAddress
        {
            get { return pageAddress; }
            set { pageAddress = value; }
        }

        public DataFromPage()
        {

        }

        public DataFromPage(string pageAddressValue)
        {
            this.pageAddress = pageAddressValue;
        }

        private string GetDataFromPage()
        {
            WebClient client = new WebClient();
            String downloadedString = client.DownloadString(pageAddress);
            return downloadedString;
        }

        private string DataToHTML()
        {
            string outStr = System.Net.WebUtility.HtmlDecode(GetDataFromPage());
            return outStr;
        }

        private string[] SplitHTML()
        {
            string[] split = DataToHTML().Split(new string[] { "<br>", "<br/>" }, StringSplitOptions.RemoveEmptyEntries);
            return split;
        }

        private int FindKeyWord(string[] split, string line, int startiNumber)
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

        private string[] CreateTransportTableStringArray()
        {
            string[] split = SplitHTML();

            string startLine = "Табло";
            int startLineNumber = FindKeyWord(split, startLine, 0);

            string endLine = "назад";
            int endLineNumber = FindKeyWord(split, endLine, startLineNumber);

            string[] transportTable = new string[endLineNumber - startLineNumber - 1];
            int j = 0;
            for (int i = startLineNumber + 1; i < endLineNumber; i++)
            {
                transportTable[j] = split[i];
                j++;
            }

            return transportTable;
        }

        public Transport CreateTransport()
        {
            string[] transportTable = CreateTransportTableStringArray();

            Transport transport = new Transport();

            for (int i = 0; i < transportTable.Length; i++)
            {
                TransportStructure transportStructureValue;
                string tempName, tempNumber;
                int spaceIndex = transportTable[i].IndexOf(' ');
                tempName = transportTable[i].Substring(0, spaceIndex);
                transportTable[i] = transportTable[i].Substring(spaceIndex + 1);
                spaceIndex = transportTable[i].IndexOf(':');
                tempNumber = transportTable[i].Substring(0, spaceIndex);
                transportTable[i] = transportTable[i].Substring(spaceIndex + 2);
                transportStructureValue = new TransportStructure(tempName, tempNumber);
                spaceIndex = transportTable[i].IndexOf(' ');
                while (spaceIndex != -1)
                {
                    transportStructureValue.AddToSchedule(transportTable[i].Substring(0, spaceIndex));
                    transportTable[i] = transportTable[i].Substring(spaceIndex + 1);
                    spaceIndex = transportTable[i].IndexOf(' ');
                }
                if (spaceIndex == -1)
                {
                    transportStructureValue.AddToSchedule(transportTable[i].Substring(0));
                }
                transport.AddToTransportList(transportStructureValue);
            }
            return transport;
        }
    }
}
