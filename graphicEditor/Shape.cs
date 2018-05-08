using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace graphicEditor
{
    public abstract class Shape
    {
        public static Graphics g;

        public Pen pen = new Pen(Color.Black);
        public Point[] point;

        public Point center;

        public virtual void Draw(Bitmap bitmap, Point[] points, bool isPainted)
        {
            g = Graphics.FromImage(bitmap);
        }

       

        public virtual void ResizableHorizontal(Shape shape, int newX)
        {
            if (newX > shape.point[0].X + 15)
                shape.point[1].X = newX;
            else
                shape.point[0].X = newX;
            shape.center.X = 0;
            for (int i = 0; i < shape.point.Length; i++)
            {
                shape.center.X += shape.point[i].X / shape.point.Length;
            }
        }
        public virtual void ResizableVertical(Shape shape, int newY)
        {
            if (newY > shape.point[0].Y + 15)
                shape.point[1].Y = newY;
            else
                shape.point[0].Y = newY;
            shape.center.Y = 0;
            for (int i = 0; i < shape.point.Length; i++)
            {
                shape.center.Y += shape.point[i].Y / shape.point.Length;
            }
        }
        public virtual void ChangeColor(Color color)
        {
            pen.Color = color;
        }
        public virtual void ChangePenWidth(float penWidth)
        {
            pen.Width = penWidth;
        }
        public virtual void MoveHorizontal(Shape shape, int offset)
        {
            
            shape.center.X = 0;
            for (int i = 0; i < shape.point.Length; i++)
            {
                shape.point[i].X -= offset;
                shape.center.X += shape.point[i].X / shape.point.Length;
            }
            //return shape;
        }
        public virtual void MoveVertical(Shape shape, int offset)
        {
            shape.center.Y = 0;
            for (int i = 0; i < shape.point.Length; i++)
            {
                shape.point[i].Y -= offset;
                shape.center.Y += shape.point[i].Y / shape.point.Length;
            }
        }


    }
}
