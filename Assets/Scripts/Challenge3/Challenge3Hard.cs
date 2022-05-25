using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// @gObj   Challenge3Hard > ExplodingCube
/// </summary>
public class Challenge3Hard : MonoBehaviour
{
    [SerializeField] private FragmentsController m_fragmentsController;
    [SerializeField] private UnityEvent m_cubeClick;
    [SerializeField] [Range(0, 10f)] private float m_cubeTransitionDuration = 2f;
    [SerializeField] [Range(0, 10f)] private float m_vibrationAmplitude = .1f;
    [SerializeField] [Range(0, 100f)] private float m_vibrationFrequency = 100f;
    private Renderer m_rend;
    private Color m_cubeStartCol;
    private bool m_isAlive = true;
    private bool m_isVibrating = false;


    private void Start()
    {
        m_rend = GetComponent<Renderer>();
        m_cubeStartCol = m_rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_cubeClick.Invoke();
        }
        if (m_isAlive && m_isVibrating)
        {
            Vibrate();
        }
    }

    private void Vibrate()
    {
        // print("vibrating");
        transform.position = new Vector3(
            Mathf.Sin(Time.time * m_vibrationFrequency) * m_vibrationAmplitude,
            Mathf.Sin(Time.time * m_vibrationFrequency) * m_vibrationAmplitude,
            Mathf.Sin(Time.time * m_vibrationFrequency) * m_vibrationAmplitude
        );
    }

    public void OnClickExplode()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        m_isVibrating = true;
        yield return StartCoroutine(SwellAndChangeColor());

        yield return new WaitForSeconds(2);
        m_fragmentsController.MoveFragments();
        m_isAlive = false;
        m_isVibrating = false;
        Destroy(gameObject);
    }


    IEnumerator SwellAndChangeColor()
    {
        StartCoroutine(Swell(3f));
        StartCoroutine(
           ChangeColor(
               m_rend, m_cubeStartCol, Color.red, m_cubeTransitionDuration
           )
       );

        yield return null;

    }


    IEnumerator ChangeColor(Renderer rend, Color startCol, Color endCol, float duration)
    {
        // print("changing colour");
        float elapsedTime = 0;
        float startTime = Time.time;

        while (elapsedTime < duration)
        {
            rend.material.color = Color.Lerp(startCol, endCol, elapsedTime / duration);
            elapsedTime = Time.time - startTime;
            yield return null;
        }
    }

    IEnumerator Swell(float increment)
    {
        float progress = 0;
        while (progress <= m_cubeTransitionDuration)
        {
            transform.localScale = Vector3.Lerp(
                new Vector3(1, 1, 1),
                new Vector3(increment, increment, increment),
                progress
            );
            progress += Time.deltaTime;
            yield return null;
        }
    }



}
