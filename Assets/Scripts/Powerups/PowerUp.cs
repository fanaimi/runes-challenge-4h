using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private int m_coolDownDuration = 3;

    [SerializeField] private Image m_powerUpBtn;

    // [SerializeField]  
    private float m_currentCooldown;

    protected bool m_isAvailable => m_currentCooldown <= 0;

    private void Update()
    {

        if (m_currentCooldown >= 0)
        {
            m_currentCooldown -= Time.deltaTime;
            // getting from 3 -> 0 : 0 -> 1
            m_powerUpBtn.fillAmount = 1 - m_currentCooldown / m_coolDownDuration;
        }
    }

    // 
    public virtual void OnPowerUpClick()
    {
        // guard clause
        if (!m_isAvailable) return;

        m_currentCooldown = m_coolDownDuration;
    }

}
