using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    public Animator animator;
    private CapsuleCollider2D capsuleCollider2D;
    void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (PlayerControl.isFire)
        {
            capsuleCollider2D.enabled = true;
            animator.SetBool("swordAnim", true);
        }
        if (!PlayerControl.isFire)
        {
            capsuleCollider2D.enabled = false;
            animator.SetBool("swordAnim", false);
        }
    }

}
