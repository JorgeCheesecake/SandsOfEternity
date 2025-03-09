using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    public AudioSource footstepsource;
    public AudioClip footstepSound;
    public AudioSource attacksource;
    public AudioClip attacksound;
    public Animator ani;
    public AudioSource jumpsource;
    public AudioClip jumpsound;

    public void PlayFootstepSound()
    {   
        if (ani.GetBool("walk") || ani.GetBool("run"))
        {
            footstepsource.PlayOneShot(footstepSound);
        }
    }

    public void PlayAttackSound()
    {
            attacksource.PlayOneShot(attacksound);
    }

    public void PlayJumpSound()
    {
        jumpsource.PlayOneShot(jumpsound);
    }
}
