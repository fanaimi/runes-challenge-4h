using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to use images

/// <summary>
/// @gObj   button O F T M
/// </summary>
public class Rune : MonoBehaviour
{
    [SerializeField] private Color m_activationColor;
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private Image m_runeImage;
    [SerializeField] private float m_colorTransitionDuration = .3f;
    // [SerializeField] private float m_minActivationDuration = .5f;

    // [SerializeField] RuneSelector m_runeSelector;

    private Coroutine m_coroutine;

    public void RuneClicked()
    {
        StopAllCoroutines();
        m_coroutine = StartCoroutine(ActivateRune());

        // to stop a single coroutine, we store it and use
        // StopCoroutine(m_coroutine);
    }


    private IEnumerator ActivateRune()
    {
        if (GameManager.Instance.m_isAlive)
        {

            m_audioSource.Play();
            // wait for Lerp to color to finish
            yield return LerpToColor(Color.white, m_activationColor);

            // yield return new WaitForSeconds(m_minActivationDuration);

            // float duration = m_audioSource.clip.length;


            while (m_audioSource.isPlaying)
            {
                // avoiding runnin gthe loop in one frame
                yield return new WaitForEndOfFrame();
            }

            yield return LerpToColor(m_activationColor, Color.white);
        }
    }


    private IEnumerator LerpToColor(Color startCol, Color endCol)
    {
        float elapsedTime = 0;
        float startTime = Time.time;

        while (elapsedTime < m_colorTransitionDuration)
        {
            m_runeImage.color = Color.Lerp(startCol, endCol, elapsedTime / m_colorTransitionDuration);
            elapsedTime = Time.time - startTime;
            yield return null;
        }    

    }
}
