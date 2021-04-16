using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Rigidbody2D player;

    private Vector2 _playerPos;
    private float _moveSpeed = 2f;
    private Rigidbody2D _rb;

    private void Start()
    {
        this._rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this._playerPos = player.position;
    }


    void FixedUpdate()
    {
        this._rb.transform.Translate(Quaternion.Euler(0, 0, 0)  
                            * new Vector3(1, 0)  
                            * (Time.deltaTime * this._moveSpeed)); 
        
        var lookDir = this._playerPos - this._rb.position;
        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        this._rb.rotation = angle;
    }
}
