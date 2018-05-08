using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace graphicEditor
{
    
    public partial class Lab1 : Form
    {

      
        public static List<versionOfShape> allShapes = new List<versionOfShape>();
      
     
        public static Point[] point = new Point[0];

        public static Bitmap bitmapMain, bitmapSecondary;
    
        public static Pen pen = new Pen(Color.Black);

        public static int selectedShapesNumber = -1;
        public static Point[] selectRectangle;
       
      
        private Point currentMouseDown;

        bool isChanged = false;
        public static Shape shape;


        public struct versionOfShape
        {
            public bool isCurrentVersion;
            public int prevVersionIndex; 
            public  List<Shape> list;
            public int count;
        }



        public Lab1()
        {
            InitializeComponent();
         
      
            bitmapMain = new Bitmap(drawField.Width, drawField.Height);
            bitmapSecondary = new Bitmap(drawField.Width, drawField.Height);
        }

        private void Selection()
        {
          

            if (selectedShapesNumber > -1&&allShapes.Count != 0)
            {
                Pen selectPen = new Pen(Color.Black);
                selectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                if (allShapes[selectedShapesNumber].list[0].point.Length != 3)
                {
                    Point[] points = new Point[2];
                    if (allShapes[Lab1.selectedShapesNumber].list[0].GetType().Name == "MyLine")
                    {
                        points[0] = new Point(Math.Min(allShapes[Lab1.selectedShapesNumber].list[0].point[0].X, allShapes[Lab1.selectedShapesNumber].list[0].point[1].X) - 10, Math.Min(Lab1.allShapes[Lab1.selectedShapesNumber].list[0].point[0].Y, Lab1.allShapes[Lab1.selectedShapesNumber].list[0].point[1].Y) - 10);
                        points[1] = new Point(Math.Max(allShapes[Lab1.selectedShapesNumber].list[0].point[0].X, allShapes[Lab1.selectedShapesNumber].list[0].point[1].X) + 10, Math.Max(Lab1.allShapes[Lab1.selectedShapesNumber].list[0].point[0].Y, Lab1.allShapes[Lab1.selectedShapesNumber].list[0].point[1].Y) + 10);

                    }

                    else
                    {
                        points[0] = (new Point(Lab1.allShapes[Lab1.selectedShapesNumber].list[0].point[0].X - 10, Lab1.allShapes[Lab1.selectedShapesNumber].list[0].point[0].Y - 10));
                        points[1] = (new Point(Lab1.allShapes[Lab1.selectedShapesNumber].list[0].point[1].X + 10, Lab1.allShapes[Lab1.selectedShapesNumber].list[0].point[1].Y + 10));
                    }

                    Lab1.point = points;
                }
                else
                {
                    //Find coordinats for allocation the triangle
                    Point[] points = { (new Point(Math.Min(allShapes[selectedShapesNumber].list[0].point[0].X, Math.Min(allShapes[selectedShapesNumber].list[0].point[1].X, allShapes[selectedShapesNumber].list[0].point[2].X)) - 10, Math.Min(allShapes[selectedShapesNumber].list[0].point[0].Y, Math.Min(allShapes[selectedShapesNumber].list[0].point[1].Y, allShapes[selectedShapesNumber].list[0].point[2].Y)) - 10)), (new Point(Math.Max(allShapes[selectedShapesNumber].list[0].point[0].X, Math.Max(allShapes[selectedShapesNumber].list[0].point[1].X, allShapes[selectedShapesNumber].list[0].point[2].X)) + 10, Math.Max(allShapes[selectedShapesNumber].list[0].point[0].Y, Math.Max(allShapes[selectedShapesNumber].list[0].point[1].Y, allShapes[selectedShapesNumber].list[0].point[2].Y)) + 10)) };
                    point = points;
                }

                MyRectangle currentShape = new MyRectangle(selectPen);
                currentShape.Draw(bitmapMain, point, false);
                drawField.Image = bitmapMain;
                selectRectangle = new Point[point.Length];
                selectRectangle[0].X = point[0].X;
                selectRectangle[0].Y = point[0].Y;
                selectRectangle[1].X = point[1].X;
                selectRectangle[1].Y = point[1].Y;

            }

        }

       

        public static void AddNewShapeToList(Shape shape)
        {
            versionOfShape subListAllShapes ;
            subListAllShapes.list = new List<Shape>();
            subListAllShapes.count = 1;
            subListAllShapes.list.Add(shape);
            subListAllShapes.prevVersionIndex = -1;
            subListAllShapes.isCurrentVersion = true;
            allShapes.Add(subListAllShapes);
        }

        public static Shape CreateNewShape(string shapeName, Point[] pointLocal, Pen pen)
        {
            ShapeFactory shapeFactory;
            switch (shapeName)
            {
                case "Triangle":
                case "MyTriangle":
                    {
                        if (pointLocal.Length != 3)
                        {
                            shapeFactory = new TriangleFactory();
                             shape = shapeFactory.CreateNewShape();
                        }
                        else
                        {
                            shape = new MyTriangle(pointLocal, pen.Color, pen.Width);
                        }

                        break;
                    }
                case "Rectangle":
                case "MyRectangle":
                    {
                        if (pointLocal.Length != 2)
                        {
                            shapeFactory = new RectangleFactory();
                            shape = shapeFactory.CreateNewShape();
                        }
                        else
                        {
                            shape = new MyRectangle(pointLocal, pen.Color, pen.Width);
                        }
                        break;
                    }

                case "Ellipce":
                case "MyEllipce":
                    {
                        if (pointLocal.Length != 2)
                        {
                            shapeFactory = new EllipceFactory();
                            shape = shapeFactory.CreateNewShape();
                        }
                        else
                        {
                            shape = new MyEllipce(pointLocal, pen.Color, pen.Width);
                        }
                        break;
                    }

                case "Line":
                case "MyLine":
                    {
                        if (pointLocal.Length != 2)
                        {
                            shapeFactory = new LineFactory();
                            shape = shapeFactory.CreateNewShape();
                        }
                        else
                        {
                            shape = new MyLine(pointLocal, pen.Color, pen.Width);
                        }
                        break;
                    }

                case "Circle":
                case "MyCircle":
                    {
                        if (pointLocal.Length != 2)
                        {
                            shapeFactory = new CircleFactory();
                            shape = shapeFactory.CreateNewShape();
                        }
                        else
                        {
                            shape = new MyCircle(pointLocal, pen.Color, pen.Width);
                        }
                        break;
                    }

                case "Square":
                case "MySquare":
                    {
                        if (pointLocal.Length != 2)
                        {
                            shapeFactory = new SquareFactory();
                            shape = shapeFactory.CreateNewShape();
                        }
                        else
                        {
                            shape = new MySquare(pointLocal, pen.Color, pen.Width);
                        }
                        break;
                    }
            }

            return shape;
        }


        private int FindDistance(Shape shape, int x, int y)
        {
            int tempDistance = (int)(Math.Pow(Math.Pow(Math.Abs(shape.center.X - x), 2) + Math.Pow(Math.Abs(shape.center.Y - y), 2), 0.5));
            return tempDistance;
        }

        public void FindShapeByClick(int x, int y)
        {
            if (Lab1.allShapes.Count > 0 && this.Cursor == Cursors.Arrow)
            {
                Lab1.selectedShapesNumber = -1;
                int firstCurrentIndex = 0;
                while (!Lab1.allShapes[firstCurrentIndex].isCurrentVersion || Lab1.allShapes[firstCurrentIndex].list[0] == null)
                    firstCurrentIndex++;

                int minDistance = (int)(Math.Pow(Math.Pow(Lab1.allShapes[firstCurrentIndex].list[0].center.X - x, 2) + Math.Pow(Lab1.allShapes[firstCurrentIndex].list[0].center.Y - y, 2), 0.5));
                int tempDistance;
                for (int i = firstCurrentIndex + 1; i < Lab1.allShapes.Count; i++)
                {
                    if (Lab1.allShapes[i].isCurrentVersion)
                    {
                        tempDistance = FindDistance(Lab1.allShapes[i].list[0], x, y);
                        if (tempDistance < 30 && minDistance >= tempDistance)
                        {
                            minDistance = tempDistance;
                            Lab1.selectedShapesNumber = i;
                        }
                    }


                }
                if (minDistance > 30)
                {
                    Lab1.selectedShapesNumber = -1;

                }
                else
                {
                    if (Lab1.selectedShapesNumber == -1)
                        Lab1.selectedShapesNumber = firstCurrentIndex;
                }

            }

        }



        private void drawField_MouseClick(object sender, MouseEventArgs e)
        {
            
            currentMouseDown.X = e.X;
            currentMouseDown.Y = e.Y;
            Array.Resize(ref point, point.Length + 1);
            point[point.Length - 1].X = e.X;
            point[point.Length - 1].Y = e.Y;
            bitmapMain = bitmapSecondary;

            if (shapeComboBox.Text != "Mouse")
            {
                shape = CreateNewShape(shapeComboBox.Text,  point, pen);
                if((shape.GetType().Name == "MyTriangle" && point.Length == 3)||(shape.GetType().Name != "MyTriangle" && point.Length == 2) && shape != null)
                    AddNewShapeToList(shape);
            }
            else
            {
                {
                    FindShapeByClick(e.X, e.Y);
                    if (selectedShapesNumber != -1)
                    {
                       
                        Selection();
                    }
                      
                    Redraw();

                }
                

                Array.Resize(ref point, 0);
            }
            
            if (shape != null && shapeComboBox.Text != "Mouse" && point.Length > 1)
            {
          
                shape.Draw(bitmapMain, point, true);
                if(shapeComboBox.Text == "Triangle" && point.Length != 2 || shapeComboBox.Text != "Triangle")
                    Array.Resize(ref point, 0);
            }
        }
       

        private Shape ChangeShapeProperties(string shapeName, Point[] pointLocal, Color color, float brushWidth)
        {
            if (shape != null)
            {
                shape.point = pointLocal;
                shape.pen.Color = color;
                shape.pen.Width = brushWidth;
            }
            return shape;
        }




        private void DrawShape(string shapeName, Point[] pointLocal, Color color, float brushWidth)
        {
             shape = ChangeShapeProperties(shapeName, pointLocal, color, brushWidth);
      
            if (shape != null && pointLocal.Length > 1)
            {
                shape.Draw(bitmapSecondary, pointLocal, false);
            }

        }

        private void drawField_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                if (selectedShapesNumber > -1)
                {
                    if ((e.X < selectRectangle[0].X + 10 && e.X > selectRectangle[0].X - 10 && e.Y < selectRectangle[1].Y && e.Y > selectRectangle[0].Y) || (e.X < selectRectangle[1].X + 10 && e.X > selectRectangle[1].X - 10 && e.Y < selectRectangle[1].Y && e.Y > selectRectangle[0].Y))
                    {
                        this.Cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        if ((e.Y < selectRectangle[0].Y + 10 && e.Y > selectRectangle[0].Y - 10 && e.X < selectRectangle[1].X && e.X > selectRectangle[0].X) || (e.Y < selectRectangle[1].Y + 10 && e.Y > selectRectangle[1].Y - 10 && e.X < selectRectangle[1].X && e.X > selectRectangle[0].X))
                            this.Cursor = Cursors.SizeNS;
                        else
                            this.Cursor = Cursors.Arrow;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                }
            }


            if (shapeComboBox.Text != "Mouse")
            {
                
                if (point.Length > 0 && shape != null)
                {
                    Array.Resize(ref point, point.Length + 1);
                    point[point.Length - 1].X = e.X;
                    point[point.Length - 1].Y = e.Y;
                    bitmapSecondary = new Bitmap(bitmapMain);
                    DrawShape(shapeComboBox.Text, point, pen.Color, pen.Width);
                    drawField.Image = bitmapSecondary;
                    if (point.Length > 1)
                        Array.Resize(ref point, point.Length - 1);
                
                }
            }
            else
            {
               
                if (e.Button == MouseButtons.Left && selectedShapesNumber > -1)
                {
                    if (allShapes[selectedShapesNumber].list[0].GetType().GetInterface("IResizable") != null)
                    {
                       shape = GetShapeForChanging();

                        if (this.Cursor == Cursors.Arrow)
                        {
                            if (e.X < selectRectangle[1].X && e.X > selectRectangle[0].X && e.Y < selectRectangle[1].Y && e.Y > selectRectangle[0].Y)
                            { 
                                shape.MoveHorizontal(shape, currentMouseDown.X - e.X);                       
                                currentMouseDown.X = e.X;
                                shape.MoveVertical(shape, currentMouseDown.Y - e.Y);
                                currentMouseDown.Y = e.Y;
                                Redraw();
                                isChanged = true;
                            }
                        }
                        else
                        {
                            if (this.Cursor == Cursors.SizeWE)
                            {
                                shape.ResizableHorizontal(shape, e.X);                               
                            }
                            if (this.Cursor == Cursors.SizeNS)
                            {
                                shape.ResizableVertical(shape, e.Y);
                            }
                            Redraw();
                            isChanged = true;
                           // Selection();
                        }
                         // Selection();


                       


                    }
                }
            }
            Selection();
            
        }


        private Shape GetShapeForChanging()
        {
            Point[] helpPoint = new Point[allShapes[selectedShapesNumber].list[0].point.Length];
            for (int i = 0; i < helpPoint.Length; i++)
            {
                helpPoint[i].X = allShapes[selectedShapesNumber].list[0].point[i].X;
                helpPoint[i].Y = allShapes[selectedShapesNumber].list[0].point[i].Y;
            }

            if (allShapes[selectedShapesNumber].list.Count != allShapes[selectedShapesNumber].count + 1)
            {
                shape = CreateNewShape(allShapes[selectedShapesNumber].list[0].GetType().Name, helpPoint, allShapes[selectedShapesNumber].list[0].pen);
                if (selectedShapesNumber != allShapes.Count - 1)
                {
                    ChangeIsCurrentInVersionStract(false, selectedShapesNumber);
                    versionOfShape newVersionOfShape = new versionOfShape();
                    newVersionOfShape.count = 1;
                    newVersionOfShape.prevVersionIndex = selectedShapesNumber;
                    newVersionOfShape.isCurrentVersion = true;
                    newVersionOfShape.list = new List<Shape>();
                    allShapes.Add(newVersionOfShape);
                    selectedShapesNumber = allShapes.Count - 1;
                    ChangeCountInVersionStract(allShapes[selectedShapesNumber].count - 1, selectedShapesNumber);
                }
                allShapes[selectedShapesNumber].list.Insert(0, shape);
            }
            return shape;
        }


        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

               pen.Color = colorDialog.Color;
                if (selectedShapesNumber > -1 && allShapes[selectedShapesNumber].list[0].GetType().GetInterface("IResizable") != null)
                {
                    shape = GetShapeForChanging();
                    shape.ChangeColor(colorDialog.Color);
                    Redraw();
                    Selection();
                }

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (int)numericUpDown.Value;
            if (selectedShapesNumber > -1 && allShapes[selectedShapesNumber].list[0].GetType().GetInterface("IResizable") != null)
            {
                shape = GetShapeForChanging();
                shape.ChangePenWidth((float)numericUpDown.Value);
                Redraw();
                Selection();
            }
        
        }


        private void Lab1_KeyDown_1(object sender, KeyEventArgs e)
        {
          
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            MyTxtFileStream txtFileStream = MyTxtFileStream.getInstance();
            if(txtFileStream.Open())
                Redraw();
            else
            {
                 List<versionOfShape> allShapes = new List<versionOfShape>();
                point = new Point[0];
                pen = new Pen(Color.Black);
                shape = null;

            }       
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyTxtFileStream txtFileStream = MyTxtFileStream.getInstance();
            txtFileStream.Save();
        }

        private void btnOpen_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void Redraw()
        {
         //  if(allShapes.Count != 0)
            {
                bitmapMain = new Bitmap(drawField.Width, drawField.Height);
                drawField.Image = bitmapMain;
                bitmapSecondary = bitmapMain;

                for (int i = 0; i < allShapes.Count; i++)
                {
                    if (allShapes[i].isCurrentVersion && allShapes[i].list[0] != null)
                        allShapes[i].list[0].Draw(bitmapMain, allShapes[i].list[0].point, false);
                }
                drawField.Image = bitmapMain;
            }
           
        }


        private void ChangeIsCurrentInVersionStract(bool isCurrentVersion, int index)
        {
            versionOfShape temp = allShapes[index];
            temp.isCurrentVersion = isCurrentVersion;
            allShapes[index] = temp;
        }

        private void ChangeCountInVersionStract(int count, int index)
        {
            versionOfShape temp = allShapes[index];
            temp.count = count;
            allShapes[index] = temp;
        }

        private void drawField_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedShapesNumber > -1 && shape != null && isChanged)
            {
                ChangeCountInVersionStract(allShapes[selectedShapesNumber].count + 1, selectedShapesNumber);
               isChanged = false;
              //  Selection();
            }
          //  Selection();

        }

        private void drawField_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void shapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Array.Resize(ref point, 0);
        }

        private void shapeComboBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Z && e.Control)
            {
                if (allShapes.Count > 0)
                {
                    if (allShapes[allShapes.Count - 1].list.Count > 0 && allShapes[allShapes.Count - 1].list.Count != 1)
                    {
                        allShapes[allShapes.Count - 1].list.RemoveAt(0);
                        ChangeCountInVersionStract(allShapes[allShapes.Count - 1].count - 1, allShapes.Count - 1);
                    }
                    else
                        if (allShapes[allShapes.Count - 1].list.Count == 1)
                        {
                            if(allShapes[allShapes.Count - 1].prevVersionIndex != -1)
                                ChangeIsCurrentInVersionStract(true, allShapes[allShapes.Count - 1].prevVersionIndex);
                            
                            allShapes.RemoveAt(allShapes.Count - 1);
                        }
                            
                    Redraw();
                }
               
            }

            

        }

        
    }
}
