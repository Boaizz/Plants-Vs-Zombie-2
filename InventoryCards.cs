using System;
using System.Collections.Generic;
using CustomProgram.Cards;
using CustomProgram.Plants;
using SplashKitSDK;

namespace CustomProgram
{
    public class InventoryCards
    {
        private List<Card> _inventoryCards;
        public InventoryCards()
        {
            _inventoryCards = new List<Card>();
            _inventoryCards.Add(new CardPeaShooter());
            _inventoryCards.Add(new CardSunFlower());
            _inventoryCards.Add(new CardSnowpea());
            _inventoryCards.Add(new CardRepeater());
            _inventoryCards.Add(new CardPotatoMine());
            _inventoryCards.Add(new CardWallnut());
            _inventoryCards.Add(new CardSoldierPea());
            _inventoryCards.Add(new CardElectricPeashooter());

        }
        public List<Card> InventoryCard
        {
            get
            {
                return _inventoryCards;
            }
        }
        public void DrawInventoryCard()
        {
            for (int i =0; i< _inventoryCards.Count; i++)
            {
                SplashKit.SpriteSetX(_inventoryCards[i].Sprite, 350 + i * 74);
                SplashKit.SpriteSetY(_inventoryCards[i].Sprite, 160 + (i / 8) * 92);
            }
        }

     


    }
}
