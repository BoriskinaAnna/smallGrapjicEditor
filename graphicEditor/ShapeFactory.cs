using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphicEditor
{
    public abstract class ShapeFactory
    {
        public abstract Shape CreateNewShape();
    }

    public class EllipceFactory : ShapeFactory
    {
        public override Shape CreateNewShape()
        {
            return new MyEllipce();
        }
    }
    public class RectangleFactory : ShapeFactory
    {
        public override Shape CreateNewShape()
        {
            return new MyRectangle(Lab1.pen);
        }
    }
    public class SquareFactory : ShapeFactory
    {
        public override Shape CreateNewShape()
        {
            return new MySquare();
        }
    }
    public class CircleFactory : ShapeFactory
    {
        public override Shape CreateNewShape()
        {
            return new MyCircle();
        }
    }
    public class TriangleFactory : ShapeFactory
    {
        public override Shape CreateNewShape()
        {
            return new MyTriangle();
        }
    }

    public class LineFactory : ShapeFactory
    {
        public override Shape CreateNewShape()
        {
            return new MyLine();
        }
    }




}
