using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamburingaUITestNetCore
{
    [TestClass]
    public class BackendTest
    {
        [TestMethod]
        public void TestInitializeCorrectNumberOfStones()
        {
            SamburingaBackend.SamburingaAdapter adapter = new SamburingaBackend.SamburingaAdapter();
            adapter.InitializeNewGame();
            Assert.AreEqual(36, adapter.GetGame().Player1.PlayerPits.Sum(x => x.NumberOfStones));
        }
    }
}
