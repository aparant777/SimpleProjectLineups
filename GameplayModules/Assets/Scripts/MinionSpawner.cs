using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {

    private GameObject minion;
    public int maxMinion;                   //to control the maximum amount of minions on the map... (currenlty not used)
    public float minionSpawnRate;           //rate at which minions are spawning (in seconds)
    public List<GameObject> totalMinions;   //just to keep track of everyone for clearing them all later and for display/events

    public Path[] path;

    private void Start() {
        minion = Resources.Load("Prefabs/Minion") as GameObject;
        StartCoroutine(SpawnMinion());
    }

    private void SelectPath(GameObject minion) {
        int pathNumber = Random.Range(0, 3);       
        minion.GetComponent<Zombie>().Setpath(path[pathNumber].gameObject);       
    }

    IEnumerator SpawnMinion() {
        while (true) {
            GameObject temp_minion = Instantiate(minion, gameObject.transform.position, Quaternion.identity) as GameObject;
            SelectPath(temp_minion);
            totalMinions.Add(temp_minion);
            yield return new WaitForSeconds(minionSpawnRate);
        }
    }
}
