using System;
using SDL2;

namespace SimpleGame.Engine.Engine.Core.Domain
{
    public class Texture
    {
        private IntPtr _texture;
        private int _height;
        private int _width;

        public IntPtr SDLTexture { get { return _texture; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
    
        private int _index = 0;

        public Texture(IntPtr texture, int width, int height, float scale = 1)
        {
            _width = (int)(width * scale);
            _height = (int)(height * scale);
            _texture = texture;
            
            //SDL.SDL_SetTextureColorMod(_texture, 30, 30, 30);
        }

        public Sprite GetSprite(SDL.SDL_Rect sourceRect)
        {
            if (sourceRect.x + sourceRect.w > Width || sourceRect.y + sourceRect.h > Height)
            {
                Debug.Log("You try to get too big sprite!!!");
                Game.QuitFlag = true;
            }
            return new Sprite(this, sourceRect);
        }
    }
}
