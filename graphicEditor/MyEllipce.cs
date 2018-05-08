using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicEditor
{
    class MyEllipce : Shape, IResizable
    {
        public MyEllipce()
        {

        }

        

        public MyEllipce(Point[] point, Color color, float width)
        {
            this.pen.Color = color;
            this.pen.Width = width;
            this.point = point;
            for (int i = 0; i < point.Length; i++)
            {
                center.X += point[i].X / point.Length;
                center.Y += point[i].Y / point.Length;
            }
            if(point[0].X > point[1].X)
                MyRectangle.SwapCoordinates(point, 0);
            if (point[0].Y > point[1].Y)
                MyRectangle.SwapCoordinates(point, 1);
        }

        public override void Draw(Bitmap bitmap, Point[] points, bool isPainted)
        {
            base.Draw(bitmap, points, false);
            Rectangle rectangle = new Rectangle(points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
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
        /*  public override void MoveHorizontal(ref Point[] point, int offset, ref Point centre)
          {

              base.MoveHorizontal(ref point, offset, ref centre);

          }*/
        public override void MoveHorizontal( Shape shape, int offset)
        {

            //return 
            base.MoveHorizontal( shape, offset);
            
        }
        public override void MoveVertical(Shape shape, int offset)
        {
            base.MoveVertical(shape, offset);
          
        }
    }
}
