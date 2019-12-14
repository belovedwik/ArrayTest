using System;
using System.Collections.Generic;
using System.Linq;

namespace TestArray
{
    public class MartixArr : IMatrix
    {
        private int[,] _arr;
        int _rowLength => _arr.GetLength(0);
        int _colLength => _arr.GetLength(1);
        private readonly int _maxUnicValues;

        public MartixArr(int dimension = 9, int maxUnicVal = 4)
        {
            _arr = new int[dimension, dimension];
            _maxUnicValues = maxUnicVal;
        }

        public void ArrayFillRandom(bool fullRefill = false) {
            
            var rand = new Random();
           
            for (int i = 0; i < _rowLength; i++)
            {
                for (int j = 0; j < _colLength; j++)
                {
                    if (fullRefill || _arr[i, j] == -1)
                        _arr[i, j] = rand.Next(0, _maxUnicValues);
                }
            }
        }

        private IEnumerable<int> SliceRow(int row)
        {
            for (var i = _arr.GetLowerBound(1); i <= _arr.GetUpperBound(1); i++)
            {
                yield return _arr[row, i];
            }
        }

        private IEnumerable<int> SliceColumn( int column)
        {
            for (var i = _arr.GetLowerBound(0); i <= _arr.GetUpperBound(0); i++)
            {
                yield return _arr[i, column];
            }
        }

        public bool CheckDuplicates() {

            bool hasDublicates = false;

            // find dublicates in row
            for (int i = 0; i < _rowLength; i++)
            {
                var rowVal = SliceRow(i); //get all data from row
                var grpValues = rowVal.GroupBy(k => k).Select(g=> new {K = g.Key, V = g.Count() }).ToList(); // grouping values
                if (grpValues.Any(g => g.V >= _maxUnicValues))
                {
                    hasDublicates = true;

                    var dubli = grpValues.Where(g => g.V >= _maxUnicValues).Select(k => k.K).Distinct();
                    for (int d = 0; d < rowVal.Count(); d++)
                    {
                        if (dubli.Any(z=>z == _arr[i, d]) )
                            _arr[i, d] = -1;
                    }
                     
                    break;
                }
            }

            if (hasDublicates)
                return hasDublicates;


            //find dublicates in column
            for (int j = 0; j < _colLength; j++)
            {
                var colVal = SliceColumn(j);
                var grpValues = colVal.GroupBy(k => k).Select(g => new { K = g.Key, V = g.Count() }).ToList(); // grouping values
                if (grpValues.Any(g => g.V >= _maxUnicValues))
                {
                    hasDublicates = true;

                    var dubli = grpValues.Where(g => g.V >= _maxUnicValues).Select(k => k.K).Distinct();
                    for (int d = 0; d < colVal.Count(); d++)
                    {
                        if (dubli.Any(z => z == _arr[d, j]))
                            _arr[d, j] = -1;
                    }
                    break;
                }
            }

            return hasDublicates;
        }


        public void PrintArray(bool clearConsole = false) {

            if (clearConsole)
                Console.Clear();

            for (int i = 0; i < _rowLength; i++)
            {
                for (int j = 0; j < _colLength; j++)
                {
                    Console.Write(string.Format("{0} ", _arr[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
           
        }

    }
}
