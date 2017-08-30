/* Purpose: Handles Minion functionality
   Attached to: Minion Spawner */

using System.Collections;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {

    private GameObject minion;
   
    private Manager manager;

    private Path[] path;

    private Object[] minionMaterials;

    private Transform minionCloneParent;    //so that the spawned minions do not clutter the hierarchy

    public float minionSpawnRate;           //rate at which minions are spawning (in seconds)

    private void Start() {
        #region REFERENCES
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        minion = Resources.Load("Prefabs/Minion") as GameObject;
        minionMaterials = Resources.LoadAll("Materials/Minion", typeof(Material));
        minionCloneParent = GameObject.Find("Minion_Parent").GetComponent<Transform>();
        path = GameObject.FindObjectsOfType<Path>();
        #endregion REFERENCES
        StartCoroutine(SpawnMinion());
    }

    private void SelectPath(GameObject minion) {
        int pathNumber = Random.Range(0, 3);       
        minion.GetComponent<Zombie>().Setpath(path[pathNumber].gameObject);       
    }

    IEnumerator SpawnMinion() {
        while (true) {
            GameObject temp_minion = Instantiate(minion, gameObject.transform.position, Quaternion.identity) as GameObject;

            /*signal the system that a minion has spawned*/
            EventManager.Event_MinionSpawned();

            /*give each minion a unique name*/
            temp_minion.gameObject.name = "Minion" + manager.number_of_minions.ToString();

            /*assign a material to the minion*/
            temp_minion.GetComponent<MeshRenderer>().material = (Material)minionMaterials[Random.Range(0, 3)];
            
            /*setting all minions to a parent, so that they do not clutter the hierarchy*/
            temp_minion.transform.SetParent(minionCloneParent);

            /*assign a path to the minion*/
            SelectPath(temp_minion);

            /*signal the system that a minion has started his path*/
            EventManager.Event_MinionInPath();

            /*tell the manager of the total minions, so that later they can be tracked*/
            manager.AddMinions(temp_minion);

            yield return new WaitForSeconds(manager.minion_spawn_rate);
        }
    }
}
