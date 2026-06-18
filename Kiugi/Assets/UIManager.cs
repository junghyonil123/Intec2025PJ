using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text_Notify;
    [SerializeField]
    TextMeshProUGUI text_SlimeCnt;

    [SerializeField]
    Button startBattle;
    [SerializeField]
    Button spawnSlime;
    [SerializeField]
    GameObject slimeCntPanel;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetSlimeCntText(int slimeCnt)
    {
        text_SlimeCnt.text = slimeCnt + "/" + PlayerController.playerData.GetMaxSpawnableSlime();
    }

    public void StartTextNotify(string contents, float duration)
    {
        StartCoroutine(StartTextNotifyEffect(contents, duration));
    }

    IEnumerator StartTextNotifyEffect(string contents, float duration)
    {
        text_Notify.gameObject.SetActive(true);
        text_Notify.text = contents;

        yield return new WaitForSecondsRealtime(duration);

        text_Notify.gameObject.SetActive(false);
    }

    public void PreparBattle()
    {
        startBattle.gameObject.SetActive(false);
        spawnSlime.gameObject.SetActive(false);
        slimeCntPanel.gameObject.SetActive(false);
    }
}
