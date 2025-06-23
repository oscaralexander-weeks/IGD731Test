using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

    public static GameObject SpawnObject(GameObject prefab, Vector3 spawnPosition, Quaternion spawnRotation)
    {

        //search through the pool to see if passed GameObject already exists 
        PooledObjectInfo pool = null;
        foreach(PooledObjectInfo p in ObjectPools)
        {
            if(p.LookUpString == prefab.name)
            {
                pool = p;
                break;
            }
        }

        //if the pool doesn't exist - create new pool 
        if(pool == null)
        {
            pool = new PooledObjectInfo() { LookUpString = prefab.name};
            ObjectPools.Add(pool);
        }

        //Check if there are any inactive objects in the pool
        //loop through and assign then break and return found object 

        GameObject gameObject = pool.InactiveObjects.FirstOrDefault();
        
        if(gameObject == null)
        {
            //if there are no inactive objects it must be instantiated 
            gameObject = Instantiate(prefab, spawnPosition, spawnRotation);
        }
        else
        {
            //if there is an inactive object, reactivate it 
            gameObject.transform.position = spawnPosition;
            gameObject.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(prefab);
            gameObject.SetActive(true);
        }

        return gameObject;
    }

    public static void ReturnObjectToPool(GameObject gameObject)
    {
        string goName = gameObject.name.Substring(0, gameObject.name.Length - 7);//remove CLONE from instantiated prefabs

        PooledObjectInfo pool = ObjectPools.Find(p => p.LookUpString == goName);

        if(pool == null)
        {
            Debug.LogWarning("Trying to release an object that hasn't been pooled");
        }
        else
        {
            gameObject.SetActive(false);
            pool.InactiveObjects.Add(gameObject);
        }
    }

}

public class PooledObjectInfo
{
    public string LookUpString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}
