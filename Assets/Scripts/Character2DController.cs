using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float movementSpeed = 1f;
    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 2f;

    private void Start()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * (Time.deltaTime * this.movementSpeed);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001)
        {
            _rigidbody2D.AddForce(new Vector2(0, this.jumpForce), ForceMode2D.Impulse);
        }
    }
}
