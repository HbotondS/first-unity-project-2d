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

        if (other.gameObject.name.Equals("Zombie(Clone)"))
        {
            Debug.Log("before: " + this.rb.position);
            this.rb.transform.Translate(Quaternion.Euler(0, 0, 0)  
                                         * (other.gameObject.GetComponent<Rigidbody2D>().position - this.rb.position)  
                                         * (Time.deltaTime * 50));

            Debug.Log("after: " + this.rb.position);
        }
    }
}
