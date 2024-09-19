namespace labirinto
{
    public class Maze
    {
        public Robot robot;

        public string mazeTxt;
        public char[,] arrayMaze;
        public int linesLength;
        public int columnLength;

        public int entranceRow;
        public int entranceColumn;


        public Maze(string _mazeTxt, Robot _robot)
        {
            mazeTxt = _mazeTxt;
            robot = _robot;
            setArrayMaze();
        }

        private void setArrayMaze()
        {
            string[] lines = mazeTxt.Split('\n');

            foreach (string line in lines)
            {
                if (line.Length == 0) continue;

                if (linesLength == 0)
                {
                    columnLength = line.Length;
                }

                linesLength++;
            }

            arrayMaze = new char[linesLength, columnLength];

            for (int i = 0; i < linesLength; i++)
            {
                string line = lines[i];
                for (int j = 0; j < columnLength; j++)
                {
                    arrayMaze[i, j] = line[j];

                    if (arrayMaze[i, j] == 'E')
                    {
                        entranceRow = i;
                        entranceColumn = j;
                    }
                }
            }
        }

        public void writeMaze()
        {
            if (arrayMaze == null) throw new Exception("Labirinto invalido");
            for (int i = 0; i < linesLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    Console.Write(arrayMaze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
