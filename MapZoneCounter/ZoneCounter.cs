using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yusuf_Ozkaplan
{
    public class ZoneCounter
    {
        private MapInterface map;
        private int width;
        private int height;
        int[,] labelMap;
        int label = 1;
        private Stack<int> labelStack;//Verilen etiketler yığında tutulur.
        string mapString = string.Empty;

        public ZoneCounter()
        {
            labelStack = new Stack<int>();
            labelStack.Push(label);
        }

        // Feeds map data into solution class, then get ready for Solve() method.
        public void Init(MapInterface map)
        {
            this.map = map;
            int label = 1;

            labelStack.Clear();
            labelStack.Push(label);

            map.GetSize(out width, out height);
            labelMap = new int[height, width];

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    labelMap[x, y] = 0;
                }
            }
        }

        // Counts zones in map provided with Init() method, then return the result.
        //2x2 lik komşuluk gözden geçirilir ve sonuç bulunur.
        public int Solve()
        {
            mapString = string.Empty;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {

                    if (map.IsBorder(row, column) == false)
                    {
                        if (row == 0)
                        {
                            /// İlk satır Etiketlemesi yapıldı.
                            labelMap[row, column] = label;
                        }
                        else if (column == 0)
                        {
                            ///ilk sütun komşuluklarından duvar olmayan ve en küçük etikete sahip olan seçilir.
                            var neighbor1 = labelMap[row - 1, column];
                            int tempLabel = 10000000;

                            if (neighbor1 == 0)
                            {
                                label++;
                                tempLabel = label;
                                labelStack.Push(label);
                            }

                            if (neighbor1 != 0 && neighbor1 < tempLabel)
                            {
                                tempLabel = neighbor1;
                            }

                            labelMap[row, column] = tempLabel;
                        }
                        else
                        {
                            ///Komşulardan En küçüğü seçilir.
                            int tempLabel = 10000000;

                            var neighborLeft = labelMap[row, column - 1];
                            var neighborTop = labelMap[row - 1, column];
                            var neighborTopLeft = labelMap[row - 1, column - 1];

                            if (neighborLeft == 0 && neighborTop == 0)
                            {
                                label++;
                                labelMap[row, column] = label;
                            }
                            else
                            {
                                if (neighborLeft != 0 && neighborLeft < tempLabel)
                                {
                                    tempLabel = neighborLeft;
                                }

                                if (neighborTop != 0 && neighborTop < tempLabel)
                                {
                                    tempLabel = neighborTop;
                                }

                                if (neighborTopLeft != 0 && neighborTopLeft < tempLabel)
                                {
                                    tempLabel = neighborLeft;
                                }



                                //if (neighborTop != 0 && neighborLeft != 0 && neighborTop < neighborLeft)
                                //{
                                //    ChangeOldLabel(row, column, neighborLeft, neighborTop);
                                //}

                                if (neighborTop != 0 && neighborLeft != 0)
                                {
                                    if (neighborTop < neighborLeft)
                                    {
                                        ChangeOldLabel(row, column, neighborLeft, neighborTop);
                                    }
                                    else if (neighborTop != neighborLeft && neighborTop > neighborLeft)
                                    {
                                        ChangeOldLabel(row, column, neighborTop, neighborLeft);
                                    }
                                }

                                labelMap[row, column] = tempLabel;
                            }
                        }
                    }
                    else
                    {
                        if (row == 0)
                        {
                            label = labelStack.Peek() + 1;
                            labelStack.Push(label);
                        }
                    }
                }
            }   

          return GetZoneCount();
        }

        /// <summary>
        /// Farklı olan etiketlerin sayısı toplam bölge sayısıdır.
        /// </summary>
        /// <returns></returns>
        private int GetZoneCount()
        {
            string mapString = string.Empty;
            List<int> listLabel = new List<int>();
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    var _label = labelMap[row, column];
                    if (_label != 0 && listLabel.Contains(_label) == false)
                    {
                        listLabel.Add(_label);
                    }

                    mapString += string.Format("{0} ", _label);
                }

                mapString += string.Format("{0}", Environment.NewLine);
            }

            return listLabel.Count;
        }

        ///// <summary>
        ///// Komşulardan enküçüğü seçildiğinde en büyük olarak setlenen lokasyonlar yeni değer ile tekrar etiketlenir.
        ///// </summary>
        ///// <param name="oldLabel"></param>
        ///// <param name="newLabel"></param>
        private void ChangeOldLabel(int row, int col, int oldLabel, int newLabel)
        {
            for (int i = 0; i <= row; i++)
            {

                int finishCount = i == row ? col : width;
                int counter = 0;
                while (counter < finishCount)
                {
                    if (labelMap[row, counter] == oldLabel)
                    {
                        labelMap[row, counter] = newLabel;
                    }

                    counter++;
                }
            }
        }
    }
}
