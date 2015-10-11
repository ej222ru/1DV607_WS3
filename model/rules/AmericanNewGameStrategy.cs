using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck aDeck, Dealer aDealer, Player aPlayer)
        {
//            Card c;
              aDealer.NewCard(aDeck, aPlayer);
//            c = a_deck.GetCard();
//            c.Show(true);
//            a_player.DealCard(c);

              aDealer.NewCard(aDeck, aDealer);
//            c = a_deck.GetCard();
//            c.Show(true);
//            a_dealer.DealCard(c);

              aDealer.NewCard(aDeck, aPlayer);
//            c = a_deck.GetCard();
//            c.Show(true);
//            a_player.DealCard(c);
              int test = 1;
              test = test++;  
              aDealer.NewCard(aDeck, aDealer, false);
//            c = a_deck.GetCard();
//            c.Show(false);
//            a_dealer.DealCard(c);

            return true;
        }
    }
}
