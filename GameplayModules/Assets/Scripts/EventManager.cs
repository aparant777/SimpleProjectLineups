/* Purpose: Event manager to handle minion spawn/in path/destroy events*/

public class EventManager {

    public delegate void MinionSpawned();
    public delegate void MinionDestroyed();
    public delegate void MinionInPath();
    public delegate void MinionTakingDamage();

    public static event MinionSpawned MinionSpawnedMethods;
    public static event MinionDestroyed MinionDestroyedMethods;
    public static event MinionInPath MinionInPathMethods;
    public static event MinionTakingDamage MinionTakingDamageMethods;

    public static void Event_MinionSpawned() {
        MinionSpawnedMethods();       
    }

    public static void Event_MinionDestroyed() {
        MinionDestroyedMethods();        
    }

    public static void Event_MinionInPath() {
        MinionInPathMethods();
    }

    public static void Event_MinionTakingDamage() {
        MinionTakingDamageMethods();
    }
}
