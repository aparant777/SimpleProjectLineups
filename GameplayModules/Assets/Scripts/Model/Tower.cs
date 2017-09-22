using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public float towerDamage;
    public GameObject projectile;
    public Transform projectile_SpawnPoint;

    public int TowerType;   //AOE or Projectile based

    private void Start() {
        /*************************** WORK IN PROGRESS***************************/
        /* The tower's in the game will have a consistent lifeline, and will die, 
         * after that, the AI will again spawn Tower's at in new positions*/

        /* Destroy(gameObject, CONSTANTS.tower_Lifetime);*/

        /*************************** WORK IN PROGRESS***************************/
    }

    /*For PROJECTILE based*/
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (TowerType == 1) {
                Vector3 triggeredPosition = other.gameObject.transform.position;
                ShootProjectile(triggeredPosition);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {   
            
        }
    }

    /*for Area Of Effect effect*/
    private void OnTriggerStay(Collider other) {
        if (TowerType == 0) {
            if (other.gameObject.tag == "Player") {
                other.gameObject.GetComponent<Zombie>().TakeDamage(towerDamage, Random.Range(0, 2));                
            }
        }
    }

    /*Shoot projectiles by tower*/
    private void ShootProjectile(Vector3 destination) {
        GameObject tempProjectile = Instantiate(projectile, projectile_SpawnPoint.position, Quaternion.identity);
        tempProjectile.GetComponent<Projectile>().destination = destination;
        tempProjectile.GetComponent<Projectile>().isActive = true;
    }
}
