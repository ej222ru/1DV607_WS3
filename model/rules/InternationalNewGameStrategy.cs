﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck aDeck, Dealer aDealer, Player aPlayer)
        {
            aDealer.NewCard(aDeck, aPlayer);
            aDealer.NewCard(aDeck, aDealer);
            aDealer.NewCard(aDeck, aPlayer);
            return true;
        }
    }
}
