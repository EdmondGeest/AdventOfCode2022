namespace Rock_Paper_Scissors.Tests
{
    [TestClass]
    public class RefereeTests
    {
        [DataRow("A", "Y", 8)]
        [DataRow("B", "X", 1)]
        [DataRow("C", "Z", 6)]
        [TestMethod]
        public void Referee_GetGameScorePlayer2_FirstStrategy_Gets_Correct_Results_For_Player2(string player1Play, string player2Play, int expectedScore)
        {
            IGameStrategy gameStrategy = new FirstGameStrategy();
            Referee referee = new Referee(gameStrategy);

            var result = referee.GetGameScorePlayer2(player1Play, player2Play);

            Assert.AreEqual(expectedScore, result);
        }

        [DataRow("A", "Y", 4)]
        [DataRow("B", "X", 1)]
        [DataRow("C", "Z", 7)]
        [TestMethod]
        public void Referee_GetGameScorePlayer2_SecondStrategy_Gets_Correct_Results_For_Player2(string player1Play, string player2Play, int expectedScore)
        {
            IGameStrategy gameStrategy = new SecondGameStrategy();
            Referee referee = new Referee(gameStrategy);

            var result = referee.GetGameScorePlayer2(player1Play, player2Play);

            Assert.AreEqual(expectedScore, result);
        }
    }
}