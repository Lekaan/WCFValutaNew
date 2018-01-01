using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace WCFValuta
{
    [DataContract]
    public class Valuta
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string iso { get; set; }
        [DataMember]
        public decimal rate { get; set; }

        public Valuta(string name, string iso, decimal rate)
        {
            this.name = name;
            this.iso = iso;
            this.rate = rate;
        }

    }
}
