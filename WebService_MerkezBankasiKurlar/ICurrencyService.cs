using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService_MerkezBankasiKurlar.Models;

namespace WebService_MerkezBankasiKurlar
{
    public interface ICurrencyService
    {
        Task<CurrencyModel[]> GetToday();
        Task<CurrencyModel[]> GetByDate(DateTime date);

    }
}
