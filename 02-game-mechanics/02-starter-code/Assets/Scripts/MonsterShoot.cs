using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    public float shotCooldown;
    private float lastShotTime;
    private List<GameObject> enemiesInRange = new List<GameObject>();
    public GameObject bulletPrefab;

    public void Update() 
    {
        if (Time.time - lastShotTime >= shotCooldown) 
        {
            // TODO: Our shot is off cooldown. If there is an enemy in range,
            // shoot at the first available one.
            if (enemiesInRange.Count > 0)
            {
                Shoot(enemiesInRange[0]);
                lastShotTime = Time.time;
            }
        }
    }

    public void Shoot(GameObject target) 
    {
        // TODO: Instantiate a bullet, set its target to the enemy we want to shoot.
        // Make sure we update our lastShotTime to Time.time (see resource below).
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet newBullet = bulletObj.GetComponent<Bullet>();
        newBullet.target = target.transform;


    }

    // TODO: When an object with the "Enemy" tag enters EnemyShooter's trigger, it should add that enemy's GameObject to its list of enemies who are in range.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }
    // TODO: When an object with the "Enemy" tag leaves EnemyShooter's trigger, it should remove that enemy's GameObject from its list of enemies who are in range.

}

