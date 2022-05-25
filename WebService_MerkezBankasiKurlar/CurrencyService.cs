using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebService_MerkezBankasiKurlar.Models;
using WebService_MerkezBankasiKurlar.Serializer;

namespace WebService_MerkezBankasiKurlar
{
    public class CurrencyService : ICurrencyService
    {
        string urlPatten = "https://www.tcmb.gov.tr/kurlar/{0}.xml";
        private readonly WebClient client;
        private readonly IXmlSerializer serializer;

        public CurrencyService()
        {
            client = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            serializer = new XmlSerializer();
        }

        public Task<CurrencyModel[]> GetByDate(DateTime date)
        {

            var day = date.Day > 0 && date.Day < 10 ? $"0{date.Day}" : date.Day.ToString();
            var month = date.Month > 0 && date.Month < 10 ? $"0{date.Month}" : date.Month.ToString();
            var url = new Uri(string.Format(urlPatten, $"{date.Year}{month}/{day}{month}{date.Year}"));
            var data = client.DownloadString(url);
            var deserializer = serializer.Deserializer<Tarih_Date>(data);
            var result = deserializer.Currency.Select(CurrencyModel.Map).ToArray();
            return Task.FromResult(result);


        }

        public Task<CurrencyModel[]> GetToday()
        {
            var url = new Uri(string.Format(urlPatten, "today"));
            var data = client.DownloadString(url);
            var deserialize = serializer.Deserializer<Tarih_Date>(data);
            var result = deserialize.Currency.Select(CurrencyModel.Map).ToArray();
            return Task.FromResult(result);
        }
    }
}
