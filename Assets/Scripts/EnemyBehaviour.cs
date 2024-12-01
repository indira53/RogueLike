using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnRate;
    public float spawnAmount;

    public Transform playerTransform;
    private NavMeshAgent agente;
    private LifeManager lifeManager;

    private Animator animator;

    

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        lifeManager = GetComponent<LifeManager>();
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        //impedir que rote porque el navmesh no está preparado para 2D y perderíamos al enemigo por el mapa
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    private void Update()
    {
        agente.SetDestination(playerTransform.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            lifeManager.Health -= 1;
            if (lifeManager.Health == 0)
            {
                this.gameObject.GetComponent<Animator>().SetBool("Dead", true);
            }
        }

    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

}


