using CustomProgram.Buttons;
using SplashKitSDK;

namespace CustomProgram.State
{
    public class MainMenuState : GameState
    {
        private Menu _menu;
        private Button _button;
        private ButtonA _buttonA;
        private Window _gameWindow;
        private Music _music;

        public MainMenuState(Window window) : base()
        {
            _menu = new Menu();
            _buttonA = new ButtonA();
            _gameWindow = window;
            _music = SplashKit.LoadMusic("Menu", "MenuTheme.mp3");
            _button = new ButtonA();
        }
        public void NextState()
        {
            GameContext.GetGameInstance(_gameWindow).CurrentState = new ChooseSeedState(_gameWindow);
        }
        public void PreviousState()
        {

        }

        public void Update()
        {
            SplashKit.ProcessEvents();
            _gameWindow.Clear(Color.White);
            if (!SplashKit.MusicPlaying()) SplashKit.PlayMusic(_music, 1, 0.5f);
            SplashKit.DrawAllSprites();
            _button.CheckButtonState();
            _button.Draw();
            if (_button.IsClickedTime >= 15)
            {
                FreeAllSprites();
                FreeAllMusics();
                NextState();
            }
            _gameWindow.Refresh(60);
        }

        public void FreeAllSprites()
        {
            SplashKit.FreeAllSprites();
        }

        public void FreeAllMusics()
        {
            SplashKit.FreeAllMusic();
        }

    }
}
