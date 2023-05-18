namespace Snake
{
    public enum Value
    {
        Empty,
        Snake,
        Food,
        OOB
    }

    public class Direction
    {
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);

        public int RowOffset { get; }
        public int ColOffset { get; }

        private Direction(int rowOffset, int colOffset)
        {
            RowOffset = rowOffset;
            ColOffset = colOffset;
        }
        public Direction Opposite()
        {
            return new Direction(-RowOffset, -ColOffset);
        }

        public override bool Equals(object? obj)
        {
            return obj is Direction direction &&
                   RowOffset == direction.RowOffset &&
                   ColOffset == direction.ColOffset;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RowOffset, ColOffset);
        }
        public static bool operator ==(Direction left, Direction right)
        {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }
        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }
    }

    public class Position
    {
        public int Row { get; }
        public int Col { get; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public Position Translate(Direction dir)
        {
            return new Position(Row + dir.RowOffset, Col + dir.ColOffset);
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Col == position.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }
        public static bool operator ==(Position left, Position right){
            return EqualityComparer<Position>.Default.Equals(left, right);
        }
                public static bool operator !=(Position left, Position right){
            return !(left==right);
        }
    }

}
