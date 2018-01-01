using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFValuta
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ValutaService : IValutaService
    {
        public bool ChangeExchangeRate(string iso, decimal amount)
        {
            return ValutaRepo.Instance.ChangeExchangeRate(iso, amount);
        }

        public decimal ConvertDKKtoEuro(decimal amount)
        {
            return ValutaRepo.Instance.DkkToEuroConvert(amount);
        }

        public decimal ConvertFromIsoToIso(string fromIso, string toIso, decimal amount)
        {
            return ValutaRepo.Instance.ConvertFromIsoToIso(fromIso, toIso, amount);
        }

        public bool CreateValuta(string iso, string name, decimal rate)
        {
            return ValutaRepo.Instance.CreateValuta(iso, name, rate);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<Valuta> GetValutaList()
        {
            return ValutaRepo.Instance.GetValutaList();
        }

        public decimal ISOtoRate(string iso)
        {
            return ValutaRepo.Instance.GetRateFromISO(iso);
        }
    }
}
