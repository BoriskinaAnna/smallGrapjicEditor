using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicEditor
{
    interface IResizable
    {
       
        void ResizableHorizontal(Shape shape, int newX);
        void ResizableVertical(Shape shape, int newY);
        void ChangeColor(Color color);
        void ChangePenWidth(float penWidth);
        void MoveHorizontal(Shape shape, int offset);
        void MoveVertical(Shape shape, int offset);


    }
}
