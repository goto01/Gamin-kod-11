using System;
using System.Collections.Generic;
using System.Linq;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace SimpleGame.Engine.Engine.EntitieSystem
{
    public static class GameEntityContainer
    {
        private const int StartedNumberOfEntities = 10;

        private static int _newNumberOfEntities = StartedNumberOfEntities;
        private static GameEntity[] _entityArray;
        private static Queue<RenderableGameEntity> _renderQueue;

        private static int FirstFreeIndex
        {
            get
            {
                for (var index = 0;index<_entityArray.Length; index++)
                    if (_entityArray[index] == null) return index;
                return -1;
            }
        }

        static GameEntityContainer()
        {
            _entityArray = new GameEntity[StartedNumberOfEntities];
            _renderQueue = new Queue<RenderableGameEntity>();
        }

        public static void RegisterEntity(GameEntity entity)
        {
            var index = FirstFreeIndex;
            if (index == -1)
            {
                index = _entityArray.Length;
                ResizeEntitiesArray();
            }
            _entityArray[index] = entity;
        }

        public static void Start()
        {
            for (var index = 0; index < _entityArray.Length; index++)
            {
                if (_entityArray[index] != null) _entityArray[index].Start();
            }
        }

        public static void Update()
        {
            _renderQueue.Clear();
            for (var index = 0; index < _entityArray.Length; index++)
            {
                if (_entityArray[index] != null && _entityArray[index].Enable)
                {
                    _entityArray[index].Update();
                    if (_entityArray[index].Renderable) AddToRenderIfRenderable(_entityArray[index] as RenderableGameEntity);
                }
            }
        }

        public static T GetEntity<T>() where T : GameEntity
        {
            return _entityArray.First(x => x is T) as T;
        }

        public static Queue<RenderableGameEntity> GetRenderableEntities()
        {
            return _renderQueue;
        }

        private static void AddToRenderIfRenderable(RenderableGameEntity entity)
        {
            if (entity == null) return;
            _renderQueue.Enqueue(entity);
        }

        private static void ResizeEntitiesArray()
        {
            var newEntities = new GameEntity[_newNumberOfEntities];
            Array.Copy(_entityArray, newEntities, _entityArray.Length);
            _entityArray = newEntities;
            GC.Collect();
            IncreaseNewNumberOfEntities();
            Debug.Log("AntityArray size increased to " + _entityArray.Length);
        }

        private static void IncreaseNewNumberOfEntities()
        {
            _newNumberOfEntities *= 2;
        }
    }
}
