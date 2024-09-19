namespace labirinto
{
    public class Robot : Radar
    {
        public int battery = 2;
        public (int, int)[] rightMovement = new (int, int)[]
        {
        (-1, 0), (0, 1), (1, 0), (0, -1)
        };

        public Robot(Maze maze) : base(maze)
        { 
        }

        public void DischargeBattery() 
        {
            battery--;
        }

        public void CatchHuman(int positionRow, int positionColumn)
        {
            for (int i = 0; i < rightMovement.Length; i++)
            {
                // Gira os 90º graus
                var movement = (positionRow + rightMovement[i].Item1, positionColumn + rightMovement[i].Item2);
                if (Sensor((pathSaved.Last().Item1, pathSaved.Last().Item2), movement)) ;
                {
                    DischargeBattery();
                    return;
                }
            }
            throw new Exception("Nenhum humano para capturar localizado pelos sensores");
        }

        public void DropHuman(int positionRow, int positionColumn)
        {
            for (int i = 0; i < rightMovement.Length; i++)
            {
                // Gira os 90º graus
                var movement = (positionRow + rightMovement[i].Item1, positionColumn + rightMovement[i].Item2);
                if (Sensor((_maze.entranceRow, _maze.entranceColumn), movement));
                {
                    DischargeBattery();
                    return;
                }
            }
            throw new Exception("Caminho de entrada não localizado pelos sensores");
        }

        public void RescueHuman()
        {
            SearchHuman();

            int positionRow = _maze.entranceRow;
            int positionColumn = _maze.entranceColumn;

            for (int i = 0; i < pathSaved.Count; i++)
            {
                if (i == pathSaved.Count - 1) break;

                (positionRow, positionColumn) = MoveTo(positionRow, positionColumn, pathSaved[i]);
            }

            // precisa verificar se o homanu está na frente
            CatchHuman(positionRow, positionColumn);

            for (int i = pathSaved.Count -1; i > 0; i--)
            {
                (positionRow, positionColumn) = MoveTo(positionRow, positionColumn, pathSaved[i]);
            }

            DropHuman(positionRow, positionColumn);
        }

        public (int,int) MoveTo(int currentRow, int currentColumn, (int,int) localiation)
        {
            int[] verticalMovements = { -1, 1, 0, 0 };
            int[] horizontalMovements = { 0, 0, -1, 1 };

            for (int i = 0; i < rightMovement.Length; i++)
            {
                // Gira os 90º graus
                var movement = (currentRow + rightMovement[i].Item1, currentColumn + rightMovement[i].Item2);
                if (Sensor(localiation, movement)) return movement;
            }

            throw new Exception("Impossível prosseguir para o caminho destino com a posição atual");
        }

        public bool Sensor((int, int) localiation, (int, int) movement)
        {
            return localiation == movement;
        }
    }
}
