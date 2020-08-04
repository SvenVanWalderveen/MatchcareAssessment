using SamburingaBackend;
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

namespace SamburingaUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SamburingaAdapter adapter = new SamburingaAdapter();
        public List<Border> player1Elements = new List<Border>();
        public List<Border> player2Elements = new List<Border>();
        public MainWindow()
        {
            InitializeComponent();
            adapter.InitializeNewGame();
            player1Elements.Add(borderPlayer1Pit0);
            player1Elements.Add(borderPlayer1Pit1);
            player1Elements.Add(borderPlayer1Pit2);
            player1Elements.Add(borderPlayer1Pit3);
            player1Elements.Add(borderPlayer1Pit4);
            player1Elements.Add(borderPlayer1Pit5);
            player1Elements.Add(borderPlayer1Pit6);

            player2Elements.Add(borderPlayer2Pit0);
            player2Elements.Add(borderPlayer2Pit1);
            player2Elements.Add(borderPlayer2Pit2);
            player2Elements.Add(borderPlayer2Pit3);
            player2Elements.Add(borderPlayer2Pit4);
            player2Elements.Add(borderPlayer2Pit5);
            player2Elements.Add(borderPlayer2Pit6);
        }

        private void Event_Click_Play(object sender, MouseButtonEventArgs e)
        {
            lblStatus.Content = "";
            //Get pitnumber
            Border label = (sender as Border);
            int pitNumber = Convert.ToInt32(label.Name.Substring(label.Name.Length - 1));
            //Play
            int playResult = adapter.Play(pitNumber);
            if(playResult != 0)
            {
                DisplayStatus(playResult);
            }
            RefreshUI();
        }

        private void DisplayStatus(int status)
        {
            if(status == 1)
            {
                lblStatus.Content = "Last stone has landed on Samburinga. Player has extra turn";
            }
            else if(status == 2)
            {
                lblStatus.Content = "Player captured stones from opponent. Turn is at player " + ((adapter.GetGame().CurrentPlayer == adapter.GetGame().Player1) ? "1" : "2");
            }
        }

        private void RefreshUI()
        {
            var currentGame = adapter.GetGame();
            lblCurrentPlayer.Content = (currentGame.CurrentPlayer == currentGame.Player1) ? "1" : "2";

            var player1 = currentGame.Player1;
            var player1Pits = player1.PlayerPits;
            for (int i = 0; i <= 6; i++)
            {
                Border borderElement = player1Elements.ElementAt(i) as Border;
                borderElement.IsEnabled = (currentGame.CurrentPlayer == currentGame.Player1) ? true : false;
                ((Label)borderElement.Child).Content = player1Pits.ElementAt(i).NumberOfStones;
            }

            var player2 = currentGame.Player2;
            var player2Pits = player2.PlayerPits;
            for (int i = 0; i <= 6; i++)
            {
                Border borderElement = player2Elements.ElementAt(i) as Border;
                borderElement.IsEnabled = (currentGame.CurrentPlayer == currentGame.Player2) ? true : false;
                ((Label)borderElement.Child).Content = player2Pits.ElementAt(i).NumberOfStones;
            }

            lblPlayer1Stones.Content = player1Pits.Sum(x => x.NumberOfStones);
            lblPlayer2Stones.Content = player2Pits.Sum(x => x.NumberOfStones);

        }
    }
}
