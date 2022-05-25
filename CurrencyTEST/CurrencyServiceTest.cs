using System;
using WebService_MerkezBankasiKurlar;
using Xunit;

namespace CurrencyTEST
{
    public class CurrencyServiceTest
    {
        private ICurrencyService service;
        
        public  CurrencyServiceTest()
        {
            service = new CurrencyService();
        }
        [Fact]
        public async void Get_Today()
        {
            var result = await service.GetToday();
            Assert.True(result.Length > 0);
        }
        [Fact]
        public async void Get_Date()
        {
            var result = await service.GetByDate(new DateTime(2020, 9, 8));
            Assert.True(result.Length > 0);
        }
    }
}
