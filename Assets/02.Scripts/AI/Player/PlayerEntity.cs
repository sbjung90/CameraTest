using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;

public class PlayerEntity : MonoBehaviour
{
    private StateMachine<PlayerEntity> _FSM;
    public StateMachine<PlayerEntity> FSM { get => _FSM; }

    bool _isContinue = true;

    public VariableJoystick variableJoystick;

    public void FindEnemy()
    {
        Debug.Log($"FindEnemy");
    }

    public void FindNextSpot()
    {
        Debug.Log($"FindNextSpot");
    }

    // Start is called before the first frame update
    void Start()
    {
        _FSM = new StateMachine<PlayerEntity>(this);

        _FSM.ChangeState(PlayerNormalState.Instance);


        StartCoroutine(UpdateAI());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateAI()
    {
        while (_isContinue)
        {
            yield return new WaitForSeconds(0.2f);
            _FSM.UpdateAI();
        }
    }
}
