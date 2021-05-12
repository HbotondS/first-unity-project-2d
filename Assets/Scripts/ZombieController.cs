using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Animator zombieAnimator;
    public GameObject bloodSplash;

    private Vector2 _playerPos;
    private float _moveSpeed = 2f;
    private Rigidbody2D _rb;
    private bool _isWalking = false;
    
    private int damage = 10;

    private void Start()
    {
        this._rb = this.GetComponent<Rigidbody2D>();
        this.zombieAnimator.SetBool("isWalking", this._isWalking);
    }

    private void Update()
    {
        this._playerPos = playerRb.position;
    }


    void FixedUpdate()
    {
        var heading = playerRb.position - this._rb.position;
        if (heading.magnitude < 5 && !this._isWalking)
        {
            this._isWalking = true;
            this.zombieAnimator.SetBool("isWalking", this._isWalking);
        }

        if (this._isWalking)
        {
            this._rb.transform.Translate(Quaternion.Euler(0, 0, 0)  
                                         * new Vector3(1, 0)  
                                         * (Time.deltaTime * this._moveSpeed)); 
        
            var lookDir = this._playerPos - this._rb.position;
            var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

            this._rb.rotation = angle;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var othersName = other.gameObject.name;
        if (othersName.Equals("Bullet(Clone)"))
        {
            var blood = Instantiate(bloodSplash, transform.position, Quaternion.identity);
            // second argument delays the destroy 
            Destroy(gameObject, 0.2f);
            Destroy(blood, 0.2f);
        }

        if (othersName.Equals("Player"))
        {
            this.zombieAnimator.SetBool("attack", true);
            other.gameObject.GetComponent<PlayerController>().ReceiveDamage(damage);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            this.zombieAnimator.SetBool("attack", false);
        }
    }
}
