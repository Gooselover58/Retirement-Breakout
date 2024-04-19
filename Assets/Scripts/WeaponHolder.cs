using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] Weapon weaponData;
    public WeaponState weaponState;
    public float throwPower;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        throwPower = 0;
        StartCoroutine("ChargePower");
    }

    private void Update()
    {
        sr.sprite = weaponData.sprite;
        weaponState = (Input.GetKey(KeyCode.Mouse0)) ? WeaponState.Charging : WeaponState.Idle;
    }

    private IEnumerator ChargePower()
    {
        while (true)
        {
            if (weaponState == WeaponState.Charging)
            {
                throwPower++;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

public enum WeaponState
{
    Idle, Charging
}