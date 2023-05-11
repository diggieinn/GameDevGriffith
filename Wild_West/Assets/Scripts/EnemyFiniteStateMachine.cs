using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFiniteStateMachine : StateMachine
{
    public NavMeshAgent _agent;
    public Animator _animController;
    public EnemyWalkTargets _targets;
    public float _targetDistance;
    public float _SpeedNormal;
    public float _SpeedFollow;


    public Transform _target;
    
    void Awake()
    {
        _target = GameObject.Find("_Player").transform;
        _targets = GetComponent<EnemyWalkTargets>();
    }

   


    public void ChangeState()
    {
        //var distance = (Vector3.Distance(_agent.transform.position, _target.position));
       // print(distance);
        if ((Vector3.Distance(_agent.transform.position, _target.position)) < _targetDistance)
        {
            _state = States.PlayerFollow;
          
        }

        else
        {
            _state = States.Walk;
        }
    }
}
