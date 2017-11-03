using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	public Manager manager;
	public GameObject zombieGO;
	public Zombie zombie;

	public float zombieHealth;
	public float zombiePosition;
	public float totalMoney;

	void Start () {
		zombieGO = GameObject.FindGameObjectWithTag ("Player");
		zombie = GameObject.FindGameObjectWithTag ("Player").GetComponent<Zombie> ();
		manager = GameObject.Find ("Manager").GetComponent<Manager> ();
	}
		
	public void Perform_Save(){
		zombieHealth = zombie.total_healthPool;
		PlayerPrefs.SetFloat ("PlayerPosition.x", zombieGO.transform.position.x);
		PlayerPrefs.SetFloat ("PlayerPosition.y", zombieGO.transform.position.y);
		PlayerPrefs.SetFloat ("PlayerPosition.z", zombieGO.transform.position.z);

		PlayerPrefs.SetFloat ("PlayerHealth",zombieHealth);
		PlayerPrefs.SetFloat ("TotalMoney", manager.totalMoney);
	}
}
