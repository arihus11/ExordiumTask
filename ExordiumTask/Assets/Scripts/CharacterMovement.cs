using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Utils;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 5f;
    private Vector2 _moveDirection;
    private Rigidbody2D _rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection.x = Input.GetAxisRaw("Horizontal");
        _moveDirection.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", _moveDirection.x);
        animator.SetFloat("Vertical", _moveDirection.y);
        animator.SetFloat("Speed", _moveDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {

        _rb.MovePosition(_rb.position + _moveDirection * speed * Time.fixedDeltaTime);
    }


}
