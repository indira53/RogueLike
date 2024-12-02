using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Chronometer : MonoBehaviour
{
    public bool timerActivate;
    private float currentTime;
    [SerializeField] private TMP_Text _text;
    public static Chronometer instance;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Scene1")
        {
            StartTimer();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActivate)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        _text.text = currentTime.ToString();
    }

    public void StartTimer()
    {
        timerActivate = true;
    }

    public void StopTimer()
    {
        timerActivate = false;
    }
}
