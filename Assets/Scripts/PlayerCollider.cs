using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public Animator fistAnimator;
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Pistol(Clone)"))
        {
            Destroy(other.gameObject);
            this.fistAnimator.SetBool("isGunEquipped", true);
        }
    }
}
