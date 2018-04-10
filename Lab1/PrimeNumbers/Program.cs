using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrimeNumbers
{
    class Program
    {
        static bool IsPrime(int x) //функция для определения простоты
    {
        bool res = true;          //
        if (x == 1) res = false;  //1 не простое

        for (int i = 2; i <= Math.Sqrt(x); i++) //массив, в котором определяется простое число путем деления на числа до корня этого числа
        {
            if (x % i == 0)
            {
                res = false;
                break;
            }
        }
        return res;
    }
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"C:\Users\user\source\repos\Lab1\primes.txt"); // считывание строки цифр в виде символов
            args = line.Split(' '); // загоняем цифры в вектор

            foreach (string s in args) // пробегаемся по массиву аргументов
            {
                if (IsPrime(int.Parse(s)))
                {
                   Console.Write(s + " ");
                }
                    
            }

            
        }
    }
}
