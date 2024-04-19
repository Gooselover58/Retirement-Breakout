using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void SpawnThrown(Weapon weapon)
    {

    }
}
