using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            WeaponManager.Instance.DropWeapon("WeaponIGuess", transform.position);
        }
    }
}
