using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBallController : MonoBehaviour
{

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<FPSController>().marcador -= 25;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Room")
        {
            Die();
        }
    }
}
