using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiplayerAnimationController : MonoBehaviour
{

    Animator animator;

    PhotonView photonView;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        photonView.RPC("AnimatePlayer", RpcTarget.AllViaServer);
    }

    [PunRPC]
    public void AnimatePlayer()
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
