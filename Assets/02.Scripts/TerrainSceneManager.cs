using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TerrainSceneManager : MonoBehaviour
{
    public GameObject _stage01;
    public GameObject _stage02;
    public GameObject _stage03;

    public void OnStageChagne(TMP_Dropdown dropdown)
    {
        Debug.Log($"i : {dropdown.value}");
        switch (dropdown.value)
        {
            case 0:
                _stage01.SetActive(true);
                _stage02.SetActive(false);
                _stage03.SetActive(false);
                break;
            case 1:
                _stage01.SetActive(false);
                _stage02.SetActive(true);
                _stage03.SetActive(false);
                Debug.Log($" 1 selected");
                break;
            case 2:
                _stage01.SetActive(false);
                _stage02.SetActive(false);
                _stage03.SetActive(true);
                break;

        }
    }
}
