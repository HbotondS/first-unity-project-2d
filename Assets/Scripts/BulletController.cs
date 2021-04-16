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
}
