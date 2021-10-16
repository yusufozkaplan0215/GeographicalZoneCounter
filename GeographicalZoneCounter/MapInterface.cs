using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yusuf_Ozkaplan
{
    public interface MapInterface
    {
        /// <summary>
        /// Haritanın genişlik ve yüksekliği setlemek için kullanılır.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void SetSize(in int width, in int height);

        /// <summary>
        /// Haritanın genişlik ve yüksekliği out olarak setlemek için kullanılır.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void GetSize(out int width, out int height);

        /// <summary>
        /// Haritanın x ve y locasyonuna kenarlık bilgisi setlenir.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void SetBorder(int x, int y);

        /// <summary>
        /// Haritanın x ve y locasyonundan kenarlık bilgisi silinir.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void ClearBorder(int x, int y);

        /// <summary>
        /// Haritanın x ve y locasyonunun kenarlık olup olmadığı bilgisidir
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        bool IsBorder(int x, int y);

        /// <summary>
        /// Haritanın gösterilir.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void Show();
    }
}
