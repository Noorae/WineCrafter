using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class AnimationChecker : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        //Play animation only if game is not paused
        private void Update()
        {
            if (Time.timeScale == 0f)
            {
                animator.enabled = false;
            }
            else
            {
                animator.enabled = true;
            }
        }
    }
}



