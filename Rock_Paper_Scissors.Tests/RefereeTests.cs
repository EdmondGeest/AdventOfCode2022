namespace Rock_Paper_Scissors.Tests
{
    [TestClass]
    public class RefereeTests
    {
        [DataRow("A", "b", 8)]
        [DataRow("B", "a", 1)]
        [DataRow("C", "c", 6)]
        [TestMethod]
        public void Referee_GetGameScorePlayer_FirstStrategy_Gets_Correct_Results_For_Player(string opponentChoice, string playerChoice, int expectedScore)
        {
            Referee referee = new Referee();
            var result = referee.GetGameScorePlayer(opponentChoice, playerChoice);

            Assert.AreEqual(expectedScore, result);
        }

        [DataRow("A", "a", 4)]
        [DataRow("B", "a", 1)]
        [DataRow("C", "a", 7)]
        [TestMethod]
        public void Referee_GetGameScorePlayer2_SecondStrategy_Gets_Correct_Results_For_Player2(string opponentChoice, string playerChoice, int expectedScore)
        {
            Referee referee = new Referee();
            var result = referee.GetGameScorePlayer(opponentChoice, playerChoice);

            Assert.AreEqual(expectedScore, result);
        }
    }
}