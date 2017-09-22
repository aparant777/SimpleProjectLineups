/* Purpose: Handles Minion functionality
   Attached to: Minion Spawner */

using System.Collections;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {

    public UIManager uIManager;

    private GameObject minion;
   
    private Manager manager;

    private Path[] path;

    private Object[] minionMaterials;

    private Transform minionCloneParent;    //so that the spawned minions do not clutter the hierarchy

    public float minionSpawnRate;           //rate at which minions are spawning (in seconds)

    public bool isControlledSpawnActivated;   //human spawner or AI spawner controlled

    private bool controlFlagActivated = false;
    private void Start() {
        #region REFERENCES
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        minion = Resources.Load("Prefabs/Minion") as GameObject;
        minionMaterials = Resources.LoadAll("Materials/Minion", typeof(Material));
        minionCloneParent = GameObject.Find("Minion_Parent").GetComponent<Transform>();
        path = GameObject.FindObjectsOfType<Path>();
        #endregion REFERENCES
        
        StartCoroutine(SpawnMinion());
    }

    private void Update() {

        /*************************** WORK IN PROGRESS***************************/
        //if (isControlledSpawnActivated) {
        //    if (controlFlagActivated == false) {
        //        StartCoroutine(SpawnMinion());
        //        controlFlagActivated = true;
        //    }
        //}
        /*************************** WORK IN PROGRESS***************************/
    }
    private void SelectPath(GameObject minion) {
        int pathNumber = Random.Range(0, 3);       
        minion.GetComponent<Zombie>().Setpath(path[pathNumber].gameObject);       
    }

    IEnumerator SpawnMinion() {
        while (true) {

            GameObject temp_minion = Instantiate(minion, gameObject.transform.position, Quaternion.identity) as GameObject;



            if (Run_Unit_Test_1(temp_minion)) {

                /*give each minion a unique name*/
                temp_minion.gameObject.name = "Minion" + manager.number_of_minions.ToString();

                /*assign a material to the minion*/
                temp_minion.GetComponent<MeshRenderer>().material = (Material)minionMaterials[Random.Range(0, 3)];

                /*setting all minions to a parent, so that they do not clutter the hierarchy*/
                temp_minion.transform.SetParent(minionCloneParent);

                /*assign a path to the minion*/
                SelectPath(temp_minion);

                /*signal the system that a minion has started his path*/
                //EventManager.Event_MinionInPath();

                temp_minion.GetComponent<Zombie>().minionSpeed = CONSTANTS.minionSpeed;

                /*tell the manager of the total minions, so that later they can be tracked*/
                manager.AddMinions(temp_minion);

                yield return new WaitForSeconds(manager.minion_spawn_rate);
            }
        }
    }

    bool Run_Unit_Test_1(GameObject temp) {
        Debug.Log("Testing Unit Test #1");
        if (temp) {
            Debug.Log("Unit_Test_1 passed");
            uIManager.Display_Unit_Test_1_Result("Unit_Test_1 passed");
            return true;
        }
        else {
            Debug.Log("Unit_Test_1 failed");
            uIManager.Display_Unit_Test_1_Result("Unit_Test_1 failed");
            return false;
        }
    }
}
