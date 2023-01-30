using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{

    public Animator animator;
    public NavMeshAgent enemy;

    void Update()
    {

        if (enemy.isStopped == false)
        {
            animator.SetBool("IsMoving", true);
        }

        if(enemy.isStopped == true)
        {
            animator.SetBool("IsMoving", false);
        }

    }
}
