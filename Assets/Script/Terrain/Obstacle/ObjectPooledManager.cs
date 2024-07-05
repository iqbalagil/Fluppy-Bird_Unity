using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPooledManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();
    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.lookupString == objectToSpawn.name);
        if (pool == null)
        {
            pool = new PooledObjectInfo() { lookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

            GameObject spawnableObj = pool.pooledObjects.FirstOrDefault();

            if (spawnableObj == null)
            {
                spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            }
            else
            {
                spawnableObj.transform.position = spawnPosition;
                spawnableObj.transform.rotation = spawnRotation;
                pool.pooledObjects.Remove(spawnableObj);
                spawnableObj.SetActive(true);
            }
            

        return spawnableObj;
    }

    public static void ReturnObjectToPool(GameObject obj)
        {
        string goName = obj.name.Substring(0, obj.name.Length - 7);
            
            PooledObjectInfo pool = ObjectPools.Find(p => p.lookupString == obj.name);
          if (pool == null)
        {
            Debug.LogWarning("Trying to realease an object taht is not pooled " + obj.name);
        } else
        {
            obj.SetActive(false);
            pool.pooledObjects.Add(obj);
        }
    }

}
public class PooledObjectInfo
{
    public List<GameObject> pooledObjects = new List<GameObject>();
    public int amountToPool;
    public string lookupString;

}