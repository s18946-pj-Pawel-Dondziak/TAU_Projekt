using GAME_TAU.Enums;

namespace GAME_TAU.GameModel
{
    public class Game
    {
        public char[,] field { get; }
        public int fieldSizeX { get; }
        public int fieldSizeY { get; }

        private bool _isWon { get; set; }

        public bool isWon
        {
            get
            {
                return _isWon;
            }
        }

        private short _numberOfMoves { get; set; } = 0;

        public short numberOfMoves
        {
            get
            {
                return _numberOfMoves;
            }
        }

        private char startChar { get; }
        private char stopChar { get; }
        private char playerChar { get; }

        private int playerCurrenX { get; set; }
        private int playerCurrenY { get; set; }

        public MoveStatusEnum lastMoveStatus { get; set; } = MoveStatusEnum.None;

        public Game(char[,] fields, int fieldSizeX, int fieldSizeY, char startChar, char stopChar, int playerCurrenX, int playerCurrenY, char playerChar)
        {
            field = fields;
            this.fieldSizeX = fieldSizeX;
            this.fieldSizeY = fieldSizeY;
            this.startChar = startChar;
            this.stopChar = stopChar;
            this.playerCurrenX = playerCurrenX;
            this.playerCurrenY = playerCurrenY;
            this.playerChar = playerChar;
        }

        public void Move(PossibleMovesEnum possibleMovesEnum)
        {
            lastMoveStatus = MoveStatusEnum.None;
            switch (possibleMovesEnum)
            {
                default:
                    return;

                case PossibleMovesEnum.Up:
                    MoveUp();
                    break;

                case PossibleMovesEnum.Down:
                    MoveDown();
                    break;

                case PossibleMovesEnum.Left:
                    MoveLeft();
                    break;

                case PossibleMovesEnum.Rigth:
                    MoveRight();
                    break;
            }
        }

        private void MovePlayerCharOnField()
        {
            if (field[playerCurrenX, playerCurrenY] != startChar)
                field[playerCurrenX, playerCurrenY] = playerChar;
            _numberOfMoves++;
        }

        private void RemovePlayerCharFromField()
        {
            if (field[playerCurrenX, playerCurrenY] != startChar)
                field[playerCurrenX, playerCurrenY] = '\0';
        }

        private void MoveRight()
        {
            if (playerCurrenY + 1 >= fieldSizeY)
            {
                lastMoveStatus = MoveStatusEnum.OutOfBounds;
                return;
            }

            if (field[playerCurrenX, playerCurrenY + 1] is not '\0')
            {
                if (field[playerCurrenX, playerCurrenY + 1] == stopChar)
                    _isWon = true;

                if (field[playerCurrenX, playerCurrenY + 1] != startChar)
                {
                    lastMoveStatus = MoveStatusEnum.Obstacle;
                    return;
                }
            }

            RemovePlayerCharFromField();
            playerCurrenY++;
            MovePlayerCharOnField();
        }

        private void MoveLeft()
        {
            if (playerCurrenY - 1 < 0)
            {
                lastMoveStatus = MoveStatusEnum.OutOfBounds;
                return;
            }

            if (field[playerCurrenX, playerCurrenY - 1] is not '\0')
            {
                if (field[playerCurrenX, playerCurrenY - 1] == stopChar)
                    _isWon = true;

                if (field[playerCurrenX, playerCurrenY - 1] != startChar)
                {
                    lastMoveStatus = MoveStatusEnum.Obstacle;
                    return;
                }
            }

            RemovePlayerCharFromField();
            playerCurrenY--;
            MovePlayerCharOnField();
        }

        private void MoveDown()
        {
            if (playerCurrenX + 1 >= fieldSizeX)
            {
                lastMoveStatus = MoveStatusEnum.OutOfBounds;
                return;
            }

            if (field[playerCurrenX + 1, playerCurrenY] is not '\0')
            {
                if (field[playerCurrenX + 1, playerCurrenY] == stopChar)
                    _isWon = true;

                if (field[playerCurrenX + 1, playerCurrenY] != startChar)
                {
                    lastMoveStatus = MoveStatusEnum.Obstacle;
                    return;
                }
            }

            RemovePlayerCharFromField();
            playerCurrenX++;

            MovePlayerCharOnField();
        }

        private void MoveUp()
        {
            if (playerCurrenX - 1 < 0)
            {
                lastMoveStatus = MoveStatusEnum.OutOfBounds;
                return;
            }

            if (field[playerCurrenX - 1, playerCurrenY] is not '\0')
            {
                if (field[playerCurrenX - 1, playerCurrenY] == stopChar)
                    _isWon = true;

                if (field[playerCurrenX - 1, playerCurrenY] != startChar)
                {
                    lastMoveStatus = MoveStatusEnum.Obstacle;
                    return;
                }
            }

            RemovePlayerCharFromField();
            playerCurrenX--;
            MovePlayerCharOnField();
        }
    }
}