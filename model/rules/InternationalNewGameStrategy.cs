using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck aDeck, Dealer aDealer, Player aPlayer, DistributeCard distributeCard)
        {
            // Card c;
            distributeCard.NewCard(aDeck, aPlayer);
            distributeCard.NewCard(aDeck, aDealer);
            distributeCard.NewCard(aDeck, aPlayer);
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
