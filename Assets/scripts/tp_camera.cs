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
        while (true)
        {
            // --- ESCENARIO 1 ---
            CambiarEscenario(escena_1, escena_2, escena_3, posEscenario1, "Escenario 1");
            yield return new WaitForSeconds(tiempo_para_tp);

            // --- ESCENARIO 2 ---
            CambiarEscenario(escena_2, escena_1, escena_3, posEscenario2, "Escenario 2");
            yield return new WaitForSeconds(tiempo_para_tp);

            // --- ESCENARIO 3 ---
            CambiarEscenario(escena_3, escena_1, escena_2, posEscenario3, "Escenario 3");
            yield return new WaitForSeconds(tiempo_para_tp);
        }
    }

    private void CambiarEscenario(GameObject activo, GameObject inactivoA, GameObject inactivoB, Vector3 nuevaPosicion, string debugMsg)
    {
        if (XR_ORIGIN != null)
        {
            XR_ORIGIN.transform.position = nuevaPosicion;
        }

        if (activo != null) activo.SetActive(true);
        if (inactivoA != null) inactivoA.SetActive(false);
        if (inactivoB != null) inactivoB.SetActive(false);

        Debug.Log(debugMsg);
    }
}