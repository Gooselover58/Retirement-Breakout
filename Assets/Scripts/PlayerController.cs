using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float gottaGoFast;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 moveIt = new Vector2(x, y) * gottaGoFast;

        anim.SetFloat("X", x);
        anim.SetFloat("Speed", moveIt.sqrMagnitude);


        rb.velocity = moveIt;
    }
}
