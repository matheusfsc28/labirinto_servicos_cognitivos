namespace labirinto
{
    public class Robot : Radar
    {
        public int battery = 2;
        public (int, int)[] rightMovement = new (int, int)[]
        {
        (-1, 0), // UP
        (0, 1),  // Right
        (1, 0),  // Down
        (0, -1)  // Left
        };
        public string[] rightMovementNames = new string[]
        {
        "south", "west", "north", "east"
        };
        public (int, int) exit;
        public string compass;

        public Robot(Maze maze) : base(maze)
        {
            SetOrientation(_maze.entranceRow, _maze.entranceColumn);
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

            for (int i = pathSaved.Count - 1; i > 0; i--)
            {
                (positionRow, positionColumn) = MoveTo(positionRow, positionColumn, pathSaved[i]);

                if (i == 0) (positionRow, positionColumn) = MoveTo(positionRow, positionColumn, (_maze.entranceRow, _maze.entranceColumn));
            }

            DropHuman(positionRow, positionColumn);
        }

        public (int, int) MoveTo(int currentRow, int currentColumn, (int, int) localiation)
        {
            (int, int) movement = (0, 0);
            int[] indexes;

            switch (compass)
            {
                case "north":
                    indexes = [ 0, 1, 3 ];
                    foreach (int i in indexes)
                    {
                        movement = (currentRow + rightMovement[i].Item1, currentColumn + rightMovement[i].Item2);
                        if (Sensor(localiation, movement)) break;
                        //Log.TurnRight
                    }
                    //Log.Avancar

                    break;
                case "east":
                    indexes = [1, 2, 0];
                    foreach (int i in indexes)
                    {
                        movement = (currentRow + rightMovement[i].Item1, currentColumn + rightMovement[i].Item2);
                        if (Sensor(localiation, movement)) break;
                        //Log.TurnRight
                    }
                    //Log.Avancar

                    break;
                case "south":
                    indexes = [2, 3, 1];
                    foreach (int i in indexes)
                    {
                        movement = (currentRow + rightMovement[i].Item1, currentColumn + rightMovement[i].Item2);
                        if (Sensor(localiation, movement)) break;
                        //Log.TurnRight
                    }
                    //Log.Avancar

                    break;
                case "west":
                    indexes = [3, 0, 2];
                    foreach (int i in indexes)
                    {
                        movement = (currentRow + rightMovement[i].Item1, currentColumn + rightMovement[i].Item2);
                        if (Sensor(localiation, movement)) break;
                        //Log.TurnRight
                    }
                    //Log.Avancar

                    break;
            }
            return movement;
        }


        public bool Sensor((int, int) localization, (int, int) movement)
        {
            return localization == movement;
        }

        public void SetOrientation(int positionRow, int positionColumn)
        {
            for (int i = 0; i < rightMovement.Length; i++)
            {
                // Gira os 90º graus
                if (positionRow + rightMovement[i].Item1 < 0 || positionRow + rightMovement[i].Item1 >= _maze.linesLength || positionColumn + rightMovement[i].Item2 < 0 || positionColumn + rightMovement[i].Item2 >= _maze.columnLength)
                {
                    compass = rightMovementNames[i];
                    exit = (positionRow + rightMovement[i].Item1, positionColumn + rightMovement[i].Item2);
                }
            }
        }
    }
}
