using SplashKitSDK;

namespace CustomProgram
{
    public class Cell //generate cell to plant plants
    {
        private Point2D _point;
        private bool _placed;
        public Cell(Point2D point)
        {
            _point = point;
            _placed = false;
        }

        public Point2D Point
        {
            get
            {
                return _point;
            }
        }

        public bool isPlaced //has plant placed on it or not
        {
            get
            {
                return _placed;
            }
            set
            {
                _placed = value;
            }
        }

    }
}
