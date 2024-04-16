using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float gottaGoFast;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 moveIt = new Vector2(x, y) * gottaGoFast;

        rb.velocity = moveIt;
    }
}
