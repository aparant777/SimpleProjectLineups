/*Purpose: Destroys the minions
 Attached to: Minion Destroyer*/

 using UnityEngine;

public class MinionDestroyer : MonoBehaviour {
    private void OnTriggerEnter(Collider iMinion) {
        if (iMinion.gameObject.tag == "Player") {
            Destroy(iMinion.gameObject);
            EventManager.Event_MinionDestroyed();           
        }
    }
}
