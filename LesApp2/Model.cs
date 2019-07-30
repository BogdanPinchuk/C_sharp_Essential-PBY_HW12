using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace LesApp2
{
    /// <summary>
    /// База даних
    /// </summary>
    class Model
    {
        /// <summary>
        /// Таймер для виконання переіодичних дій
        /// </summary>
        public DispatcherTimer Timer { get; private set; }
        /// <summary>
        /// Секундомір
        /// </summary>
        public Stopwatch Stopwatch { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Model()
        {
            // створення таймера
            Timer = new DispatcherTimer()
            {
                // 1 тайл = 100 нс, 1000 т = 100 мс
                // частота виконання по таймеру якогось методу
                Interval = new TimeSpan(1000)
            };

            // створення секундоміра
            Stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Запуск
        /// </summary>
        public void Start()
        {
            Timer.Start();
            Stopwatch.Start();
        }

        /// <summary>
        /// Пауза
        /// </summary>
        public void Pause()
        {
            Stopwatch.Stop();
            Timer.Stop();
        }

        /// <summary>
        /// Скидання
        /// </summary>
        public void Reset()
        {
            Stopwatch.Reset();
            Timer.Stop();
        }
    }
}
