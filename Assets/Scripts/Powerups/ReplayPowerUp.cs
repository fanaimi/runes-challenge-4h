using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @gObj   replayBtn
/// </summary>
public class ReplayPowerUp : PowerUp  
{

    [SerializeField] private Image[] m_btnImgs;
    [SerializeField] private RuneSelector m_RSScript;
    [SerializeField] private int m_minIndex = 1;

    private int[] m_correctSequence;

    private bool m_canBeClicked => m_RSScript.m_currentIndex > m_minIndex;

    public override void OnPowerUpClick()
    {
        if (m_isAvailable && m_canBeClicked)
        {

            print("replay " + m_RSScript.m_currentIndex);
            base.OnPowerUpClick();
            m_RSScript.ShuffleRuneSequence();
            m_RSScript.m_currentIndex = 0;
            m_RSScript.m_counter = 0;
            foreach (var img in m_btnImgs)
            {
                img.color = Color.white;
            }
        }
    }
}
