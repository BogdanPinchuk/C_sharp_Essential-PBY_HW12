using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LesApp4
{
    /// <summary>
    /// Менеджер
    /// </summary>
    class Presenter
    {
        /// <summary>
        /// Делегат дял арифметичних операцій
        /// </summary>
        private delegate double AO();

        /// <summary>
        /// Інтерфейс
        /// </summary>
        public MainWindow MainWindow { get; private set; }
        /// <summary>
        /// База даних
        /// </summary>
        public Model Model { get; private set; }
        /// <summary>
        /// Доступ до змінної A
        /// </summary>
        internal bool successA { get; private set; }
        /// <summary>
        /// Доступ до змінної B
        /// </summary>
        internal bool successB { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mainWindow"></param>
        public Presenter(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            Model = new Model();
            // підключення до подій, методів які будуть виконуватись
            MainWindow.EventKeyA += SaveA;
            MainWindow.EventKeyB += SaveB;
            // підключення подій арифметичних операцій
            MainWindow.EventAdd += Add;
            MainWindow.EventSub += Sub;
            MainWindow.EventMul += Mul;
            MainWindow.EventDiv += Div;
        }

        #region Аналіз введених даних
        /// <summary>
        /// Збереження змінної A
        /// </summary>
        private void SaveA()
        {
            double a = default(double);
            bool access = default(bool);
            Save(MainWindow.tbA, ref access, ref a);
            Model.A = a;
            successA = access;
        }
        /// <summary>
        /// Збереження змінної B
        /// </summary>
        private void SaveB()
        {
            double b = default(double);
            bool access = default(bool);
            Save(MainWindow.tbB, ref access, ref b);
            Model.B = b;
            successB = access;
        }

        /// <summary>
        /// Аналіз і збереження даних
        /// </summary>
        /// <param name="tb">текстове поле вводу</param>
        /// <param name="success">правильність введених даних</param>
        /// <param name="value">введене число</param>
        private void Save(TextBox tb, ref bool success, ref double value)
        {
            // на момент напсиання вокористовується VS 2015 і .NetFW 4.6.2
            double temp;
            success = double.TryParse(tb.Text.Replace(".", ","), out temp);

            if (success)
            {
                value = temp;
                MainWindow.tbError.Text = string.Empty;
            }
            else
            {
                MainWindow.tbError.Text = "Введені помилкові дані.";
                MainWindow.tbR.Text = "Result";
            }

        }
        #endregion

        #region Розрахунки
        /// <summary>
        /// Сума
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add(object sender, EventArgs e)
        {
            // якщо десь невірно введені дані то виходимо із методу
            if (!successA || !successB)
            {
                return;
            }

            // якщо дані введені вірно, то розраховуємо результат і виводимо на інтерфейс
            Result(Model.Add);
        }
        /// <summary>
        /// Різниця
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sub(object sender, EventArgs e)
        {
            // якщо десь невірно введені дані то виходимо із методу
            if (!successA || !successB)
            {
                return;
            }

            // якщо дані введені вірно, то розраховуємо результат і виводимо на інтерфейс
            Result(Model.Sub);
        }
        /// <summary>
        /// Добуток
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mul(object sender, EventArgs e)
        {
            // якщо десь невірно введені дані то виходимо із методу
            if (!successA || !successB)
            {
                return;
            }

            // якщо дані введені вірно, то розраховуємо результат і виводимо на інтерфейс
            Result(Model.Mul);
        }
        /// <summary>
        /// Частка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Div(object sender, EventArgs e)
        {
            // якщо десь невірно введені дані то виходимо із методу
            if (!successA || !successB)
            {
                return;
            }

            // якщо дані введені вірно, то розраховуємо результат і виводимо на інтерфейс
            Result(Model.Div);
        }

        /// <summary>
        /// Виконання арифметичних операцій
        /// </summary>
        /// <param name="delAO">делегат з арифметичною операцією</param>
        private void Result(AO delAO)
        {
            MainWindow.tbR.Text = delAO().ToString();
        } 
        #endregion

    }
}
