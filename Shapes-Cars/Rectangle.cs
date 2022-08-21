using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

public class Rectangle:IDrawable
{
    private int x;

    public int X
    {
        get { return x; }
        set { x = value; }
    }
    private int y;

    public int Y
    {
        get { return y; }
        set { y = value; }
    }
    public void Draw() 
    {
        
        for (int i = 0; i < this.y; i++)
        {
            for (int j = 0; j < this.x; j++)
            {
                //Console.WriteLine("*"+ );
            }
        }
    }
}