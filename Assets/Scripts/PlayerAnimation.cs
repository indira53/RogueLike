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
        

        float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        
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
            lastDirection = DirectionToIndex(_direction); //para que se mantenga la direcci�n que tenemos cuando dejamos de movernos

    
        }
        
        
        animator.Play(directionArray[lastDirection]);
    }


    //Convierte un Vector2 direcci�n en un index en un trozo del circulo
    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 noDirection = _direction.normalized;
        float step = 360 / 8; //360� dividido entre 8 trozos

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


    // Update is called once per frame
    void Update()
    {
    
    }
}
