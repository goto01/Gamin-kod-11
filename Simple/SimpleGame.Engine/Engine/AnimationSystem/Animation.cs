using System;
using SDL2;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;
using SimpleGame.Engine.Engine.Helpers;
using SimpleGame.Engine.Engine.SDLEventHandler;

namespace SimpleGame.Engine.Engine.AnimationSystem
{
    public class Animation
    {
        private readonly string _name;
        private readonly Sprite[] _sprites;
        private readonly float _delay;
        private readonly bool _repeat;
        private bool _active;
        private float _timer;
        private int _spriteIndex;
        private int _delta;
        private bool _once;

        public event EventHandler End;

        public string Name { get { return _name; } }
        private Sprite CurrentSprite { get { return _sprites[_spriteIndex]; } }

        public Animation(string name, Sprite[] sprites, float delay, bool once, bool repeat = true)
        {
            _name = name;
            _sprites = sprites;
            _delay = delay;
            _repeat = repeat;
            _once = once;
        }

        public void Start()
        {
            _active = true;
            _timer = 0;
            _spriteIndex = 0;
            _delta = 1;
        }

        public void Stop()
        {
            End.Raise(this);
            _active = false;
        }

        public void UpdateAnimation(SpriteGameEntity entity)
        {
            if (!_active) return;

            if (UpdateTimer())
            {
                SwitchSprite();
            }
            UpdateSprite(entity);
        }

        private void UpdateSprite(SpriteGameEntity entity)
        {
            entity.Sprite = CurrentSprite;
        }

        private bool UpdateTimer()
        {
            _timer += Time.DeltaTime;
            if (_timer > _delay)
            {
                _timer %= _delay;
                return true;
            }
            return false;
        }

        private void SwitchSprite()
        {
            if (_spriteIndex == _sprites.Length - 1 && _once)
            {
                Stop();
                return;
            }
            if (_repeat) _spriteIndex = ++_spriteIndex%_sprites.Length;
            else
            {
                _spriteIndex += _delta;
                if (_spriteIndex == _sprites.Length-1 || _spriteIndex == 0)
                    _delta *= -1;
            }
        }
    }
}
