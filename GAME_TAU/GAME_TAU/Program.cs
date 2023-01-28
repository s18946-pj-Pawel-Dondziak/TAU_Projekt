using GAME_TAU.ConsoleHelper;
using GAME_TAU.GameModel;

try
{
    Game game = GameGenerator.GenerateGame(20, 20, 100, 'A', 'B', 'X', 'O');

    ConsoleHelper.DisplayGame(game);

    while (!game.isWon)
    {
        game.Move(ConsoleHelper.Input());
        ConsoleHelper.DisplayGame(game);
    }

    Console.WriteLine("YOU WON!!! It took you {0} moves to won.", game.numberOfMoves);
}
catch(Exception ex) { Console.WriteLine("Something went wrong :("); }
