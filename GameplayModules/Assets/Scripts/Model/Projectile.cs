using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [System.Serializable]
    public enum damageType {
        basicDamage,
        abilityDamage
    };

    public damageType damage;
    public float damagePerShot;
    public bool isActive;
    public Vector3 destination;
    public float projectileSpeed;
    
    private void Start() {
        isActive = true;
        Destroy(gameObject, 2f);
    }

    private void Update() {
        if(isActive)
            MoveProjectile();
    }

    public void MoveProjectile() {
        Debug.Log("moving");
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, destination, projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Zombie>().TakeDamage(damagePerShot, Random.Range(0, 2));
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Zombie>().TakeDamage(damagePerShot, Random.Range(0, 2));
            Destroy(gameObject);
        }
    }
}
