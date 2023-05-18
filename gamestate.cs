using System.Collections.Generic;

namespace Snake{
    public class Gamestate
    {
        public int Rows {get;}
        public int Cols {get;} 
        public Value[,] Grid {get;}
        public Direction P1Dir {get; private set;}
        public Direction P2Dir {get; private set;}
        public int Score1 {get; private set;}
        public int Score2{get; private set;}

        private readonly LinkedList<Position> p1Positions;
        private readonly LinkedList<Position> p2Positions;
        private readonly Random random = new Random();

        public Gamestate (int rows, int cols, Food food, Snakes snakes, int numPlayers){
            Rows=rows;
            Cols=cols;
            Grid = new Value[rows, cols];
            P1Dir = Direction.Down;
            P2Dir = Direction.Down;
            p1Positions = new LinkedList<Position>();
            if(numPlayers==1){
                p1Positions = snakes.AddSnake(Cols, p1Positions);
            }
            else if(numPlayers==2){
                p2Positions = new LinkedList<Position>();
                List<LinkedList<Position>> start = new List<LinkedList<Position>>();
                start = snakes.AddSnakes(Cols, p1Positions, p2Positions, 2);
                p1Positions = start[0];
                p2Positions = start[1];
            }

            food.AddFood(GetEmptyPositions(), Grid);
        }


        public List<Position> GetEmptyPositions(){
            List<Position> output = new List<Position>();
            for(int r=0; r<Rows; r++){
                for(int c=0; c<Cols; c++){
                    if(Grid[r,c]==Value.Empty)
                        output.Add(new Position(r,c));
                }
            }
            return output;
        }
        //List<Position> empty = new List<Position>(Gamestate.GetEmptyPositions());
    }
}