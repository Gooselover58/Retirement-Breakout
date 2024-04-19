using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPivot : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Camera cam;
    private Vector2 ogOffset;

    void Start()
    {
        player = WeaponManager.Instance.player.transform;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        ogOffset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        Vector2 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = rb.position - mouse;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.position = (Vector2)player.transform.position + ogOffset;
    }
}