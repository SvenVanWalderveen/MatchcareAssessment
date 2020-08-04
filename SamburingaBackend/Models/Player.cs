using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamburingaBackend.Models
{
    public class Player
    {
        public List<BoardPit> PlayerPits { get; set; }

        public Player()
        {
            PlayerPits = new List<BoardPit>();
            for (int i = 0; i < 6; i++)
            {
                PlayerPits.Add(new BoardPit(i));
            }
            PlayerPits.Add(new BoardPit());
        }

        public void PutStonesToSamburinga(int numberOfStones)
        {
            PlayerPits.Last().NumberOfStones += numberOfStones;
        }
    }
}
