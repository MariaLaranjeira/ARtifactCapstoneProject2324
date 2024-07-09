using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationController : MonoBehaviour
{
    Animator animator;
    public string animationClipName;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimationLoop());
    }

    IEnumerator PlayAnimationLoop()
    {
        while (true)
        {
            animator.Play(animationClipName);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 0.1f);
        }
    }
}
