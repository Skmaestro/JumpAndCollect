using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCollectableSpawner : MonoBehaviour
{
    [SerializeField] private List<CollectableItem> Collectables = new List<CollectableItem>();
    [SerializeField] private int MaxCollectables = 30;
    [SerializeField] private float MaxSpread = 20f;
    [SerializeField] private float SpawnTime = 1f;
    [SerializeField] private List<CollectableItem> instantiatedCollectables = new List<CollectableItem>();
    private void Start()
    {
        instantiatedCollectables = new List<CollectableItem>();
        if (Collectables == null || Collectables.Count < 1)
        {
            Debug.LogError("SpawnList Empty");
            return;
        }
        StartCoroutine(spawnCycle());
    }
    IEnumerator spawnCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);

            instantiatedCollectables.RemoveAll(item => item == null);

            if (instantiatedCollectables.Count >= MaxCollectables)
                continue;
            Vector3 spawnPos = new Vector3(Random.Range(-MaxSpread, MaxSpread),Random.Range(.5f, 2.5f),Random.Range(-MaxSpread, MaxSpread));
            CollectableItem item = Instantiate(Collectables[Random.Range(0, Collectables.Count)], spawnPos, Quaternion.identity);
            instantiatedCollectables.Add(item);
        }
    }
}
