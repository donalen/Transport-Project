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
        static void Main(string[] args)
        {
            DataFromPage dfp = new DataFromPage();
            Transport transport = dfp.CreateTransport();

            transport.PrintTransportList();

            string nameValue = "Ав";
            string numberValue = "3";

            if (transport.isTransportFound(nameValue, numberValue))
            {
                transport.FindTransport(nameValue, numberValue).PrintTransportStructure();
            }
            else
                Console.Write("Element is not found");
        }
    }
}
