namespace MarsRover
{
    public class Plateau
    {
        public static int LowerLeftX { get; } = 0;
        public static int LowerLeftY { get; } = 0;

        private int _upperRightX;
        private int _upperRightY;

        public Plateau(int upperRightX, int upperRightY)
        {
            _upperRightX = upperRightX;
            _upperRightY = upperRightY;
        }

        public int UpperRightX
        {
            get => _upperRightX;
            set => _upperRightX = value;
        }

        public int UpperRightY
        {
            get => _upperRightY;
            set => _upperRightY = value;
        }
    }
}