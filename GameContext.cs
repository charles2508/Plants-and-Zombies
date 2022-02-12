using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class GameContext
    {
        private GameState _state;
        private static GameContext _uniqueGameContext; //Singleton Pattern
        private GameContext(Window window) //private constructor
        {
            _state = new MenuState(window);
        }

        public void Update()
        {
            State.Update();
        }


        public GameState State
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

        public static GameContext GetInstance(Window window) //return the unique instance of GameContext
        {
            if (_uniqueGameContext == null)
            {
                _uniqueGameContext = new GameContext(window);
            }
            return _uniqueGameContext;
        }
    }
}
