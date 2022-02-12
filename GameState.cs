using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public interface GameState
    {
        public abstract void Next();
        public abstract void Previous();
        public abstract void Update();
        public abstract void FreeAllSprites();
        public abstract void FreeAllMusics();

    }
}
