using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// @gObj   RuneGrid > Rune01 -> deactivated
/// </summary>
public class TestEvents : MonoBehaviour
{

    [SerializeField] private UnityEvent m_click;
    [SerializeField] private TMP_Text m_amount;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_click.Invoke();
        }
    }

    public void AddScore(int score)
    {
        Debug.Log(m_amount.text);
        int originalScore = int.Parse(m_amount.text);
        int newScore = originalScore + score;
        m_amount.text = newScore.ToString();
    }

    

    public void PlaySound()
    {
        // Debug.Log("boo");
    }


}
