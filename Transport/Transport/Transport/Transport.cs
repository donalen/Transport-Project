﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class Transport
    {
        private string name;
        private string number;
        private List<string> schedule;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public Transport()
        {
            this.name = null;
            this.number = null;
            schedule = new List<string>();
        }

        public Transport(string nameValue, string numberValue)
        {
            this.name = nameValue;
            this.number = numberValue;
            schedule = new List<string>();
        }

        public void AddToSchedule(string element)
        {
            this.schedule.Add(element);
        }

        public void PrintTransport()
        {
            Console.WriteLine(this.name);
            Console.WriteLine(this.number);
            //foreach (string element in this.schedule)
            //{
            //    Console.WriteLine(element);
            //}
        }
    }
}