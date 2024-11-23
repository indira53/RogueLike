using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public string[] idleDirections = { "Idle Up", "Idle Left Up", "Idle Left", "Idle Left Down", "Idle Down", "Idle Right Down", "Idle Right", "Idle Right Up" };
    public string[] walkDirections = { "Walk Up", "Walk Left Up", "Walk Left", "Walk Left Down", "Walk Down", "Walk Right Down", "Walk Right", "Walk Right Up" };

    int lastDirection=0;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();

        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        Debug.Log("R1 " + result1);

        float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        Debug.Log("R2 " + result2);
    }
    public void SetDirection(Vector2 _direction)
    {
 
        string[] directionArray = null;
        if (_direction.magnitude < 0.01)
        {
            directionArray = idleDirections;

        }
        else
        {
            directionArray = walkDirections;
            lastDirection = DirectionToIndex(_direction); //para que se mantenga la dirección que tenemos cuando dejamos de movernos

    
        }
        
        Debug.Log($"Playing : {directionArray[lastDirection]}");
        animator.Play(directionArray[lastDirection]);
    }


    //Convierte un Vector2 dirección en un index en un trozo del circulo
    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 noDirection = _direction.normalized;
        float step = 360 / 8; //360º dividido entre 8 trozos

        float offset = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, noDirection); //devuelve el angulo en grados entre A y B

        angle += offset;

        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);

    }

    /*private void UpdateAnimation()
    {
        Vector2 direction = transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg; //para que detecte el angulo de inclinación 
        animator.SetFloat("angle", angle);

        if (Input.GetKeyDown(KeyCode.W)) { directionY += -1; }
        if (Input.GetKeyDown(KeyCode.A)) { directionX += -1; }
        if (Input.GetKeyDown(KeyCode.S)) { directionY += 1; }
        if (Input.GetKeyDown(KeyCode.D)) { directionX += 1; }

    }*/

    /* public void RestartWASD()
     {
         animator.SetBool("WASD", false);
     }*/

    // Update is called once per frame
    void Update()
    {
    
        /*
        UpdateAnimation();

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("WASD", true);
        }*/
    }
}
