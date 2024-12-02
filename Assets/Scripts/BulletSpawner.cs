using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    public Transform bulletSpawner;
    public float bulletSpeed = 10f;
    public float timeShoot = 2f;
    public float refreshShoot = 0f;
    public float bulletLife = 3f;
    private PlayerManager _playerManager;

    // Start is called before the first frame update
    void Start()
    {
        refreshShoot = 6f;
        _playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (refreshShoot > timeShoot)
        {
            Shoot();
            refreshShoot = 0f;
        }
        refreshShoot += Time.deltaTime;
    }

    void Shoot()
    {
        var vector = _playerManager.GetDirectionVector();
        GameObject proyectil = Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.Euler(0f, 0f, _playerManager.DirectionAngle()));

        //A�adir velocidad al proyectil
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        // Debug.Log(player.GetComponent<PlayerManager>().direction);
        rb.velocity = _playerManager.GetDirectionVector() * bulletSpeed; //Asume que la nave est� orientada hacia arriba
    }

}