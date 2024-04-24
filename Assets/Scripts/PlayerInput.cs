using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerInput handles all of the player specific input behaviour, and passes the input information
/// to the appropriate scripts.
/// </summary>
public class PlayerInput : MonoBehaviour
{

    // local references

    [SerializeField]
    private EngineBase engine;

    private WeaponBase weapon;
    public WeaponBase Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    void Start()
    {
        weapon = GetComponent<WeaponBase>();
        engine = GetComponent<EngineBase>();
    }

    void Update()
    {
        // read our horizontal input axis
        float horizontalInput = Input.GetAxis("Horizontal");
        // if movement input is not zero
        if (horizontalInput != 0.0f)
        {
            // ensure our engineBase Script is populated to avoid errors
            if (engine != null)
            {
                // pass our movement input to our engineBase Script
                engine.MovePlayer(horizontalInput * Vector2.right);
            }
        }

        // if we press the Fire1 button
        if (Input.GetButton("Fire1"))
        {
            // if our shootingScript is populated
            if (weapon != null)
            {
                // tell shootingScript to shoot
                weapon.Shoot();
            }
        }
    }

    /* <summary>
    SwapWeapon handles creating a new WeaponBase component based on the given weaponType. This
    will popluate the newWeapon's controls and remove the existing weapon ready for usage.
    </summary>
    <param name="weaponType">The given weaponType to swap our current weapon to, this is an enum in WeaponBase.cs</param> */
    public void SwapWeapon(WeaponType weaponType)
    {
        // make a new weapon dependent on the weaponType
        WeaponBase newWeapon = null;
        switch (weaponType)
        {
            case WeaponType.machineGun:
                newWeapon = gameObject.AddComponent<WeaponMachineGun>();
                break;
            case WeaponType.tripleShot:
                newWeapon = gameObject.AddComponent<WeaponTripleShot>();
                break;
        }

        // update the data of our newWeapon with that of our current weapon
        newWeapon.UpdateWeaponControls(weapon);
        // remove the old weapon
        Destroy(weapon);
        // set our current weapon to be the newWeapon
        weapon = newWeapon;
    }
}   
