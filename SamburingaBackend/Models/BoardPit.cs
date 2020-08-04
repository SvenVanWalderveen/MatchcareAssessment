using System;
using System.Collections.Generic;
using System.Text;

namespace SamburingaBackend.Models
{
    public class BoardPit
    {
        public int PitNumber { get; set; }
        public int NumberOfStones { get; set; }

        public BoardPit(int PitNumber) {
            this.PitNumber = PitNumber;
            NumberOfStones = 6;
        }
        public BoardPit()
        {
            this.PitNumber = 6;
            NumberOfStones = 0;
        }

        public void PutStone()
        {
            this.NumberOfStones++;
        }

        internal void ClearStones()
        {
            this.NumberOfStones = 0;
        }
    }
}
