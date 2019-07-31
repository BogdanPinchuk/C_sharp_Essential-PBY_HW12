using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LesApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Менеджер
        /// </summary>
        internal Presenter Presenter { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            // створення менедження і передача управління графічним інтерфейсом GUI
            Presenter = new Presenter(this);
        }

        #region Події
        /// <summary>
        /// Подія аналізу 1-го аргумента
        /// </summary>
        private event Action eKeyA;
        /// <summary>
        /// Подія аналізу 2-го аргумента
        /// </summary>
        private event Action eKeyB;
        /// <summary>
        /// Сума
        /// </summary>
        private event EventHandler eAdd;
        /// <summary>
        /// Різниця
        /// </summary>
        private event EventHandler eSub;
        /// <summary>
        /// Добуток
        /// </summary>
        private event EventHandler eMul;
        /// <summary>
        /// Частка
        /// </summary>
        private event EventHandler eDiv;

        /// <summary>
        /// Аналіз 1-го аргумента
        /// </summary>
        public event Action EventKeyA
        {
            add { eKeyA += value; }
            remove { eKeyA -= value; }
        }
        /// <summary>
        /// Аналіз 2-го аргумента
        /// </summary>
        public event Action EventKeyB
        {
            add { eKeyB += value; }
            remove { eKeyB -= value; }
        }
        /// <summary>
        /// Сума
        /// </summary>
        public event EventHandler EventAdd
        {
            add { eAdd += value; }
            remove { eAdd -= value; }
        }
        /// <summary>
        /// Різниця
        /// </summary>
        public event EventHandler EventSub
        {
            add { eSub += value; }
            remove { eSub -= value; }
        }
        /// <summary>
         /// Добуток
         /// </summary>
        public event EventHandler EventMul
        {
            add { eMul += value; }
            remove { eMul -= value; }
        }
        /// <summary>
         /// Частка
         /// </summary>
        public event EventHandler EventDiv
        {
            add { eDiv += value; }
            remove { eDiv -= value; }
        }
        #endregion

        #region Обробка клавіш
        /// <summary>
        /// Сума
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAdd_Click(object sender, RoutedEventArgs e)
        {
            eKey();
            eAdd(sender, e);
        }
        /// <summary>
        /// Різниця
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSub_Click(object sender, RoutedEventArgs e)
        {
            eKey();
            eSub(sender, e);
        }
        /// <summary>
        /// Добуток
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbMul_Click(object sender, RoutedEventArgs e)
        {
            eKey();
            eMul(sender, e);
        }
        /// <summary>
        /// Частка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbDiv_Click(object sender, RoutedEventArgs e)
        {
            eKey();
            eDiv(sender, e);
        }

        /// <summary>
        /// При натисканні Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbA_KeyDown(object sender, KeyEventArgs e)
        {
            // якщо натиснуто Enter, то перевірити чи введені дані є числом
            if (e.Key == Key.Enter)
            {
                eKey();
            }
        }
        /// <summary>
        /// При натисканні Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbB_KeyDown(object sender, KeyEventArgs e)
        {
            // якщо натиснуто Enter, то перевірити чи введені дані є числом
            if (e.Key == Key.Enter)
            {
                eKey();
            }
        }

        /// <summary>
        /// Для аналізу введених даних
        /// </summary>
        private void eKey()
        {
            eKeyA();
            eKeyB();
        }
        #endregion

    }
}
