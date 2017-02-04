using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using SimpleGame.Engine.Engine.Coroutines;

namespace SimpleGame.Engine.Engine.EntitieSystem.Entities
{
    public abstract class GameEntity
    {
        private List<IEnumerator> _coroutines;
        private bool _enable;

        public abstract bool Renderable{ get; }

        public virtual bool Enable
        {
            get
            {
                return _enable;
            }
            set
            {
                _enable = value;
            }
        }

        public GameEntity()
        {
            Enable = true;
            _coroutines = new List<IEnumerator>();
        }

        public abstract void Start();

        public abstract void Update();

        public void StartCoroutine(IEnumerator enumerator)
        {
            _coroutines.Add(enumerator);
        }

        public void UpdateCoroutines()
        {
            for (var index = 0; index < _coroutines.Count; index++)
            {
                var current = _coroutines[index].Current as IWaitFor;
                if (current == null || current.TimeFor()) _coroutines[index].MoveNext();
            }
        }
    }
}
