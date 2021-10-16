using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yusuf_Ozkaplan
{
    public class ZoneCounter : ZoneCounterInterface
    {
        private MapInterface map;
        private int width;
        private int height;
        int[,] labelMap;
        int label = 1;
        private Stack<int> labelStack;
        public Dictionary<int, LabelStartFinishLocation> dicLabelStartFinishLocation;
        string mapString = string.Empty;

        public ZoneCounter()
        {
            labelStack = new Stack<int>();
            labelStack.Push(label);
            dicLabelStartFinishLocation = new Dictionary<int, LabelStartFinishLocation>();
        }

        /// <summary>
        /// Harita çözümlemek için dışarıdan soyutlanarak çözüm için ilklenir.
        /// </summary>
        /// <param name="map"></param>
        public void Init(MapInterface map)
        {
            this.map = map;
            int label = 1;

            dicLabelStartFinishLocation.Clear();
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

        /// <summary>
        /// Haritadaki bölge sayısı döner.
        /// Etiketleme MEtodu Kullanılmıştır.
        /// </summary>
        /// <returns></returns>
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

                            if (dicLabelStartFinishLocation.ContainsKey(label) == false)
                            {
                                dicLabelStartFinishLocation.Add(label, new LabelStartFinishLocation()
                                {
                                    Label = label,
                                    StartLocation = new System.Drawing.Point(row, column)
                                });
                            }
                        }
                        else if (column == 0)
                        {
                            ///il sütun komşuluklarından duvar olmayan ve en küçük etikete sahip olan seçilir.
                            var neighbor1 = labelMap[row - 1, column];
                            var neighbor2 = labelMap[row - 1, column + 1];
                            int tempLabel = 10000000;

                            if (neighbor1 == 0 && neighbor2 == 0)
                            {
                                if (dicLabelStartFinishLocation.ContainsKey(label) == false)
                                {
                                    dicLabelStartFinishLocation.Add(label, new LabelStartFinishLocation());
                                }

                                dicLabelStartFinishLocation[label].FinishLocation = new System.Drawing.Point(row, column);
                                label++;

                                if (dicLabelStartFinishLocation.ContainsKey(label) == false)
                                {
                                    dicLabelStartFinishLocation.Add(label, new LabelStartFinishLocation()
                                    {
                                        Label = label,
                                        StartLocation = new System.Drawing.Point(row, column)
                                    });
                                }

                                tempLabel = label;
                                labelStack.Push(label);
                            }

                            if (neighbor1 != 0 && neighbor1 < tempLabel)
                            {
                                tempLabel = neighbor1;
                            }

                            if (neighbor2 != 0 && neighbor2 < tempLabel)
                            {
                                tempLabel = neighbor2;
                            }

                            labelMap[row, column] = tempLabel;
                        }
                        else
                        {
                            ///
                            int tempLabel = 10000000;
                            bool isNewLabel = false;

                            var neighbor = labelMap[row, column - 1];
                            if (neighbor != 0 && neighbor < tempLabel)
                            {
                                tempLabel = neighbor;
                                isNewLabel = false;
                            }
                            else if (neighbor == 0)
                            {
                                isNewLabel = true;
                            }

                            for (int i = -1; i <= 1; i++)
                            {
                                if (column + i >= width)
                                {
                                    break;
                                }

                                neighbor = labelMap[row - 1, column + i];
                                if (neighbor != 0 && neighbor < tempLabel)
                                {
                                    int oldLabel = tempLabel;                                   
                                                                       
                                    tempLabel = neighbor;
                                    isNewLabel = isNewLabel && false;

                                    if (oldLabel != 10000000)
                                    {
                                        if (dicLabelStartFinishLocation.ContainsKey(label) == false)
                                        {
                                            dicLabelStartFinishLocation.Add(label, new LabelStartFinishLocation());
                                        }

                                        dicLabelStartFinishLocation[oldLabel].FinishLocation = new System.Drawing.Point(row, column);
                                        ChangeOldLabel(oldLabel, tempLabel);
                                        labelStack.Pop();
                                    }                                    
                                }
                                else if (neighbor == 0)
                                {
                                    isNewLabel = isNewLabel && true;
                                }
                            }

                            if (isNewLabel)
                            {
                                if (dicLabelStartFinishLocation.ContainsKey(label) == false)
                                {
                                    dicLabelStartFinishLocation.Add(label, new LabelStartFinishLocation());
                                }

                                dicLabelStartFinishLocation[label].FinishLocation = new System.Drawing.Point(row, column);
                                label++;

                                if (dicLabelStartFinishLocation.ContainsKey(label) == false)
                                {
                                    dicLabelStartFinishLocation.Add(label, new LabelStartFinishLocation()
                                    {
                                        Label = label,
                                        StartLocation = new System.Drawing.Point(row, column)
                                    });
                                }

                                tempLabel = label;
                                labelStack.Push(label);
                            }

                            labelMap[row, column] = tempLabel;
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

                    mapString += string.Concat(labelMap[row, column].ToString(), " ");
                }

                mapString += "\n";
            }

            return dicLabelStartFinishLocation.Count;
        }

        public string GetLabelMap()
        {
            return mapString;
        }

        private void ChangeOldLabel(int oldLabel, int newLabel)
        {
            var value = dicLabelStartFinishLocation[label];
            var startRow = value.StartLocation.X;
            var finishRow = value.FinishLocation.X;
            var startColumn = value.StartLocation.Y;
            var finishColumn = value.FinishLocation.Y;

            while (finishRow >= startRow)
            {
                int tempColumn = 0;
                if (startRow == finishRow)
                {
                    tempColumn = startColumn;
                }

                while (finishColumn >= tempColumn)
                {
                    if (labelMap[startRow, finishColumn] == oldLabel)
                    {
                        labelMap[startRow, finishColumn] = newLabel;
                    }

                    finishColumn--;
                }

                finishColumn = width-1;
                finishRow--;
            }
        }
    }
}
