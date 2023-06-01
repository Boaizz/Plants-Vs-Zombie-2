using System;
using System.Collections.Generic;
using CustomProgram.Cards;
using SplashKitSDK;

namespace CustomProgram
{
    public class ChosenCards 
    {
        List<Card> _chosenCards;
        //This constructor is used for ChooseSeedState
        public ChosenCards()
        {
            _chosenCards = new List<Card>(); //The list of cards in ChoseSeedState is initial empty
        }

        //This constructor is used for IngameState
        public ChosenCards(List<Card> chosenList) :this()
        {
            foreach (Card card in chosenList)
            {
                _chosenCards.Add((Card)Activator.CreateInstance(card.GetType())); //this list of card will be chosen in IngameState
            }
        }
        public void DrawCardsInGame()
        {
            for (int i = 0; i < _chosenCards.Count; i++)
            {
                SplashKit.SpriteSetX(_chosenCards[i].Sprite, 400 + i * 65);
                SplashKit.SpriteSetY(_chosenCards[i].Sprite, 5);
            }
        }

        public void DrawChosenCards()
        {
            for (int i = 0; i < _chosenCards.Count; i++)
            {
                SplashKit.SpriteSetX(_chosenCards[i].Sprite, 400 + i * 65);
                SplashKit.SpriteSetY(_chosenCards[i].Sprite, 5);
            }
        }

        public void Add(Card card)
        {
            _chosenCards.Add(card);
        }

        public void Remove(Card card)
        {
            _chosenCards.Remove(card);
        }

        public List<Card> Chosencards
        {
            get
            {
                return _chosenCards;
            }
        }
    }
}
