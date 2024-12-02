using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public static WeaponsManager Instance;
    private List<GameObject> _availableWeapons = new();
    [NonSerialized] public GameObject Player;

    private void Start()
    {
        Instance = this;
    }

    public void SetPlayer(GameObject player)
    {
        Player = player;
        for (int i = 0; i < Player.transform.childCount; i++)
        {
            _availableWeapons.Add(Player.transform.GetChild(i).gameObject);
        }
        Debug.Log(_availableWeapons);
    }
    public void EnableWeapon(string name)
    {
        foreach (var weapon in _availableWeapons)
        {
            if (weapon.name == name)
            {
                weapon.SetActive(true);
            }
        }
    }
}
