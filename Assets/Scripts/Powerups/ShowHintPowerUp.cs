using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// @gObj   HInt Button
/// </summary>
public class ShowHintPowerUp : PowerUp
{
    // var orderedListRandom = m_bots.OrderBy(t => Random.Range(0,100));

    [SerializeField] private Image[] m_btnImgs;
    [SerializeField] private RuneSelector m_RSScript;

    private int[] m_correctSequence;



    public override void OnPowerUpClick()
    {
        if (m_isAvailable)
        {
            base.OnPowerUpClick();
            //m_btnImgs[m_RSScript.m_currentIndex].color = Color.green;
            
            m_btnImgs[m_RSScript.m_currentRuneSequence[m_RSScript.m_currentIndex] ].color = Color.green;
        }
    }


}
