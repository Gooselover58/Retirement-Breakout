using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject obj;
    private static WeaponManager instance;

    public static WeaponManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = GameObject.FindAnyObjectByType<WeaponManager>();
            }
            return instance;
        }
    }

    public void DropWeapon(string obName)
    {
        GameObject ob = Instantiate(obj, Vector3.zero, Quaternion.identity);
        ob.name = obName;
    }
}
