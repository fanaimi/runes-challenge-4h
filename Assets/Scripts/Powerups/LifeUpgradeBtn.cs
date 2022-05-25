using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicalRunes;
using UnityEngine.UI;
using TMPro;



/// <summary>
/// @gObj   LifeUpgradeBtn
/// @chlg   unit1 challenge 8 hard (c8H)
/// @desc   this will allow user to spend coins to add starting lives
///             by clickin on LifeUpgradeButton
/// </summary>
public class LifeUpgradeBtn : MonoBehaviour
{

    [SerializeField] private PowerUpConfig m_lifeUpgradeConfig;
    [SerializeField] private Image m_image;

    [SerializeField] private TextMeshProUGUI m_livesText;

    // Start is called before the first frame update
    void Start()
    {
        m_image.sprite = m_lifeUpgradeConfig.m_powerUpSprite;
    }

    


    public void BuyStartingLives()
    {
        if (!GameManager.Instance.m_isAlive) return;
        
        if (GameManager.Instance.m_gameCoinsScore < GameManager.Instance.m_extraLifePrice) return;

        UiManager.Instance.ShowQuickAnnouncement("You have bought 1 extra starting life!");
        GameManager.Instance.IncreaseStartingLives();
        UiManager.Instance.AddScore(-GameManager.Instance.m_extraLifePrice);

        int lives = int.Parse(m_livesText.text);
        lives += 1;
        // print(lives);
        m_livesText.text = lives.ToString();
    }
}
