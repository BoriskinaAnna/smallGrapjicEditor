using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicEditor
{
    class MyCircle : Shape, IResizable
    {

        public MyCircle()
        {

        }
        public MyCircle(Point[] point, Color color, float width)
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
            Boolean changedX = false, changedY = false;
            //  MyRectangle myRectangle = new MyRectangle(pen);
            MyRectangle.ChangeCoordinate(ref changedX, ref changedY, ref point);
           // MyRectangle.SwapCoordinates
            MySquare mySquare = new MySquare();
            int height = Math.Min(point[1].X - point[0].X, point[1].Y - point[0].Y);


            if (changedX)
            {
                point = MyRectangle.SwapCoordinates(point, 0);
            }
            if (changedY)
            {
                point = MyRectangle.SwapCoordinates(point, 1);
            }

      
            Rectangle rectangle = mySquare.SearchRectAngleCoordinats(height, changedX, changedY, point);
            if (isPainted)
            {
                point[0].X = rectangle.X;
                point[0].Y = rectangle.Y;
                point[1].X = point[0].X + height;
                point[1].Y = point[0].Y + height;
            }
            g.DrawEllipse(pen, rectangle);
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
        /* public override void MoveHorizontal(ref Point[] point, int offset, ref Point centre)
         {

             base.MoveHorizontal(ref point, offset, ref centre);
         }*/
        public override void MoveHorizontal( Shape shape, int offset)
        {

            base.MoveHorizontal( shape, offset);
           // return shape;
        }
        public override void MoveVertical(Shape shape, int offset)
        {
            base.MoveVertical(shape, offset);
        }
    }
}
