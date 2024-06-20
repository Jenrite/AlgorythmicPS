using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
public float shotCooldown;
    private float lastShotTime;
    private List<GameObject> enemiesInRange = new List<GameObject>();

    public void Update() 
    {
        if (Time.time - lastShotTime >= shotCooldown) 
        {
            // TODO: Our shot is off cooldown. If there is an enemy in range,
            // shoot at the first available one.
        }
    }

    public void Shoot(GameObject target) 
    {
        // TODO: Instantiate a bullet, set its target to the enemy we want to shoot.
        // Make sure we update our lastShotTime to Time.time (see resource below).
    }

    // TODO: When an object with the "Enemy" tag enters EnemyShooter's trigger, it should add that enemy's GameObject to its list of enemies who are in range.

    // TODO: When an object with the "Enemy" tag leaves EnemyShooter's trigger, it should remove that enemy's GameObject from its list of enemies who are in range.

}

