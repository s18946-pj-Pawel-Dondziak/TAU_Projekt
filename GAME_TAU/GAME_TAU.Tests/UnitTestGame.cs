using GAME_TAU.GameModel;

namespace GAME_TAU.Tests
{
    [TestClass]
    public class UnitTestGame
    {
        private Game game { get; }
        private short numberOfObstacles { get; } = 7;
        private int fieldSizeX { get; } = 5;
        private int fieldSizeY { get; } = 5;
        private char startChar { get; } = 'A';
        private char stopChar { get; } = 'B';
        private char playerChar { get; } = 'O';
        private char obsteclasChar { get; } = 'X';

        public UnitTestGame()
        {
            try
            {
                game = GameGenerator.GenerateGame(fieldSizeX, fieldSizeY, numberOfObstacles, startChar, stopChar, obsteclasChar, playerChar);
            }
            catch (Exception) { throw new Exception("Could not create game."); }
        }

        [TestMethod]
        public void CheckFieldSizeY()
        {
            Assert.AreEqual(game.fieldSizeY, fieldSizeY);
        }

        [TestMethod]
        public void CheckFieldSizeX()
        {
            Assert.AreEqual(game.fieldSizeX, fieldSizeX);
        }

        [TestMethod]
        public void CheckIfGameIsNotWonAtStart()
        {
            Assert.AreEqual(game.isWon, false);
        }

        [TestMethod]
        public void AttemptedAtTryingToMakeNonExistingMove()
        {
            game.Move(Enums.PossibleMovesEnum.None);
            Assert.AreEqual(game.lastMoveStatus, Enums.MoveStatusEnum.None);
        }

        [TestMethod]
        public void CheckNumberOFObstacles()
        {
            int nOfObstacles = 0;

            for (int i = 0; i < game.fieldSizeX; i++)
            {
                for (int j = 0; j < game.fieldSizeY; j++)
                {
                    if (game.field[i, j] == obsteclasChar)
                        nOfObstacles++;
                }
            }

            Assert.AreEqual(nOfObstacles, numberOfObstacles);
        }

        [TestMethod]
        public void AttemptedAtMakingWrongMove()
        {
            for (int i = 0; i < game.fieldSizeY; i++)
                game.Move(Enums.PossibleMovesEnum.Left);

            bool couldNotMove = game.lastMoveStatus == Enums.MoveStatusEnum.OutOfBounds ||
                game.lastMoveStatus == Enums.MoveStatusEnum.Obstacle;
            Assert.AreEqual(couldNotMove, true);
        }
    }
}