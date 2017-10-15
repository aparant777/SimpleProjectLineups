/* Purpose: Minion logic and respective functionality
   Attached to: NULL*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    public Path path;
    public float minionSpeed;
    private float pathLength;
    private int currrentNodeNumber;
    private Node targetNode;
    public SphereCollider evasionRadius;

    public UIManager ui;
    public Image ui_image_healthBar;
    public Text ui_text_health;
    public GameObject ps_blood;

    public GameObject destination;
    public NavMeshAgent navmesh;

    #region MINION_STATS
    public float total_healthPool;
        public float total_basicArmor;
        public float total_abilityArmor;
        public float healthRegeneration;
        public bool is_dead;
        public float currenthealthPool;
        public bool isMinionPlayerControlled;
    #endregion MINION_STATS

    void Start() {
        /*get the path length and set the starting index as 0*/
        //pathLength = path.Length;
        currrentNodeNumber = 0;

        total_healthPool = CONSTANTS.total_healthPool;
        currenthealthPool = total_healthPool;
        ui_text_health.text = total_healthPool.ToString();

        total_basicArmor = CONSTANTS.total_basicArmor;
        total_abilityArmor = CONSTANTS.total_abilityArmor;
      
        ui_image_healthBar.fillAmount = currenthealthPool / total_healthPool;

        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        navmesh = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update() {



        navmesh.SetDestination(destination.transform.position);
        /*get the node from Path array*/
        //targetNode = path.GetNode(currrentNodeNumber);

        ///*Check the minimum distance between minion and node*/
        //if (CheckDistance()) {
        //    /*go to the next node, but check if the node does not increment more than path length*/
        //    if (currrentNodeNumber < pathLength - 1)
        //        currrentNodeNumber++;
        //    else
        //        return;
        //}

        //if (currrentNodeNumber >= pathLength) {
        //    Debug.LogError("Current Node Number exceeded the array length");
        //    return;
        //}

        //MoveMinion();
        //Healing();
        UpdateUI();
    }

    private void MoveMinion() {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetNode.transform.position, minionSpeed * Time.deltaTime);        
    }

    private bool CheckDistance() {
        return Vector3.Distance(transform.position, targetNode.transform.position) < path.Radius;
    }

    public void Setpath(GameObject ipath) {
        if (ipath != null) {
            path = ipath.GetComponent<Path>();
        } else {
            Debug.LogError("Path is null");
        }
    }   

    public void TakeDamage(float damageValue, int damageType) {

        //0=basic damage, 1=ability damage
        if (total_healthPool <= 0) {
            SetMinionDead(true);
        } else {
            if (Run_Unit_Test_3(total_basicArmor, total_abilityArmor)) {
                if (damageType == 0) {
                    total_healthPool = Mathf.Clamp(total_healthPool + total_basicArmor - damageValue, 0, total_healthPool);
                }
                else {
                    total_healthPool = Mathf.Clamp(total_healthPool + total_abilityArmor - damageValue, 0, total_healthPool);
                }
            }
        }

        if(total_healthPool <= 0) {
            SetMinionDead(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        //check if 'other' is a projectile
        if (other.gameObject.tag == "projectile") {
            //apply the damage to minion from projectile
            TakeDamage(other.gameObject.GetComponent<Projectile>().damagePerShot, Random.Range(0,2));
        }
    }

    public void SetMinionDead(bool iIsDead) {
        is_dead = iIsDead;
        BIs_Dead();
    }

    public bool BIs_Dead() {
        ps_blood.SetActive(true);   //activate particle system
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Invoke("DestroyZombie", 1.2f);
        return is_dead;
    }

    public void Healing() {
        if (Run_Unit_Test_2()) {
            total_healthPool = Mathf.Clamp(total_healthPool + healthRegeneration, 0, currenthealthPool);
        }
    }

    public void UpdateUI() {
        ui_image_healthBar.fillAmount = total_healthPool / 1000f;
        ui_text_health.text = total_healthPool.ToString();
    }

    public void DestroyZombie() {
        Destroy(gameObject);
    }

    public bool IsMinionHumanControlled() {
        return isMinionPlayerControlled;
    }

    bool Run_Unit_Test_2() {
        Debug.Log("Testing Unit Test #2");

        if (CONSTANTS.total_healthPool < 0) {
            Debug.Log("Unit_Test_2 failed");
            ui.Display_Unit_Test_2_Result("Unit_Test_2 failed");
            return false;
        }
        else {
            Debug.Log("Unit_Test_2 passed");
            ui.Display_Unit_Test_2_Result("Unit_Test_2 passed");
            return true;
        }
    }

    bool Run_Unit_Test_3(float testVariable1, float testVariable2) {
        Debug.Log("Testing Unit Test #3");
        if (testVariable1 <= 0 && 
            testVariable2 <= 0) {
            Debug.Log("Unit_Test_3 failed");
            ui.Display_Unit_Test_3_Result("Unit_Test_3 failed");
            return false;
        }
        else {
            Debug.Log("Unit_Test_3 passed");
            ui.Display_Unit_Test_3_Result("Unit_Test_3 passed");
            return true;
        }
    }
}