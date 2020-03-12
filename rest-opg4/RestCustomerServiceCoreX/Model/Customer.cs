using RestCustomerServiceCoreY.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestCustomerServiceCoreY.Model
{

    [DataContract]
    public class Customer
    {
        [DataMember]
        public long Isbn13 { get; set; }

        [DataMember]
        public String Titel { get; set; }

        [DataMember]
        public String Forfatter { get; set; }

        [DataMember]
        public int Sidetal { get; set; }


        public Customer()
        { //Start data generation
        }

        public Customer(String titel, String forfatter, int sidetal)
        {
            if (forfatter.Length <= 2)
            {
                throw new ArgumentException("Forfatter har for lille navn");
            }

            if (sidetal <= 4 || sidetal >= 1000)
            {
                throw new ArgumentException("Sidetal skal være mellem 4 og 1000");
            }

            this.Isbn13 = CustomerController.nextId++;
            this.Titel = titel;
            this.Forfatter = forfatter;
            this.Sidetal = sidetal;
        }

        public override string ToString()
        {
            return $"{nameof(Isbn13)}: {Isbn13}, {nameof(Titel)}: {Titel}, {nameof(Forfatter)}: {Forfatter}, {nameof(Sidetal)}: {Sidetal}";

        }

    }
}


       