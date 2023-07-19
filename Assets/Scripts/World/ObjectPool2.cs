using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class poolItem2
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}

public class ObjectPool2 : MonoBehaviour
{
    public static ObjectPool2 instance;
    public List<poolItem> items;   //items to be used
    public List<GameObject> pooledItems;   //items used
 

    private void Awake()
    {
        instance = this;
        pooledItems = new List<GameObject>();
        foreach (poolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);

            }
        }

    }
    public GameObject GetRandom()
    {   
        Utils.Shuffle(pooledItems);
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy)
            {
                return pooledItems[i];
            }
        }
        foreach (poolItem item in items)
        {
            GameObject obj = Instantiate(item.prefab);
            obj.SetActive(false);
            pooledItems.Add(obj);

            return obj;
        }
        return null;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
public static class Utils2
{
    public static System.Random r = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while(n>1)
        {
            n--;
            int k = r.Next(n +1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
};
