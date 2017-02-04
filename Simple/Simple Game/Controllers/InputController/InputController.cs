using System.Collections.Generic;
using System.Linq;
using SDL2;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.SDLEventHandler;

namespace Simple_Game.Controllers.InputController
{
    class InputController : BaseController<InputController>
    {
        private IDictionary<int, char> _keys = new Dictionary<int, char>()
        {
            { (int)SDL.SDL_Keycode.SDLK_q, 'й' },
            { (int)SDL.SDL_Keycode.SDLK_w, 'ц' },
            { (int)SDL.SDL_Keycode.SDLK_e, 'у' },
            { (int)SDL.SDL_Keycode.SDLK_r, 'к' },
            { (int)SDL.SDL_Keycode.SDLK_t, 'е' },
            { (int)SDL.SDL_Keycode.SDLK_y, 'н' },
            { (int)SDL.SDL_Keycode.SDLK_u, 'г' },
            { (int)SDL.SDL_Keycode.SDLK_i, 'ш' },
            { (int)SDL.SDL_Keycode.SDLK_o, 'щ' },
            { (int)SDL.SDL_Keycode.SDLK_p, 'з' },
            { (int)SDL.SDL_Keycode.SDLK_a, 'ф' },
            { (int)SDL.SDL_Keycode.SDLK_s, 'ы' },
            { (int)SDL.SDL_Keycode.SDLK_d, 'в' },
            { (int)SDL.SDL_Keycode.SDLK_f, 'а' },
            { (int)SDL.SDL_Keycode.SDLK_g, 'п' },
            { (int)SDL.SDL_Keycode.SDLK_h, 'р' },
            { (int)SDL.SDL_Keycode.SDLK_j, 'о' },
            { (int)SDL.SDL_Keycode.SDLK_k, 'л' },
            { (int)SDL.SDL_Keycode.SDLK_l, 'д' },
            { (int)SDL.SDL_Keycode.SDLK_z, 'я' },
            { (int)SDL.SDL_Keycode.SDLK_x, 'ч' },
            { (int)SDL.SDL_Keycode.SDLK_c, 'с' },
            { (int)SDL.SDL_Keycode.SDLK_v, 'м' },
            { (int)SDL.SDL_Keycode.SDLK_b, 'и' },
            { (int)SDL.SDL_Keycode.SDLK_n, 'т' },
            { (int)SDL.SDL_Keycode.SDLK_m, 'ь' },
            { 1093, 'х' },
            { 1078, 'ж' },
            { 1101, 'э' },
            { 1073, 'б' },
            { 1102, 'ю' },
            { 1098, 'ъ' },
            { (int)SDL.SDL_Keycode.SDLK_SPACE, ' ' },
        };

        public override void Start()
        {
            
        }

        public override void Update()
        {

        }

        public bool GetBackspaceDown()
        {
            return Input.GetKeyDown(SDL.SDL_Keycode.SDLK_BACKSPACE);
        }

        public bool GetEnterDown()
        {
            return Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RETURN);
        }

        public IList<char> GetDownKeys()
        {
            var res = new List<char>();
            var keys = Input.GetDownKeys();
            for (var index = 0; index < keys.Count; index++)
            {
                char @char;
                _keys.TryGetValue((int)keys[index], out @char);
                if (@char != default(char)) res.Add(@char);
            }
            return res;
        }
    }
}
