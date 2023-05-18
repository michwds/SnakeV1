namespace Snake
{


    public class PlayerObject
    {

        private readonly LinkedList<Position> pos = new LinkedList<Position>();
        public Direction Dir {get; private set;}
        public PlayerObject(Value[,] grid, int col)
        {

            for (int r = 0; r < 2; r++)
            {
                grid[r, col] = Value.Snake;
                pos.AddFirst(new Position(r, col));
            }  
            Dir = Direction.Down;

        }
        public Position getHead(){
            return pos.First.Value;
        }
        public Position getTail(){
            return pos.Last.Value;
        }
        public IEnumerable<Position> getAllPositions(){
            return pos;
        }
        public void AddHead(Position p, Value[,] grid){
            pos.AddFirst(p);
            grid[p.Row, p.Col] = Value.Snake;
        }
        public void RemoveTail(Value[,] grid){
            Position p = pos.Last.Value;
            grid[p.Row, p.Col] = Value.Empty;
            pos.RemoveLast();
        }
        public void ChangeDirection(Direction d){
            Dir = d;
        }

    }
}
