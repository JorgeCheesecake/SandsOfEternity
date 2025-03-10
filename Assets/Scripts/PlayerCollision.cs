using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColission : MonoBehaviour
{
    public bool CanOpen;
    public bool Open;

    void OnTriggerStay(Collider obj)
    {
        if(obj.gameObject.tag == "Cofre")
        {
            CanOpen = true;

            if(Open == true)
            {
                obj.GetComponent<Animator>().enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == "Cofre")
        {
            CanOpen = false;
        }
    }  

    public void OpenCofre()
    {
        if (CanOpen == true)
        {
            Open = true;
        }
        
    }
}