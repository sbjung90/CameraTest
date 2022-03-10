using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject   _rainEffect;
    public GameObject   _snowEffect;
    public GameObject   _sakuraEffect;

    private void Awake()
    {
        ResourceService.Instance.StartService();
        SoundService.Instance.StartService();
    }

    private void Start()
    {
        SoundService.Instance.PlaySound("CombatBGM");
    }

    // Start is called before the first frame update
    public void OnGameExit()
    {
        Application.Quit();
    }

    public void OnEffectChagne(TMP_Dropdown dropdown)
    {
        Debug.Log($"i : {dropdown.value}");
        switch (dropdown.value)
        {
            case 0:
                _rainEffect.SetActive(false);
                _snowEffect.SetActive(false);
                _sakuraEffect.SetActive(false);
                break;
            case 1:
                _rainEffect.SetActive(true);
                _snowEffect.SetActive(false);
                _sakuraEffect.SetActive(false);
                Debug.Log($" 1 selected");
                break;
            case 2:
                _rainEffect.SetActive(false);
                _snowEffect.SetActive(true);
                _sakuraEffect.SetActive(false);
                break;
            case 3:
                _rainEffect.SetActive(false);
                _snowEffect.SetActive(false);
                _sakuraEffect.SetActive(true);
                break;

        }
    }
}
