using UnityEngine;
using System.Collections.Generic;

public class PoolingManager : MonoBehaviour {

    public GameObject pooledObject;
    public int amountOfObjectsToPool;
    public List<GameObject> pool;
    public Transform resetPosition;
    public bool isPoolExpandable = true;

    private void Start() {
        isPoolExpandable = true;
        InstantiatePool(amountOfObjectsToPool);
    }

    public void InstantiatePool(int totalPooledObjects) {
        for (int i = 0; i < amountOfObjectsToPool; i++) {
            GameObject temp = Instantiate(pooledObject);
            temp.SetActive(false);
            pool.Add(temp);
        }
    }

    public GameObject  GetObjectFromPool() {
        if (pool.Count > 0) {
            for (int i = 0; i < pool.Count; i++) {
                if (!pool[i].activeInHierarchy) {
                    pool[i].SetActive(true);
                    return pool[i];
                }
            }

            if (isPoolExpandable) {
                GameObject temp = Instantiate(pooledObject);
                pooledObject.SetActive(false);
                pool.Add(temp);
                return temp;
            }
            else {
                return null;
            }
        }
        else {
            return null;
        }
    }

    public void ResetObject(GameObject temp) {
        for(int i = 0; i < pool.Count; i++) {
            if(pool[i] == temp) {
                temp.SetActive(false);
                temp.transform.position = resetPosition.position;
            }
        }
    }
}
