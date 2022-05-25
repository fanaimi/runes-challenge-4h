using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocaleButtonsController : MonoBehaviour
{
    [SerializeField] PowerUpConfig m_pUp;
    [SerializeField] private TextMeshProUGUI m_announcer;
    // Start is called before the first frame update

    // AnnouncerListen
    // s_currentLocale = Locale.en;
    // Localization.s_currentLocalizationTable[m_powerUpNameID]
    public void SwitchToEnglish()
    {
        print("eng");
        Localization.s_currentLocale = Locale.en;
        m_announcer.text = Localization.s_currentLocalizationTable["AnnouncerListen"];
    }

    public void SwitchToPortuguese()
    {
        print("port");
        Localization.s_currentLocale = Locale.pt;
        m_announcer.text = Localization.s_currentLocalizationTable["AnnouncerListen"];
    }

}
