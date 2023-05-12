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

        private readonly LinkedList<Position> p1Positions = new LinkedList<Position>();
        private readonly LinkedList<Position> p2Positions = new LinkedList<Position>();
        private readonly Random random = new Random();

        public Gamestate (int rows, int cols){
            Rows=rows;
            Cols=cols;
            Grid = new Value[rows, cols];
            P1Dir = Direction.Down;
            P2Dir = Direction.Down;
            AddSnakes();
        }

        private void AddSnakes(){
            int p1 = Cols/3;
            int p2 = 2*Cols/3;

            for(int r=0; r<2; r++){
                Grid[r,p1] = Value.P1Snake;
                Grid[r,p2] = Value.P2Snake;
                p1Positions.AddFirst(new Position(r, p1));
                p2Positions.AddFirst(new Position(r, p2));
            }
            
        }
    }
}