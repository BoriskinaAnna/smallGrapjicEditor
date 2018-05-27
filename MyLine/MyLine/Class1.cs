using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyLine
{
    public class MyLine : Shape.Shape, Shape.IResizable
    {
        //  public static MyLine instance;
        public MyLine()
        {

        }

        public Shape.Shape Initialization(Point[] point, Pen pen)
        {
            Shape.Shape shape = new MyLine();
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

        public MyLine(Point[] point, Color color, float width)
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





        public override void Draw(Bitmap bitmap, Point[] points, bool isPainted)
        {
            base.Draw(bitmap, points, false);
            g.DrawLine(pen, points[0].X, points[0].Y, points[1].X, points[1].Y);
        }



        private int getIndexMaxPoint(int point0, int point1)
        {
            int max;
            if (point0 > point1)
            {
                max = 0;
            }
            else
            {
                max = 1;
            }

            return max;

        }

        private int getIndexMinPoint(int point0, int point1)
        {
            int min;
            if (point0 < point1)
            {
                min = 0;
            }
            else
            {
                min = 1;
            }
            return min;

        }











        public override void ResizableHorizontal(Shape.Shape shape, int newX)
        {


            if (newX > Math.Max(shape.point[0].X, shape.point[1].X) - 15)
                shape.point[getIndexMaxPoint(shape.point[0].X, shape.point[1].X)].X = newX;
            else
                shape.point[getIndexMinPoint(shape.point[0].X, shape.point[1].X)].X = newX;
            shape.center.X = 0;
            for (int i = 0; i < 2; i++)
            {
                shape.center.X += shape.point[i].X / shape.point.Length;
            }

        }
        public override void ResizableVertical(Shape.Shape shape, int newY)
        {
            if (newY > Math.Max(shape.point[0].Y, shape.point[1].Y) - 15)
                shape.point[getIndexMaxPoint(shape.point[0].Y, shape.point[1].Y)].Y = newY;
            else
                shape.point[getIndexMinPoint(shape.point[0].Y, shape.point[1].Y)].Y = newY;
            shape.center.Y = 0;
            for (int i = 0; i < 2; i++)
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
            for (int i = 0; i < 2; i++)
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
            for (int i = 0; i < 2; i++)
            {
                shape.point[i].Y -= offset;
                //   centre.X += point[i].X / point.Length;
                shape.center.Y += shape.point[i].Y / shape.point.Length;
            }
        }
    }
}
