using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    [NonSerialized] public GameObject player;
    public Animator[] heartAnimators;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        player.GetComponent<PlayerManager>().gameManager = this;
        Camera.main.GetComponent<ControlCamera>().playerTransform = player.transform;
        GetComponent<EnemySpawner>().player = player;
    }
    public void UpdateLifeDisplay(int currentHealth, int newHealth)
    {
        if (currentHealth > newHealth)
        {

            heartAnimators[newHealth].SetInteger("LifeChange", -1);
        }

        if (newHealth == 0)
        {
            player.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}