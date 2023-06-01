using CustomProgram.State;
using SplashKitSDK;

namespace CustomProgram
{
    public class GameContext
    {
        private GameState _state;
        private static GameContext _gameContext; //Singleton Pattern
        private GameContext(Window window)
        {
            _state = new MainMenuState(window);  //default state to main menu state
        }
        public GameState CurrentState
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public void Update()
        {
            CurrentState.Update();
        }

        public static GameContext GetGameInstance(Window window)   //get game instance 
        {
            if (_gameContext == null)
            {
                _gameContext = new GameContext(window);
            }
            return _gameContext;
        }
    }
}
