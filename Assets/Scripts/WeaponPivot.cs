using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WeaponPivot : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Camera cam;
    private WeaponHolder wh;
    private Vector2 ogOffset;
    public float angle;

    void Start()
    {
        player = WeaponManager.Instance.player.transform;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        wh = transform.GetChild(1).GetComponent<WeaponHolder>();
        wh.wp = this;
        ogOffset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        Vector2 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = rb.position - mouse;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = (wh.weaponState == WeaponState.Charging) ? angle + wh.throwPower : angle;
        rb.position = (Vector2)player.transform.position + ogOffset;
    }
}
