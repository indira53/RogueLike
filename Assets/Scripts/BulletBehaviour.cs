using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletTime = 3f;
    private float shootedTime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootedTime += Time.deltaTime;
        Debug.Log(shootedTime);
        if (bulletTime <= shootedTime)
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

}
    
