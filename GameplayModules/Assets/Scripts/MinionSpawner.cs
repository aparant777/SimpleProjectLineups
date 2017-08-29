using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {

    private GameObject minion;
    public int maxMinion;                   //to control the maximum amount of minions on the map... (currenlty not used)
    public float minionSpawnRate;           //rate at which minions are spawning (in seconds)
  
    public Manager manager;

    public Path[] path;
    public Object[] minionMaterials;

    public Transform minionCloneParent;

    private void Start() {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        minion = Resources.Load("Prefabs/Minion") as GameObject;
        minionMaterials = Resources.LoadAll("Materials/Minion", typeof(Material));
        minionCloneParent = GameObject.Find("Minion_Clone_Parent").GetComponent<Transform>();

        StartCoroutine(SpawnMinion());
    }

    private void SelectPath(GameObject minion) {
        int pathNumber = Random.Range(0, 3);       
        minion.GetComponent<Zombie>().Setpath(path[pathNumber].gameObject);       
    }

    IEnumerator SpawnMinion() {
        while (true) {
            GameObject temp_minion = Instantiate(minion, gameObject.transform.position, Quaternion.identity) as GameObject;
            
            /*assign a material to the minion*/
            temp_minion.GetComponent<MeshRenderer>().material = (Material)minionMaterials[Random.Range(0, 3)];
            
            /*setting all minions to a parent, so that they do not clutter the hierarchy*/
            temp_minion.transform.SetParent(minionCloneParent);

            /*assign a path to the minion*/
            SelectPath(temp_minion);

            /*tell the manager of the total minions, so that later they can be tracked*/
            manager.AddMinions(temp_minion);

            yield return new WaitForSeconds(manager.minion_spawn_rate);
        }
    }
}
