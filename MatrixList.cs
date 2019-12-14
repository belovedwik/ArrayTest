using System;
using System.Collections.Generic;
using System.Linq;

namespace TestArray
{
    public class MatrixList : IMatrix
    {
        private List<List<int>> _list;
        private int _dimension;
        private readonly int _maxUnicValues;

        public MatrixList(int dimension = 9, int maxUnicVal = 4)
        {
            _dimension = dimension;
            _maxUnicValues = maxUnicVal;
            _list = new List<List<int>>(dimension);
            for (int l = 0; l < _dimension; l++)
                _list.Add(new List<int>()); 
            
        }

        public void ArrayFillRandom(bool fullRefill = false)
        {
            var rand = new Random();

            for (int i = 0; i < _dimension; i++)
            {
                if (fullRefill)
                    _list[i] = new List<int>();

                for (int j = _list[i].Count(); j < _dimension; j++)
                {
                    _list[i].Add(rand.Next(0, _maxUnicValues));
                }
            }
        }

        public bool CheckDuplicates()
        {

            bool hasDublicates = false;

            for (int i = 0; i < _dimension; i++) {
                var rowVal = _list[i];
                var grpValues = rowVal.GroupBy(k => k).Select(g => new { K = g.Key, V = g.Count() }).ToList(); // grouping values
                if (grpValues.Any(g => g.V >= _maxUnicValues))
                {
                    hasDublicates = true;

                    var dubli = grpValues.Where(g => g.V >= _maxUnicValues).Select(k => k.K).Distinct();

                    for (int d = _dimension-1; d >= 0; d--)
                    {
                        if (dubli.Any(z => z == _list[i][d]))
                            _list[i].RemoveAt(d);
                    }

                    break;
                }
            }

            if (hasDublicates)
                return hasDublicates;

            for (int i = 0; i < _dimension; i++) {
                var colVal = _list.Select(p => p[i]);
                var grpValues = colVal.GroupBy(k => k).Select(g => new { K = g.Key, V = g.Count() }).ToList(); // grouping values
                if (grpValues.Any(g => g.V >= _maxUnicValues))
                {
                    hasDublicates = true;

                    var dubli = grpValues.Where(g => g.V >= _maxUnicValues).Select(k => k.K).Distinct();

                    for (int d = _dimension-1; d >= 0; d--)
                    {
                        if (dubli.Any(z => z == _list[d][i]))
                            _list[d].RemoveAt(i);
                    }

                    break;
                }
            }

            return hasDublicates;
        }

        public void PrintArray(bool clearConsole = false)
        {
            if (clearConsole)
                Console.Clear();

            foreach(var row in _list)
            {
                foreach (var col in row)
                {
                    Console.Write(string.Format("{0} ", col));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
