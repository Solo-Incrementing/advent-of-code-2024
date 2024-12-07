using advent_of_code_2024.Helpers;

namespace advent_of_code_2024.Solutions
{
    internal class Day6
    {
        public static bool PositionInsideBounds(Vector2Int position, int xBound, int yBound)
        {
            return position.X >= 0 &&
                   position.Y >= 0 &&
                   position.X < xBound &&
                   position.Y < yBound;
        }

        public static int CountDistinctGuardPositions(string[] map, char guard, char obstacle)
        {
            Dictionary<Vector2Int, Vector2Int> turnRight = new Dictionary<Vector2Int, Vector2Int>
            {
                // up to right
                { new Vector2Int(0, -1), new Vector2Int(1, 0) },
                // right to down
                { new Vector2Int(1, 0), new Vector2Int(0, 1) },
                // down to left
                { new Vector2Int(0, 1), new Vector2Int(-1, 0) },
                // left to up
                { new Vector2Int(-1, 0), new Vector2Int(0, -1) }
            };

            Vector2Int currentPosition = new Vector2Int(0);
            Vector2Int currentDirection = new Vector2Int(0, -1);

            bool guardFound = false;
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == guard)
                    {
                        currentPosition = new Vector2Int(j, i);
                        guardFound = true;
                        break;
                    }
                    if (guardFound) break;
                }
                if (guardFound) break;
            }

            List<Vector2Int> visitedPositions = new List<Vector2Int>();

            int safetyCount = 100000;

            while (safetyCount > 0)
            {
                if (!visitedPositions.Contains(currentPosition))
                {
                    visitedPositions.Add(currentPosition);
                }

                Vector2Int nextPosition = currentPosition + currentDirection;

                if (!PositionInsideBounds(nextPosition, map[0].Length, map.Length))
                {
                    break;
                }

                while (map[nextPosition.Y][nextPosition.X] == obstacle)
                {

                    currentDirection = turnRight[currentDirection];
                    nextPosition = currentPosition + currentDirection;

                    if (!PositionInsideBounds(nextPosition, map[0].Length, map.Length))
                    {
                        break;
                    }
                }

                currentPosition = nextPosition;

                safetyCount--;
            }

            return visitedPositions.Count;
        }
    }
}
