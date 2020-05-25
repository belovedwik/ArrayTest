using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestArray.Test
{
    [TestClass]
    public class UnitTest
    {
        private IMatrix matrix;
        [TestMethod]
        public void TestArray_OK()
        {
            matrix = new MatrixList(9, 4);

            Assert.AreEqual("1", 1.ToString());
        }

        [TestMethod]
        public void TestMatrix_OK()
        {
            matrix = new MartixArr(9, 4);

            Assert.AreEqual("1", 1.ToString());
        }

        [TestMethod]
        public void TestMatrix_NotEqual()
        {
           
            matrix = new MartixArr(9, 4);
            var matrixA = new MartixArr(9, 4);
            Assert.AreNotEqual(matrix, matrixA);
        }
    }
}
