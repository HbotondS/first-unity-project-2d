using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator upperBodyAnimator;

    public float bulletForce = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && this.upperBodyAnimator.GetBool("isGunEquipped"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(this.bulletPrefab, this.firePoint.position, this.firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(this.firePoint.right * this.bulletForce, ForceMode2D.Impulse);
    }
}
