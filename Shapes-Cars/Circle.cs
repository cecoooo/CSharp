using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

public class Circle: IDrawable
{
    private int radius;

    public int Radius
    {
        get { return radius; }
        set { radius = value; }
    }
    public Circle() 
    {
    
    }
    public Circle(int radius)
    {
        this.radius = radius;
    }

    public void Draw() 
    {
        int start = this.radius-1;
        int end = this.radius*3 + 2;
        for (int i = 0; i <= this.radius*2; i++)
        {
            if (i == 0 || i == this.radius)
            {
                Console.WriteLine();
                for (int j = 0; j < this.radius; j++) Console.Write(" ");
                for (int j = 0; j <= this.radius; j++) Console.Write("*");
                continue;
            }
            else if (i == this.radius) 
            {
                Console.WriteLine();
                Console.Write("*");
                for (int j = 0; j < this.radius*4-1; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
            }
            else
            {
                Console.WriteLine();
                for (int j = 0; j <= this.radius * 2; j++)
                {
                    if (j == start || j == end-1)
                    {
                        Console.Write("**");
                        j++;
                    }
                    else Console.Write(" ");
                }
            } 
            start--;
            end++;
            if (start == 0)
            {
                start = this.radius * 3 + 2;
                end = 0;
            }
        }
    }
}

/*
 4x+1
 2x+1
2x
x
start = x-1 /-- => 0
end = 4x+1 - (x-1) = 3x+2 / ++ => 4x+1

x=5
start = 3-4
end = 17-18
2
19
1 
20
0
21

*/