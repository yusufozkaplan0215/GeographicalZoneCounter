using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yusuf_Ozkaplan
{
    public class MapInformation : MapInterface
    {
        #region Variable

        private int width;
        private int height;
        private int[,] mapArray;

        #endregion

      
        // Creates / Allocates a map of given size.
        public void SetSize(in int width, in int height)
        {
            this.width = width;
            this.height = height;

            mapArray = new int[height, width];
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    mapArray[row, column] = 0;
                }
            }
        }

        // Get dimensions of given map.
        public void GetSize(out int width, out int height)
        {
            width = this.width;
            height = this.height;
        }

        // Sets border at given point.
        public void SetBorder(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return;
            }

            mapArray[x, y] = 1;
        }

        // Clears border at given point.
        public void ClearBorder(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return;
            }

            mapArray[x, y] = 0;
        }

        // Checks if given point is border.
        public bool IsBorder(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return false;
            }

            return mapArray[x, y] == 1;
        }

        // Show map contents.
        public void Show()
        {
            string mapContent = string.Empty;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    mapContent += string.Format("{0} ", mapArray[row, column]);
                }

                mapContent += Environment.NewLine;
            }

            Console.WriteLine("-------Map Contents-------");
            Console.WriteLine(mapContent);
        }
    }
}
