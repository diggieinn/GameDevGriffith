using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyActions : EnemyFiniteStateMachine
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckStateFollow();
        CheckStateWalk();
       
        ChangeState();
    }

    void CheckStateWalk()
    {
        if (_state == States.Walk)
            Walk();
    }

    void CheckStateFollow()
    {
        if (_state == States.PlayerFollow)
            PlayerFollow();
    }

    void Walk()
    {
        _agent.SetDestination(_targets.GetCurrentTargetPoint().position);
        _agent.speed = _SpeedNormal;
        _agent.stoppingDistance = 0f;

        if (GetPathRemainingDistance(_agent) < .1f)
            _targets.NextTarget();

        _animController.SetBool("IsWalk",true);
    }


    float GetPathRemainingDistance(NavMeshAgent navMeshAgent)
    {
        if (navMeshAgent.pathPending ||
            navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid ||
            navMeshAgent.path.corners.Length == 0)
            return 1f;

        float distance = 0.0f;
        for (int i = 0; i < navMeshAgent.path.corners.Length - 1; ++i)
        {
            distance += Vector3.Distance(navMeshAgent.path.corners[i], navMeshAgent.path.corners[i + 1]);
        }

        return distance;
    }

    void PlayerFollow()
    {
        if (!_target.GetComponent<Player>()._isMove)
        {
            _agent.enabled = false;
            _animController.SetTrigger("Action");
            _agent.transform.LookAt(_target);

            return;
        }


        _agent.SetDestination(_target.position);
        _agent.speed = _SpeedFollow;
        _agent.stoppingDistance = 7f;
        _animController.SetBool("IsWalk", false);


        if (Vector3.Distance(_agent.transform.position,_target.position) < 5 )
        {

            _target.GetComponent<Player>().GameOver();
        }


    }
}
