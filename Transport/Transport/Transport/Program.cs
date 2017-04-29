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
            DataFromPage dfpFromAlena = new DataFromPage("http://yartr.ru/rasp.php?vt=1&nmar=3&q=0&id=315&view=1");
            Transport transportFromAlena = dfpFromAlena.CreateTransport();

            DataFromPage dfpFromAndrey = new DataFromPage("http://yartr.ru/rasp.php?vt=1&nmar=3&q=1&id=931&view=1");
            Transport transportFromAndrey = dfpFromAndrey.CreateTransport();

            transportFromAlena.PrintTransportList();
            Console.WriteLine();
            transportFromAndrey.PrintTransportList();

            //string nameValue = "Ав";
            //string numberValue = "3";

            //if (transportFromAlena.isTransportFound(nameValue, numberValue))
            //{
            //    transportFromAlena.FindTransport(nameValue, numberValue).PrintTransportStructure();
            //}
            //else
            //    Console.Write("Element is not found");
        }
    }
}
