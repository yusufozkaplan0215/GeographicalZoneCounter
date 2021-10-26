using System;

namespace Yusuf_Ozkaplan
{
    class Program
    {
        static void Main(string[] args)
        {
			MapInformation mapInformation = new MapInformation();
			mapInformation.SetSize(6, 6);

			mapInformation.SetBorder(0, 1);
			mapInformation.SetBorder(2, 0);
			mapInformation.SetBorder(2, 1);
			mapInformation.SetBorder(1, 2);
			mapInformation.SetBorder(1, 3);
			mapInformation.SetBorder(2, 3);
			mapInformation.SetBorder(3, 3);
			mapInformation.SetBorder(3, 4);
			mapInformation.SetBorder(3, 5);
			mapInformation.SetBorder(4, 3);
			mapInformation.SetBorder(5, 3);
			mapInformation.SetBorder(0, 4);

			mapInformation.Show();

			Console.WriteLine(Environment.NewLine);

			///Calculate Map zone
			ZoneCounter zoneCounter = new ZoneCounter();
            zoneCounter.Init(mapInformation);
			int zoneCount = zoneCounter.Solve();

			Console.WriteLine("Zone Count = " + zoneCount);

            Console.ReadKey();
        }
    }
}
