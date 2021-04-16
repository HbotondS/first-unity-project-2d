using System.Collections.Generic;
using UnityEngine;

public class FireArmSpawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;

    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        var bounds = quad.GetComponent<MeshCollider>().bounds;

        for(var i = 0; i < numberToSpawn; i++)
        {
            var randomItem = Random.Range(0, spawnPool.Count);
            var toSpawn = spawnPool[randomItem];

            var screenX = Random.Range(bounds.min.x, bounds.max.x);
            var screenY = Random.Range(bounds.min.y, bounds.max.y);
            var pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
    
    private void DestroyObjects()
    {
        foreach(var o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }
}
