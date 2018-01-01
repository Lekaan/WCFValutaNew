using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFValuta
{
    [ServiceContract]
    public interface IValutaService
    {
        [OperationContract]
        decimal ConvertDKKtoEuro(decimal amount);
        [OperationContract]
        decimal ISOtoRate(string iso);
        [OperationContract]
        List<Valuta> GetValutaList();
        [OperationContract]
        decimal ConvertFromIsoToIso(string fromIso, string toIso, decimal amount);
        [OperationContract]
        bool ChangeExchangeRate(string iso, decimal amount);
        [OperationContract]
        bool CreateValuta(string iso, string name, decimal rate);
    }
}
