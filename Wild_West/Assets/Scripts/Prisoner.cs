using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prisoner : MonoBehaviour
{
    public Transform _player;
  

    Animator _anim;
    NavMeshAgent _agent;
    void Start()
    {
       _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    bool _isFree = false;
    void Update()
    {
        if (!_isFree) return;


        _agent.SetDestination(_player.position);

        if(_agent.velocity.magnitude > .5f) _anim.SetBool("IsRun", true);
        else _anim.SetBool("IsRun", false);

    }


    public void Free()
    {
        _anim.SetBool("Free", true);

        Invoke("SetAgent",.7f);
      
    }


    void SetAgent()
    {
        _isFree = true;
        _agent.enabled = true;
    }
}
