namespace Snake{

    public class Food{

        public Food(){

        }
        private readonly Random random = new Random();
        public Value[,] AddFood(List<Position> positions, Value[,] grid){
            if(positions.Count==0)
                return null;
            else{
                Position spawn = positions[random.Next(positions.Count)];
                grid[spawn.Row, spawn.Col] = Value.Food;
                return grid;
            }
        }
    }
}