using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public interface IState<T>
    {
        void Enter(T entity);
        void Execute(T entity);
        void Exit(T entity);
        bool OnMessage(T entity, Telegram telegram);
    }
}
