using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    //기능명
    //1. 죽었을때 결과창을  띄워준다
    [SerializeField]
    GameObject resultBGImage;

    [SerializeField]
    TextMeshProUGUI reusltText;

    [SerializeField]
    TextMeshProUGUI infoText;

    public void ShowResultPanel(bool isDie)
    {
        resultBGImage.SetActive(true);

        if (isDie)
        {
            reusltText.text = "Die..";
            infoText.text = "click any button to respawn..";
        }
        else
        {
            reusltText.text = "Clear!!";
            infoText.text = "click any button to nextlevel";
        }
    }

    public void HideResultPanel()
    {
        resultBGImage.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
            HideResultPanel();
    }
}
