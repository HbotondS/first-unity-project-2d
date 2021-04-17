using UnityEngine;

public class UpperBodyController : MonoBehaviour
{
    public Animator fistAnimator;

    void Update()
    {
        this.fistAnimator.SetBool("attack", Input.GetButtonDown("Fire1"));
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.fistAnimator.SetTrigger("isReloading");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.fistAnimator.SetTrigger("meleeattack");
        }
    }
}
