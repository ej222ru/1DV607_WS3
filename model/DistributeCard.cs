using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class DistributeCard
    {
        public void NewCard(Deck aDeck, Player aPlayer, bool showCard = true)
        {
            Card newCardFromDeck = aDeck.GetCard();
            newCardFromDeck.Show(showCard);
            aPlayer.DealCard(newCardFromDeck);
//            return newCardFromDeck;
        }
    }
}
