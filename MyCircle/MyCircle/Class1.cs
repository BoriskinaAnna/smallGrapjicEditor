using System;

using System.Drawing;
using Shape;


namespace MyCircle
{
    public class MyCircle : Shape.Shape, IResizable
    {

        public Shape.Shape Initialization(Point[] point, Pen pen)
        {
            Shape.Shape shape = new MyCircle();
            shape.pen = pen;
            shape.point = point;
            if (point != null)
                for (int i = 0; i < point.Length; i++)
                {
                    shape.center.X += point[i].X / point.Length;
                    shape.center.Y += point[i].Y / point.Length;
                }
            return shape;
        }

        private Point[] SwapCoordinates(Point[] points, byte coordinate)//0- X; 1-Y
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


        private void ChangeCoordinate(ref bool changedX, ref bool changedY, ref Point[] points)
        {
            if (points[0].Y > points[1].Y)
            {
                changedY = true;
                points = SwapCoordinates(points, 1);
            }
            if (points[0].X > points[1].X)
            {
                changedX = true;
                points = SwapCoordinates(points, 0);
            }
        }


        private Rectangle SearchRectAngleCoordinats(int height, bool changedX, bool changedY, Point[] points)
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




        public override void Draw(Bitmap bitmap, Point[] point, bool isPainted)
        {
            base.Draw(bitmap, point, false);
            Boolean changedX = false, changedY = false;
       
            ChangeCoordinate(ref changedX, ref changedY, ref point);
         
            int height = Math.Min(point[1].X - point[0].X, point[1].Y - point[0].Y);


            if (changedX)
            {
                point = SwapCoordinates(point, 0);
            }
            if (changedY)
            {
                point = SwapCoordinates(point, 1);
            }


            Rectangle rectangle = SearchRectAngleCoordinats(height, changedX, changedY, point);
            if (isPainted)
            {
                point[0].X = rectangle.X;
                point[0].Y = rectangle.Y;
                point[1].X = point[0].X + height;
                point[1].Y = point[0].Y + height;
            }
            g.DrawEllipse(pen, rectangle);
        }

        public override void ResizableHorizontal(Shape.Shape shape, int newX)
        {
            base.ResizableHorizontal(shape, newX);
        }
        public override void ResizableVertical(Shape.Shape shape, int newY)
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
        /* public override void MoveHorizontal(ref Point[] point, int offset, ref Point centre)
         {

             base.MoveHorizontal(ref point, offset, ref centre);
         }*/
        public override void MoveHorizontal(Shape.Shape shape, int offset)
        {

            base.MoveHorizontal(shape, offset);
            // return shape;
        }
        public override void MoveVertical(Shape.Shape shape, int offset)
        {
            base.MoveVertical(shape, offset);
        }
    }
}
