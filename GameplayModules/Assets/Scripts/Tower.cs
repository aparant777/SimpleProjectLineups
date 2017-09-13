using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    enum TowerType {
        AOE,
        Projectile
    };

    public float towerDamage;
    public GameObject projectile;
    public Transform projectile_SpawnPoint;  

   private void OnTriggerEnter(Collider other) {

        //if(enum_TowerType == TowerType.Projectile)
        if (other.gameObject.tag == "Player") {
            Vector3 triggeredPosition = other.gameObject.transform.position;
            ShootProjectile(triggeredPosition);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("Minion exitted from here");
        }
    }

    /*for Area Of Effect effect*/
    private void OnTriggerStay(Collider other) {
        
        if (other.gameObject.tag == "Player") {
            EventManager.Event_MinionTakingDamage();
            other.gameObject.GetComponent<Zombie>().TakeDamage(towerDamage, Random.Range(0,2));
        }
    }

    /*Shoot projectiles by tower*/
    private void ShootProjectile(Vector3 destination) {
        GameObject tempProjectile = Instantiate(projectile, projectile_SpawnPoint.position, Quaternion.identity);
        tempProjectile.GetComponent<Projectile>().destination = destination;
        tempProjectile.GetComponent<Projectile>().isActive = true;
    }
}
