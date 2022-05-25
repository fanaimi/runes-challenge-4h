using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(Rigidbody))]
public class Announcer : MonoBehaviour
{
    // reading about [attributes]
    // Transform always want FLOAT! 
    [SerializeField] [Range(0f, 1f)] private float m_bounceAmplitude = 0.01f;
    [SerializeField] [Range(-10f, 10f)] private float m_bounceFrequency = 0.01f;


    // Update is called once per frame
    void Update()
    {
        // transform.localScale = new Vector3(0, 0, 0);
        // transform.localScale = Vector3.zero;
        transform.localScale = Vector3.one + 
            Vector3.one * Mathf.Sin(Time.time * m_bounceFrequency) * m_bounceAmplitude;
    }
}
