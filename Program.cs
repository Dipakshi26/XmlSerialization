using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializeDeserializeHandsOn
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //to store customers details of type EBill class
          
            EBBills ebills = new EBBills();
            ebills.SerializeInXmlFormat();

            


        }
    }
}

  