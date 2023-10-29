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
        public Referee() 
        {
        }

        /// <summary>
        /// Deze functie berekent de score van playerChoice voor een wedstrijd Rock Paper Scissors
        /// </summary>
        /// <param name="opponentChoice"></param>
        /// <param name="player2"></param>
        /// <returns>Score van playerChoice</returns>
        public int GetGameScorePlayer(string opponentChoice, string playerChoice)
        {
            // Bepaal basisscore player
            int scorePlayer = DetermineBaseScorePlayer(playerChoice);

            // Bepaal het wedstrijdresultaat
            GameResultEnum gameResultPlayer = DetermineGameResultPlayer(opponentChoice, playerChoice);

            // Bepaal eindscore player
            scorePlayer = DetermineFinalScorePlayer(scorePlayer, gameResultPlayer);

            return scorePlayer;
        }

        /// <summary>
        /// Deze functie bepaalt de basisscore voor een speler
        /// Rock => 1 punt
        /// Paper => 2 punten
        /// Sciccors => 3 punten
        /// </summary>
        /// <param name="player"></param>
        /// <returns>de basisscore</returns>
        private int DetermineBaseScorePlayer(string player)
        {
            int score = 0;
            switch (player.ToLower())
            {
                case "a":
                    score = 1;
                    break;
                case "b":
                    score = 2;
                    break;
                case "c":
                    score = 3;
                    break;
                default:
                    break;
            }

            return score;
        }

        /// <summary>
        /// Deze functie bepaalt de wedstrijduitslag voor player
        /// Win
        /// Draw
        /// Loss
        /// </summary>
        /// <param name="opponentChoice"></param>
        /// <param name="playerChoice"></param>
        /// <returns>Wedstrijduitslag</returns>
        public GameResultEnum DetermineGameResultPlayer(string opponentChoice, string playerChoice)
        {
            GameResultEnum gameResult = GameResultEnum.Draw;
            switch (opponentChoice.ToLower())
            {
                case "a":
                    switch (playerChoice.ToLower())
                    {
                        case "a":
                            gameResult = GameResultEnum.Draw;
                            break;
                        case "b":
                            gameResult = GameResultEnum.Win;
                            break;
                        case "c":
                            gameResult = GameResultEnum.Loss;
                            break;
                        default:
                            break;
                    }
                    break;
                case "b":
                    switch (playerChoice.ToLower())
                    {
                        case "a":
                            gameResult = GameResultEnum.Loss;
                            break;
                        case "b":
                            gameResult = GameResultEnum.Draw;
                            break;
                        case "c":
                            gameResult = GameResultEnum.Win;
                            break;
                        default:
                            break;
                    }
                    break;
                case "c":
                    switch (playerChoice.ToLower())
                    {
                        case "a":
                            gameResult = GameResultEnum.Win;
                            break;
                        case "b":
                            gameResult = GameResultEnum.Loss;
                            break;
                        case "c":
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
