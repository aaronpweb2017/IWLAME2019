using System;
using Xunit;
using ASPNETCoreWebApiAzurePRONuncia.Controllers;
using ASPNETCoreWebApiAzurePRONuncia.Models;

namespace ASPNETCoreWebApiAzurePRONuncia
{
    public class TestClass
    {

        string consstr;
        IJugadoresRepository IAzJuRepo;
        JugadoresController JuController;

        public TestClass() {
            consstr = "AccountName=s102webge50;AccountKey=hlQo"
            +"riRnPqgZ+r4A53CoWsJRGJe3TMh3FtOBdBm3iPujOVvnOEPUcG"
            +"p0xMk07VB8k0wvuSWFQzHW6L1msOnbnw==;EndpointSuffix="
            +"core.windows.net;DefaultEndpointsProtocol=https;"; 
            IAzJuRepo = new AzureJugadoresRepository(consstr);
            JuController = new JugadoresController(IAzJuRepo);
        }

        [Fact]
        public void PassingNoPlayersFactTest() {
            int expectedPlayersLength = 4;
            int actualPlayersLength = JuController.GetPlayers().Result.Count;
            Assert.Equal(expectedPlayersLength, actualPlayersLength);
        }

        [Theory] [InlineData(1)] [InlineData(2)] [InlineData(3)] [InlineData(4)]
        public void PassingNoPlayersTheoryTest(int expectedLength) {
            Assert.True(JuController.GetPlayers().Result.Count.Equals(expectedLength));
        }

        [Fact]
        public void PassingGetPlayerTest() {
            Jugador expectedPlayer = new Jugador() {
                email="daniel-carvajal@gmail.com", username="DanielCE2019",
                name="Daniel", lastname="Escamilla", level=1, nopoints=150
            };
            string partitionKey = "daniel-carvajal@gmail.com";
            Jugador actualPlayer = JuController.GetPlayer(partitionKey).Result;
            Assert.Equal(expectedPlayer, actualPlayer);
        }

        [Fact]
        public void PassingCreatePlayerTest() {
            Jugador testPlayer = new Jugador() {
                email="gustavo-cave@gmail.com", username="gvocave19962019",
                name="Gustavo", lastname="Cañedo", level=2, nopoints=500 };
            bool response = JuController.CreatePlayer(testPlayer).Result;
            Assert.True(response);
        }

        [Fact]
        public void PassingModifyPlayerTest() {
            Jugador testPlayer = new Jugador() {
                username="gvocave19962019",
                name="Gustavo", lastname="Cañedo",
                level=3, nopoints=960 };
            string partitionKey = "gustavo-cave@gmail.com";
            bool response = JuController.ModifyPlayer(partitionKey, testPlayer).Result;
            Assert.True(response);
        }

        [Fact]
        public void PassingDeletePlayerTest() {
            string partitionKey = "gustavo-cave@gmail.com";
            bool response = JuController.DeletePlayer(partitionKey).Result;
            Assert.True(response);
        }

        [Fact]
        public void PassingNoGroupsTest() {
            int expectedGoupsLength = 3;
            string partitionKey = "daniel-carvajal@gmail.com";
            int actualGroupsLength = JuController.GetAllPlayerGroups(partitionKey).Result.Count;
            Assert.Equal(expectedGoupsLength, actualGroupsLength);
        }

        [Fact]
        public void PassingNoPhrasesGroupsTest() {
            int expectedPhrasesLength = 40;
            string partitionKey = "daniel-carvajal@gmail.com";
            string rowKey = "Actividades";
            int actualPhrasesLength = JuController.GetAllPlayerGroupPhrases(partitionKey, rowKey).Result.Count;
            Assert.Equal(expectedPhrasesLength, actualPhrasesLength);
        }
    }
}