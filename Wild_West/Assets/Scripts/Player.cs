using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;
    public float _leftRightSpeed;
    public Animator _anim;
    public Rigidbody _rigid;
    public UserInterface ui;

    void Start()
    {
        
    }

    void Update()
    {


        Movement();
    }

    public bool _isMove = true;

    public void GameOver()
    {
        _isMove = false;
        ui.LevelFailed();

    }
    void Movement()
    {
        if (!_isMove)
        {
            return;
        }


        var v = _rigid.velocity.magnitude;

        if (v > 0) _anim.SetBool("IsRun", true);
        else _anim.SetBool("IsRun", false);


       
    }
    void Rotate()
    {
        Vector3 xzDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (xzDirection.magnitude > 0 && xzDirection != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
          Quaternion.LookRotation(xzDirection), _leftRightSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        if (!_isMove)
        {
            _rigid.velocity = Vector3.zero;
            _anim.SetBool("IsRun", false);
            return;
        }

        Move();
        Rotate();
    }

    public void Move()
    {
       // print(Input.GetAxis("Horizontal"));
        _rigid.velocity = (new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) *
            _speed * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Prisoner")
        {
            other.enabled = false;
            other.GetComponent<Prisoner>().Free();
            ui.FreePrisoners();
           
        }
    }
}
