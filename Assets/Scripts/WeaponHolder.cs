using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] List<Weapon> weaponData;
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
        if (HasWeapon())
        {
            sr.sprite = weaponData[0].sprite;
        }
        else
        {
            sr.sprite = null;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && HasWeapon())
        {
            weaponState = WeaponState.Charging;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && weaponState == WeaponState.Charging && HasWeapon())
        {
            WeaponManager.Instance.SpawnThrown(weaponData[0], wp.angle, throwPower);
            weaponData[0] = null;
            SortWeapons();
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

    private void SortWeapons()
    {
        for (int i = 0; i < weaponData.Count(); i++)
        {
            if (i >= weaponData.Count() - 1)
            {
                weaponData.Remove(weaponData[i]);
            }
            else
            {
                weaponData[i] = weaponData[i + 1];
            }
        }
    }

    private bool HasWeapon()
    {
        if (weaponData.Count > 0)
        {
            if (weaponData[0] != null)
            {
                return true;
            }
        }
        return false;
    }
}

public enum WeaponState
{
    Idle, Charging
}