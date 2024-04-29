using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] Weapon weaponData;
    public WeaponState weaponState;
    public float throwPower;
    public WeaponPivot wp;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        throwPower = 0;
        StartCoroutine("ChargePower");
    }

    private void Update()
    {
        sr.sprite = weaponData.sprite;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weaponState = WeaponState.Charging;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && weaponState == WeaponState.Charging)
        {
            WeaponManager.Instance.SpawnThrown(weaponData, wp.angle, throwPower);
            weaponState = WeaponState.Idle;
        }
    }

    private IEnumerator ChargePower()
    {
        while (true)
        {
            if (weaponState == WeaponState.Charging && throwPower < 90)
            {
                throwPower += 2;
            }
            else if (weaponState == WeaponState.Idle)
            {
                throwPower = 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}

public enum WeaponState
{
    Idle, Charging
}