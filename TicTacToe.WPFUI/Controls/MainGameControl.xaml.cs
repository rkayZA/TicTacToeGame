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
using TicTacToe.Library;

namespace TicTacToe.WPFUI.Controls
{
    /// <summary>
    /// Interaction logic for MainGameControl.xaml
    /// </summary>
    public partial class MainGameControl : UserControl
    {
        public MainGameControl()
        {
            InitializeComponent();
            nowPlayingTokenText.Text = Global.playerToken;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            clickedButton.Content = nowPlayingTokenText.Text;
            
            clickedButton.IsEnabled = false;
            Global.cellsToClick -= 1;
            // TODO: Check for a winning combination and end game if there is one. 
            // TODO: If all grid cells have been chosen with no winning combination end the game
            if (Global.cellsToClick == 0)
            {
                MessageBox.Show("GameOver");
            }
            else
            {
                
                TogglePlayerToken();
                
            }
           

        }

        private void TogglePlayerToken()
        {
            if (nowPlayingTokenText.Text.ToLower() == Global.playerToken.ToLower())
            {
                nowPlayingTokenText.Text = Global.opponentToken;
            }
            else
            {
                nowPlayingTokenText.Text = Global.playerToken;
            }
            
        }
    }
}
