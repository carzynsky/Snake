using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Neo_Snake
{
    class NeoSnake
    {
        private int segments;
        private int segment;
        private int[] x = new int[900];
        private int[] y = new int[900];
        private string moveDirection;

        public int getSegments()
        {
            return segments;
        }
        public int getSegment()
        {
            return segment;
        }
        public int getHeadX()
        {
            return x[0];
        }
        public int getHeadY()
        {
            return y[0];
        }

        public string getMoveDirection()
        {
            return moveDirection;
        }
        public void setMoveDirection(string newMoveDirection)
        {
            this.moveDirection = newMoveDirection;
        }

        public NeoSnake(int width, int height)
        {
            segment = width / 20;
            segments = 3;
            moveDirection = "right";
            int xHead = segment * 9;
            int yHead = segment * 9;
            for (int i=0; i<segments; i++)
            {
                x[i] = xHead - (i * segment);
                y[i] = yHead;
            }
        }
        public void eat()
        {
            x[segments] = x[segments - 1];
            y[segments] = y[segments - 1];
            segments += 1;

        }
        public void move()
        {
            for(int i=segments; i>0; i--)
            {
                x[i] = x[i - 1];
                y[i] = y[i - 1];
                 
            }
            if(moveDirection == "left")
            {
                x[0] -= segment;
            }
            if (moveDirection == "right")
            {
                x[0] += segment;
            }
            if (moveDirection == "up")
            {
                y[0] -= segment;
            }
            if (moveDirection == "down")
            {
                y[0] += segment;
            }
            if (x[0] < 0) x[0] = 19*segment;
            if (x[0] > 20*segment) x[0] = 0;
            if (y[0] < 0) y[0] = 19*segment;
            if (y[0] > 20 * segment) y[0] = 0;


        }
        public void draw(Graphics g, Brush b)
        {
            for(int i=0; i<segments; i++)
            {
                g.FillRectangle(b, x[i], y[i], segment, segment);
            }
        }
        public bool isAlive()
        {
            for(int i=1; i<segments; i++)
            {
                if (x[i] == x[0] && y[i] == y[0])
                    return false;
            }
            return true;
        }
    }
}
