/*Purpose: Destroys the minions
 Attached to: Minion Destroyer*/

 using UnityEngine;

public class MinionDestroyer : MonoBehaviour {
    private void OnTriggerEnter(Collider iMinion) {
        if (iMinion.gameObject.tag == "Player") {
            iMinion.GetComponent<Zombie>().SetMinionDead(true);
            EventManager.Event_MinionDestroyed();           
        }
    }
}
