using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannioBallController : MonoBehaviour
{

    public Material[] texturas = new Material[3];
    private void Start()
    {
        GetComponent<Renderer>().material = texturas[0];
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lejano")
        {
            GetComponent<Renderer>().material = texturas[1];
        }else if(other.tag == "Cercano")
        {
            GetComponent<Renderer>().material = texturas[2];
        }else if(other.tag == "Player")
        {
            other.GetComponent<FPSController>().marcador -= 15;
        }
    }
}
