using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class Transport
    {
        List<TransportStructure> transportStructure;

        public List<TransportStructure> TransportStructure
        {
            get { return TransportStructure; }
        }

        public Transport()
        {
            transportStructure = new List<TransportStructure>();
        }

        public void AddToTransportList(TransportStructure element)
        {
            this.transportStructure.Add(element);
        }

        public void PrintTransportList()
        {
            foreach (TransportStructure element in this.transportStructure)
                element.PrintTransportStructure();
        }

        public bool isTransportFound(string nameValue, string numberValue)
        {
            bool isFound = false;
            foreach (TransportStructure element in this.transportStructure)
                if (element.Name == nameValue && element.Number == numberValue)
                    isFound = true;
            return isFound;
        }

        public TransportStructure FindTransport(string nameValue, string numberValue)
        {
            TransportStructure transportStructureValue = new TransportStructure();
            foreach (TransportStructure element in this.transportStructure)
                if (element.Name == nameValue && element.Number == numberValue)
                {
                    transportStructureValue = element;
                    break;
                }
            return transportStructureValue;
        }
    }
}
