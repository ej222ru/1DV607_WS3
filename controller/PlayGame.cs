using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.IBlackJackObserver
    {
        model.Game m_game;
        view.IView m_view;
        public PlayGame()
        {
            // create a setup controller 
            SetupGame setup = new SetupGame();

            // create a game with config delivered from the setup controller
            m_game = new model.Game(setup.GetWinnerAtDrawRules(), setup.GetDealer17Rules(), setup.GetGameRules());
            // Let setup controller create the game view depending on language 
            m_view = setup.GetLanguageView();

            m_game.AddSubscriber(this);
        }
        private void Display()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
        }

        public bool Play()
        {
            Display();
            UserAction userAction = m_view.GetUserAction();
            switch (userAction)
            {
                case UserAction.Play:   { m_game.NewGame(); break; }
                case UserAction.Hit:    { m_game.Hit(); break; }
                case UserAction.Stand:  { m_game.Stand(); break; }
                case UserAction.Quit :  { return false; }
                default: break;    
            }
            return true;
        }
        public void newCardDelt()
        {
            Display();
            System.Threading.Thread.Sleep(2000);
        }

    }
}
