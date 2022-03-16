using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPool
    {
        public string name;
        public GameObject prefab;
        public int amount;
        public Transform parent;
        public List<GameObject> pool;
    }
    public List<ObjectPool> listOfPool;
    

    public static PoolingController instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < listOfPool.Count; i++)
        {
             GameObject obj;
            for(int a = 0; a < listOfPool[i].amount; a++)
            {
                obj = Instantiate(listOfPool[i].prefab);
                obj.SetActive(false);
                obj.transform.SetParent(listOfPool[i].parent);
                listOfPool[i].pool.Add(obj);
            } 
        }
       
    }

   public GameObject GetPoolObject(int shotType)
   {
       for(int i = 0; i < listOfPool[shotType].amount; i++)
       {
           if(!listOfPool[shotType].pool[i].activeInHierarchy)
           {
               return listOfPool[shotType].pool[i];
           }
       }

       return null;
   }
} 
