using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject toSpawn;
    public GameObject quad;
    public Camera view;
    public Rigidbody2D player;
    public GameObject bloodSplash;

    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        StartCoroutine(Waiter());
    }

    private IEnumerator Waiter()
    {
        
        var mapBounds = quad.GetComponent<MeshCollider>().bounds;

        while (true)
        {
            var pos = GeneratePos(mapBounds);

            var zombie = Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            var zombieController = zombie.GetComponent<ZombieController>();
            zombieController.player = this.player;
            zombieController.bloodSplash = this.bloodSplash;

            var secondsToWait = Random.Range(5, 10);

            yield return new WaitForSeconds(secondsToWait);   
        }
    }

    private Vector2 GeneratePos(Bounds mapBounds)
    {
        var cameraHeight = view.orthographicSize;
        var cameraWidth = view.aspect * cameraHeight;
        var cameraPos = view.transform.position;
        while (true)
        {
            var posX = Random.Range(mapBounds.min.x, mapBounds.max.x);
            var posY = Random.Range(mapBounds.min.y, mapBounds.max.y);
        
            if ((posX < (cameraPos.x - cameraWidth) || posX > (cameraPos.x + cameraWidth)) &&
                (posY < (cameraPos.y - cameraHeight) || posY > (cameraPos.y + cameraHeight)))
            {
                return new Vector2(posX, posY);
            }
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
