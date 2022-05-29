using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _fristState;

    private Player _target;
    private State _currantState;

    public State Current => _currantState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_fristState);
    }

    private void Update()
    {
        if (_currantState == null)
            return;

        var nextState = _currantState.GetNexState();
        if (nextState != null)
            Transit(nextState);

    }

    private void Reset(State startState)
    {
        _currantState = startState;

        if (_currantState != null)
            _currantState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currantState != null)
            _currantState.Exit();

        _currantState = nextState;

        if (_currantState != null)
            _currantState.Enter(_target);

    }

}
