using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp4
{
    /// <summary>
    /// База даних
    /// </summary>
    class Model
    {
        /// <summary>
        /// 1-й аргумент
        /// </summary>
        public double A { get; set; }
        /// <summary>
        /// 2-й аргумент
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Сума
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Add(double a, double b) => a + b;
        /// <summary>
        /// Сума
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Add() => Add(A, B);
        /// <summary>
        /// Різниця
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Sub(double a, double b) => a - b;
        /// <summary>
        /// Різниця
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// 
        /// <summary>
        /// Добуток
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Sub() => Sub(A, B);
        /// <summary>
        /// Добуток
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Mul(double a, double b) => a * b;
        /// <summary>
        /// Добуток
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Mul() => Mul(A, B);
        /// <summary>
        /// Частка
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Div(double a, double b)
        {
            double temp = default(double);

            if (a != 0 && b != 0)
            {
                temp = a / b;
            }
            if (a > 0 && b == 0)
            {
                temp = double.PositiveInfinity;
            }
            else if (a < 0 && b == 0)
            {
                temp = double.NegativeInfinity;
            }
            else if (a == 0 && b == 0)
            {
                temp = double.NaN;
            }

            return temp;
        }
        /// <summary>
        /// Частка
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Div() => Div(A, B);

    }
}
