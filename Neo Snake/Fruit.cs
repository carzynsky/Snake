using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo_Snake
{
    class Fruit
    {
        private int x;
        private int y;
        private int segment;

        public Fruit(int segment)
        {
            this.segment = segment;
            createNewFruit();
        }

        public void createNewFruit()
        {
            Random rand = new Random();
            x = rand.Next(0, 20) * segment;
            y = rand.Next(0, 20) * segment;
        }

        public bool isNewFruit(int xHead, int yHead)
        {
            if(xHead == x && yHead == y)
            {
                createNewFruit();
                return true;
            }
            return false;
        }

        public void drawFruit(Graphics g, Brush b)
        {
            g.FillRectangle(b, x, y, segment, segment);
        }
    }
}
