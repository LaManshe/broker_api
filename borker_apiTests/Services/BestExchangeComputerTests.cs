using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using borker_api.Services.Interfaces;
using borker_api.DAL.Entities;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore;

namespace borker_api.Services.Tests
{
    [TestClass]
    public class BestExchangeComputerTests
    {
        [TestMethod]
        public void GetBestExchangeTest()
        {
            var builder = WebHost
                .CreateDefaultBuilder()
                ;
            builder.ConfigureServices(options => options.AddTransient<IBestExchangeCompute, BestExchangeComputer>());

            var server = new TestServer(builder);

            #region Arrange
            List<Rate> rates = new List<Rate>()
            {
                new Rate() { Date = DateTime.ParseExact("2014-12-15", "yyyy-MM-dd", null), RUB = 60.17, EUR = 12 },
                new Rate() { Date = DateTime.ParseExact("2014-12-16", "yyyy-MM-dd", null), RUB = 72.99, EUR = 12 },
                new Rate() { Date = DateTime.ParseExact("2014-12-17", "yyyy-MM-dd", null), RUB = 66.01, EUR = 12 },
                new Rate() { Date = DateTime.ParseExact("2014-12-18", "yyyy-MM-dd", null), RUB = 61.44, EUR = 12 },
                new Rate() { Date = DateTime.ParseExact("2014-12-19", "yyyy-MM-dd", null), RUB = 59.79, EUR = 12 },
                new Rate() { Date = DateTime.ParseExact("2014-12-20", "yyyy-MM-dd", null), RUB = 59.79, EUR = 12 },
                new Rate() { Date = DateTime.ParseExact("2014-12-21", "yyyy-MM-dd", null), RUB = 59.79, EUR = 12 },
                new Rate() { Date = DateTime.ParseExact("2014-12-22", "yyyy-MM-dd", null), RUB = 54.78, EUR = 12 },
                new Rate() { Date = DateTime.ParseExact("2014-12-23", "yyyy-MM-dd", null), RUB = 54.80, EUR = 12 }
            };
            double moneyUSD = 100;

            double expected = 127.24;
            #endregion

            #region Act
            var service = server.Services.GetService<IBestExchangeCompute>();
            var method = service as BestExchangeComputer;
            var result = method.GetBestExchange(rates, moneyUSD).Revenue;
            #endregion

            #region Assert
            Assert.AreEqual(expected, result);
            #endregion
        }
    }
}