using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float power;
    public float rotation;
    private Vector2 vel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = rotation;
        StartCoroutine("SlowDown");
    }

    private void FixedUpdate()
    {
        vel = transform.right * power;
        rb.velocity = vel;
    }
    private IEnumerator SlowDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (power > 0)
            {
                power--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
