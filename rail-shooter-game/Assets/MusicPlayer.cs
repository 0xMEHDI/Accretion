using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke("LoadFirstScene", 2.0f);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}