using UnityEngine;
using UnityEngine.UI;

public class openOptions : MonoBehaviour
{
    public GameObject optionsPanal;
    // Start is called before the first frame update
    void Start()
    {
        Button theButton = GetComponent<Button>();
        theButton.onClick.AddListener(optionsNow);
    }
    void optionsNow()
    {
        optionsPanal.SetActive(!optionsPanal.activeSelf);
    }
}
