using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    public GameObject ShopPanal;
    void Start()
    {
        Button theButton = GetComponent<Button>();
        theButton.onClick.AddListener(ShopNow);
    }
    void ShopNow()
    {
        ShopPanal.SetActive(!ShopPanal.activeSelf);
    }
}
