using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{
    [SerializeField] Locale lang;

    public void ChangeLanguage()
    {
        Localization.s_currentLocale = lang;
        LanguageController.s_instance.UpdateLanguage();
    }
}