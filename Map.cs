using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram
{
    public class Map : GameObject
    {
        private List<Cell> _cells; 
        private Font _font;
        private Sprite _sunSprite;
        public Map() : base("Map", "map2_resized1.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 0);
            SplashKit.SpriteSetY(this.Sprite, 0);
            _cells = new List<Cell>();
            _font = SplashKit.LoadFont("CASCADEMONO", "CASCADEMONO.TTF");
            _sunSprite = SplashKit.CreateSprite(new Bitmap("Sun", "Sun_1.png"));
            SplashKit.SpriteSetX(_sunSprite, 300);
            SplashKit.SpriteSetY(_sunSprite, 60);
        }

        public void DrawPlayerSun(int sun)
        {
            SplashKit.DrawText(string.Format("{0}",sun) , Color.Black, _font,100,320,80);
        }

        public void DrawRemainingZombies(int zombsleft)
        {
            SplashKit.DrawText(string.Format("Remaining zombies: {0}", zombsleft), Color.Black, _font, 100, 950, 30);
        }

        public void GenerateCell() //generate cell for map
        {
            int initialcellX = 445;
            int initialcellY = 145;
            int cellWidth = 90;
            int cellHeight = 110;
            for (int x=0; x<5; x++)
            {
                for (int y=0; y<10; y++)
                {
                    Point2D point = new Point2D();
                    point.X = initialcellX + cellWidth * y;
                    point.Y = initialcellY + cellHeight * x;
                    Cell cell = new Cell(point);
                    _cells.Add(cell);
                }
            }
        }
        public Cell LocateCellByMousePostion(Point2D pt) //check when mouse location in a nearest cell
        {
            float minDistance = SplashKit.PointPointDistance(_cells[0].Point, pt);
            Cell cellOfMouse = _cells[0];
            foreach (Cell cell in _cells)
            {
                float distance = SplashKit.PointPointDistance(cell.Point, pt);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    cellOfMouse = cell;
                }
            }
            return cellOfMouse;
        }

    }
}
