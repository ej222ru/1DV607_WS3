using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck aDeck, Dealer aDealer, Player aPlayer, DistributeCard distributeCard)
        {
//            Card c;
            distributeCard.NewCard(aDeck, aPlayer);
//            c = a_deck.GetCard();
//            c.Show(true);
//            a_player.DealCard(c);

            distributeCard.NewCard(aDeck, aDealer);
//            c = a_deck.GetCard();
//            c.Show(true);
//            a_dealer.DealCard(c);

            distributeCard.NewCard(aDeck, aPlayer);
//            c = a_deck.GetCard();
//            c.Show(true);
//            a_player.DealCard(c);

            distributeCard.NewCard(aDeck, aDealer, false);
//            c = a_deck.GetCard();
//            c.Show(false);
//            a_dealer.DealCard(c);

            return true;
        }
    }
}
