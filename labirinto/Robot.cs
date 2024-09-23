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
        public string actionRobot = "LIGAR";
        public (int, int) humanPosition;
        public bool hasHuman = false;

        public Robot(Maze maze) : base(maze)
        {
            _log = new Log(maze._mazeName);
            SetOrientation(_maze.entranceRow, _maze.entranceColumn);
        }


        public void DischargeBattery()
        {
            battery--;
        }

        public void CatchHuman(int currentRow, int currentColumn, (int, int) humanPosition)
        {
            if (battery <= 0)
                throw new Exception("Bateria insuficiente para realizar ação");
            if (_maze.returnStringPosition(humanPosition) != "HUMANO")
                throw new Exception("Nenhum humano para capturar localizado pelos sensores");

            string movementCompass = compass;
            (int, int) sensorFront = (0, 0);
            (int, int) sensorRight = (0, 0);
            (int, int) sensorLeft = (0, 0);

            while (!(_maze.returnStringPosition(sensorFront) == "HUMANO"))
                switch (movementCompass)
                {
                    case "north":
                        // north, west, east
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[0], movementDirections[1], movementDirections[3]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (!(_maze.returnStringPosition(sensorFront) == "HUMANO"))
                        {
                            movementCompass = "east";
                            actionRobot = "D";
                        }

                        break;
                    case "east":
                        // east, south, north
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[1], movementDirections[2], movementDirections[0]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (!(_maze.returnStringPosition(sensorFront) == "HUMANO"))
                        {
                            movementCompass = "south";
                            actionRobot = "D";
                        }

                        break;
                    case "south":
                        // south, west, east
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[2], movementDirections[3], movementDirections[1]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (!(_maze.returnStringPosition(sensorFront) == "HUMANO"))
                        {
                            movementCompass = "west";
                            actionRobot = "D";
                        }

                        break;
                    case "west":
                        // west, north, south
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[3], movementDirections[0], movementDirections[2]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (!(_maze.returnStringPosition(sensorFront) == "HUMANO"))
                        {
                            movementCompass = "north";
                            actionRobot = "D";
                        }

                        break;
                }

            compass = movementCompass;
            actionRobot = "P";
            hasHuman = true;

            DischargeBattery();
            _maze.ReplaceMaze(sensorFront, ' ');
        }


        public void DropHuman(int currentRow, int currentColumn)
        {
            if (battery <= 0)
                throw new Exception("Bateria insuficiente para realizar ação");

            string movementCompass = compass;
            (int, int) sensorFront = (0, 0);
            (int, int) sensorRight = (0, 0);
            (int, int) sensorLeft = (0, 0);

            while (!(_maze.returnStringPosition(sensorFront) == "SAIDA"))
                switch (movementCompass)
                {
                    case "north":
                        // north, west, east
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[0], movementDirections[1], movementDirections[3]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);
                        if (!(_maze.returnStringPosition(sensorFront) == "SAIDA"))
                        {
                            movementCompass = "east";
                            actionRobot = "D";
                        }

                        break;
                    case "east":
                        // east, south, north
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[1], movementDirections[2], movementDirections[0]);


                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);
                        if (!(_maze.returnStringPosition(sensorFront) == "SAIDA"))
                        {
                            movementCompass = "south";
                            actionRobot = "D";
                        }

                        break;
                    case "south":
                        // south, west, east
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[2], movementDirections[3], movementDirections[1]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);
                        if (!(_maze.returnStringPosition(sensorFront) == "SAIDA"))
                        {
                            movementCompass = "west";
                            actionRobot = "D";
                        }

                        break;
                    case "west":
                        // west, north, south
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[3], movementDirections[0], movementDirections[2]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (!(_maze.returnStringPosition(sensorFront) == "SAIDA"))
                        {
                            movementCompass = "north";
                            actionRobot = "D";
                        }
                        break;
                }

            compass = movementCompass;
            actionRobot = "E";
            hasHuman = false;

            DischargeBattery();
            _maze.ReplaceMaze(sensorFront, ' ');

            _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);
        }

        public void RescueHuman()
        {
            SearchHuman();

            int positionRow = _maze.entranceRow;
            int positionColumn = _maze.entranceColumn;

            for (int i = 1; i < pathSaved.Count - 1; i++)
            {
                (positionRow, positionColumn) = MoveTo(positionRow, positionColumn, pathSaved[i]);
            }

            //precisa verificar se o homanu está na frente
            CatchHuman(positionRow, positionColumn, pathSaved.Last());

            //começa a partir da terceira posição regressiva de pathSaved
            for (int i = pathSaved.Count - 3; i > 0; i--)
            {
                (positionRow, positionColumn) = MoveTo(positionRow, positionColumn, pathSaved[i]);
            }

            DropHuman(positionRow, positionColumn);
        }

        public (int, int) MoveTo(int currentRow, int currentColumn, (int, int) localization)
        {
            string movementCompass = compass;
            (int, int) sensorFront = (0, 0);
            (int, int) sensorRight = (0, 0);
            (int, int) sensorLeft = (0, 0);

            while (!(CheckFrontSensor(localization, sensorFront)))
                switch (movementCompass)
                {
                    case "north":
                        // north, west, east
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[0], movementDirections[1], movementDirections[3]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (CheckFrontSensor(localization, sensorFront))
                        {
                            compass = movementCompass;
                            actionRobot = "A";
                        }
                        else
                        {
                            movementCompass = "east";
                            actionRobot = "D";
                        }
                        break;
                    case "east":
                        // east, south, north
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[1], movementDirections[2], movementDirections[0]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (CheckFrontSensor(localization, sensorFront))
                        {
                            compass = movementCompass;
                            actionRobot = "A";
                        }
                        else
                        {
                            movementCompass = "south";
                            actionRobot = "D";
                        }
                        break;
                    case "south":
                        // south, west, east
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[2], movementDirections[3], movementDirections[1]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (CheckFrontSensor(localization, sensorFront))
                        {
                            compass = movementCompass;
                            actionRobot = "A";
                        }
                        else
                        {
                            movementCompass = "west";
                            actionRobot = "D";
                        }
                        break;
                    case "west":
                        // west, north, south
                        (sensorFront, sensorRight, sensorLeft) = CheckSensorsAround(currentRow, currentColumn, movementDirections[3], movementDirections[0], movementDirections[2]);

                        _log.WriteToCsv(actionRobot, _maze.returnStringPosition(sensorFront),
                            _maze.returnStringPosition(sensorRight), _maze.returnStringPosition(sensorLeft), hasHuman);

                        if (CheckFrontSensor(localization, sensorFront))
                        {
                            compass = movementCompass;
                            actionRobot = "A";
                        }
                        else
                        {
                            movementCompass = "north";
                            actionRobot = "D";
                        }
                        break;
                }
            return sensorFront;
        }

        public ((int, int), (int, int), (int, int)) CheckSensorsAround(int currentRow, int currentColumn, (int, int) movementDirectionsFront, (int, int) movementDirectionsRight, (int, int) movementDirectionsLeft)
        {
            return ((currentRow + movementDirectionsFront.Item1, currentColumn + movementDirectionsFront.Item2),
                (currentRow + movementDirectionsRight.Item1, currentColumn + movementDirectionsRight.Item2),
                (currentRow + movementDirectionsLeft.Item1, currentColumn + movementDirectionsLeft.Item2));
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
