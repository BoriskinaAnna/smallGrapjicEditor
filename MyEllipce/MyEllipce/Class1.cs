
using System.Drawing;



namespace MyEllipce
{
    public class MyEllipce : Shape.Shape, Shape.IResizable
    {
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



        public Shape.Shape Initialization(Point[] point, Pen pen)
        {
            Shape.Shape shape = new MyEllipce();

            shape.pen = pen;
            shape.point = point;
            if (point != null)
            {
                for (int i = 0; i < point.Length; i++)
                {
                    shape.center.X += point[i].X / point.Length;
                    shape.center.Y += point[i].Y / point.Length;
                }
                if (point.Length > 1)
                {
                   
                        if (point[0].X > point[1].X)
                            SwapCoordinates(point, 0);
                        if (point[0].Y > point[1].Y)
                            SwapCoordinates(point, 1);
                    
               
                }
                
            }
            return shape;
        }

        public override void Draw(Bitmap bitmap, Point[] points, bool isPainted)
        {
            base.Draw(bitmap, points, false);
            Rectangle rectangle = new Rectangle(points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
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
        /*  public override void MoveHorizontal(ref Point[] point, int offset, ref Point centre)
          {

              base.MoveHorizontal(ref point, offset, ref centre);

          }*/
        public override void MoveHorizontal(Shape.Shape shape, int offset)
        {

            //return 
            base.MoveHorizontal(shape, offset);

        }
        public override void MoveVertical(Shape.Shape shape, int offset)
        {
            base.MoveVertical(shape, offset);

        }
    }
}
