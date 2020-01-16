using EURO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EuroTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFirstWinner()
        {
            //arrange
            string fTeam = "Den";
            int fTeamGoals = 2;
            string sTeam = "USA";
            int sTeamGoals = 0;

            //act
            string winner = Euro.Winner(fTeam, fTeamGoals, sTeam, sTeamGoals);

            //assert
            Assert.AreEqual("Den", winner);
        }

        [TestMethod]
        public void TestSecondWinner()
        {
            //arrange
            string fTeam = "SVK";
            int fTeamGoals = 0;
            string sTeam = "USA";
            int sTeamGoals = 2;

            //act
            string winner = Euro.Winner(fTeam, fTeamGoals, sTeam, sTeamGoals);

            //assert
            Assert.AreEqual("USA", winner);
        }

        [TestMethod]
        public void TestDraw()
        {
            //arrange
            string fTeam = "Den";
            int fTeamGoals = 2;
            string sTeam = "USA";
            int sTeamGoals = 2;

            //act
            string winner = Euro.Winner(fTeam, fTeamGoals, sTeam, sTeamGoals);

            //assert
            Assert.AreEqual("Draw", winner);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestException()
        {
            //arrange
            string fTeam = "Den";
            int fTeamGoals = 0;
            string sTeam = "USA";
            int sTeamGoals = -2;

            //act
            string winner = Euro.Winner(fTeam, fTeamGoals, sTeam, sTeamGoals);
        }

    }

}
