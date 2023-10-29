using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{

    /// <summary>
    /// De referee, scheidsrechter, bepaalt de uitslag van een wedstrijd
    /// De referee kent de regels van het spel
    /// </summary>
    public class Referee
    {
        public Referee() { }

        /// <summary>
        /// Deze functie berekent de score van player2 voor een wedstrijd Rock Paper Scissors
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns>Score van player2</returns>
        public int GetGameScorePlayer2(string player1, string player2)
        {
            // Bepaal basisscore player 2
            int scorePlayer2 = DetermineBaseScorePlayer2(player2);

            // Bepaal het wedtrijdresultaat
            GameResultEnum gameResultPlayer2 = DetermineGameResultPlayer2(player1, player2);

            // Bepaal eindscore player 2
            scorePlayer2 = DetermineFinalScorePlayer(scorePlayer2, gameResultPlayer2);

            return scorePlayer2;
        }

        /// <summary>
        /// Deze functie bepaalt de basisscore voor een speler
        /// Rock => 1 punt
        /// Paper => 2 punten
        /// Sciccors => 3 punten
        /// </summary>
        /// <param name="player"></param>
        /// <returns>de basisscore</returns>
        private int DetermineBaseScorePlayer2(string player)
        {
            int score = 0;
            switch (player.ToLower())
            {
                case "x":
                    score = 1;
                    break;
                case "y":
                    score = 2;
                    break;
                case "z":
                    score = 3;
                    break;
                default:
                    break;
            }

            return score;
        }

        /// <summary>
        /// Deze functie bepaalt de wedstrijduitslag voor player2 
        /// Win
        /// Draw
        /// Loss
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns>Wedstrijduitslag</returns>
        private GameResultEnum DetermineGameResultPlayer2(string player1, string player2)
        {
            GameResultEnum gameResult = GameResultEnum.Draw;
            switch (player1.ToLower())
            {
                case "a":
                    switch (player2.ToLower())
                    {
                        case "x":
                            gameResult = GameResultEnum.Draw;
                            break;
                        case "y":
                            gameResult = GameResultEnum.Win;
                            break;
                        case "z":
                            gameResult = GameResultEnum.Loss;
                            break;
                        default:
                            break;
                    }
                    break;
                case "b":
                    switch (player2.ToLower())
                    {
                        case "x":
                            gameResult = GameResultEnum.Loss;
                            break;
                        case "y":
                            gameResult = GameResultEnum.Draw;
                            break;
                        case "z":
                            gameResult = GameResultEnum.Win;
                            break;
                        default:
                            break;
                    }
                    break;
                case "c":
                    switch (player2.ToLower())
                    {
                        case "x":
                            gameResult = GameResultEnum.Win;
                            break;
                        case "y":
                            gameResult = GameResultEnum.Loss;
                            break;
                        case "z":
                            gameResult = GameResultEnum.Draw;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return gameResult;
        }

        /// <summary>
        /// Deze functie berekent de eindscore van een wedstrijd voor een speler 
        /// </summary>
        /// <param name="score"></param>
        /// <param name="gameResult"></param>
        /// <returns>Eindscore</returns>
        private int DetermineFinalScorePlayer(int score, GameResultEnum gameResult)
        {
            switch (gameResult)
            {
                case GameResultEnum.Win:
                    score += 6;
                    break;
                case GameResultEnum.Draw:
                    score += 3;
                    break;
                case GameResultEnum.Loss:
                    score += 0;
                    break;
                default:
                    break;
            }

            return score;
        }

    }
}
