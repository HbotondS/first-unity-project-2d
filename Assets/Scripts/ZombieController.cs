using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Rigidbody2D player;

    private Vector2 _playerPos;

    private void Update()
    {
        this._playerPos = player.position;
    }


    void FixedUpdate()
    {
        var rb = this.GetComponent<Rigidbody2D>();
        var lookDir = this._playerPos - rb.position;
        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = angle;
    }
}
