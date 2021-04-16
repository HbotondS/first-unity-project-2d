using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public int numberToSpawn;
    public GameObject toSpawn;
    public GameObject quad;
    public Rigidbody2D player;

    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        var bounds = quad.GetComponent<MeshCollider>().bounds;

        for(var i = 0; i < numberToSpawn; i++)
        {
            var screenX = Random.Range(bounds.min.x, bounds.max.x);
            var screenY = Random.Range(bounds.min.y, bounds.max.y);
            var pos = new Vector2(screenX, screenY);

            var zombie = Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            var zombieController = zombie.GetComponent<ZombieController>();
            zombieController.player = player;
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
