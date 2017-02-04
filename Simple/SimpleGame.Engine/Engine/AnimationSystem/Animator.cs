using System;
using System.Collections.Generic;
using System.Linq;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace SimpleGame.Engine.Engine.AnimationSystem
{
    public class Animator
    {
        private Transition[] _transitions;
        private IDictionary<string, Animation> _animations;
        private Animation _currentAnimation;

        public Animator(Animation[] animations, Transition[] transitions)
        {
            InitAnimations(animations);
            _transitions = transitions;
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
            if (_currentAnimation != null && _currentAnimation.Name.Equals(name)) return;
            //_currentAnimation?.Stop();
            _currentAnimation = _animations[name];
            _currentAnimation.End += CurrentAnimationOnEnd;
            _currentAnimation.Start();
        }

        public void UpdateAnimation(SpriteGameEntity entity)
        {
            _currentAnimation.UpdateAnimation(entity);
        }

        private void CurrentAnimationOnEnd(object sender, EventArgs eventArgs)
        {
            var animation = sender as Animation;
            animation.End -= CurrentAnimationOnEnd;
            var transition = _transitions.FirstOrDefault(x => x.From.Equals(animation));
            if (transition != default (Transition)) PlayAnimation(transition.To.Name);
        }
    }
}
