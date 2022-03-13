using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable IDE0044 // �б� ���� ������ �߰�
#pragma warning disable IDE0051 // ������ �ʴ� private ��� ����

namespace AI
{
    public class StateMachine <T> where T : MonoBehaviour
    {

        private T _owner;

        private IState<T> _currentState;

        private IState<T> _previousState;

        private IState<T> _globalState;

        public StateMachine(T owner)
        {
            _owner = owner;
            _currentState = null;
            _previousState = null;
            _globalState = null;
        }

        public void UpdateAI()
        {
            _globalState?.Execute(_owner);
            _currentState?.Execute(_owner);
        }

        public bool HandleMessage(Telegram msg)
        {
            if (_currentState != null && _currentState.OnMessage(_owner, msg))
                return true;

            if (_globalState != null && _globalState.OnMessage(_owner, msg))
                return true;

            return false;
        }

        public void ChangeState(IState<T> newState)
        {
            _previousState = _currentState;

            _currentState?.Exit(_owner);

            _currentState = newState;

            _currentState?.Enter(_owner);
        }

        public void RevertToPreviousState()
        {
            ChangeState(_previousState);
        }

        public bool IsInState(IState<T> s)
        {
            if (_currentState.GetType() == s.GetType())
                return true;

            return false;
        }

        public string GetNameOfCurrentState()
        {
            string name = string.Empty;
            name = _currentState?.GetType().Name;
            return name;
        }

        public IState<T> CurrentState { get => _currentState; set => _currentState = value; }
        public IState<T> GlobalState { get => _globalState; set => _globalState = value; }
        public IState<T> PreviousState { get => _previousState; set => _previousState = value; }
    }
}
