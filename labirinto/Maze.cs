using static System.Net.Mime.MediaTypeNames;

namespace labirinto
{
    public class Maze
    {
        public string mazeTxt;
        public char[,] arrayMaze;
        public int linesLength;
        public int columnLength = 0;

        public int entranceRow;
        public int entranceColumn;


        public Maze(string _mazeTxt)
        {
            mazeTxt = _mazeTxt;
            setArrayMaze();
        }

        private void setArrayMaze()
        {
            string[] lines = mazeTxt.Split('\n');

            foreach (string line in lines)
            { 
                if (line.Length == 0 || line.Length < columnLength) continue;

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

        public string returnStringPosition((int,int) position)
        {
            int linePosition = position.Item1;
            int columnPosition = position.Item2;


            if (linePosition < 0 || linePosition >= linesLength || columnPosition < 0 || columnPosition >= columnLength)
                    return ("Posicao fora do labirinto");

            switch (arrayMaze[linePosition, columnPosition])
            {
                case '*':
                    return "Parede";
                case ' ':
                    return "Espaco vazio";
                case 'H':
                    return "Humano";
                case 'E':
                    return "Saida";
                default:
                    return "Erro";
            }
        }
    }
}
