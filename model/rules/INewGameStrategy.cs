using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface INewGameStrategy
    {
        bool NewGame(Deck aDeck, Dealer aDealer, Player aPlayer);
    }
}
