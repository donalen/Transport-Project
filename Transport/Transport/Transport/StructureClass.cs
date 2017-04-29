using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public struct TransportStructure
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

        public TransportStructure(string nameValue, string numberValue)
        {
            this.name = nameValue;
            this.number = numberValue;
            schedule = new List<string>();
        }

        public void AddToSchedule(string element)
        {
            this.schedule.Add(element);
        }

        public void PrintTransportStructure()
        {
            Console.Write("{0} ", this.name);
            Console.Write("{0} ", this.number);
            foreach (string element in this.schedule)
            {
                Console.Write("{0} ", element);
            }
            Console.WriteLine();
        }
    }
}
