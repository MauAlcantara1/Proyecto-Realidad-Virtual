using UnityEngine;
using System.Collections;

public class tp_camera : MonoBehaviour
{   
    //Aqui solo le damos los objetos con los que vamos a trabajar
    [SerializeField] GameObject escena_1; //escenario mau
    [SerializeField] GameObject escena_2; // Escenario Ale
    [SerializeField] GameObject escena_3; // Escenario Mariana
    [SerializeField] GameObject XR_ORIGIN;

    public float tiempo_para_tp = 5f;

    //aqui estan las coordenadas a donde ira la camara, aunque las verdaderas se asignaron en 
    // el inspector 
    public Vector3 posEscenario1 = new Vector3(0f, 5f, -10f);
    public Vector3 posEscenario2 = new Vector3(10f, 2f, 5f);
    public Vector3 posEscenario3 = new Vector3(-5f, 8f, 0f);

    void Start()
    {   
        //Inicia la secuencia ciclica para la posicion de la camara y escenarios
        StartCoroutine(TeleportProcess());
    }

  

    IEnumerator TeleportProcess()
    {   

        XR_ORIGIN.transform.position = posEscenario1; // la camara se movera a la posicion1
        Debug.Log("Escenario1"); //comprobar funcionamiento
        escena_1.SetActive(true); //Los siguientes 3 solo son para activar y desactivar los escenarios con el fin 
        escena_2.SetActive(false); //de no exigir en cuanto a recursos
        escena_3.SetActive(false);

        // Espera el tiempo configurado antes de cambiar
        yield return new WaitForSeconds(tiempo_para_tp);


        XR_ORIGIN.transform.position = posEscenario2;
        Debug.Log("Escenario2");
        escena_1.SetActive(false);
        escena_2.SetActive(true);
        escena_3.SetActive(false);

        yield return new WaitForSeconds(tiempo_para_tp);


        XR_ORIGIN.transform.position = posEscenario3;
        Debug.Log("Escenario3");
        escena_1.SetActive(false);
        escena_2.SetActive(false);
        escena_3.SetActive(true);

        //reinicia la corrutina para crear un bucle infinito
        StartCoroutine(TeleportProcess());
    }
}