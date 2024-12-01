using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    public string[] idleDirections = { "Idle Up", "Idle Left Up", "Idle Left", "Idle Left Down", "Idle Down", "Idle Right Down", "Idle Right", "Idle Right Up" };
    public string[] walkDirections = { "Walk Up", "Walk Left Up", "Walk Left", "Walk Left Down", "Walk Down", "Walk Right Down", "Walk Right", "Walk Right Up" };

    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();


    }
    public void SetDirection(int directionIndex, bool moving)
    {
        if (moving)
        {
            _animator.Play(walkDirections[directionIndex]);
        }
        else
        {
            _animator.Play(idleDirections[directionIndex]);
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}