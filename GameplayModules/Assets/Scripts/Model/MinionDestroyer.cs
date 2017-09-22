/*Purpose: Destroys the minions
 Attached to: Minion Destroyer*/

 using UnityEngine;

public class MinionDestroyer : MonoBehaviour {

    public float health;
    public float perMinionDamage;
    public UIManager uIManager;

    private void Start() {
        health = CONSTANTS.ai_base_health;
        perMinionDamage = CONSTANTS.damage_per_minion;

        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider iMinion) {
        if (iMinion.gameObject.tag == "Player") {
            iMinion.GetComponent<Zombie>().SetMinionDead(true);
            if (health > 0) {
                health -= perMinionDamage;
            }
            uIManager.UpdateAIBaseHealth_value(health);
        }
        
    }

    private void Update() {
        if(health < 0) {
            Debug.Log("BASE DEAD");
        }
    }
}
