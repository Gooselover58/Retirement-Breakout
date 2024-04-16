using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] Weapon weaponData;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }
}

public enum weaponState
{
    Idle, Charging
}