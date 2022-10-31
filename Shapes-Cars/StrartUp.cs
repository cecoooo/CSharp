using System;

namespace Shapes
{
    public class StrartUp
    {
        static void Main()
        {
            IDrawable circle = new Circle(5);
            circle.Draw();
        }
    }
}
