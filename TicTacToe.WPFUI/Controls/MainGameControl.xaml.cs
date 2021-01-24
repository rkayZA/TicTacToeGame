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
            Global.ClearPlacemements();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            clickedButton.Content = nowPlayingTokenText.Text;
            clickedButton.IsEnabled = false;
            int buttonId = int.Parse(clickedButton.Uid);
            Global.tokenPlacements[buttonId] = nowPlayingTokenText.Text;
            Global.cellsToClick -= 1;

            bool gameContinues = Global.CheckGameOver(Global.tokenPlacements);

            if (Global.cellsToClick == 0)
            {
                nowPlayingText.Text = "DRAW!!";
                nowPlayingTokenText.Visibility = Visibility.Collapsed;
                appButtons.Visibility = Visibility.Visible;
            }
            else
            {
                if (gameContinues == false)
                {
                    nowPlayingText.FontWeight = FontWeights.Bold;
                    nowPlayingText.Foreground = Brushes.Green;
                    nowPlayingText.Text = $"{ nowPlayingTokenText.Text} WINS!!! ";
                    nowPlayingTokenText.Visibility = Visibility.Collapsed;
                    appButtons.Visibility = Visibility.Visible;
                }else
                {
                    TogglePlayerToken();
                }
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

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._mainWindow.GameContent.Content = new ChooseTokenControl();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
