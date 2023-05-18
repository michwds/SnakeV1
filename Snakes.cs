namespace Snake{
    

        public class Snakes{

            private Value[,] Grid;
            public Snakes(Value[,] grid){
                Grid = grid;

            }
            public LinkedList<Position> AddSnake(int cols, LinkedList<Position> pos){
                int p1 = cols/2;

                for(int r=0; r<2; r++){
                    Grid[r,p1] = Value.P1Snake;
                    pos.AddFirst(new Position(r, p1));
                }
            return pos;
            }
            public List<LinkedList<Position>> AddSnakes(int cols, LinkedList<Position> pos1, LinkedList<Position> pos2, int numPlayers){
                int p1 = cols/3;
                int p2 = p1*2;
                for(int r=0; r<2; r++){
                    Grid[r,p1] = Value.P1Snake;
                    Grid[r,p2] = Value.P2Snake;
                    pos1.AddFirst(new Position(r, p1));
                    pos2.AddFirst(new Position(r, p2));
                }
            return new List<LinkedList<Position>>{pos1, pos2};
            }

        }

    }
