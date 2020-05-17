using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KizunaController : MonoBehaviour
{
    public bool activo;
    Animator animaciones;
    public float countdown;
    public int estado = 0;
    // Start is called before the first frame update
    void Start()
    {
        animaciones = GetComponent<Animator>();
        countdown = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            switch (estado)
            {
                case 0:
                    animaciones.Play("Breakdance");
                    countdown = 2f;
                    estado++;
                    break;
                case 1:
                    animaciones.Play("Stabbing");
                    countdown = 2f;
                    estado--;
                    break;
                case 2:
                    animaciones.Play("Standing");
                    countdown = 4f;
                    estado--;
                    break;
                default:
                    break;
            }
        }
        countdown -= 1 * Time.deltaTime;
    }
}
