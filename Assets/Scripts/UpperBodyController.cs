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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.name.Equals("Pistol(Clone)"))
        {
            this.fistAnimator.SetBool("isGunEquipped", true);
        }
    }
}
