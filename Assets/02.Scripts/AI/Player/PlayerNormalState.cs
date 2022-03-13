using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;

public class PlayerNormalState : StateSingleton<PlayerNormalState>, IState<PlayerEntity>  
{
    int _idleCount = 0;
    public void Enter(PlayerEntity entity)
    {
        entity.FindEnemy();
    }

    public void Execute(PlayerEntity entity)
    {
        Debug.Log($"PlayerNormalState Execute");
        if (entity.variableJoystick.Direction == Vector2.zero)
        {
            ++_idleCount;
            Debug.Log($"PlayerNormalState Execute : {_idleCount}");

            if (_idleCount > 10)
            {
                entity.FSM.ChangeState(PlayerAutoState.Instance);
            }
        }
    }

    public void Exit(PlayerEntity entity)
    {
        _idleCount = 0;
    }

    public bool OnMessage(PlayerEntity entity, Telegram telegram)
    {
        return true;
    }
}
