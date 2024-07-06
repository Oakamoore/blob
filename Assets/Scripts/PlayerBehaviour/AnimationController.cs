using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("MouseButtonHeld", true);
        }

        if (Input.GetMouseButton(1))
        {
            animator.SetBool("MouseButtonHeld", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("MouseButtonHeld", false);
        }

    }
}
