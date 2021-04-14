using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Animator feetAnimator;
    public Rigidbody2D rb;
    public Camera cam;

    private float _isRunning = 1f;
    private Vector2 _movement;
    private Vector2 _mousePos;

    // used for getting the inputs 
    void Update()
    {
        this._movement.x = Input.GetAxis("Horizontal");
        this._movement.y = Input.GetAxis("Vertical");

        this._mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        this.feetAnimator.SetFloat("speed", this._movement.y);
        this.feetAnimator.SetFloat("horizontalSpeed", this._movement.x);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.feetAnimator.SetBool("isRunning", true);
            this._isRunning = 2;
        }
        else
        {
            this.feetAnimator.SetBool("isRunning", false);
            this._isRunning = 1;
        }
    }

    // depending on the inputs move the character 
    void FixedUpdate()
    {
        this.rb.MovePosition(this.rb.position + this._movement * this._isRunning * this.movementSpeed * Time.deltaTime);

        Vector2 lookDir = this._mousePos - this.rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        this.rb.rotation = angle;
    }
}
