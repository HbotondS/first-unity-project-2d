using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBodyController : MonoBehaviour
{
    public Animator fistAnimator;

    void Update()
    {
        this.fistAnimator.SetBool("attack", Input.GetMouseButton(0));
    }
}
