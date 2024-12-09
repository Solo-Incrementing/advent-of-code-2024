using advent_of_code_2024.Helpers;

namespace advent_of_code_2024.Solutions
{
    internal class Day4 : IDay
    {

        private static int CountOfWordSearch(string[] characterGrid, string searchWord)
        {
            int searchCount = 0;
            Vector2Int[] directions = {
                new Vector2Int(1, 1),
                new Vector2Int(1, 0),
                new Vector2Int(1, -1),
                new Vector2Int(0, -1),
                new Vector2Int(-1, -1),
                new Vector2Int(-1, 0),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1)
            };

            for (int row = 0; row < characterGrid.Length; row++)
            {
                for (int col = 0; col < characterGrid[row].Length; col++)
                {
                    Vector2Int startPosition = new Vector2Int(col, row);

                    if (characterGrid[col][row] == searchWord[0])
                    {
                        for (int directionIndex = 0; directionIndex < directions.Length; directionIndex++)
                        {
                            bool wordFound = true;

                            Vector2Int currentDirection = directions[directionIndex];

                            for (int i = 1; i < searchWord.Length; i++)
                            {
                                Vector2Int newPosition = new Vector2Int(
                                    startPosition.X + currentDirection.X * i,
                                    startPosition.Y + currentDirection.Y * i
                                    );

                                if (
                                    newPosition.X >= 0 &&
                                    newPosition.X < characterGrid[row].Length &&
                                    newPosition.Y >= 0 &&
                                    newPosition.Y < characterGrid.Length)
                                {
                                    if (characterGrid[newPosition.X][newPosition.Y] != searchWord[i])
                                    {
                                        wordFound = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    wordFound = false;
                                    break;
                                }
                            }

                            if (wordFound)
                            {
                                searchCount++;
                            }
                        }
                    }

                }
            }

            return searchCount;
        }

        // search word must have an odd number of letters
        private static int oddWordCrossSearch(string[] characterGrid, string searchWord)
        {
            if (searchWord.Length % 2 == 0 && searchWord.Length <= 2) return 0;

            int searchCount = 0;
            Vector2Int[] directions = {
                new Vector2Int(1, 1),
                new Vector2Int(1, -1),
                new Vector2Int(-1, -1),
                new Vector2Int(-1, 1),
            };

            for (int row = 0; row < characterGrid.Length; row++)
            {
                for (int col = 0; col < characterGrid[row].Length; col++)
                {
                    if (characterGrid[col][row] == searchWord[(searchWord.Length - 1) / 2])
                    {
                        int foundWordCount = 0;

                        for (int directionIndex = 0; directionIndex < directions.Length; directionIndex++)
                        {
                            // start from the furthest point from the center of the word
                            // e.g if the word is 5 letters long, start from currentpos + (2,2)

                            Vector2Int startPosition = new Vector2Int(
                                col + directions[directionIndex].X * (searchWord.Length - 1) / 2,
                                row + directions[directionIndex].Y * (searchWord.Length - 1) / 2
                                );

                            bool wordFound = true;

                            // currentDirection is in the opposite direction because we are going inwards from the edge of the cross
                            Vector2Int currentDirection = new Vector2Int(
                                directions[directionIndex].X * -1,
                                directions[directionIndex].Y * -1
                                );

                            for (int i = 0; i < searchWord.Length; i++)
                            {
                                Vector2Int newPosition = new Vector2Int(
                                    startPosition.X + currentDirection.X * i,
                                    startPosition.Y + currentDirection.Y * i
                                    );

                                if (
                                    newPosition.X >= 0 &&
                                    newPosition.X < characterGrid[row].Length &&
                                    newPosition.Y >= 0 &&
                                    newPosition.Y < characterGrid.Length)
                                {
                                    if (characterGrid[newPosition.X][newPosition.Y] != searchWord[i])
                                    {
                                        wordFound = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    wordFound = false;
                                    break;
                                }
                            }

                            if (wordFound) foundWordCount++;
                        }

                        if (foundWordCount >= 2)
                        {
                            searchCount++;
                        }
                    }

                }
            }

            return searchCount;
        }

        public static void SolveProblem(string[] input)
        {
            Console.WriteLine(CountOfWordSearch(input, "XMAS"));
            Console.WriteLine(oddWordCrossSearch(input, "MAS"));
        }
    }
}