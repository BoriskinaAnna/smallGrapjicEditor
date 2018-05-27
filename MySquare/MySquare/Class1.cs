using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Shape;

namespace MySquare
{
    public class MySquare : Shape.Shape, IResizable
    {

        public MySquare()
        {

        }

        public Shape.Shape Initialization(Point[] point, Pen pen)
        {
            Shape.Shape shape = new MySquare();
            shape.pen = pen;
            shape.point = point;
            if (point != null && point.Length > 1)
                for (int i = 0; i < 2; i++)
                {
                    shape.center.X += point[i].X / 2;
                    shape.center.Y += point[i].Y / 2;
                }
            return shape;
        }

        public MySquare(Point[] point, Color color, float width)
        {
            this.pen.Color = color;
            this.pen.Width = width;
            this.point = point;
            for (int i = 0; i < 2; i++)
            {
                center.X += point[i].X / 2;
                center.Y += point[i].Y / 2;
            }
        }

        public Rectangle SearchRectAngleCoordinats(int height, bool changedX, bool changedY, Point[] points)
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



        private static Point[] SwapCoordinates(Point[] points, byte coordinate)//0- X; 1-Y
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


        private static void ChangeCoordinate(ref bool changedX, ref bool changedY, ref Point[] points)
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



        public override void Draw(Bitmap bitmap, Point[] points, bool isPainted)
        {
            base.Draw(bitmap, points, false);

            //  MyRectangle myRectangle = new MyRectangle(pen);
            Boolean changedX = false, changedY = false;
            ChangeCoordinate(ref changedX, ref changedY, ref points);

            int height;

            height = Math.Min(points[1].X - points[0].X, points[1].Y - points[0].Y);


            if (changedX)
            {
                SwapCoordinates(points, 0);
            }
            if (changedY)
            {
                SwapCoordinates(points, 1);
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
    
        public override void MoveHorizontal(Shape.Shape shape, int offset)
        {

            base.MoveHorizontal(shape, offset);
        
        }
        public override void MoveVertical(Shape.Shape shape, int offset)
        {
            base.MoveVertical(shape, offset);
        }
    }
}
