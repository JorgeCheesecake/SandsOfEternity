using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidosenemigo : MonoBehaviour
{
        public AudioClip footstepSound;
        public AudioSource footstepsource;
        public AudioClip attacksound;
        public AudioSource attacksource;
        public Animator ani;

        public void PlayFootstepSound()
        {
            if (ani.GetBool("Walk") || ani.GetBool("run"))
            {
                footstepsource.PlayOneShot(footstepSound);
            }
        }

        public void PlayAttackSound()
        {
            attacksource.PlayOneShot(attacksound);
        }

}
