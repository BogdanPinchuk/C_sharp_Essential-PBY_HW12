using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    /// <summary>
    /// Менеджер
    /// </summary>
    class Presenter
    {
        /// <summary>
        /// Інтерфейс
        /// </summary>
        private readonly MainWindow mainWindow = null;
        /// <summary>
        /// Дані
        /// </summary>
        private readonly Model model = null;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mainWindow">Діалогове вікно</param>
        public Presenter(MainWindow mainWindow)
        {
            this.model = new Model();
            this.mainWindow = mainWindow;
            this.model.Timer.Tick += Timer_Tick;
            this.mainWindow.EventUpdate += Timer_Tick;
            this.mainWindow.EventStart += model.Start;
            this.mainWindow.EventPause += model.Pause;
            this.mainWindow.EventReset += model.Reset;
        }

        /// <summary>
        /// Періодичне виконання певних дій
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // виведення мілісекунд
            mainWindow.tbTimer.Text =
                $"{model.Stopwatch.Elapsed.Minutes}:" +
                $"{model.Stopwatch.Elapsed.Seconds}:" +
                $"{model.Stopwatch.Elapsed.Milliseconds}";
        }
    }
}
