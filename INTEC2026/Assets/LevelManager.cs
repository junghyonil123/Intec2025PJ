using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> levels;

    [SerializeField]
    int curLevel = 1;

    public void MoveToNextLevel()
    {
        levels[curLevel - 1].SetActive(false);
        curLevel += 1;
        levels[curLevel - 1].SetActive(true);
    }
}
