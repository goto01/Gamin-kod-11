using System;
using SDL2;
using SimpleGame.Engine.Engine.Core.Domain;

namespace SimpleGame.Engine.Engine.EntitieSystem.Entities
{
    public abstract class RenderableGameEntity : GameEntity
    {
        protected bool _horizontalFlip = false;
        protected bool _verticalFlip = false;
        private Vector2 _position;

        public override bool Renderable { get { return true; } }
        
        public SDL.SDL_RendererFlip Flip
        {
            get
            {
                var flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE;
                if (_horizontalFlip) flip |= SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL;
                if (_verticalFlip) flip |= SDL.SDL_RendererFlip.SDL_FLIP_VERTICAL;
                return flip;
            }
        }
        
        public virtual Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        
        protected void TranslateHorizontal(float offset)
        {
            var pos = Position;
            pos.X += offset;
            Position = pos;
        }

        protected void TranslateVertical(float offset)
        {
            var pos = Position;
            pos.Y += offset;
            Position = pos;
        }

        public abstract void RenderToRenderer(IntPtr renderer);
    }
}
