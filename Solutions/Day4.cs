using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024.Solutions
{
    internal class Day4
    {
        public struct Vector2
        {
            public Vector2(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; }
            public int Y { get; }

            public override string ToString() => $"({X}, {Y})";
        }

        public static int CountOfWordSearch(string[] characterGrid, string searchWord) {
            int searchCount = 0;
            Vector2[] directions = {
                new Vector2(1, 1),
                new Vector2(1, 0),
                new Vector2(1, -1),
                new Vector2(0, -1),
                new Vector2(-1, -1),
                new Vector2(-1, 0),
                new Vector2(-1, 1),
                new Vector2(0, 1)
            };

            for (int row = 0; row < characterGrid.Length; row++) {
                for (int col = 0; col < characterGrid[row].Length; col++)
                {
                    Vector2 startPosition = new Vector2(col, row);

                    if (characterGrid[col][row] == searchWord[0])
                    {
                        for (int directionIndex = 0; directionIndex < directions.Length; directionIndex++)
                        {
                            bool wordFound = true;

                            Vector2 currentDirection = directions[directionIndex];

                            for (int i = 1; i < searchWord.Length; i++)
                            {
                                Vector2 newPosition = new Vector2(
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
    }
}
