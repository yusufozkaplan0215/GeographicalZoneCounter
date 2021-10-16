using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yusuf_Ozkaplan
{
    public interface ZoneCounterInterface
    {
        /// <summary>
        /// Harita çözümlemek için dışarıdan soyutlanarak çözüm için ilklenir.
        /// </summary>
        /// <param name="map"></param>
        void Init(MapInterface map);

        /// <summary>
        /// Haritadaki bölge sayısı döner.
        /// </summary>
        /// <returns></returns>
        int Solve();
    }
}
