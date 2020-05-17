using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject cannion, kizuna, ballFace;
    public int estado;
    public float tiempo, velocidad;
    public Transform[] referencias = new Transform[6];
    public Text texto;
    public Material[] texturas = new Material[4];
    public Transform playerPos;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play(0);
        audio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case 0:
                kizuna.GetComponent<KizunaController>().activo = true;
                estado++;
                tiempo = 1.5f;
                break;
            case 1:
                if (tiempo <= 0)
                {
                    texto.text = "" + "Apunta al siguiente";// "Intenta acumular puntos";
                    estado++;
                    tiempo = 1.5f;
                }
                break;
            case 2:
                if (tiempo <= 0)
                {
                    texto.text = "" + "Objetivo para destruirlo";//"Destruyendo objetivos";
                    estado++;
                    tiempo = 1.5f;
                }
                break;
            case 3:
                if(tiempo <= 0)
                {
                    texto.text = "";
                    GameObject canon = (GameObject)Instantiate(cannion, referencias[0]);
                    canon.GetComponent<CannionController>().activo = true;
                    canon.transform.tag = "Target2";
                    estado++;
                }
                break;
            case 4:
                if (GameObject.FindGameObjectsWithTag("Target2").Length == 0)
                {
                    texto.text = "Muy bien";
                    estado++;
                    tiempo = 1.5f;
                    kizuna.GetComponent<KizunaController>().estado = 2;
                }
                break;
            case 5:
                if(tiempo <= 0)
                {
                    texto.text = "Pongamonos serios";
                    tiempo = 1.5f;
                    estado++;
                }
                break;
            case 6:
                if(tiempo <= 0)
                {
                    texto.text = "Acumula tantos puntos como puedas";
                    tiempo = 1.5f;
                    estado++;
                }
                break;
            case 7:
                if (tiempo <= 0)
                {
                    texto.text = "";
                    tiempo = 1.5f;
                    estado++;
                }
                break;
            case 8:
                if(tiempo <= 0 && GameObject.FindGameObjectsWithTag("Target3").Length == 0)
                {
                    GameObject canon = (GameObject)Instantiate(cannion, referencias[1]);
                    canon.GetComponent<CannionController>().activo = true;
                    canon.transform.tag = "Target2";
                    estado++;
                }
                break;
            case 9:
                if (GameObject.FindGameObjectsWithTag("Target2").Length == 0)
                {
                    GameObject canon = (GameObject)Instantiate(cannion, referencias[2]);
                    canon.GetComponent<CannionController>().activo = true;
                    canon.transform.tag = "Target2";
                    estado++;
                }
                break;
            case 10:
                if (GameObject.FindGameObjectsWithTag("Target2").Length == 0)
                {
                    GameObject canon1 = (GameObject)Instantiate(cannion, referencias[1]);
                    canon1.GetComponent<CannionController>().activo = true;
                    canon1.transform.tag = "Target2";
                    GameObject canon2 = (GameObject)Instantiate(cannion, referencias[2]);
                    canon2.GetComponent<CannionController>().activo = true;
                    canon2.transform.tag = "Target2";
                    estado++;
                }
                break;
            case 11:
                if (GameObject.FindGameObjectsWithTag("Target2").Length == 0)
                {
                    GameObject ball = (GameObject)Instantiate(ballFace, referencias[2]);
                    
                    Vector3 normalizado = (playerPos.position - ball.transform.position).normalized;
                    ball.GetComponent<Rigidbody>().velocity = normalizado * velocidad;
                    GameObject ball2 = (GameObject)Instantiate(ballFace, referencias[1]);
                    
                    Vector3 normalizado2 = (playerPos.position - ball2.transform.position).normalized;
                    ball2.GetComponent<Rigidbody>().velocity = normalizado2 * velocidad;
                    GameObject ball3 = (GameObject)Instantiate(ballFace, referencias[0]);
                    
                    Vector3 normalizado3 = (playerPos.position - ball3.transform.position).normalized;
                    ball3.GetComponent<Rigidbody>().velocity = normalizado3 * velocidad;
                    float valor = Random.value;
                    if (valor < 0.25f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[0];
                        ball2.GetComponent<Renderer>().material = texturas[0];
                        ball3.GetComponent<Renderer>().material = texturas[0];
                    }
                    else if (valor >= 0.25f || valor < 0.5f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[1];
                        ball2.GetComponent<Renderer>().material = texturas[1];
                        ball3.GetComponent<Renderer>().material = texturas[1];
                    }
                    else if (valor >= 0.5f || valor < 0.75f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[2];
                        ball2.GetComponent<Renderer>().material = texturas[2];
                        ball3.GetComponent<Renderer>().material = texturas[2];
                    }
                    else
                    {
                        ball.GetComponent<Renderer>().material = texturas[3];
                        ball2.GetComponent<Renderer>().material = texturas[3];
                        ball3.GetComponent<Renderer>().material = texturas[3];
                    }
                    ball.transform.tag = "Target3";
                    ball2.transform.tag = "Target3";
                    ball3.transform.tag = "Target3";
                    estado++;
                }
                break;
            case 12:
                if (GameObject.FindGameObjectsWithTag("Target3").Length == 0)
                {
                    GameObject ball = (GameObject)Instantiate(ballFace, referencias[2]);
                    Vector3 normalizado = (playerPos.position - ball.transform.position).normalized;
                    ball.GetComponent<Rigidbody>().velocity = normalizado * velocidad;
                    
                    GameObject ball2 = (GameObject)Instantiate(ballFace, referencias[1]);
                    Vector3 normalizado2 = (playerPos.position - ball2.transform.position).normalized;
                    ball2.GetComponent<Rigidbody>().velocity = normalizado2 * velocidad;

                    GameObject ball3 = (GameObject)Instantiate(ballFace, referencias[3]);
                    Vector3 normalizado3 = (playerPos.position - ball3.transform.position).normalized;
                    ball3.GetComponent<Rigidbody>().velocity = normalizado3 * velocidad;

                    GameObject ball4 = (GameObject)Instantiate(ballFace, referencias[4]);
                    Vector3 normalizado4 = (playerPos.position - ball4.transform.position).normalized;
                    ball4.GetComponent<Rigidbody>().velocity = normalizado4 * velocidad;


                    GameObject canon = (GameObject)Instantiate(cannion, referencias[0]);
                    canon.GetComponent<CannionController>().activo = true;
                    canon.transform.tag = "Target2";

                    float valor = Random.value;
                    if (valor < 0.25f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[0];
                        ball2.GetComponent<Renderer>().material = texturas[0];
                        ball3.GetComponent<Renderer>().material = texturas[0];
                        ball4.GetComponent<Renderer>().material = texturas[0];
                    }
                    else if (valor >= 0.25f || valor < 0.5f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[1];
                        ball2.GetComponent<Renderer>().material = texturas[1];
                        ball3.GetComponent<Renderer>().material = texturas[1];
                        ball4.GetComponent<Renderer>().material = texturas[1];
                    }
                    else if (valor >= 0.5f || valor < 0.75f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[2];
                        ball2.GetComponent<Renderer>().material = texturas[2];
                        ball3.GetComponent<Renderer>().material = texturas[2];
                        ball4.GetComponent<Renderer>().material = texturas[2];
                    }
                    else
                    {
                        ball.GetComponent<Renderer>().material = texturas[3];
                        ball2.GetComponent<Renderer>().material = texturas[3];
                        ball3.GetComponent<Renderer>().material = texturas[3];
                        ball4.GetComponent<Renderer>().material = texturas[3];
                    }
                    ball.transform.tag = "Target3";
                    ball2.transform.tag = "Target3";
                    ball3.transform.tag = "Target3";
                    ball4.transform.tag = "Target3";
                    estado++;
                }
                break;
            case 13:
                if (GameObject.FindGameObjectsWithTag("Target3").Length == 0)
                {
                    GameObject ball = (GameObject)Instantiate(ballFace, referencias[0]);
                    Vector3 normalizado = (playerPos.position - ball.transform.position).normalized;
                    ball.GetComponent<Rigidbody>().velocity = normalizado * velocidad;

                    GameObject ball2 = (GameObject)Instantiate(ballFace, referencias[5]);
                    Vector3 normalizado2 = (playerPos.position - ball2.transform.position).normalized;
                    ball2.GetComponent<Rigidbody>().velocity = normalizado2 * velocidad;

                    GameObject ball3 = (GameObject)Instantiate(ballFace, referencias[6]);
                    Vector3 normalizado3 = (playerPos.position - ball3.transform.position).normalized;
                    ball3.GetComponent<Rigidbody>().velocity = normalizado3 * velocidad;

                    GameObject ball4 = (GameObject)Instantiate(ballFace, referencias[7]);
                    Vector3 normalizado4 = (playerPos.position - ball4.transform.position).normalized;
                    ball4.GetComponent<Rigidbody>().velocity = normalizado4 * velocidad;

                    GameObject ball5 = (GameObject)Instantiate(ballFace, referencias[8]);
                    Vector3 normalizado5 = (playerPos.position - ball5.transform.position).normalized;
                    ball5.GetComponent<Rigidbody>().velocity = normalizado5 * velocidad;

                    GameObject ball6 = (GameObject)Instantiate(ballFace, referencias[9]);
                    Vector3 normalizado6 = (playerPos.position - ball6.transform.position).normalized;
                    ball6.GetComponent<Rigidbody>().velocity = normalizado6 * velocidad;

                    GameObject ball7 = (GameObject)Instantiate(ballFace, referencias[10]);
                    Vector3 normalizado7 = (playerPos.position - ball7.transform.position).normalized;
                    ball7.GetComponent<Rigidbody>().velocity = normalizado7 * velocidad;

                    GameObject ball8 = (GameObject)Instantiate(ballFace, referencias[11]);
                    Vector3 normalizado8 = (playerPos.position - ball8.transform.position).normalized;
                    ball8.GetComponent<Rigidbody>().velocity = normalizado8 * velocidad;

                    GameObject ball9 = (GameObject)Instantiate(ballFace, referencias[12]);
                    Vector3 normalizado9 = (playerPos.position - ball9.transform.position).normalized;
                    ball9.GetComponent<Rigidbody>().velocity = normalizado9 * velocidad;

                    float valor = Random.value;
                    if (valor < 0.25f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[0];
                        ball2.GetComponent<Renderer>().material = texturas[0];
                        ball3.GetComponent<Renderer>().material = texturas[0];
                        ball4.GetComponent<Renderer>().material = texturas[0];
                        ball5.GetComponent<Renderer>().material = texturas[0];
                        ball6.GetComponent<Renderer>().material = texturas[0];
                        ball7.GetComponent<Renderer>().material = texturas[0];
                        ball8.GetComponent<Renderer>().material = texturas[0];
                        ball9.GetComponent<Renderer>().material = texturas[0];
                    }
                    else if (valor >= 0.25f || valor < 0.5f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[1];
                        ball2.GetComponent<Renderer>().material = texturas[1];
                        ball3.GetComponent<Renderer>().material = texturas[1];
                        ball4.GetComponent<Renderer>().material = texturas[1];
                        ball5.GetComponent<Renderer>().material = texturas[1];
                        ball6.GetComponent<Renderer>().material = texturas[1];
                        ball7.GetComponent<Renderer>().material = texturas[1];
                        ball8.GetComponent<Renderer>().material = texturas[1];
                        ball9.GetComponent<Renderer>().material = texturas[1];
                    }
                    else if (valor >= 0.5f || valor < 0.75f)
                    {
                        ball.GetComponent<Renderer>().material = texturas[2];
                        ball2.GetComponent<Renderer>().material = texturas[2];
                        ball3.GetComponent<Renderer>().material = texturas[2];
                        ball4.GetComponent<Renderer>().material = texturas[2];
                        ball5.GetComponent<Renderer>().material = texturas[2];
                        ball6.GetComponent<Renderer>().material = texturas[2];
                        ball7.GetComponent<Renderer>().material = texturas[2];
                        ball8.GetComponent<Renderer>().material = texturas[2];
                        ball9.GetComponent<Renderer>().material = texturas[2];
                    }
                    else
                    {
                        ball.GetComponent<Renderer>().material = texturas[3];
                        ball2.GetComponent<Renderer>().material = texturas[3];
                        ball3.GetComponent<Renderer>().material = texturas[3];
                        ball4.GetComponent<Renderer>().material = texturas[3];
                        ball5.GetComponent<Renderer>().material = texturas[3];
                        ball6.GetComponent<Renderer>().material = texturas[3];
                        ball7.GetComponent<Renderer>().material = texturas[3];
                        ball8.GetComponent<Renderer>().material = texturas[3];
                        ball9.GetComponent<Renderer>().material = texturas[3];
                    }
                    ball.transform.tag = "Target3";
                    ball2.transform.tag = "Target3";
                    ball3.transform.tag = "Target3";
                    ball4.transform.tag = "Target3";
                    ball5.transform.tag = "Target3";
                    ball6.transform.tag = "Target3";
                    ball7.transform.tag = "Target3";
                    ball8.transform.tag = "Target3";
                    ball9.transform.tag = "Target3";
                    estado = 8;
                }
                break;
            default:
                break;
        }
        tiempo -= 1 * Time.deltaTime;
    }

}
