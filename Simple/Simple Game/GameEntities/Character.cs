using SDL2;
using SimpleGame.Engine.Engine.AnimationSystem;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;
using SimpleGame.Engine.Engine.SDLEventHandler;

namespace Simple_Game.GameEntities
{
    class Character : AnimatedGameEntity
    {
        public float _speed = 75;

        private float Offset { get { return _speed*Time.DeltaTime; } }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKey(SDL.SDL_Keycode.SDLK_LEFT))
                TranslateHorizontal(-Offset);
            if (Input.GetKey(SDL.SDL_Keycode.SDLK_RIGHT))
                TranslateHorizontal(Offset);
        }

        public Character(Sprite sprite, Animator animator) : base(sprite, animator)
        {
        }
    }
}
