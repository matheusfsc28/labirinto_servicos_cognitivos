namespace labirinto
{
    public class Robot : Radar
    {
        Log _log;

        public int battery = 2;
        public (int, int)[] movementDirections = new (int, int)[]
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
            _log = new Log();
            SetOrientation(_maze.entranceRow, _maze.entranceColumn);
        }


        public void DischargeBattery()
        {
            battery--;
        }

        //public void CatchHuman(int positionRow, int positionColumn)
        //{
        //    for (int i = 0; i < movementDirections.Length; i++)
        //    {
        //        // Gira os 90º graus
        //        var movement = (positionRow + movementDirections[i].Item1, positionColumn + movementDirections[i].Item2);
        //        if (Sensor((pathSaved.Last().Item1, pathSaved.Last().Item2), movement))
        //        {
        //            DischargeBattery();
        //            //Log.PegarHumano
        //            return;
        //        }


        //    }
        //    throw new Exception("Nenhum humano para capturar localizado pelos sensores");
        //}

        //public void DropHuman(int positionRow, int positionColumn)
        //{
        //    for (int i = 0; i < movementDirections.Length; i++)
        //    {
        //        // Gira os 90º graus
        //        var movement = (positionRow + movementDirections[i].Item1, positionColumn + movementDirections[i].Item2);
        //        if (Sensor((exit.Item1, exit.Item2), movement))
        //        {
        //            DischargeBattery();
        //            //Log.PegarHumano
        //            return;
        //        }
        //    }
        //    throw new Exception("Caminho de entrada não localizado pelos sensores");
        //}

        public void RescueHuman()
        {
            SearchHuman();

            int positionRow = _maze.entranceRow;
            int positionColumn = _maze.entranceColumn;

            for (int i = 0; i < pathSaved.Count; i++)
            {
                if (i == 0) continue;
                else if (i == pathSaved.Count - 1) break;

                (positionRow, positionColumn) = MoveTo(positionRow, positionColumn, pathSaved[i]);
            }

            //// precisa verificar se o homanu está na frente
            //CatchHuman(positionRow, positionColumn);

            //for (int i = pathSaved.Count - 1; i > 0; i--)
            //{
            //    (positionRow, positionColumn) = MoveTo(positionRow, positionColumn, pathSaved[i]);

            //}

            //DropHuman(positionRow, positionColumn);
        }

        public (int, int) MoveTo(int currentRow, int currentColumn, (int, int) localization)
        {
            (int, string)[] indexes;

            string movementCompass = compass;
            (int, int) sensorFront = (0, 0);
            (int, int) sensorRight = (0, 0);
            (int, int) sensorLeft = (0, 0);

            while (!(CheckFrontSensor(localization, sensorFront)))
                switch (movementCompass)
                {
                    case "north":
                        indexes = [(0, "north"), (1, "east"), (3, "west")];

                        sensorFront = (currentRow + movementDirections[0].Item1, currentColumn + movementDirections[0].Item2);
                        sensorRight = (currentRow + movementDirections[1].Item1, currentColumn + movementDirections[1].Item2);
                        sensorLeft = (currentRow + movementDirections[3].Item1, currentColumn + movementDirections[3].Item2);

                        if (CheckFrontSensor(localization, sensorFront))
                        {
                            compass = movementCompass;
                            _log.WriteToCsv('A', _maze.returnStringPosition(sensorFront), _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft));
                        }
                        else
                        {
                            movementCompass = "east";
                            _log.WriteToCsv('D', _maze.returnStringPosition(sensorFront), _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft));
                        }
                        break;
                    case "east":
                        indexes = [(1, "east"), (2, "south"), (0, "north")];

                        sensorFront = (currentRow + movementDirections[1].Item1, currentColumn + movementDirections[1].Item2);
                        sensorRight = (currentRow + movementDirections[2].Item1, currentColumn + movementDirections[2].Item2);
                        sensorLeft = (currentRow + movementDirections[0].Item1, currentColumn + movementDirections[0].Item2);

                        if (CheckFrontSensor(localization, sensorFront))
                        {
                            compass = movementCompass;
                            _log.WriteToCsv('A', _maze.returnStringPosition(sensorFront), _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft));
                        }
                        else
                        {
                            movementCompass = "south";
                            _log.WriteToCsv('D', _maze.returnStringPosition(sensorFront), _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft));
                        }
                        break;
                    case "south":
                        indexes = [(2, "south"), (3, "west"), (1, "east")];

                        sensorFront = (currentRow + movementDirections[2].Item1, currentColumn + movementDirections[2].Item2);
                        sensorRight = (currentRow + movementDirections[3].Item1, currentColumn + movementDirections[3].Item2);
                        sensorLeft = (currentRow + movementDirections[1].Item1, currentColumn + movementDirections[1].Item2);

                        if (CheckFrontSensor(localization, sensorFront))
                        {
                            compass = movementCompass;
                            _log.WriteToCsv('A', _maze.returnStringPosition(sensorFront), _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft));
                        }
                        else
                        {
                            movementCompass = "west";
                            _log.WriteToCsv('D', _maze.returnStringPosition(sensorFront), _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft));
                        }
                        break;
                    case "west":
                        indexes = [(3, "west"), (0, "north"), (2, "south")];

                        sensorFront = (currentRow + movementDirections[3].Item1, currentColumn + movementDirections[3].Item2);
                        sensorRight = (currentRow + movementDirections[0].Item1, currentColumn + movementDirections[0].Item2);
                        sensorLeft = (currentRow + movementDirections[2].Item1, currentColumn + movementDirections[2].Item2);

                        if (CheckFrontSensor(localization, sensorFront))
                        {
                            compass = movementCompass;
                            _log.WriteToCsv('A', _maze.returnStringPosition(sensorFront), _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft));
                        }
                        else
                        {
                            movementCompass = "north";
                            _log.WriteToCsv('D', _maze.returnStringPosition(sensorFront), _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft));
                        }
                        break;
                }
            return sensorFront;
        }


        public bool CheckFrontSensor((int, int) localization, (int, int) movement)
        {
            return localization == movement;
        }

        public void SetOrientation(int positionRow, int positionColumn)
        {
            for (int i = 0; i < movementDirections.Length; i++)
            {
                // Gira os 90º graus
                if (positionRow + movementDirections[i].Item1 < 0 ||
                    positionRow + movementDirections[i].Item1 >= _maze.linesLength ||
                    positionColumn + movementDirections[i].Item2 < 0 ||
                    positionColumn + movementDirections[i].Item2 >= _maze.columnLength)
                {
                    compass = rightMovementNames[i];
                    exit = (positionRow + movementDirections[i].Item1, positionColumn + movementDirections[i].Item2);
                }
            }
        }
    }
}
