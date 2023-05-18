using System.Collections.Generic;

namespace Snake
{
    public class Gamestate
    {
        public int Rows { get; }
        public int Cols { get; }
        public Value[,] Grid { get; }
        public Direction P1Dir { get; private set; }
        public Direction P2Dir { get; private set; }
        private List<PlayerObject> players = new List<PlayerObject>();
        private Food Food;

        private readonly Random random = new Random();

        public Gamestate(int rows, int cols, Food food, int numPlayers)
        {
            Rows = rows;
            Cols = cols;
            Food = food;
            Grid = new Value[rows, cols];
            P1Dir = Direction.Down;
            P2Dir = Direction.Down;
            for (int i = 0; i < numPlayers; i++)
            {
                players[i] = new PlayerObject(Grid, (i + 1) * Cols / (numPlayers + 1));
            }
            Food.AddFood(GetEmptyPositions(), Grid);
        }


        public List<Position> GetEmptyPositions()
        {
            List<Position> output = new List<Position>();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c] == Value.Empty)
                        output.Add(new Position(r, c));
                }
            }
            return output;
        }

        private bool CheckOOB(Position pos)
        {
            return pos.Row < 0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Cols;
        }
        private Value CheckCollision(Position pos, PlayerObject snake)
        {
            if (pos == snake.getTail())
                return Value.Empty;
            return Grid[pos.Row, pos.Col];
        }

        public void Move(PlayerObject snake)
        {
            Position next = snake.getHead().Translate(snake.Dir);
            Value hit = Value.Empty;
            if (CheckOOB(next)){
                hit = Value.OOB;
                snake.isAlive = false;
            }
            else
            {
                foreach (var item in players)
                {
                    hit = CheckCollision(next, item);
                    if (hit == Value.Snake)
                        snake.isAlive = false;
                }
            }
            if(hit == Value.Empty){
                snake.RemoveTail(Grid);
                snake.AddHead(next, Grid);
            }
            else if(hit == Value.Food){
                snake.AddHead(next, Grid);
                snake.Score++;
                Food.AddFood(GetEmptyPositions(), Grid);
            }
        }
    }
}