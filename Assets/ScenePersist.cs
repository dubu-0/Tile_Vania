using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    private static ScenePersist _scenePersist;
    private  int _currentSceneBuildIndex;

    private ScenePersist() { }
    
    private void Awake()
    {
        if (_scenePersist == null)
        {
            _scenePersist = this;
            _currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != _currentSceneBuildIndex) Destroy(gameObject);
    }
}
