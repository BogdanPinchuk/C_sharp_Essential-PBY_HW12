using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LesApp2
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

        #region Події
        /// <summary>
        /// Подія запуску секундоміра
        /// </summary>
        private event Action eStart = null;
        /// <summary>
        /// Подія призупинки секундоміра
        /// </summary>
        private event Action ePause = null;
        /// <summary>
        /// Подія скидання секундоміра
        /// </summary>
        private event Action eReset = null;
        /// <summary>
        /// Подія оновлення лічильника на формі
        /// </summary>
        private event EventHandler eUpdate = null;

        /// <summary>
        /// Подія запуску
        /// </summary>
        public event Action EventStart
        {
            add { eStart += value; }
            remove { eStart -= value; }
        }
        /// <summary>
        /// Подія призупинки
        /// </summary>
        public event Action EventPause
        {
            add { ePause += value; }
            remove { ePause -= value; }
        }
        /// <summary>
        /// Подія скидання
        /// </summary>
        public event Action EventReset
        {
            add { eReset += value; }
            remove { eReset -= value; }
        }
        /// <summary>
        /// Подія оновлення
        /// </summary>
        public event EventHandler EventUpdate
        {
            add { eUpdate += value; }
            remove { eUpdate -= value; }
        } 
        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // створення менедження і передача управління графічним інтерфейсом GUI
            Presenter = new Presenter(this);
        }

        #region Обробка клавіш
        /// <summary>
        /// Дія при натисканні на клавішу Старт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtStart_Click(object sender, RoutedEventArgs e)
        {
            eStart();
        }

        /// <summary>
        /// Дія при натисканні на клавішу Пауза
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtPause_Click(object sender, RoutedEventArgs e)
        {
            ePause();
        }

        /// <summary>
        /// Дія при натисканні на клавішу Скинути
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtReset_Click(object sender, RoutedEventArgs e)
        {
            eReset();
            eUpdate(sender, e);
        } 
        #endregion

    }

}
