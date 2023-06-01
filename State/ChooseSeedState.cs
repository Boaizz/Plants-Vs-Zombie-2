using System;
using System.Collections.Generic;
using CustomProgram.Buttons;
using CustomProgram.Cards;
using SplashKitSDK;

namespace CustomProgram.State
{
    class ChooseSeedState : GameState
    {
        private Window _gameWindow;
        private Map _map;
        private InventoryPanel _inventoryPanel;
        private SeedChosenPanel _seedChosenPanel;
        private ButtonDeselected _deselectedButton;
        private ButtonSelected _selectedButton;
        private ButtonX _buttonX;
        private ButtonY _buttonY;
        private InventoryCards _inventoryCards;
        private ChosenCards _chosenCards;
        private Card _selectedCard;
        private Card _deselectedCard;
        private Music _music;
        private List<Button> _buttons;
        public ChooseSeedState(Window window) : base()
        {
            _gameWindow = window;
            _map = new Map();
            _inventoryPanel = new InventoryPanel();
            _seedChosenPanel = new SeedChosenPanel();
            _inventoryCards = new InventoryCards();
            _chosenCards = new ChosenCards();
            _buttonX = new ButtonX();
            _buttonY = new ButtonY();
            _deselectedButton = new ButtonDeselected();
            _selectedButton = new ButtonSelected();
            _music = SplashKit.LoadMusic("ChooseSeed", "ChooseSeed.mp3");
            _buttons = new List<Button>();
            _buttons.Add(_buttonX);
            _buttons.Add(_buttonY);
            _buttons.Add(_deselectedButton);
            _buttons.Add(_selectedButton);
        }

        public void NextState()
        {
            GameContext.GetGameInstance(_gameWindow).CurrentState = new IngameState(_gameWindow, ChosenCards.Chosencards);
        }
        public void PreviousState()
        {
            GameContext.GetGameInstance(_gameWindow).CurrentState = new MainMenuState(_gameWindow);
        }

        public void Update()
        {
            SplashKit.ProcessEvents();
            _gameWindow.Clear(Color.White);
            if (!SplashKit.MusicPlaying())
            {
                SplashKit.PlayMusic(_music);
            }
            _inventoryCards.DrawInventoryCard();
            _chosenCards.DrawChosenCards();
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Point2D point = new Point2D();
                point.X = SplashKit.MouseX();
                point.Y = SplashKit.MouseY();
                if (point.X >= 350 && point.X <= 1000 && point.Y >= 160 && point.Y <= 250)      //selecting card
                {
                    PickCard(point);
                }
                else if (SplashKit.SpritePointCollision(_selectedButton.Sprite, point))
                {
                    if (_selectedCard != null)
                    {
                        _chosenCards.Add(_selectedCard);
                        _selectedCard = null;
                    }
                }
                else if (point.X >= 0 && point.X <= 785 && point.Y >= 6 && point.Y <= 91)
                {
                    DeselectCard(point);                                                            //deselecting card
                }
                else if (SplashKit.SpritePointCollision(_deselectedButton.Sprite, point))
                {
                    if (_deselectedCard != null)
                    {
                        _chosenCards.Remove(_deselectedCard);
                        _deselectedCard = null;
                    }
                }
            }

            foreach (Button button in _buttons)                    //button to change to menu state
            {
                button.CheckButtonState();
                button.Draw();
                if (button.GetType().Equals(typeof(ButtonY)))
                {
                    if (button.IsClickedTime >= 15)
                    {
                        FreeAllSprites();
                        FreeAllMusics();
                        PreviousState();
                        break;
                    }
                }
                if (button.GetType().Equals(typeof(ButtonX)))                       //button to change to ingamestate
                {
                    if (button.IsClickedTime >= 15)
                    {
                        button.IsClickedTime = 0;
                        if (ChosenCards.Chosencards.Count >= 6)
                        {
                            FreeAllSprites();
                            FreeAllMusics();
                            NextState();
                            break;
                        }
                    }
                }
            }
            SplashKit.DrawAllSprites();
            SplashKit.UpdateAllSprites();
            _gameWindow.Refresh(60);
        }
        public void FreeAllSprites()                                    //delete all sprites
        {
            SplashKit.FreeAllSprites();
            for (int i = 0; i < _inventoryCards.InventoryCard.Count; i++)
            {
                _inventoryCards.InventoryCard.Remove(_inventoryCards.InventoryCard[i]);
            }
        }

        public void FreeAllMusics()
        {
            SplashKit.FreeAllMusic();
        }

        public void PickCard(Point2D point)
        {

            foreach (Card card in _inventoryCards.InventoryCard)
            {
                if (SplashKit.SpritePointCollision(card.Sprite, point))
                {
                    _selectedCard = card;
                }
            }
        }
        public void DeselectCard(Point2D point)
        {
            foreach (Card card in _chosenCards.Chosencards)
            {
                if (SplashKit.SpritePointCollision(card.Sprite, point))
                {
                    _deselectedCard = card;
                }

            }
        }
        public ChosenCards ChosenCards
        {
            get
            {
                return _chosenCards;
            }
        }


    }
}
