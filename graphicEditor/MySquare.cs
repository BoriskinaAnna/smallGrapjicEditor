using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicEditor
{
    class MySquare : Shape, IResizable
    {

        public MySquare()
        {

        }

        public MySquare(Point[] point, Color color, float width)
        {
            this.pen.Color = color;
            this.pen.Width = width;
            this.point = point;
            for (int i = 0; i < 2; i++)
            {
                center.X += point[i].X /2;
                center.Y += point[i].Y / 2;
            }
        }

        public Rectangle SearchRectAngleCoordinats( int height, bool changedX, bool changedY, Point[] points)
        {

            Rectangle rectangle;
            if (changedX && changedY)
            {
                rectangle = new Rectangle(points[0].X - height, points[0].Y - height, height, height);
            }
            else
            {
                if (changedX)
                {
                    rectangle = new Rectangle(points[0].X - height, points[0].Y, height, height);
                }
                else
                {
                    if (changedY)
                    {

                        rectangle = new Rectangle(points[0].X, points[0].Y - height, height, height);
                    }
                    else
                    {
                        rectangle = new Rectangle(points[0].X, points[0].Y, height, height);
                    }
                }
            }
            return rectangle;

        }



        public override void Draw(Bitmap bitmap, Point[] points, bool isPainted)
        {
            base.Draw(bitmap, points, false);

          //  MyRectangle myRectangle = new MyRectangle(pen);
            Boolean changedX = false, changedY = false;
            MyRectangle.ChangeCoordinate(ref changedX, ref changedY, ref points);

            int height;

            height = Math.Min(points[1].X - points[0].X, points[1].Y - points[0].Y);


            if (changedX)
            {
                MyRectangle.SwapCoordinates(points, 0);
            }
            if (changedY)
            {
                MyRectangle.SwapCoordinates(points, 1);
            }
            Rectangle rectangle = SearchRectAngleCoordinats(height, changedX, changedY, points);

            if (isPainted)
            {
                point[0].X = rectangle.X;
                point[0].Y = rectangle.Y;
                point[1].X = point[0].X + height;
                point[1].Y = point[0].Y + height;
            }


            g.DrawRectangle(pen, rectangle);

           
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
          //  return shape;
        }
        public override void MoveVertical(Shape shape, int offset)
        {
            base.MoveVertical(shape, offset);
        }
    }
}
