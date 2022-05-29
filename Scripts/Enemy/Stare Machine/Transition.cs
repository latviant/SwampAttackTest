using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetSet;

    protected Player Target { get; private set; }

    public State TargetState => _targetSet;

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
