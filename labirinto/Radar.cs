namespace labirinto
{
    public class Radar
    {

        public Maze _maze;
        public bool[,] searched;
        public List<(int, int)> pathSaved = new List<(int, int)>();

        public Radar(Maze maze)
        {
            _maze = maze;
        }

        public bool SearchHuman()
        {
            searched = new bool[_maze.linesLength, _maze.columnLength];

            return MakeSearch(_maze.entranceRow, _maze.entranceColumn);
                
        }

        private bool MakeSearch(int vertical, int horizontal)
        {
            if (vertical < 0 || vertical >= _maze.linesLength || horizontal < 0 || horizontal >= _maze.columnLength)
                return false;

            if (searched[vertical, horizontal] || _maze.arrayMaze[vertical, horizontal] == '*')
                return false;

            searched[vertical, horizontal] = true;

            pathSaved.Add((vertical, horizontal));

            if (_maze.arrayMaze[vertical, horizontal] == 'H')
                return true;

            int[] verticalMovements = { -1, 1, 0, 0 };
            int[] horizontalMovements = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int nextVertical = vertical + verticalMovements[i];
                int nextHorizontal = horizontal + horizontalMovements[i];

                if (MakeSearch(nextVertical, nextHorizontal))
                    return true;
            }

            pathSaved.RemoveAt(pathSaved.Count - 1);

            return false;
        }
    }
}
