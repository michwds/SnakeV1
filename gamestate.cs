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
        private List<PlayerObject> players = new List<PlayerObject>();

        private readonly Random random = new Random();

        public Gamestate (int rows, int cols, Food food, int numPlayers){
            Rows=rows;
            Cols=cols;
            Grid = new Value[rows, cols];
            P1Dir = Direction.Down;
            P2Dir = Direction.Down;
            for(int i=0; i<numPlayers; i++){
                players[i] = new PlayerObject(Grid, (i+1)*Cols/(numPlayers+1));
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