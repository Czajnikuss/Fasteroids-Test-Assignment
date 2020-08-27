using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectsPooler Instance;

    private void Awake() {
        Instance = this;
    }


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> objectsDictionary;

    void Start()
    {
        objectsDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var item in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();
            for (int i = 0; i < item.size; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }
            objectsDictionary.Add(item.tag, objPool);

        }

    }

    public GameObject SpawnFromDictionary(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = objectsDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        objectToSpawn.GetComponent<IPooledObject>().OnObjectPooled();
        
        objectsDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    public GameObject SpawnFromDictionary(string tag, Transform parentTransform)
    {
        GameObject objectToSpawn = objectsDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetParent(parentTransform);

        objectToSpawn.GetComponent<IPooledObject>().OnObjectPooled();
        
        objectsDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

   
}
