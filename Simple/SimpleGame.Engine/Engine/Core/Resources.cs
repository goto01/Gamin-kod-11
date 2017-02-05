using System;
using System.Collections.Generic;
using SDL2;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.Core.SDLHelpers;
using SimpleGame.Engine.Engine.SDLRenderer;

namespace SimpleGame.Engine.Engine.Core
{
    public static class Resources
    {
        private static IList<IntPtr> _importedTextures;
        private static IList<IntPtr> _importedFonts; 
        
        private const string ImportSettingsPath = "Resources/ImportSettings.json";
        private const string ResourcesPath = "Resources/";
        private const string ImageResourcePath = ResourcesPath + "png/";
        private const string FontResourcePath = ResourcesPath + "fonts/";

        public static void Init()
        {
            if (Renderer.GRenderer == default(IntPtr))
            {
                Debug.Log("You try init resources without initialization renderer!!!");
                Game.QuitFlag = true;
            }

            var imgFlags = SDL_image.IMG_InitFlags.IMG_INIT_PNG;
            if (SDL_image.IMG_Init(imgFlags)==0 & imgFlags == 0)
            {
                Debug.LogSDLError("Can't init image init");
                Game.QuitFlag = true;
            }
            if (SDL_ttf.TTF_Init() == -1)
            {
                Debug.LogSDLError("Can't init ttf");
                Game.QuitFlag = true;
            }
            if (SDL_mixer.Mix_OpenAudio(44100, SDL_mixer.MIX_DEFAULT_FORMAT, 2, 2048) < 0)
            {
                Debug.LogSDLError("Can't open sfx ");
                Game.QuitFlag = true;
            }
            //var s = SDL_mixer.Mix_LoadWAV("Resources/sfx/ost.wav");
            //SDL_mixer.Mix_PlayChannel(-1, s, 0);

            _importedTextures = new List<IntPtr>();
            _importedFonts = new List<IntPtr>();
        }

        public static IntPtr LoadFont(string name)
        {
            if (_importedFonts == null)
            {
                Debug.Log("Try to load texture before initialization!!!");
                Game.QuitFlag = true;
            }
            var font = SDL_ttf.TTF_OpenFont(FontResourcePath + name, 28);
            if (font == default(IntPtr))
            {
                Debug.LogSDLError("Can't load font " + name);
                Game.QuitFlag = true;
            }
            _importedFonts.Add(font);
            return font;
        }

        public static Texture LoadTexture(string path)
        {
            if (_importedTextures == null)
            {
                Debug.Log("Try to load texture before initialization!!!");
                Game.QuitFlag = true;
            }

            Texture texture = null;
            var sdlTexture = default(IntPtr);

            var loadedSurface = SDL_image.IMG_Load(ImageResourcePath + path);
            if (loadedSurface == default(IntPtr))
            {
                Debug.LogSDLError("Can't load surface at the path " + path);
                Game.QuitFlag = true;
            }
            else
            {
                var loadedSurfaceStruct = MarshalHelper.GetObjectFromPointer<SDL.SDL_Surface>(loadedSurface);
                sdlTexture = SDL.SDL_CreateTextureFromSurface(Renderer.GRenderer, loadedSurface);
                if (sdlTexture == default(IntPtr))
                {
                    Debug.LogSDLError("Can't create texture from surface at the path " + path);
                    Game.QuitFlag = true;
                }

                texture = new Texture(sdlTexture, loadedSurfaceStruct.w, loadedSurfaceStruct.h);

                SDL.SDL_FreeSurface(loadedSurface);
            }

            _importedTextures.Add(sdlTexture);
            return texture;
        }

        public static void FreeResources()
        {
            foreach (var texture in _importedTextures)
            {
                SDL.SDL_DestroyTexture(texture);
            }
            _importedTextures.Clear();
            _importedFonts.Clear();
        }
    }
}
