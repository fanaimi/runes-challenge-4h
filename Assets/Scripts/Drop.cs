using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Vector3 m_startPos;
    private float m_verticalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_verticalSpeed = UnityEngine.Random.Range(-5, -15);
        m_startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -6)
            transform.position += new Vector3(
                0, 
                m_verticalSpeed* Time.deltaTime, 
                0);
        else
            ResetDrop();
    }

    public void ResetDrop()
    {
        gameObject.SetActive(false);
        transform.position = m_startPos;
    }

}
