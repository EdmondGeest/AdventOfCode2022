namespace Rock_Paper_Scissors.Tests
{
    [TestClass]
    
    public class GameStrategyTests
    {
        [DataRow("A", "Y", "b")]
        [DataRow("B", "X", "a")]
        [DataRow("C", "Z", "c")]
        [TestMethod]
        public void FirstStrategy_Sets_Correct_Choice_For_Player(string player1Play, string player2Play, string expectedChoice)
        {
            IGameStrategy gameStrategy = new Part1GameStrategy();
            string player1Choice = player1Play;
            string player2Choice = gameStrategy.DeterminePlayerChoice(player1Choice, player2Play);

            Assert.AreEqual(expectedChoice, player2Choice);
        }

        [DataRow("A", "Y", "a")]
        [DataRow("B", "X", "a")]
        [DataRow("C", "Z", "a")]
        [TestMethod]
        public void SecondStrategy_Sets_Correct_Choice_For_Player(string player1Play, string player2Play, string expectedChoice)
        {
            IGameStrategy gameStrategy = new Part2GameStrategy();
            string player1Choice = player1Play;
            string player2Choice = gameStrategy.DeterminePlayerChoice(player1Choice, player2Play);

            Assert.AreEqual(expectedChoice, player2Choice);
        }

    }
}
