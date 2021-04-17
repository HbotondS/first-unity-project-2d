using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Renderer _renderer;

    void Start()
    {
        this._renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!this._renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Zombie(Clone)"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
