using System.Collections;
using System.Collections.Generic;
using SimpleGame.Engine.Engine.Coroutines;

namespace SimpleGame.Engine.Engine.EntitieSystem.Entities
{
    public abstract class GameEntity
    {
        private List<IEnumerator> _coroutines;

        public abstract bool Renderable{ get; }

        public bool Enable { get; set; }

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
