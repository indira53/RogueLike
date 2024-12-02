using System;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{

    [NonSerialized] public Transform OrbSpawner;
    // Los pone el orb spawner
    [NonSerialized] public float RotaionSpeed;
    [NonSerialized] public float Radius;
    [NonSerialized] public float AngleOffset;
    void Update()
    {
        float angle = Time.time * RotaionSpeed + AngleOffset;
        var positionCenterObject = OrbSpawner.position;

        var x = positionCenterObject.x + Mathf.Cos(angle) * Radius;
        var y = positionCenterObject.y + Mathf.Sin(angle) * Radius;
        transform.position = new Vector3(x, y);
    }
}
