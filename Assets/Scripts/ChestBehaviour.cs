using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChestBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    public string ChestContent;
    public GameObject panelOrb;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) // Usamos Collider2D para 2D
    {
        Debug.Log(other);
        // Verificamos si el objeto con el que el jugador colide es el cofre
        if (other.CompareTag("Player")) // Aseg�rate de que el cofre tenga el tag "Coffin"
        {
            _animator.SetBool("Collision", true);
            
            // Activamos la animaci�n del cofre usando un Trigger
            WeaponsManager.Instance.EnableWeapon(ChestContent);
            panelOrb.SetActive(true);
            Invoke("DisablePanel", 2.0f);
        }
    }
    public void DisablePanel()
    {
        panelOrb.SetActive(false);
    }
}
