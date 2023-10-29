namespace Rock_Paper_Scissors.Tests
{
    [TestClass]
    public class RefereeTests
    {
        [DataRow("A", "Y", 8)]
        [DataRow("B", "X", 1)]
        [DataRow("C", "Z", 6)]
        [TestMethod]
        public void Referee_GetGameScorePlayer2_Gets_Correct_Results_For_Player2(string player1Play, string player2Play, int expectedScore)
        {
            Referee referee = new Referee();

            var result = referee.GetGameScorePlayer2(player1Play, player2Play);

            Assert.AreEqual(expectedScore, result);
        }
    }
}