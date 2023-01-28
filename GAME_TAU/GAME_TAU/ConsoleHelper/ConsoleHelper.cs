using GAME_TAU.Enums;
using GAME_TAU.GameModel;

namespace GAME_TAU.ConsoleHelper
{
    public static class ConsoleHelper
    {
        public static void DisplayGame(Game game)
        {
            Console.Clear();
            for (int i = 0; i < game.fieldSizeX; i++)
            {
                for (int j = 0; j < game.fieldSizeY; j++)
                {
                    char m = game.field[i, j];
                    Console.Write("[{0}]", m is '\0' ? ' ' : m);
                }
                Console.WriteLine();
            }
        }

        public static PossibleMovesEnum Input()
        {
            switch (Console.ReadKey().KeyChar)
            {
                default:
                    return PossibleMovesEnum.None;

                case 'a':
                    return PossibleMovesEnum.Left;

                case 'w':
                    return PossibleMovesEnum.Up;

                case 's':
                    return PossibleMovesEnum.Down;

                case 'd':
                    return PossibleMovesEnum.Rigth;
            }
        }
    }
}