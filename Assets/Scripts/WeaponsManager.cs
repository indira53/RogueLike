using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public Transform orb;         // El orbe que debe rotar
    public Transform player;      // El jugador alrededor del cual rotará el orbe
    public float speed = 50f;     // Velocidad de rotación
    public float radius = 2f;     // Distancia desde el jugador

    public Animator chestAnimator1;

    private Vector3 offset;       // Para mantener la posición relativa entre el orbe y el jugador

    // Start is called before the first frame update
    void Start()
    {

        // Calcular la distancia inicial entre el orbe y el jugador
        //offset = orb.position - player.position;
    }

    // Update is called once per frame
    /*void Update()
    {
        
        // Verificar si ambos objetos están asignados
        if (orb != null && player != null)
        {
            // Actualizar la posición del orbe para que se mantenga a la misma distancia del jugador
            Vector3 direction = (orb.position - player.position).normalized;
            orb.position = player.position + direction * radius;

            // Rotar el orbe alrededor del jugador usando el eje Z (en 2D)
            orb.RotateAround(player.position, Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            // Si el orbe o el jugador no están asignados, mostrar un error en consola
            Debug.LogError("El orbe o el jugador no están asignados en el GameManager.");
        }

    }*/
}
