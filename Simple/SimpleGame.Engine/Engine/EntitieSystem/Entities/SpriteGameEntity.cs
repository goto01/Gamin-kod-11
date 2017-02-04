using System;
using SDL2;
using SimpleGame.Engine.Engine.Core.Domain;

namespace SimpleGame.Engine.Engine.EntitieSystem.Entities
{
    public abstract class SpriteGameEntity : RenderableGameEntity
    {
        protected Sprite _sprite;
        protected SDL.SDL_Color _modulationColor;
        protected Vector2 _pivot;

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public Vector2 Pivot
        {
            get { return _pivot; }
            set { _pivot = value; }
        }

        public SpriteGameEntity(Sprite sprite)
        {
            _sprite = sprite;
            _modulationColor = new SDL.SDL_Color() {r = 255, g = 255, b = 255, a = 255};
        }

        public override void RenderToRenderer(IntPtr renderer)
        {
            SetPosition();
            var dstRect = _sprite.DestinationRect;
            var srcRect = _sprite.SourceRect;
            SDL.SDL_SetTextureColorMod(_sprite.SDLTexture, _modulationColor.r, _modulationColor.g, _modulationColor.b);
            SDL.SDL_SetTextureAlphaMod(_sprite.SDLTexture, _modulationColor.a);
            var center = default(SDL.SDL_Point);
            SDL.SDL_RenderCopyEx(renderer, _sprite.SDLTexture, ref srcRect, ref dstRect, 0, ref center, Flip);
        }

        private void SetPosition()
        {
            var rect = _sprite.DestinationRect;
            rect.x = (int)Position.X - (int)(_pivot.X * _sprite.DestinationRect.w);
            rect.y = (int)Position.Y - (int)(_pivot.Y * _sprite.DestinationRect.h);
            _sprite.DestinationRect = rect;
        }
    }
}
