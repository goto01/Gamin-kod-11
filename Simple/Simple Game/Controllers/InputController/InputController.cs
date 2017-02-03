using SDL2;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.SDLEventHandler;

namespace Simple_Game.Controllers.InputController
{
    class InputController : BaseController<InputController>
    {
        public override void Start()
        {
            
        }

        public override void Update()
        {
            //Debug.Log(Input.GetKey(SDL.SDL_Keycode.SDLK_UP).ToString());
        }
    }
}
