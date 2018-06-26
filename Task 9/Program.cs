using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    class Program
    {
        /// <summary>
        /// Проверка ввода целых чисел
        /// </summary>
        /// <returns>Целое число</returns>
        static int ReadInt()
        {
            int k = 0; bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out k);
                if (!ok) Console.WriteLine("Неправильный ввод. Ожидалось натуральное число. Пожалуйста, повторите ввод");
            }
            while (!ok);

            return k;
        }

        /// <summary>
        /// Проверка ввода вещественных чисел
        /// </summary>
        /// <returns>Вещественное число</returns>
        static double ReadDouble()
        {
            double data = 0; bool ok;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out data);
                if (!ok) Console.WriteLine("Неправильный ввод. Ожидалось вещественное число. Пожалуйста, повторите ввод");
            }
            while (!ok);
            return data;
        }


        static void Main(string[] args)
        {
            // Создание списка
            Console.WriteLine("Введите количество элементов в списке");
            int N = ReadInt();
            DoublyList list = DoublyList.MakeDoublyList(N);
            DoublyList.ShowDoublyList(list);


            // Поиск элементов
            // По номеру
            Console.WriteLine("Введите номер элемента для поиска");
            int num = ReadInt();
            DoublyList foundEl = DoublyList.SearchElemNum(list, num);
            if (foundEl == null) Console.WriteLine("Элемент не найден");
            else Console.WriteLine(foundEl);

            // По данным
            Console.WriteLine("Введите данные элемента для поиска");
            double data = ReadDouble();            
            foundEl = DoublyList.SearchElemData(list, data);
            if (foundEl == null) Console.WriteLine("Элемент не найден");
            else Console.WriteLine(foundEl);


            // Удаление элементов
            // По номеру
            Console.WriteLine("Введите номер элемента для удаления");
            num = ReadInt();
            list = DoublyList.DeleteElemNum(list, num);
            DoublyList.ShowDoublyList(list);

            // По данным
            Console.WriteLine("Введите данные элемента для удаления");
            data = ReadDouble();
            list = DoublyList.DeleteElemData(list, data);
            DoublyList.ShowDoublyList(list);

            Console.ReadLine();
        }
    }
}
