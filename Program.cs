using SplashKitSDK;

namespace CustomProgram
{
    public class Program
    {
        public static void Main()
        {
            Window myWindow = new Window("Plants And Zombies", 1240,700);
            while (!myWindow.CloseRequested)
            {
                GameContext.GetGameInstance(myWindow).Update();
            }
        }
    }
}
