﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerPlusWinnerStrategy : IWinnerStrategy
    {
        private const int g_maxScore = 21;
        public bool IsDealerWinner(Player a_dealer, Player a_player) 
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > g_maxScore)
            {
                return false;
            }
            return a_dealer.CalcScore() > a_player.CalcScore();
        }
    }
}
