using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toMainMenue : MonoBehaviour
{
    private void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(BacktoMainMenue);
    }

    void BacktoMainMenue()
    {
        Time.timeScale = 1f;
        ChangeScene("Main_menu");
    }
    void ChangeScene(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}