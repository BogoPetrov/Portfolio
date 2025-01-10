using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BanckAccaunt;

namespace BanckAccauntTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_DepositMethod()
        {
            Assert.AreEqual(BanckAccaunts.Deposid(-10), 10);
        }
        [TestMethod]
        public void Test_WithdrawMethod()
        {
            Assert.AreEqual(BanckAccaunts.Withdraw(10), 0);
        }
        [TestMethod]
        public void Test_CheckMethod()
        {
            Assert.AreEqual(BanckAccaunts.Check(), true);
        }
    }
}
