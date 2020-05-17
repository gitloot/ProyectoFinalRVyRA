using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannionController : MonoBehaviour
{
    public GameObject ballCannion;
    public GameObject bodyCannion;
    public Transform playerPos;
    public float tiempoDisparo, velocidad;
    private float contador;
    public bool activo;
    public Material[] texturas = new Material[3];
    public int hp;
    public int estado;
    // Start is called before the first frame update
    void Start()
    {
        contador = tiempoDisparo;
        estado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (activo == true)
        {
            contador -= 1 * Time.deltaTime;
            if (contador <= 0)
            {
                Disparar();
                contador = tiempoDisparo;
            }
            Rutina();
        }
    }

    void Disparar()
    {
        GameObject bala = (GameObject)Instantiate(ballCannion, transform);
        bala.transform.tag = "Target";
        Vector3 normalizado = (playerPos.position - ballCannion.transform.position).normalized;
        bala.GetComponent<Rigidbody>().velocity = normalizado * velocidad;
    }

    void Rutina()
    {
        switch (estado)
        {
            case 0:
                if(activo == true)
                {
                    hp = 100;
                    bodyCannion.GetComponent<Renderer>().material = texturas[0];
                    estado++;
                }
                break;
            case 1:
                if(hp < 70)
                {
                    bodyCannion.GetComponent<Renderer>().material = texturas[1];
                    estado++;
                }
                break;
            case 2:
                if (hp < 40)
                {
                    bodyCannion.GetComponent<Renderer>().material = texturas[2];
                    estado++;
                }
                break;
            default:
                if(hp <= 0)
                {
                    Die();
                }
                break;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
