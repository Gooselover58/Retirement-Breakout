using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [HideInInspector] public float power;
    [HideInInspector] public float rotation;
    [HideInInspector] public Weapon weaponData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine("WaitForAssign");
    }

    private IEnumerator WaitForAssign()
    {
        yield return new WaitUntil(() => power != 0);
        rb.rotation = rotation + 90f;
        transform.rotation = Quaternion.Euler(0, 0, rotation - 90f);
        rb.AddForce(transform.right * power, ForceMode2D.Impulse);
        sr.sprite = weaponData.sprite;
        rb.drag = weaponData.weight;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") && rb.velocity.magnitude > 20)
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Ground"))
        {
            Debug.Log(rb.velocity.magnitude);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
        }
    }
}
