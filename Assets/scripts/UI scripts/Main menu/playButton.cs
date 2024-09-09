using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(startGame);
    }

    void startGame()
    {
        ChangeScene("main_Screen");
    }
    void ChangeScene(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
