using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicalRunes;

// [System.Serializable]
[CreateAssetMenu(fileName = "Powerup Config", menuName = "Configs/Power Up")]
public class PowerUpConfig : ScriptableObject // SO canont be added to object in the scene
{
    public PowerUpType m_powerUpType;
    // public string m_powerUpName;
    // s[TextArea] public string m_description;

    public bool m_upgradable;

    public Sprite m_powerUpSprite;

    public string m_powerUpNameID;
    public string m_descriptionID;

    public string m_powerUpName => Localization.s_currentLocalizationTable[m_powerUpNameID];
    public string m_description => Localization.s_currentLocalizationTable[m_descriptionID];



}
