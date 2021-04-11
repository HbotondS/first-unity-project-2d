using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        this.transform.position = new Vector3(this.player.position.x, this.player.position.y, this.transform.position.z);
    }
}
