using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFValuta
{
    class ValutaRepo
    {
        private static Dictionary<string, Valuta> valutaList = new Dictionary<string, Valuta>();

        private static ValutaRepo instance;
        private ValutaRepo() { }

        public static ValutaRepo Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ValutaRepo();
                    LoadDataToList();
                }
                return instance;
            }
        }

        public static void LoadDataToList()
        {
            valutaList.Add("usd", new Valuta("Amerika", "USD", new decimal(524.0200)));
            valutaList.Add("cad", new Valuta("Canada", "CAD", new decimal(492.2700)));
            valutaList.Add("eur", new Valuta("Euro", "EUR", new decimal(745.9900)));
            valutaList.Add("nok", new Valuta("Norge", "NOK", new decimal(90.3400)));
            valutaList.Add("gbp", new Valuta("Storbritannien", "GBP", new decimal(947.5300)));
            valutaList.Add("sek", new Valuta("Sverige", "SEK", new decimal(78.2100)));
            valutaList.Add("dkk", new Valuta("Denmark", "DKK", new decimal(100.0000)));
        }

        public decimal DkkToEuroConvert(decimal amount)
        {
            Valuta valuta = valutaList["eur"];
            return (valuta.rate / 100) * amount;
        }

        public decimal GetRateFromISO(string iso)
        {
            if (valutaList.ContainsKey(iso))
            {
                return valutaList[iso].rate;
            }

            return new decimal(0.00);
        }

        public decimal ConvertToIso(string toIso, decimal amount)
        {
            if (valutaList.ContainsKey(toIso))
            {
                Valuta valuta = valutaList[toIso];
                return (valuta.rate / 100) * amount;
            }
            else
            {
                return new decimal(0.00);
            }
        }

        public decimal ConvertFromIsoToIso(string fromIso, string toIso, decimal amount)
        {
            if (valutaList.ContainsKey(fromIso) && valutaList.ContainsKey(toIso))
            {
                Valuta valutaFrom = valutaList[fromIso];
                Valuta valutaTo = valutaList[toIso];


                
                return Convert.ToDecimal((amount * valutaFrom.rate) / valutaTo.rate);
            }
            else
            {
                return new decimal();
            }
        }

        public List<Valuta> GetValutaList()
        {
            return valutaList.Select(x => x.Value).ToList();
        }

        public bool ChangeExchangeRate(string iso, decimal amount)
        {
            if (valutaList.ContainsKey(iso))
            {
                Valuta valuta = valutaList[iso];
                valuta.rate = amount;
                return true;
            }
            return false;
        }

        public bool CreateValuta(string iso, string name, decimal rate)
        {
            valutaList.Add(iso.ToLower(), new Valuta(name, iso.ToUpper(), rate));
            return true;
        }
    }
}
