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
            Transport[] transport = dfp.CreateTransport();

            foreach (Transport tr in transport)
                tr.PrintTransport();
        }
    }
}
