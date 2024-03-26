using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationBehaviour : MonoBehaviour
{
    public Animator animator;
    public int animationIndex;
    public GameObject dummy;

    private void SetAnimIndex()
    {
        animator.SetInteger("animationIndex", animationIndex);
    }
}
