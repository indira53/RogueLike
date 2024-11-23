using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] public float playerSpeed = 5f;
    

    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalMovement, verticalMovement) * playerSpeed * Time.deltaTime;
        transform.Translate(direction);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }
    //cada direccion irá con un string
    private void OldPlayerMovement()
    {
        moveH = Input.GetAxis("Horizontal") * playerSpeed;
        moveV = Input.GetAxis("Vertical") * playerSpeed;
        rb.velocity = new Vector2(moveH, moveV);
        transform.Translate(rb.velocity);
        FindObjectOfType<PlayerAnimation>().SetDirection(rb.velocity);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }
}
