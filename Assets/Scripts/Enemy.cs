using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;


    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("arma"))
        {
            print ("Daño");
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }



    public void Comportamiento()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("Walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("Walk", true);
                    break;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position) > 2)
            {
                var lookpos = target.transform.position - transform.position;
                lookpos.y = 0;
                var rotation = Quaternion.LookRotation(lookpos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2f);
                ani.SetBool("Walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);

                ani.SetBool("Attack", false);
            }      
            else if (Vector3.Distance(transform.position, target.transform.position) < 2)
            {
                ani.SetBool("run", false);
                ani.SetBool("Walk", false);


                ani.SetBool("Attack", true);
                atacando = true;
            }      
        }
    }

    public void Final_ani()
    {
        ani.SetBool("Attack", false);
        atacando = false;
        
    }




        // Update is called once per frame
    void Update()
    {
        Comportamiento();
        Debug.Log(Vector3.Distance(transform.position, target.transform.position));
    }
}
