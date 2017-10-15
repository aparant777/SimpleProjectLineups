using UnityEngine;

public class MouseController : MonoBehaviour {

    // Use this for initialization
    public GameObject temp;
    public GameObject ground;
    public TowerManager towerManager;

    private void Update() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetButtonDown("Fire1")) {
            if(ground.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                InstantiateTower(new Vector3(hit.point.x, hit.point.y + 7.0f, hit.point.z));
            }
           //  Debug.Log(hit.collider.gameObject.name);
        }        
    }
    

    private void InstantiateTower(Vector3 towerPosition) {
        towerManager.InstntiateTower(towerPosition);
    }
}
