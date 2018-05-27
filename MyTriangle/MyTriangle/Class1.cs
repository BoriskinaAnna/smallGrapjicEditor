using System;
using System.Drawing;
using Shape;

namespace MyTriangle
{
    public class MyTriangle : Shape.Shape, Shape.IResizable
    {
        public MyTriangle()
        {

        }
        public Shape.Shape Initialization(Point[] point, Pen pen)
        {
            Shape.Shape shape = new MyTriangle();
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



        public MyTriangle(Point[] point, Color color, float width)
        {
            this.pen.Color = color;
            this.pen.Width = width;
            this.point = point;
            for (int i = 0; i < point.Length; i++)
            {
                center.X += point[i].X / point.Length;
                center.Y += point[i].Y / point.Length;
            }
        }

        public override void Draw(Bitmap bitmap, Point[] point, bool isPainted)
        {
            base.Draw(bitmap, point, false);
            g.DrawPolygon(pen, point);
        }


        private int getIndexMaxPoint(int point0, int point1, int point2)
        {
            int max;
            if (point0 > point1 && point0 > point2)
            {
                max = 0;
            }
            else
            {
                if (point1 > point0 && point1 > point2)
                {
                    max = 1;
                }
                else
                {
                    max = 2;
                }
            }
            return max;

        }

        private int getIndexMinPoint(int point0, int point1, int point2)
        {
            int min;
            if (point0 < point1 && point0 < point2)
            {
                min = 0;
            }
            else
            {
                if (point1 < point0 && point1 < point2)
                {
                    min = 1;
                }
                else
                {
                    min = 2;
                }
            }
            return min;

        }






        public override void ResizableHorizontal(Shape.Shape shape, int newX)
        {


            if (newX > Math.Max(shape.point[0].X, Math.Max(shape.point[1].X, shape.point[2].X)) - 15)
                shape.point[getIndexMaxPoint(shape.point[0].X, shape.point[1].X, shape.point[2].X)].X = newX;
            else
                shape.point[getIndexMinPoint(shape.point[0].X, shape.point[1].X, shape.point[2].X)].X = newX;
            shape.center.X = 0;
            for (int i = 0; i < 3; i++)
            {
                shape.center.X += shape.point[i].X / shape.point.Length;
            }

        }
        public override void ResizableVertical(Shape.Shape shape, int newY)
        {
            if (newY > Math.Max(shape.point[0].Y, Math.Max(shape.point[1].Y, shape.point[2].Y)) - 15)
                shape.point[getIndexMaxPoint(shape.point[0].Y, shape.point[1].Y, shape.point[2].Y)].Y = newY;
            else
                shape.point[getIndexMinPoint(shape.point[0].Y, shape.point[1].Y, shape.point[2].Y)].Y = newY;
            shape.center.Y = 0;
            for (int i = 0; i < 3; i++)
            {
                shape.center.Y += shape.point[i].Y / shape.point.Length;
            }
        }
        public override void ChangeColor(Color color)
        {
            pen.Color = color;

        }
        public override void ChangePenWidth(float penWidth)
        {
            pen.Width = penWidth;
        }
        public override void MoveHorizontal(Shape.Shape shape, int offset)
        {
            shape.center.X = 0;
            for (int i = 0; i < shape.point.Length; i++)
            {
                shape.point[i].X -= offset;
                shape.center.X += shape.point[i].X / shape.point.Length;
                //   centre.Y += point[i].Y / point.Length;
            }
            // return shape;

        }
        public override void MoveVertical(Shape.Shape shape, int offset)
        {
            shape.center.Y = 0;
            for (int i = 0; i < shape.point.Length; i++)
            {
                shape.point[i].Y -= offset;
                //   centre.X += point[i].X / point.Length;
                shape.center.Y += shape.point[i].Y / shape.point.Length;
            }
        }
    }
}
