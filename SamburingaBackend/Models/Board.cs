using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamburingaBackend.Models
{
    public class Board
    {
        public Player CurrentPlayer { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Board()
        {
            Player1 = new Player();
            Player2 = new Player();
            CurrentPlayer = Player1;
        }

        private Player GetOpponent()
        {
            if(CurrentPlayer == Player1)
            {
                return Player2;
            }
            else if(CurrentPlayer == Player2)
            {
                return Player1;
            }
            return null;
        }

        private void ChangeTurn()
        {
            CurrentPlayer = GetOpponent();
        }

        public int Play(int pitNumber)
        {
            //For UI return integer to know if player has captured stones or last stone on Samburinga
            BoardPit pit = CurrentPlayer.PlayerPits.ElementAt(pitNumber);
            int numberOfStones = pit.NumberOfStones;
            pit.ClearStones();      //Clear current pit
            while (numberOfStones > 0)      //Sow stones 
            {
                pitNumber++;
                if (pitNumber == CurrentPlayer.PlayerPits.Count)
                {
                    //End of pits reached. Start on front
                    pitNumber = 0;
                }
                CurrentPlayer.PlayerPits.ElementAt(pitNumber).PutStone();
                numberOfStones--;
            }
            //Check if last stone landed on Samburinga
            if (pitNumber == 6)
            {
                return 1;
            }
            //Check for capturing stone. If last pit you put stone in, contains 1 stone, means it was empty. Allowed to capture stone
            if (CurrentPlayer.PlayerPits.ElementAt(pitNumber).NumberOfStones == 1)
            {
                //Capture stones
                CaptureStones(pitNumber);
                ChangeTurn();
                return 2;
            }
            ChangeTurn();       //Change turn to other player
            return 0;
        }

        private void CaptureStones(int pitNumber)
        {
            Player opponent = GetOpponent();
            BoardPit pit = opponent.PlayerPits.ElementAt(Math.Abs(pitNumber - 5));      //Find opposite pit by absolute of 5.
            int totalStones = pit.NumberOfStones + 1;
            CurrentPlayer.PutStonesToSamburinga(totalStones);       //Add captured stones to Samburinga
            pit.ClearStones();      //Clear the pit of opponent
            ((BoardPit)CurrentPlayer.PlayerPits.ElementAt(pitNumber)).ClearStones();    //Clear pit of current player
            
        }
    }
}
