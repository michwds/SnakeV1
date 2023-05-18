namespace Snake{

    public class Food{

        public Food(){

        }
        private readonly Random random = new Random();
        public int AddFood(List<Position> positions, Value[,] grid){
            if(positions.Count==0)
                return 0;
            else{
                Position spawn = positions[random.Next(positions.Count)];
                grid[spawn.Row, spawn.Col] = Value.Food;
                return 1;
            }
        }
    }
}