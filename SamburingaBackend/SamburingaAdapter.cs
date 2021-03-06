﻿using SamburingaBackend.Cache;
using SamburingaBackend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamburingaBackend
{
    //Adapter class is for external projects to talk to. 
    public class SamburingaAdapter
    {
        public void InitializeNewGame()
        {
            AppCache.SamburingaGame = new Board(); 
        }

        public Board GetGame()
        {
            return AppCache.SamburingaGame;
        }

        public int Play(int pitNumber)
        {
            return AppCache.SamburingaGame.Play(pitNumber);
        }
    }
}
