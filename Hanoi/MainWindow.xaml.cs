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

namespace Hanoi
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
              
        public MainWindow()
        {
            // Main method for initializing the canvas.
            InitializeComponent();
            Initialize_Hanoi();
        }

        
        private void B_Initialize_Click(object sender, RoutedEventArgs e)
        {
            // This is a mehtod for manually initializing the canvas.
            Initialize_Hanoi();
        }

        //The following four methods are used to tell the program what should happen if the movement buttons are clicked.
        private void B_Start_Support_Click(object sender, RoutedEventArgs e)
        {
            From_Start_to_Support();         
        }

        private void B_Support_Destination_Click(object sender, RoutedEventArgs e)
        {
            From_Support_to_Destination();
        }

        private void B_Support_Start_Click(object sender, RoutedEventArgs e)
        {
            From_Support_to_Start();
        }
        
        private void B_Destination_Support_Click(object sender, RoutedEventArgs e)
        {
            From_Destination_to_Support();
        }      

        private void B_Start_Destination_Click(object sender, RoutedEventArgs e)
        {
            From_Start_to_Destination();
        }

        private void B_Destination_Start_Click(object sender, RoutedEventArgs e)
        {
            From_Destination_to_Start();
        }

        private void B_Hanoi_Click(object sender, RoutedEventArgs e)
        {
            /*
            *The "Hanoi" button performs an automatic solution of the problem by using an algorithm. 
            */
            Solve_hanoi();            
        }
    }
}
