using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPointer : MonoBehaviour
{
    public Transform player;
    
    private Camera _camera;

    private void Start()
    {
        this._camera = Camera.main;
    }

    void Update()
    {
        var mousePosition = this._camera.ScreenToWorldPoint(Input.mousePosition);

        var perpendicular = Vector3.Cross(this.transform.position - mousePosition, Vector3.forward);
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
    }
}
