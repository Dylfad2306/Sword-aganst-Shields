using UnityEngine;
using UnityEngine.UI;

public class openMems : MonoBehaviour
{
    public GameObject memsPanal;
    // Start is called before the first frame update
    void Start()
    {
        Button theButton = GetComponent<Button>();
        theButton.onClick.AddListener(memsNow);
    }
    void memsNow()
    {
        memsPanal.SetActive(!memsPanal.activeSelf);
    }
}
