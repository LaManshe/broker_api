using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using borker_api.DAL.Entities;
using borker_api.Models.Mapping;
using AutoMapper;
using borker_api.ApiInteraction.Service.Interfaces;
using borker_api.Interfaces;
using borker_api.Data;
using borker_api.ApiInteraction;
using borker_apiTests;

namespace borker_api.Services.Tests
{
    [TestClass]
    public class BestExchangeComputerTests
    {
        private ServiceCollection _serviceProviders;
        private IMapper _mapper;
        private IRepository<Rate> _dbRepository;
        private IRatesRepository _apiRepository;

        [TestInitialize]
        public void TestInit()
        {
            var serviceProvider = new ServiceCollection()
                .MockDb()
                .MockApiServices()
                .AddAutoMapper(typeof(MapProfile))
                .BuildServiceProvider()
                ;

            _mapper = serviceProvider.GetService<IMapper>();
            _dbRepository = serviceProvider.GetService<IRepository<Rate>>();
            _apiRepository = serviceProvider.GetService<IRatesRepository>();
        }

        [TestMethod]
        public void GetBestExchangeTest()
        {
            BestExchangeComputer bestExchangeComputer = new BestExchangeComputer(_mapper);

            #region Arrange
            List<Rate> rates = new List<Rate>()
            {
                new Rate() { Date = DateTime.ParseExact("2014-12-15", "yyyy-MM-dd", null), RUB = 60.17 },
                new Rate() { Date = DateTime.ParseExact("2014-12-16", "yyyy-MM-dd", null), RUB = 72.99 },
                new Rate() { Date = DateTime.ParseExact("2014-12-17", "yyyy-MM-dd", null), RUB = 66.01 },
                new Rate() { Date = DateTime.ParseExact("2014-12-18", "yyyy-MM-dd", null), RUB = 61.44 },
                new Rate() { Date = DateTime.ParseExact("2014-12-19", "yyyy-MM-dd", null), RUB = 59.79 },
                new Rate() { Date = DateTime.ParseExact("2014-12-20", "yyyy-MM-dd", null), RUB = 59.79 },
                new Rate() { Date = DateTime.ParseExact("2014-12-21", "yyyy-MM-dd", null), RUB = 59.79 },
                new Rate() { Date = DateTime.ParseExact("2014-12-22", "yyyy-MM-dd", null), RUB = 54.78 },
                new Rate() { Date = DateTime.ParseExact("2014-12-23", "yyyy-MM-dd", null), RUB = 54.80 }
            };
            double moneyUSD = 100;
            double expected = 127.24205914567358;
            #endregion

            #region Act
            var result = bestExchangeComputer.GetBestExchange(rates, moneyUSD).Revenue;
            #endregion

            #region Assert
            Assert.AreEqual(expected, result);
            #endregion
        }

        [TestMethod]
        public void GetDataFromDbAndApiTests()
        {
            DataRates dataRates = new DataRates(_apiRepository, _dbRepository, _mapper);

            var startDate = DateTime.Parse("2022-08-30 00:00:00.000000");
            var endDate = DateTime.Parse("2022-09-04 00:00:00.000000");

            List<Rate>? expected = new List<Rate>()
            {
                new Rate()
                {
                    Date = DateTime.Parse("2022-08-30 00:00:00.000000"),
                    RUB = 333,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false,
                    Id = 0
                },
                new Rate()
                {
                    Date = DateTime.Parse("2022-08-31 00:00:00.000000"),
                    RUB = 333,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false,
                    Id = 0
                },
                new Rate()
                {
                    Date = DateTime.Parse("2022-09-01 00:00:00.000000"),
                    RUB = 999,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false,
                    Id = 0
                },
                new Rate()
                {
                    Date = DateTime.Parse("2022-09-02 00:00:00.000000"),
                    RUB = 999,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false,
                    Id = 0
                },
                new Rate()
                {
                    Date = DateTime.Parse("2022-09-03 00:00:00.000000"),
                    RUB = 999,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false,
                    Id = 0
                },
                new Rate()
                {
                    Date = DateTime.Parse("2022-09-04 00:00:00.000000"),
                    RUB = 333,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false,
                    Id = 0
                },
            };

            var result = dataRates.GetDataFromDbAndApi(startDate, endDate);

            Assert.IsTrue(result.SequenceEqual(result, new MyRateComparer()));
        }
    }
}