using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    public float targetDistance;
    public Camera fpsCam;
    public Text tablero;
    public int marcador;

    private void Start()
    {
        marcador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 100f))
        {
            Debug.DrawRay(transform.position, transform.
                TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.transform.tag == "Target")
            {
                hit.transform.GetComponent<CannioBallController>().Die();
                marcador += 1;
                tablero.text = "" + marcador;
            }else if (hit.transform.tag == "Target2")
            {
                hit.transform.GetComponent<CannionController>().hp -= 5;
                marcador += 2;
                tablero.text = "" + marcador;
            }
            else if (hit.transform.tag == "Target3")
            {
                hit.transform.GetComponent<NPCBallController>().Die();
                marcador += 5;
                tablero.text = "" + marcador;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.
                TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
}
