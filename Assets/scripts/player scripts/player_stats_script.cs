using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerstatsscipt : MonoBehaviour
{
    public float PlayerHP = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP <= 0)
        {
            ChangeScene("dethe_screen");
        }
    }
    void ChangeScene(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
