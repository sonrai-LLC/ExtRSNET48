﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class ReferenceDataTests
    {
        public readonly string token = "9fa5a9bfbcc5cdb6ea5cd9da8acc6dd2de079d67";

        [TestMethod]
        public async Task GetSynonymsSucceeds()
        {
            var result = await ReferenceDataService.GetSynonyms("nonplussed bored");
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public async Task GetSynonymsFails()
        {
            var result = await ReferenceDataService.GetSynonyms(null);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public async Task GetAppPublicIPSucceeds()
        {
            var result = await ReferenceDataService.GetAppPublicIP();
            var ip = result.Substring(result.Length - 7);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public async Task GetCountryByIPSucceeds()
        {
            var result = await ReferenceDataService.GetCountryByIP("8.8.8.4");
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public async Task GetTickerInfoSucceeds()
        {
            var result = await ReferenceDataService.GetTickerInfo("JCI", token);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public async Task GetTickerPricesSucceeds()
        {
            var result = await ReferenceDataService.GetTickerPrices("JCI", token);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public async Task GetForexPriceSucceeds()
        {
            var result = await ReferenceDataService.GetForexPrice("EURUSD", token);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
