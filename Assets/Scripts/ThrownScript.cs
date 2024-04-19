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
    }

    private void Update()
    {
        vel = Vector2.right * power;
        rb.velocity = vel;
        rb.angularVelocity = power;
    }

    private IEnumerator SlowDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (power > 0)
            {
                power = power * 0.9f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
