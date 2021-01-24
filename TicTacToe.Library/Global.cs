using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Library
{
    public class Global
    {
        public static string playerToken;
        public static string opponentToken;
        public static int cellsToClick;
        public static string[] tokenPlacements = new string[9];

        public static bool CheckGameOver(string[] tokenPlacements)
        {
            bool gameGoesOn = true;
            bool allEqual;
            string firstItem = "";

            int[,] winningCombinations = new int[8, 3]
            {
                {0,1,2},
                {3,4,5},
                {6,7,8},
                {0,3,6},
                {1,4,7},
                {2,5,8},
                {0,4,8},
                {2,4,6},
            };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                string[] combo = new string[3];

                for (int j = 0; j < winningCombinations.GetLength(1); j++)
                {
                    combo[j] = tokenPlacements[winningCombinations[i, j]];
                    int pos = winningCombinations[i, j];
                    //Console.Write($"{gamePlacements[winningCombinations[i, j]]} ");
                }

                allEqual = true;
                firstItem = combo[0];
                foreach (string item in combo)
                {

                    if (item != firstItem)
                    {
                        allEqual = false;
                        break;
                    }
                }

                if (allEqual == true)
                {
                    gameGoesOn = false;
                }
            }
            return gameGoesOn;
        }

        public static void ClearPlacemements()
        {
            for(int i = 0; i < tokenPlacements.Length; i++)
            {
                tokenPlacements[i] = (i + 1).ToString();
            }

            cellsToClick = 9;
        }
    }
}
