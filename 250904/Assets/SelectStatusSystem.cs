using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SelectStatusSystem : MonoBehaviour
{
    public static SelectStatusSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    List<GameObject> slots;
    List<int> activeSlotIndex = new();

    void CloseAllSlot()
    {
        for (int i = 0; i < slots.Count; i++)
            slots[i].SetActive(false);

        activeSlotIndex.Clear();
    }

    public void Open()
    {
        CloseAllSlot();
        
        for (int i = 0; i < 3; i++)
        {
            int randomSlotIndex = Random.Range(0, slots.Count); //뽑을 랜덤 슬롯
            
            while (activeSlotIndex.Contains(randomSlotIndex)) //랜덤슬롯이 활성화된 슬롯이라면 다시 뽑기
                randomSlotIndex = Random.Range(0, slots.Count);

            activeSlotIndex.Add(randomSlotIndex);//활성화한 슬롯을 추가

            slots[randomSlotIndex].SetActive(true);//슬롯활성화
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Time.timeScale = 0f;
    }


    public void AddDamage()
    {
        Player.Instance.attack += 1;
        Close();
    }

    public void Heal()
    {
        Player.Instance.curHP = Player.Instance.maxHP;
        Close();
    }

    public void AddSpeed()
    {
        //속도증가
        Close();
    }
    public void AddRange()
    {
        //범위증가
        Close();
    }

    public void AddMaxHP()
    {
        //최대체력증가
        Close();
    }

    public void AddRecievedEXP()
    {
        //경험치 획득량증가
        Close();
    }

    void Close()
    {
        CloseAllSlot();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

}
