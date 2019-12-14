using System;
namespace TestArray
{
    public interface IMatrix
    { 
         bool CheckDuplicates();

         void PrintArray(bool clearConsole = false);

         void ArrayFillRandom(bool fullRefill = false);
    }
}
