using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] public float playerSpeed = 5f;
    public Animator chestAnimator;
    private LifeManager lifeManager;
    public Animator[] heartAnimators;

    // Start is called before the first frame update
    void Start()
    {
        lifeManager = GetComponent<LifeManager>();

    }

    private void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalMovement, verticalMovement) * playerSpeed * Time.deltaTime;
        transform.Translate(direction);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        
    }

    private void OnTriggerEnter2D(Collider2D other) // Usamos Collider2D para 2D
    {
        // Verificamos si el objeto con el que el jugador colide es el cofre
        if (other.CompareTag("Chest"))  // Asegúrate de que el cofre tenga el tag "Coffin"
        {
            // Activamos la animación del cofre usando un Trigger
            chestAnimator.SetBool("Collision", true);  // Activamos el trigger "OpenCoffin" en el Animator

        }

        if (other.CompareTag("Door"))
        {
            Debug.Log("puerta");
            SceneManager.GetActiveScene();
            switch (SceneManager.GetActiveScene().name)
            {
                case "MainScene": 
                    SceneManager.LoadScene("Scene2");
                    SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName("Scene2"));
                    break;
                case "Scene2":
                    SceneManager.LoadScene("MainScene");
                    SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName("MainScene"));
                    break;
            }
        }

        if (other.CompareTag("Enemy"))  
        {
            var currentHealth = lifeManager.Health;
            lifeManager.Health -= 1;
            var newHealth = lifeManager.Health;
            Debug.Log($"Vida: {currentHealth} -> {newHealth}");

            if (currentHealth > newHealth)
            {
                
                heartAnimators[newHealth].SetInteger("LifeChange", -1);
            }
        }
    }
}
