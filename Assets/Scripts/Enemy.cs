
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public List<Transform> _observeLocation = new List<Transform>();
    public NavMeshAgent _agent;

    public State _currentState;

    public void Start()
    {
        _currentState = new Roaming(this, _agent);
    }

    public void Update()
    {
        _currentState = _currentState.Process();
    }
}
