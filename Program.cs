using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class Program
    {
        public static void Main()
        {
            Window myWindow = new Window("Plants And Zombies", 1248,705);
            while (!myWindow.CloseRequested)
            {
                GameContext.GetInstance(myWindow).Update();
            }
        }
    }
}
