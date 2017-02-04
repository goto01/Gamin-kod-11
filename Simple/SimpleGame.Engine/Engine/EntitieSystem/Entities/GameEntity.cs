using System.Collections;
using System.Collections.Generic;

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
                if (!_coroutines[index].MoveNext()) _coroutines.RemoveAt(index--);
        }
    }
}
