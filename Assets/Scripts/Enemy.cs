using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;
    public Slider slider;
    public float velocidad = 1.0f; // Velocidad del enemigo
    private Rigidbody rb; // Rigidbody del enemigo
    public GameObject barrera;

    // Start is called before the first frame update
    void Start()
    { 
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>(); // Obtener el Rigidbody del enemigo
        barrera.SetActive(false);
    }

    public void Comportamiento()
    {
        if (atacando) // Verifica si el bool Attack está activo
    {
        return; // Si está activo, sale de la función Comportamiento
    }
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
                    rb.MovePosition(transform.position + transform.forward * velocidad * Time.deltaTime); // Mover el enemigo con Rigidbody
                    ani.SetBool("Walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1.3f)
            {
                var lookpos = target.transform.position - transform.position;
                lookpos.y = 0;
                var rotation = Quaternion.LookRotation(lookpos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2f);
                ani.SetBool("Walk", false);

                ani.SetBool("run", true);
                rb.MovePosition(transform.position + transform.forward * velocidad * Time.deltaTime); // Mover el enemigo con Rigidbody

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

    public void Muerte()
    {
        slider.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        barrera.SetActive(false);

    }

    public void Final_ani()
    {
        ani.SetBool("Attack", false);
        atacando = false;
    }

    public void ApareceBarrera()
    {
        barrera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0)
        {
            Comportamiento();
        }

        if (slider.value == 0)
        {
            ani.SetBool("morir", true);
        }
    }
}