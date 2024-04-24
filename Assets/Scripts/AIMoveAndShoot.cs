using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveAndShoot : MonoBehaviour {

    // state
    private Vector2 movementDirection;

    // local references
    private WeaponBase weapon;
    private EngineBase engine;

    void Start() 
    {
        // populate our local references
        weapon = GetComponent<WeaponBase>();
        engine = GetComponent<EngineBase>();

        // get a random direction between South-East and South-West
        float x = Random.Range(-0.5f, 0.5f);
        float y = -0.5f;
        movementDirection = new Vector2(x, y).normalized; // ensure it is normalised
    }

    // Update is called once per frame
    void Update () 
    {
        // shoot if we have a IWeapon component attached
        if (weapon != null) {
            weapon.Shoot();
        }
        
        // move our enemy if we have a EngineBase component attached
        if (engine != null) {
            engine.MoveEnemy(movementDirection);
        }

    }   
}
