using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hanoi
{
    public partial class MainWindow : Window
    {
        static System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        int alarmCounter = 0;
        int i_timespan = 250;
        
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            timer.Stop();
            if (alarmCounter != 31)
            {                
                timer.IsEnabled = true;
                Steps_to_solve(alarmCounter);
                alarmCounter += 1;
            }
            // If the condition of the if function ends, the timer stops aswell.
        }

        public void Tick_Timer_Restart()
        {
            alarmCounter = 0;
            timer.IsEnabled = false;
            timer.Stop();
            timer = new System.Windows.Threading.DispatcherTimer();
            // Sets the timer interval to "i_timespan" milliseconds.
            timer.Interval = new TimeSpan(0, 0, 0, 0, i_timespan);
            /* Adds the event for the method that will 
            process the timer event to the timer. */
            timer.Tick += TimerEventProcessor;
            timer.Start();

        }

        public void Steps_to_solve(int alarm)
        {
            switch (alarm)
            {
                case 0:
                    From_Start_to_Destination();
                    break;
                case 1:
                    From_Start_to_Support();
                    break;
                case 2:
                    From_Destination_to_Support();
                    break;
                case 3:
                    From_Start_to_Destination();
                    break;
                case 4:
                    From_Support_to_Start();
                    break;
                    //1
                case 5:
                    From_Support_to_Destination();
                    break;
                case 6:
                    From_Start_to_Destination();
                    break;
                case 7:
                    From_Start_to_Support();
                    break;
                case 8:
                    From_Destination_to_Support();
                    break;
                case 9:
                    From_Destination_to_Start();
                    break;
                    //2
                case 10:
                    From_Support_to_Start(); ;
                    break;
                case 11:
                    From_Destination_to_Support();
                    break;
                case 12:
                    From_Start_to_Destination();
                    break;
                case 13:
                    From_Start_to_Support();
                    break;
                case 14:
                    From_Destination_to_Support();
                    break;
                    //3
                case 15:
                    From_Start_to_Destination();
                    break;
                case 16:
                    From_Support_to_Start();
                    break;
                case 17:
                    From_Support_to_Destination();
                    break;
                case 18:
                    From_Start_to_Destination();
                    break;
                case 19:
                    From_Support_to_Start();
                    break;
                    //4
                case 20:
                    From_Destination_to_Support();
                    break;
                case 21:
                    From_Destination_to_Start();
                    break;
                case 22:
                    From_Support_to_Start();
                    break;
                case 23:
                    From_Support_to_Destination();
                    break;
                case 24:
                    From_Start_to_Destination();
                    break;
                    //5
                case 25:
                    From_Start_to_Support();
                    break;
                case 26:
                    From_Destination_to_Support();
                    break;
                case 27:
                    From_Start_to_Destination();
                    break;
                case 28:
                    From_Support_to_Start();
                    break;
                case 29:
                    From_Support_to_Destination();
                    break;
                case 30:
                    From_Start_to_Destination();
                    break;
                default:
                    break;
            }
        }

        public void Solve_hanoi()
        {
            /*
            *The "Hanoi" button performs an automatic solution of the problem by using an algorithm. 
            */
            Initialize_Hanoi();            
            Tick_Timer_Restart();          
        }
    }
}
