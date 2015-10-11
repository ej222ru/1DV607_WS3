using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck aDeck, Dealer aDealer, Player aPlayer)
        {
            // Card c;
            aDealer.NewCard(aDeck, aPlayer);
            aDealer.NewCard(aDeck, aDealer);
            aDealer.NewCard(aDeck, aPlayer);
            /*
            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);

            c = a_deck.GetCard();
            c.Show(true);
            a_dealer.DealCard(c);

            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);
            */
            return true;
        }
    }
}
