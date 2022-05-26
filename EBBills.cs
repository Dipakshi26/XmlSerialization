
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializeDeserializeHandsOn
{
    public class EBBills
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int NoOfUnits { get; set; }
        public int UnitPerCost { get; set; } = 7;
        public int Total { get; set; }

        public void SerializeInXmlFormat()
        {
            List<EBBills> list = new List<EBBills>();

            Console.WriteLine("Enter no. of customers data you want to store.");
            int totalCustomers = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < totalCustomers; i++)
            {
                EBBills ebillObj = new EBBills();
                Console.WriteLine("Enter Customer Id.");
                ebillObj.CustomerId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Customer name");
                ebillObj.CustomerName = (Console.ReadLine());

                Console.WriteLine("Enter No of units");
                ebillObj.NoOfUnits = Convert.ToInt32(Console.ReadLine());

                ebillObj.Total = 7 * ebillObj.NoOfUnits;

                list.Add(ebillObj);
            }
         

            XmlSerializer serializer = new XmlSerializer(typeof(List<EBBills>));

            FileStream fileStream = new FileStream(@"C:\Users\LUCKY\source\repos\SerializeDeserializeHandsOn\SerializeDeserializeHandsOn1..txt", FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            XmlWriter xmlWriter = new XmlTextWriter(streamWriter);

            serializer.Serialize(xmlWriter, list);

            xmlWriter.Close();
            streamWriter.Close();

        }
        public void DeSerializeFromXmlFormatToListEBill()
        {
            List<EBBills> list = new List<EBBills>();

            XmlSerializer ser = new XmlSerializer(typeof(List<EBBills>));

            using (XmlReader reader = XmlReader.Create(@"C:\Users\LUCKY\source\repos\SerializeDeserializeHandsOn\SerializeDeserializeHandsOn.txt"))
            {
                list = (List<EBBills>)ser.Deserialize(reader);
            }

            foreach (EBBills ebill in list)
            {
                Console.WriteLine(ebill.CustomerId + " " + ebill.CustomerName + " " + ebill.NoOfUnits + " " + ebill.Total);
            }
        }
    }
}
