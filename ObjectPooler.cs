using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    public GameObject poolObject;
    public int pooledAmount;
    public bool willGrow;

    private List<GameObject> poolObjects;

    private void Awake() 
    {
        current = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        poolObjects = new List<GameObject>();
        for(int i=0;i<pooledAmount;i++) 
        {
            GameObject obj = Instantiate(poolObject);
            obj.SetActive(false);
            poolObjects.Add(obj);   
        }    
    }

    public GameObject GetPoolObject()
    {
        for(int i=0;i<poolObjects.Count;i++)
        {
            if(!poolObjects[i].activeInHierarchy) 
            {
                return poolObjects[i];
            } 
        }
        if(willGrow) 
        {
            GameObject obj = Instantiate(poolObject);
            poolObjects.Add(obj);
            return obj;
        }   
        return null;
    }
}
