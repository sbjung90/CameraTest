using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;

public class PlayerAutoState : StateSingleton<PlayerAutoState>, IState<PlayerEntity>
{
    public void Enter(PlayerEntity entity)
    {
        entity.FindNextSpot();
    }

    public void Execute(PlayerEntity entity)
    {
        Debug.Log($"PlayerAutoState Execute");
        if (entity.variableJoystick.Direction != Vector2.zero)
        {
            entity.FSM.ChangeState(PlayerNormalState.Instance);
        }
    }

    public void Exit(PlayerEntity entity)
    {

    }

    public bool OnMessage(PlayerEntity entity, Telegram telegram)
    {
        throw new System.NotImplementedException();
    }
}
