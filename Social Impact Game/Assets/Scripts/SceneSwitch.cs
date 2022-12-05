using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public static SceneSwitch instance;

    private void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        
    }

    public void ChangeScene(string n)
    {
        SceneManager.LoadScene(n);
    }
    public void ChangeScene(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void ChangeNextScene()
    {
        int id = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > id)
            SceneManager.LoadScene(id);
    }
}
