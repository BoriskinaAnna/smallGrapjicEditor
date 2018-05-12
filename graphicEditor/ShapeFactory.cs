using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicEditor
{
    public abstract class ShapeFactory
    {
        public abstract Shape.Shape CreateNewShape();
    }

    public class EllipceFactory : ShapeFactory
    {
        public override Shape.Shape CreateNewShape()
        {
            return Lab1.myEllipce.Initialization(null, new Pen(Color.Black));
        }
    }
    public class RectangleFactory : ShapeFactory
    {
        public override Shape.Shape CreateNewShape()
        {
            return Lab1.myRectangle.Initialization(null, new Pen(Color.Black));
        }
    }
    public class SquareFactory : ShapeFactory
    {
        public override Shape.Shape CreateNewShape()
        {
            return Lab1.mySquare.Initialization(null, new Pen(Color.Black));
        }
    }
    public class CircleFactory : ShapeFactory
    {
        public override Shape.Shape CreateNewShape()
        {
            return Lab1.myCircle.Initialization(null, new Pen(Color.Black));
        }
    }
    public class TriangleFactory : ShapeFactory
    {
        public override Shape.Shape CreateNewShape()
        {
            return Lab1.myTriangle.Initialization(null, new Pen(Color.Black));
        }
    }

    public class LineFactory : ShapeFactory
    {
        public override Shape.Shape CreateNewShape()
        {
            return Lab1.myLine.Initialization(null, new Pen(Color.Black));
        }
    }




}
