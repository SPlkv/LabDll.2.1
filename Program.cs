using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lab2._1
{
    class Program
    {
        [DllImport(dllName: "Lib2.1.dll", CallingConvention = CallingConvention.Cdecl)]                /* загрузка dll*/
        public static extern double TheFunc(string surname, double x);

        private static double CallTheFunc(string surname,double x)            
        {
            return TheFunc(surname, x);                     /* значение по оси y*/
        }
        private static double MyFunc(double x)             
        {
            return 9.07 * Math.Pow(x, 2) - 1.814 * x + 7.336;
            
        }

        static void Main(string[] args)
        {
            var xCoord = new List<double>();     /*координаты по оси x хранятся в списке, чтобы потом использовать для построения графика*/
            var yCoord = new List<double>();     /*координаты по оси y хранятся в списке, чтобы потом использовать для построения графика*/

            //Console.WriteLine("Введите свою фамилию: ");
            //string surname = Console.ReadLine();
            string surname = "Polkova";

            for (var x = 0; x <= 10; x += 1)       /*получение значений необходимых для построения графика*/
            {
                double call = CallTheFunc(surname,x);

                xCoord.Add(x);            
                yCoord.Add(call);
                Console.WriteLine($"{ x}  { call}");           /*для нахождения координат вершины параболы*/
            }

            var xCoord1 = new List<double>();    
            var yCoord1 = new List<double>();

            for (var x = 0; x <= 10; x += 1)        /*график с вычисленными a,b,c*/
            {
                double call1 = MyFunc(x);

                xCoord1.Add(x);
                yCoord1.Add(call1);
                
            }

            var graphic = new ScottPlot.Plot(300, 300);                   /*построение графика*/
            graphic.PlotScatter(xCoord.ToArray(), yCoord.ToArray());
            graphic.SaveFig("TheFunc.png");

            var graphic1 = new ScottPlot.Plot(300, 300);                   /*построение графика*/
            graphic.PlotScatter(xCoord1.ToArray(), yCoord1.ToArray());
            graphic.SaveFig("TheFunc1.png");

            Console.ReadLine();
        }
    }
}
