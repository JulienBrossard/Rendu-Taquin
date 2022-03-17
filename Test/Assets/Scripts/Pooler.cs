using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler instance;
    
    private Dictionary<string, Pool> pools = new Dictionary<string, Pool>(); // Dictionaire pour les objets

    [SerializeField] private List<PoolKey> poolKeys = new List<PoolKey>(); // Clé des objets

    private int i;

    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public Queue<GameObject> queue = new Queue<GameObject>();
        public int baseCount; // Nombre d'objets
        public float baseRefreshSpeed = 5; // Vitesse de spawn au début
        public float refreshSpeed = 5; // Vitesse de rafraichissement
    }

    [System.Serializable]
    public class PoolKey
    {
        public string key;
        public Pool pool;
    }

    private void Awake()
    {
        instance = this;
        
        InitPools();
        PopulatePools();
    }


    void InitPools() // Initialiser le pooler
    {
        for (i = 0; i < poolKeys.Count; i++)
        {
            pools.Add(poolKeys[i].key, poolKeys[i].pool);
        }
    }

    void PopulatePools() // Pool.Value tous les objets
    {
        foreach (var pool in pools)
        {
            PopulatePool(pool.Value);
        }
    }

    void PopulatePool(Pool pool) // Instancie les objets
    {
        for (i = 0; i < pool.baseCount; i++)
        {
            AddInstance(pool);
        }
    }

    private GameObject objectInstance; 
    void AddInstance(Pool pool) // Instancie et désactive l'objet
    {
        objectInstance = Instantiate(pool.prefab,transform);
        objectInstance.SetActive(false);
        
        pool.queue.Enqueue(objectInstance);
    }

    private void Start() 
    {
        InitRefreshCount();
    }

    void InitRefreshCount() // Initialiation du refresh
    {
        foreach (KeyValuePair<string, Pool> pool in pools)
        {
            StartCoroutine(RefreshPool(pool.Value, pool.Value.refreshSpeed));
        }
    }

    IEnumerator RefreshPool(Pool pool, float t) // Refresh les objets
    {
        yield return new WaitForSeconds(t);
        if (pool.queue.Count < pool.baseCount)
        {
            AddInstance(pool);
            pool.refreshSpeed = pool.baseRefreshSpeed * pool.queue.Count / pool.baseCount;
        }
        
        StartCoroutine(RefreshPool(pool, pool.refreshSpeed));
    }

    public GameObject Pop(string key) // Pop un objet en fonction de leur clé
    {
        if (pools[key].queue.Count == 0)
        {
            Debug.LogWarning("Pool of "+key+" is empty");
            AddInstance(pools[key]);
        }
        
        objectInstance = pools[key].queue.Dequeue();
        objectInstance.SetActive(true);

        return objectInstance;
    }

    public void DePop(string key, GameObject go) // Dépopoe un objet en fonction de sa clé
    {
        pools[key].queue.Enqueue(go);

        go.transform.parent = transform;
        go.SetActive(false);
    }

    public void DelayedDePop(float t, string key, GameObject go) 
    {
        StartCoroutine(DelayedDePopCoroutine(t, key, go));
    }

    IEnumerator DelayedDePopCoroutine(float t, string key, GameObject go)
    {
        yield return new WaitForSeconds(t);
        DePop(key, go);
    }
}
