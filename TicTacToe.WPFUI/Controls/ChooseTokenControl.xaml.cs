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
    /// Interaction logic for ChooseTokenControl.xaml
    /// </summary>
    public partial class ChooseTokenControl : UserControl
    {
        public ChooseTokenControl()
        {
            InitializeComponent();
        }

        private void choiceXBtn_Click(object sender, RoutedEventArgs e)
        {
            Global.playerToken = choiceXBtn.Content.ToString();
            Global.opponentToken = choiceOBtn.Content.ToString();
            MainWindow._mainWindow.GameContent.Content = new MainGameControl();
        }

        private void choiceOBtn_Click(object sender, RoutedEventArgs e)
        {
            Global.playerToken = choiceOBtn.Content.ToString();
            Global.opponentToken = choiceXBtn.Content.ToString();
            MainWindow._mainWindow.GameContent.Content = new MainGameControl();
        }
    }
}
