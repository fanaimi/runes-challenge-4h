using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace MusicalRunes
{
    public class PowerUpUpgradePopup : MonoBehaviour
    {

        [SerializeField] public PowerUpConfig m_powerUp;
        [SerializeField] private Image m_btnImg;
        [SerializeField] private TextMeshProUGUI m_btnTxt;

        private void Start()
        {
            Setup(m_powerUp);
        }

        public void Setup(PowerUpConfig config)
        {
            m_btnTxt.text = config.m_powerUpName;
            gameObject.name = config.m_powerUpName;
            m_btnImg.sprite = config.m_powerUpSprite;
        }

    }

}
