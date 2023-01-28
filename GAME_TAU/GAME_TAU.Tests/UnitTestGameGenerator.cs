using GAME_TAU.GameModel;

namespace GAME_TAU.Tests
{
    [TestClass]
    public class UnitTestGameGenerator
    {
        [TestMethod]
        public void CheckIfGameISGenerated()
        {
            Exception? exception = null;
            try
            {
                Game game = GameGenerator.GenerateGame(5, 6, 7, 'C', 'P', 'M', 'K');
            }
            catch (Exception ex) { exception = ex; }
            Assert.AreEqual(exception, null);
        }

        [TestMethod]
        public void CheckIfGeneratorTrowsExceptionForTheSameChars()
        {
            Exception? exception = new Exception();
            try
            {
                Game game = GameGenerator.GenerateGame(5, 6, 7, 'C', 'C', 'M', 'K');
            }
            catch (Exception ex) { exception = ex; }

            Assert.AreEqual(exception.Message, "Chars for start, stop, obstacle and playerChar should be diffent.");
        }

        [TestMethod]
        public void CheckIfGeneratorTrowsExceptionForTooSmallField()
        {
            Exception? exception = new Exception();
            try
            {
                Game game = GameGenerator.GenerateGame(1, 6, 7, 'C', 'C', 'M', 'K');
            }
            catch (Exception ex) { exception = ex; }

            Assert.AreEqual(exception.Message, "Values X and Y should be greather than 5.");
        }

        [TestMethod]
        public void CheckIfGeneratorTrowsExceptionForTooManyObstacles()
        {
            Exception? exception = new Exception();
            try
            {
                Game game = GameGenerator.GenerateGame(8, 6, 100, 'C', 'A', 'M', 'K');
            }
            catch (Exception ex) { exception = ex; }

            Assert.AreEqual(exception.Message, "There are too many obstacles given.");
        }

        [TestMethod]
        public void CheckIfGeneratedGameIsNotWon()
        {
            bool isGameWon = true;
            try
            {
                Game game = GameGenerator.GenerateGame(8, 6, 4, 'C', 'X', 'M', 'K');
                isGameWon = game.isWon;
            }
            catch (Exception) { }

            Assert.AreEqual(isGameWon, false);
        }
    }
}