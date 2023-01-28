namespace GAME_TAU.GameModel
{
    public static class GameGenerator
    {
        public static Game GenerateGame(int X, int Y, short numberOfObstacles, char startChar, char stopChar, char obstacleChar, char playerChar)
        {
            ValidatingData(X, Y, numberOfObstacles, startChar, stopChar, obstacleChar, playerChar);

            int startingPoint = 0;
            char[,] Fields = CreateField(X, Y, numberOfObstacles, startChar, stopChar, obstacleChar, out startingPoint);

            return new Game(Fields, X, Y, startChar, stopChar, startingPoint, 0, playerChar);
        }

        private static char[,] CreateField(int X, int Y, short numberOfObstacles, char startChar, char stopChar, char obstacleChar, out int sP)
        {
            char[,] Fields = new char[X, Y];

            Random random = new Random();
            int startingPoint = random.Next(0, X - 1);
            int endingPoint = random.Next(0, X - 1);

            Fields[startingPoint, 0] = startChar;
            Fields[endingPoint, Y - 1] = stopChar;

            short AddedObsticles = 0;
            while (AddedObsticles < numberOfObstacles)
            {
                int RandomX = random.Next(0, X);
                int RandomY = random.Next(0, Y);
                if (Fields[RandomX, RandomY] is '\0')
                {
                    Fields[RandomX, RandomY] = obstacleChar;
                    AddedObsticles++;
                }
            }

            sP = startingPoint;
            return Fields;
        }

        private static void ValidatingData(int X, int Y, short numberOfObstacles, char startChar, char stopChar, char obstacleChar, char playerChar)
        {
            if (X < 5 || Y < 5)
                throw new Exception("Values X and Y should be greather than 5.");

            if (numberOfObstacles > X * Y / 2)
                throw new Exception("There are too many obstacles given.");

            if (startChar == stopChar || startChar == obstacleChar || stopChar == obstacleChar ||
                playerChar == stopChar || playerChar == stopChar || playerChar == obstacleChar)
                throw new Exception("Chars for start, stop, obstacle and playerChar should be diffent.");
        }
    }
}