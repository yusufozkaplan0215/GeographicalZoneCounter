using System;

namespace Yusuf_Ozkaplan
{
    class Program
    {
        static void Main(string[] args)
        {
			MapInformation mapInformation = new MapInformation();
			mapInformation.SetSize(36, 24);

			mapInformation.SetBorder(0, 18);
			mapInformation.SetBorder(0, 24);

			mapInformation.SetBorder(1, 16);
			mapInformation.SetBorder(1, 17);
			mapInformation.SetBorder(1, 24);

			mapInformation.SetBorder(2, 15);
			mapInformation.SetBorder(2, 24);

			mapInformation.SetBorder(3, 14);
			mapInformation.SetBorder(3, 25);

			mapInformation.SetBorder(4, 12);
			mapInformation.SetBorder(4, 13);
			mapInformation.SetBorder(4, 25);

			mapInformation.SetBorder(5, 11);
			mapInformation.SetBorder(5, 26);
			mapInformation.SetBorder(5, 35);

			mapInformation.SetBorder(6, 10);
			mapInformation.SetBorder(6, 26);
			mapInformation.SetBorder(6, 27);
			mapInformation.SetBorder(6, 28);
			mapInformation.SetBorder(6, 29);
			mapInformation.SetBorder(6, 30);
			mapInformation.SetBorder(6, 31);
			mapInformation.SetBorder(6, 32);
			mapInformation.SetBorder(6, 33);
			mapInformation.SetBorder(6, 34);

			mapInformation.SetBorder(7, 8);
			mapInformation.SetBorder(7, 9);
			mapInformation.SetBorder(7, 26);

			mapInformation.SetBorder(8, 7);
			mapInformation.SetBorder(8, 27);

			mapInformation.SetBorder(9, 5);
			mapInformation.SetBorder(9, 6);
			mapInformation.SetBorder(9, 27);

			mapInformation.SetBorder(10, 4);
			mapInformation.SetBorder(10, 5);
			mapInformation.SetBorder(10, 27);

			mapInformation.SetBorder(11, 3);
			mapInformation.SetBorder(11, 6);
			mapInformation.SetBorder(11, 28);

			mapInformation.SetBorder(12, 2);
			mapInformation.SetBorder(12, 7);
			mapInformation.SetBorder(12, 28);

			mapInformation.SetBorder(13, 0);
			mapInformation.SetBorder(13, 1);
			mapInformation.SetBorder(13, 7);
			mapInformation.SetBorder(13, 25);
			mapInformation.SetBorder(13, 26);
			mapInformation.SetBorder(13, 27);
			mapInformation.SetBorder(13, 28);
			mapInformation.SetBorder(13, 29);

			mapInformation.SetBorder(14, 8);
			mapInformation.SetBorder(14, 21);
			mapInformation.SetBorder(14, 22);
			mapInformation.SetBorder(14, 23);
			mapInformation.SetBorder(14, 24);
			mapInformation.SetBorder(14, 29);

			mapInformation.SetBorder(15, 8);
			mapInformation.SetBorder(15, 17);
			mapInformation.SetBorder(15, 18);
			mapInformation.SetBorder(15, 19);
			mapInformation.SetBorder(15, 20);
			mapInformation.SetBorder(15, 29);

			mapInformation.SetBorder(16, 9);
			mapInformation.SetBorder(16, 13);
			mapInformation.SetBorder(16, 14);
			mapInformation.SetBorder(16, 15);
			//mapInformation.SetBorder(16, 16);
			mapInformation.SetBorder(16, 26);
			mapInformation.SetBorder(16, 30);

			mapInformation.SetBorder(17, 9);
			mapInformation.SetBorder(17, 10);
			mapInformation.SetBorder(17, 11);
			mapInformation.SetBorder(17, 12);
			mapInformation.SetBorder(17, 30);

			mapInformation.SetBorder(18, 10);
			mapInformation.SetBorder(18, 31);

			mapInformation.SetBorder(19, 10);
			mapInformation.SetBorder(19, 31);

			mapInformation.SetBorder(20, 11);
			mapInformation.SetBorder(20, 31);

			mapInformation.SetBorder(21, 11);
			mapInformation.SetBorder(21, 32);

			mapInformation.SetBorder(22, 12);
			mapInformation.SetBorder(22, 32);

			mapInformation.SetBorder(23, 12);
			mapInformation.SetBorder(23, 33);

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
