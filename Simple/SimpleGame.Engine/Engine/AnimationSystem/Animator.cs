using System.Collections.Generic;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace SimpleGame.Engine.Engine.AnimationSystem
{
    public class Animator
    {
        private IDictionary<string, Animation> _animations;
        private Animation _currentAnimation;

        public Animator(Animation[] animations)
        {
            InitAnimations(animations);
        }

        public void InitAnimations(Animation[] animations)
        {
            _animations = new Dictionary<string, Animation>();
            for (var index = 0; index < animations.Length; index++)
            {
                _animations.Add(animations[index].Name, animations[index]);
            }
            PlayAnimation(animations[0].Name);
        }

        public void PlayAnimation(string name)
        {
            if (!_animations.ContainsKey(name))
            {
                Debug.Log("Try to set animation wich doesn't exist - " + name);
                Game.QuitFlag = true;
            }
            _currentAnimation?.Stop();
            _currentAnimation = _animations[name];
            _currentAnimation.Start();
        }

        public void UpdateAnimation(SpriteGameEntity entity)
        {
            _currentAnimation.UpdateAnimation(entity);
        }
    }
}
