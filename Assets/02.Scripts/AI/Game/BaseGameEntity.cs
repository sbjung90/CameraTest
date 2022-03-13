using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class BaseGameEntity
    {
        private int _id;
        public int ID
        {
            get => _id;
            set { _id = value; _nextValidID = _id + 1; }
        }

        public int Type { get; private set; }
        public bool Tag { get; set; }

        private static int _nextValidID = 0;

        public static int GetNextValidID
        {
            get => _nextValidID;
        }

        public static void ResetNextValidID()
        {
            _nextValidID = 0;
        }

        public virtual void Update() { }
        public virtual bool HandleMessage(Telegram msg)
        {
            return false;
        }

        protected Transform transform;

        protected float _boundingRadius;

        public BaseGameEntity(int id)
        {
            ID = id;
        }
    }
}
