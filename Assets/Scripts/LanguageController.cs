using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// @gObj   GameManager
/// </summary>
public class LanguageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_annoucerText;

    [SerializeField] private string m_greetingID;

    public static LanguageController s_instance;

    void Awake()
    {
        if (s_instance) return;

        s_instance = this;
    }
    public void UpdateLanguage()
    {
        m_annoucerText.text = Localization.s_currentLocalizationTable[m_greetingID];
    }
}
