using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class EntityManager : Singleton<SoundService>
    {
        private readonly Dictionary<int, BaseGameEntity> _entityDic = new();

        public void RegisterEntity(BaseGameEntity entity)
        {
            _entityDic[entity.ID] = entity;
        }

        public void RemoveEntity(BaseGameEntity entity)
        {
            _entityDic.Remove(entity.ID);
        }

        public void Reset()
        {
            _entityDic.Clear();
        }

        public BaseGameEntity GetEntityFromID(int id)
        {
            return _entityDic[id];
        }
    }
}
