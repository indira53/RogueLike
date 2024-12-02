using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public float playerSpeed = 5f;
    private LifeManager _lifeManager;
    public float angle;
    public int directionIndex;
    public bool moving;
    [NonSerialized] public GameManager gameManager;
    private PlayerAnimation _playerAnimation;
    [NonSerialized]
    public readonly Vector2[] Directions = {
        Vector2.up,
        (Vector2.up + Vector2.left) * Mathf.Sqrt(2) / 2,
        Vector2.left,
        (Vector2.down + Vector2.left) * Mathf.Sqrt(2) / 2,
        Vector2.down,
        (Vector2.down + Vector2.right) * Mathf.Sqrt(2) / 2,
        Vector2.right,
        (Vector2.up + Vector2.right) * Mathf.Sqrt(2) / 2
    };

    public Vector2 GetDirectionVector()
    {
        return Directions[directionIndex];
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerAnimation = FindObjectOfType<PlayerAnimation>();
        _lifeManager = GetComponent<LifeManager>();
        Debug.Log(Directions.Length);
    }

    private void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        var rawMovement = new Vector2(horizontalMovement, verticalMovement);
        rawMovement = rawMovement.x != 0 && rawMovement.y != 0 ? rawMovement * Mathf.Sqrt(2) / 2 : rawMovement;
        // Debug.Log(rawMovement);
        if (rawMovement.magnitude >= 0.1f)
        {
            //angle = Vector2ToAngle(rawMovement);
            //directionIndex = Angle2Index(angle);
            directionIndex = DirectionToIndex(rawMovement);
            moving = true;
        }
        else
        {
            moving = false;
        }
        var moveOffset = rawMovement * (playerSpeed * Time.deltaTime);
        transform.Translate(moveOffset);
        _playerAnimation.SetDirection(directionIndex, moving);
    }

    //Convierte un Vector2 dirección en un index en un trozo del circulo
    public float DirectionAngle()
    {
        var vector2 = GetDirectionVector();
        return Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
    }

    private int DirectionToIndex(Vector2 direction)
    {
        const float step = 45f; //360º dividido entre 8 trozos
        const float offset = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, direction.normalized); //devuelve el angulo en grados entre A y B
        angle += offset;

        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            Debug.Log("puerta");
            switch (SceneManager.GetActiveScene().name)
            {
                case "Scene1":
                    SceneManager.LoadScene("Scene2");
                    SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName("Scene2"));
                    break;
                case "Scene2":
                    SceneManager.LoadScene("Scene1");
                    SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName("Scene1"));
                    break;
            }
        }

        if (other.CompareTag("Enemy"))
        {
            var currentHealth = _lifeManager.Health;
            _lifeManager.Health -= 1;
            var newHealth = _lifeManager.Health;
            Debug.Log($"Vida: {currentHealth} -> {newHealth}");

            gameManager.UpdateLifeDisplay(currentHealth, newHealth);
        }
    }
}