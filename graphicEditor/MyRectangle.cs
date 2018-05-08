using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicEditor
{
    class MyRectangle : Shape, IResizable
    {
        public MyRectangle(Pen pen)
        {
            this.pen = pen;
        }

        public MyRectangle(Point[] point, Color color, float width)
        {
            this.pen.Color = color;
            this.pen.Width = width;
            this.point = point;
            for (int i = 0; i < point.Length; i++)
            {
                center.X += point[i].X / point.Length;
                center.Y += point[i].Y / point.Length;
            }
           // this.center = centre;
        }

        public static Point[] SwapCoordinates( Point[] points, byte coordinate )//0- X; 1-Y
        {
            if (coordinate == 0)
            {
                 int temp;
                    temp = points[0].X;
                    points[0].X = points[1].X;
                    points[1].X = temp;
            
            }
            else
            {
              
                    int temp;
                    temp = points[0].Y;
                    points[0].Y = points[1].Y;
                    points[1].Y = temp;
              
            }
           
            return points;

        }


        public static void ChangeCoordinate(ref bool changedX, ref bool changedY, ref Point[] points)
        {
            if (points[0].Y > points[1].Y)
            {
                changedY = true;
                points = SwapCoordinates( points, 1);
            }
            if (points[0].X > points[1].X)
            {
                changedX = true;
                points = SwapCoordinates( points, 0);
            }
        }

        public override void Draw(Bitmap bitmap, Point[] points, bool isPainted)
        {
            base.Draw(bitmap, points, false);
            Boolean changedX = false, changedY = false;

            ChangeCoordinate(ref changedX, ref changedY, ref points);
        
            Rectangle rectangle = new Rectangle(points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
            g.DrawRectangle(pen, rectangle);
     
            if (!isPainted)
            {
                if (changedX)
                {
                    points = SwapCoordinates(points, 0);
                }
                if (changedY)
                {
                    points = SwapCoordinates(points, 1);
                }
            }
          
        }
        public override void ResizableHorizontal(Shape shape, int newX)
        {
            base.ResizableHorizontal(shape, newX);
        }
        public override void ResizableVertical(Shape shape, int newY)
        {
            base.ResizableVertical(shape, newY);
        }
        public override void ChangeColor(Color color)
        {
            base.ChangeColor(color);

        }
        public override void ChangePenWidth(float penWidth)
        {
            base.ChangePenWidth(penWidth);
        }
        /*  public override void MoveHorizontal(ref Point[] point, int offset, ref Point centre)
          {

              base.MoveHorizontal(ref point, offset, ref centre);
          }*/
        public override void MoveHorizontal( Shape shape, int offset)
        {

            base.MoveHorizontal( shape, offset);
            //return shape;
        }
        public override void MoveVertical(Shape shape, int offset)
        {
            base.MoveVertical(shape, offset);
        }


    }
}
