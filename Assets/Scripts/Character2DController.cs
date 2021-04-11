using System;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Animator feetAnimator;
    public Animator fistAnimator;

    private void Update()
    {
        var verticalMovement = Input.GetAxis("Vertical");
        var horizontalMovement = Input.GetAxis("Horizontal");
        var angle = (float)Math.Atan2(transform.right.y, transform.right.x);
        // Debug.Log(angle);
        transform.Translate(Quaternion.Euler(0, 0, angle) 
                            * new Vector3(verticalMovement, -horizontalMovement) 
                            * (Time.deltaTime * this.movementSpeed));

        this.feetAnimator.SetFloat("speed", verticalMovement);
        this.feetAnimator.SetFloat("horizontalSpeed", horizontalMovement);
        this.fistAnimator.SetFloat("speed", verticalMovement);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.feetAnimator.SetBool("isRunning", true);
            this.movementSpeed = 2;
        }
        else
        {
            this.feetAnimator.SetBool("isRunning", false);
            this.movementSpeed = 1;
        }
    }
}
