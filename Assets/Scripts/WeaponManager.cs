using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject thrownOb;
    private static WeaponManager instance;

    public static WeaponManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<WeaponManager>();
            }
            return instance;
        }
    }

    public void SpawnThrown(Weapon weapon, float rotation, float power)
    {
        GameObject newThrown = Instantiate(thrownOb, player.transform.position, Quaternion.identity);
        ThrownScript ts = newThrown.GetComponent<ThrownScript>();
        ts.weaponData = weapon;
        ts.rotation = rotation;
        ts.power = power;
    }
}
