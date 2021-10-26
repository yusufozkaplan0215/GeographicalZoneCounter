using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yusuf_Ozkaplan
{
    public interface MapInterface
    {
        // Creates / Allocates a map of given size.
        void SetSize(in int width, in int height);

        // Get dimensions of given map.
        void GetSize(out int width, out int height);

        // Sets border at given point.
        void SetBorder(int x, int y);

        // Clears border at given point.
        void ClearBorder(int x, int y);

        // Checks if given point is border.
        bool IsBorder(int x, int y);

        // Show map contents.
        void Show();
    }
}
