using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class Map : GameObject
    {
        private List<CentrePoint> _centrePoints; //Centre point of each cell (grid) 
        private Font _font;
        private Bitmap _sunBitmap;
        private Sprite _sunSprite;
        public Map() : base("Map", "map1.jpg")
        {
            SplashKit.SpriteSetX(this.Sprite, 0);
            SplashKit.SpriteSetY(this.Sprite, 0);
            _centrePoints = new List<CentrePoint>();
            _font = SplashKit.LoadFont("CONSOLA", "CONSOLA.TTF");
            _sunBitmap = new Bitmap("Sun Bitmap", "Sun_1.png");
            _sunSprite = SplashKit.CreateSprite(_sunBitmap);
            SplashKit.SpriteSetX(_sunSprite, 400);
            SplashKit.SpriteSetY(_sunSprite, 15);
        }

        //Testing purpose
        public void DrawSunPoint(int sunPoints)
        {
            SplashKit.DrawText(string.Format("{0}",sunPoints) , Color.BlanchedAlmond, _font,30,460,30);
        }

        public void DrawRemainingZombies(int remainingZombies)
        {
            SplashKit.DrawText(string.Format("{0}", remainingZombies), Color.BlanchedAlmond, _font, 30, 1100, 30);
        }

        public void AddCentrePoint()
        {
            int initialCentrePointX = 445;
            int initialCentrePointY = 145;
            int cellWidth = 88;
            int cellHeight = 110;
            for (int x=0; x<5; x++)
            {
                for (int y=0; y<9; y++)
                {
                    if (x >=3)
                    {
                        Point2D point1 = new Point2D();
                        point1.X = initialCentrePointX + cellWidth * y;
                        point1.Y = initialCentrePointY + (cellHeight-3) * x;
                        CentrePoint newCentrePoint1 = new CentrePoint(point1);
                        _centrePoints.Add(newCentrePoint1);
                        continue;
                    }
                    Point2D point = new Point2D();
                    point.X = initialCentrePointX + cellWidth * y;
                    point.Y = initialCentrePointY + cellHeight * x;
                    CentrePoint newCentrePoint = new CentrePoint(point);
                    _centrePoints.Add(newCentrePoint);
                }
            }
        }

        //This function finds the nearest centre point to each user's mouse click
        public CentrePoint FindNearestCentre(Point2D pt)
        {
            float minDistance = SplashKit.PointPointDistance(_centrePoints[0].Point, pt);
            CentrePoint nearestCentrePoint = _centrePoints[0];
            foreach (CentrePoint centrePoint in _centrePoints)
            {
                float distance = SplashKit.PointPointDistance(centrePoint.Point, pt);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestCentrePoint = centrePoint;
                }
            }
            return nearestCentrePoint;
        }

        public List<CentrePoint> CentrePoints
        {
            get
            {
                return _centrePoints;
            }
        }

    }
}
