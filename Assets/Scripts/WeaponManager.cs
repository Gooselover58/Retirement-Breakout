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
                instance = GameObject.FindObjectOfType<WeaponManager>();
            }
            return instance;
        }
    }

    public void DropWeapon(string obName, Vector3 pos)
    {
        GameObject ob = Instantiate(obj, pos, Quaternion.identity);
        ob.name = obName;
    }
}
