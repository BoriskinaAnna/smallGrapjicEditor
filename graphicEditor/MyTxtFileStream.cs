using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphicEditor
{
    class MyTxtFileStream
    {

        private static MyTxtFileStream instance;

        private MyTxtFileStream()
        { }

        public static MyTxtFileStream getInstance()
        {
            if (instance == null)
                instance = new MyTxtFileStream();
            return instance;
        }

        public void Save()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {


                using (FileStream fstream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    for (int i = 0; i < Lab1.allShapes.Count; i++)
                    {
                        if (Lab1.allShapes[i].isCurrentVersion && Lab1.allShapes[i].list[0] != null)
                        {
                            byte[] array = new byte[1];
                            array[0] = Lab1.allShapes[i].list[0].pen.Color.R;
                            fstream.Write(array, 0, 1);
                            array[0] = Lab1.allShapes[i].list[0].pen.Color.G;
                            fstream.Write(array, 0, 1);
                            array[0] = Lab1.allShapes[i].list[0].pen.Color.B;
                            fstream.Write(array, 0, 1);
                            array = BitConverter.GetBytes(Lab1.allShapes[i].list[0].pen.Width);
                            fstream.Write(array, 0, array.Length);

                            array = System.Text.Encoding.Default.GetBytes(Lab1.allShapes[i].list[0].GetType().Name);
                            Array.Resize(ref array, 11);
                            fstream.Write(array, 0, array.Length);

                            for (int j = 0; j < Lab1.allShapes[i].list[0].point.Length; j++)
                            {
                                array = BitConverter.GetBytes(Lab1.allShapes[i].list[0].point[j].X);
                                fstream.Write(array, 0, array.Length);
                                array = BitConverter.GetBytes(Lab1.allShapes[i].list[0].point[j].Y);
                                fstream.Write(array, 0, array.Length);
                            }
                        }

                    }
                }
            }
        }



        private byte[] GetSubarray(byte[] array, ref int currentByte, int countBytes)
        {
            byte[] helpArray;
            helpArray = new byte[countBytes];
            Array.Copy(array, currentByte, helpArray, 0, countBytes);
            currentByte += countBytes;

            return helpArray;
        }

        private string GetCleanShapeName(string shapeName)
        {
            int index = shapeName.IndexOf("\0");
            if (index > 0)
                shapeName = shapeName.Substring(0, index);
            return shapeName;
        }

        private Point[] GetPointArray(byte[] array, ref int currentByte, byte countPoints)
        {
            Point[] point = new Point[countPoints];
            byte[] helpArray;
            for (int i = 0; i < countPoints; i++)
            {
                helpArray = GetSubarray(array, ref currentByte, 4);
                point[i].X = BitConverter.ToInt32(helpArray, 0);

                helpArray = GetSubarray(array, ref currentByte, 4);
                point[i].Y = BitConverter.ToInt32(helpArray, 0);

            }
            return point;

        }


        public bool Open()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Lab1.allShapes = new List<Lab1.versionOfShape>();
                    using (FileStream fstream = File.OpenRead(openFile.FileName))
                    {
                        byte[] array = new byte[fstream.Length];
                        fstream.Read(array, 0, array.Length);
                        int currentByte = 0;
                        while (currentByte < array.Length)
                        {
                            byte[] helpArray;
                            Color color = Color.FromArgb(array[currentByte++], array[currentByte++], array[currentByte++]);
                            helpArray = GetSubarray(array, ref currentByte, 4);
                            float width = BitConverter.ToSingle(helpArray, 0);
                            helpArray = GetSubarray(array, ref currentByte, 11);
                            string shapeName = System.Text.Encoding.Default.GetString(helpArray);
                            shapeName = GetCleanShapeName(shapeName);
                            Point[] point;
                            if (shapeName == "MyTriangle")
                            {
                                point = GetPointArray(array, ref currentByte, 3);
                            }
                            else
                            {
                                point = GetPointArray(array, ref currentByte, 2);
                            }
                            Lab1.pen.Color = color;
                            Lab1.pen.Width = width;
                            Lab1.shape = Lab1.CreateNewShape(shapeName, point, Lab1.pen);
                            if (Lab1.shape != null)
                                Lab1.AddNewShapeToList(Lab1.shape);

                        }
                        //Redraw();
                        
                    }
                   
                }
                
                catch (Exception exception)
                {
                    MessageBox.Show("Incorrect data in the file");
                    return false;
                }
               
            }
            return true;
        }

    }
}
