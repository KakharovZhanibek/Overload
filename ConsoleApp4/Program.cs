using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public enum gender { man, woman }
    class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public gender Gender { get; set; }

        public static bool operator ==(Human a, Human b)
        {
            return a.Age == b.Age;
        }
        public static bool operator !=(Human a, Human b)
        {
            return a.Age != b.Age;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    class IntArray
    {
        private int[] _arr;

        public IntArray()
        {
            this._arr = new int[0];
        }

        public IntArray(int size)
        {
            this._arr = new int[size];
        }
        /// <summary>
        /// получение данных из массива по индексу
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>значение элемента</returns>
        public int this[int index]
        {
            get
            {
                int res = int.MinValue;
                try
                {

                    res = this._arr[index];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Error: array doesn't have {0} element!", index);
                }
                return res;
            }
            set
            {
                if (index > -1 && index < this._arr.Length)
                    this._arr[index] = value;
            }
        }
        /// <summary>
        /// Количество элементов
        /// </summary>
        public int Count
        {
            get { return this._arr.Length; }
        }
        public void Print()
        {
            Console.Write("Array: ");
            for (int i = 0; i < _arr.Length; i++)
                Console.Write("{0} ", _arr[i]);
            Console.WriteLine();
        }
        public static int Sum(IntArray arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Count - 1; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public static bool operator ==(IntArray arr1, IntArray arr2)
        {
            bool x = true;
            for (int i = 0; i < arr1.Count - 1; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Массивы не равны");
                    x = false;
                    return x;
                }
            }
            Console.WriteLine("Массивы равны");
            return x;
        }
        public static bool operator !=(IntArray arr1, IntArray arr2)
        {
            bool x = false;
            for (int i = 0; i < arr1.Count - 1; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Массивы не равны");
                    x = true;
                    return x;
                }
            }
            return x;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public static bool operator >(IntArray arr1, IntArray arr2)
        {
            return Sum(arr1) > Sum(arr2);
        }
        public static bool operator <(IntArray arr1, IntArray arr2)
        {
            return Sum(arr1) < Sum(arr2);
        }
        public static IntArray operator *(IntArray arr1, IntArray arr2)
        {
            IntArray arr = new IntArray(arr1.Count);

            for (int i = 0; i < arr.Count; i++)
            {
                arr[i] = arr1[i] * arr2[i];
            }
            return arr;
        }
        public static IntArray operator +(IntArray arr1, IntArray arr2)
        {
            IntArray arr = new IntArray(arr1.Count * 2);
            for (int i = 0; i < arr1.Count - 1; i++)
            {
                arr[i] = arr1[i];
            }
            int x = 0;
            for (int i = arr1.Count; i < arr1.Count * 2 - 1; i++)
            {
                arr[i] = arr2[x];
                x++;
            }
            return arr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Exmpl01();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
            Exmpl02();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Exmpl01()
        {
            Human h1 = new Human();
            Human h2 = new Human();

            Console.WriteLine("Введите данные");

            Console.WriteLine("Имя     :");
            h1.Name = Console.ReadLine();

            Console.WriteLine("Возраст :");
            h1.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Пол   0=М 1=Ж :");
            while (true)
            {
                var k = Console.ReadLine();
                if (k == "0")
                {
                    h1.Gender = gender.man;
                    break;
                }
                else if (k == "1")
                {
                    h1.Gender = gender.woman;
                    break;
                }
                else
                {
                    Console.WriteLine("Введены неправильные данные");
                    Console.WriteLine("Пол   0=М 1=Ж :");

                    k = Console.ReadLine();
                }
            }


            Console.WriteLine("\n\n");

            Console.WriteLine("Имя     :");
            h2.Name = Console.ReadLine();

            Console.WriteLine("Возраст :");
            h2.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Пол   0=М 1=Ж :");

            while (true)
            {
                var k = Console.ReadLine();
                if (k == "0")
                {
                    h2.Gender = gender.man;
                    break;
                }
                else if (k == "1")
                {
                    h2.Gender = gender.woman;
                    break;
                }
                else
                {
                    Console.WriteLine("Введены неправильные данные");
                    Console.WriteLine("Пол   0=М 1=Ж :");

                    k = Console.ReadLine();
                }
            }

            if (h1 == h2)
            {
                Console.WriteLine("Равно");
            }
            if (h1 != h2)
            {
                Console.WriteLine("Не равно");
            }
        }
        static void Exmpl02()
        {
            IntArray arr = new IntArray(10);
            IntArray arr2 = new IntArray(10);
            Random rand = new Random();
            for (int i = 0; i < arr.Count; i++)
                arr[i] = rand.Next(-10, 10);

            for (int i = 0; i < arr2.Count; i++)
                arr2[i] = rand.Next(-10, 10);

            arr.Print();
            arr2.Print();

            if (arr > arr2)
            {
                Console.WriteLine("Сумма первого массива больше");
            }
            else if (arr < arr2)
            {
                Console.WriteLine("Сумма второго массива больше");
            }
            else
            {
                Console.WriteLine("Сумма массивов равна");
            }
        }
    }
}
