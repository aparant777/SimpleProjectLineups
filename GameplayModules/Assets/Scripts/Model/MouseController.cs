using UnityEngine;

public class MouseController : MonoBehaviour {

    // Use this for initialization
    public GameObject temp;
    public GameObject ground;
    public TowerManager towerManager;
    public Manager manager;

    private void Start() {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }
    private void Update() {

        if (manager.hasGameStarted) {

            if (Time.timeScale == 1) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Input.GetButtonDown("Fire1")) {
                    if (ground.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                        if (manager.HasenoughMoney(500)) {
                            InstantiateTower(new Vector3(hit.point.x, hit.point.y + 7.0f, hit.point.z));
                            manager.Cost_Tower(500);
                        }
                    }
                    //  Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
    }
    

    private void InstantiateTower(Vector3 towerPosition) {
        towerManager.InstntiateTower(towerPosition);
    }
}
