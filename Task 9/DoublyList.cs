using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_9
{
    class DoublyList
    {
        public int number;
        public double data;
        public DoublyList next, prev;

        public DoublyList()
        {
            number = 0;
            data = 0;
            next = null;
            prev = null;
        }
        public DoublyList(int num, double data)
        {
            number = num;
            this.data = data;
            next = null;
            prev = null;
        }
        public override string ToString()
        {
            return number + ") " + data + " ";
        }

        /// <summary>
        /// Формирование одного элемента списка
        /// </summary>
        /// <param name="d">Информационное поле текущего элемента</param>
        /// <returns>Заполненный элемент</returns>
        public static DoublyList MakeDoubly(int num, double d)
        {
            DoublyList p = new DoublyList(num, d);
            return p;
        }

        /// <summary>
        /// Заполнение двунаправленного списка
        /// </summary>
        /// <param name="size">Размер списка</param>
        /// <returns>Заполненный список</returns>
        public static DoublyList MakeDoublyList(int size)
        {
            // Файлы
            StreamReader fileRead = new StreamReader("input.txt");
            string MainStr = fileRead.ReadToEnd();
            char[] ch = { ' ', '\r', '\n', '\t' };
            string[] StrNum = MainStr.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            fileRead.Close();
            double[] num = new double[size];
            int stop = size;
            if (size > StrNum.Length) stop = StrNum.Length;
            for (int i = 0; i < stop; i++)
            {
                bool ok = double.TryParse(StrNum[i], out num[i]);
            }

            DoublyList beg = MakeDoubly(1, num[0]);
            DoublyList end = beg;

            for (int i = 2; i <= size; i++)
            {
                double info = num[i - 1];
                DoublyList p = MakeDoubly(i, info);
                if (info > 0)
                {
                    p.next = beg;
                    beg.prev = p;
                    beg = p;
                }
                else if (info < 0)
                {
                    end.next = p;
                    p.prev = end;
                    end = p;
                }
                else
                {
                    DoublyList t = end;
                    while (t.data < 0 && t.prev != null)
                        t = t.prev;
                    if (t == end)
                    {
                        end.next = p;
                        p.prev = end;
                        end = p;
                    }
                    else if (t.prev == null)
                    {
                        p.next = beg;
                        beg.prev = p;
                        beg = p;

                    }
                    else
                    {
                        t.next.prev = p;
                        p.next = t.next;
                        p.prev = t;
                        t.next = p;
                    }
                }
            }
            return beg;
        }

        /// <summary>
        /// Поиск элемента по номеру
        /// </summary>
        /// <param name="beg">Список</param>
        /// <param name="num">Номер</param>
        /// <returns>Искомый элемент</returns>
        public static DoublyList SearchElemNum(DoublyList beg, int num)
        {
            while (beg.number != num && beg.next != null)
                beg = beg.next;
            if (beg.next == null && beg.number != num)
                return null;
            return beg;
        }

        /// <summary>
        /// Поиск элемента по данным 
        /// </summary>
        /// <param name="beg">Список</param>
        /// <param name="data">Данные</param>
        /// <returns>Искомый элемент</returns>
        public static DoublyList SearchElemData(DoublyList beg, double data)
        {
            while (beg.data != data && beg.next != null)
                beg = beg.next;
            if (beg.next == null && beg.data != data)
                return null;
            return beg;
        }

        /// <summary>
        /// Удаление элемента по номеру
        /// </summary>
        /// <param name="beg">Список</param>
        /// <param name="num">Номер</param>
        /// <returns>Результат удаления</returns>
        public static DoublyList DeleteElemNum(DoublyList beg, int num)
        {
            DoublyList del = SearchElemNum(beg, num);
            if (del == null) Console.WriteLine("Элемент не найден");
            else
                del.prev.next = del.next;
            return beg;
        }

        /// <summary>
        /// Удаление элемента по данным
        /// </summary>
        /// <param name="beg">Список</param>
        /// <param name="data">Данные</param>
        /// <returns>Результат удаления</returns>
        public static DoublyList DeleteElemData(DoublyList beg, double data)
        {
            DoublyList del = SearchElemData(beg, data);
            if (del == null) Console.WriteLine("Элемент не найден");
            else
                del.prev.next = del.next;
            return beg;
        }

        /// <summary>
        /// Вывод списка
        /// </summary>
        /// <param name="BegDoubly">Двунаправленный список</param>
        public static void ShowDoublyList(DoublyList BegDoubly)
        {
            if (BegDoubly == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            DoublyList p = BegDoubly;
            while (p != null)
            {
                Console.Write("{0}", p);
                p = p.next;
            }
            Console.WriteLine();
        }
    }

}
