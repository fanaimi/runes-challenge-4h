using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// @gObj   GameManager
/// @desc       
/// </summary>
public class RuneSelector : MonoBehaviour
{


    public int[] m_currentRuneSequence = new[] { 0, 1, 2, 3 };
    public int m_currentIndex = 0;

    public int m_counter;

    [SerializeField] private TMP_Text m_announcement;

    [SerializeField] private AudioSource m_as;

    private int m_currentRoundsScore = 0;


    // ============== 8 
    // public bool m_isAlive;
    [SerializeField] private TextMeshProUGUI m_timerText;
    [SerializeField] private TextMeshProUGUI m_livesText;
    [SerializeField] private TextMeshProUGUI m_newAnnouncer;
    [SerializeField] private GameObject[] m_bloodDrops = new GameObject[16];
    [SerializeField] private int m_timerInitialValue;
    [SerializeField] private int m_quickTime;
    [SerializeField] private int m_quickScoreAmount;
    [SerializeField] private int m_normalScoreAmount = 5;
    private int m_livesLeft;
    // [SerializeField] private int m_turnsBeforeShuffleBtns = 3;

    private int m_timer;

    private bool m_isTimerRunning = true;


    private void Awake()
    {
    }

    private void Start()
    {
        GameManager.Instance.m_isAlive = true;
        m_timer = m_timerInitialValue;
        InvokeRepeating("RunCountdown", 0, 1);
        SetUpStartingLives();
    }

    private void SetUpStartingLives()
    {   
        m_livesLeft = GameManager.Instance.m_startingLives;
        m_livesText.text = m_livesLeft.ToString();
    }


    public void OnRuneActivated(int index)
    {
        // guard clause
        if (m_currentIndex >= m_currentRuneSequence.Length) return;
        if (!GameManager.Instance.m_isAlive) return;


        if (m_currentRuneSequence[m_currentIndex] == index)
        {
            
            CorrectSelected();
            ResetCountDown();
        }
        else 
        {
            Failed();
            StopCountDown();
        }
    }


    private void CorrectSelected()
    {
       
        bool quick = m_timer >= m_quickTime;
        UiManager.Instance.AddScore(quick ? m_quickScoreAmount : m_normalScoreAmount);


        m_currentIndex++;
        // m_as.Play();
        m_counter++;
        if (m_counter == m_currentRuneSequence.Length)
        {
            CompletedSequence();
        }
    }

    private void RunCountdown() 
    {
        if (m_timer > 1 && m_isTimerRunning && GameManager.Instance.m_isAlive)
        {
            m_timer--;
            m_timerText.text = m_timer.ToString();
        }
        else 
        {
            // Die();
            LoseLife();
        } 
    }

    private void LoseLife() 
    {
        if (m_livesLeft >= 1)
        {
            m_livesLeft--;
            ShowLivesLeft(m_livesLeft);
            m_newAnnouncer.text = "you lost one life";
            Invoke("ResetAnnouncer", 1);

            CancelInvoke("RunCountdown");
            m_timer = m_timerInitialValue;
            InvokeRepeating("RunCountdown", 0, 1);
        }
        else 
        {
            Die();
        }
        
    }

    private void ResetAnnouncer()
    {
        m_newAnnouncer.text = "HEY, LISTEN!";
    }


    private void ShowLivesLeft(int noOfLives)
    {
        m_livesText.text = noOfLives.ToString();
    }


    private void Die()
    {
        // Debug.Log("you dead");
        m_newAnnouncer.text =  "you dead";
        GameManager.Instance.m_isAlive = false;
        m_isTimerRunning = false;
    }


    private void ResetCountDown()
    {
        GameManager.Instance.m_isAlive = true;
        m_isTimerRunning = true;
        m_timer = m_timerInitialValue;
        CancelInvoke("RunCountdown");
        InvokeRepeating("RunCountdown", 0, 1);
    }

    private void StopCountDown()
    {
        CancelInvoke("RunCountdown");
        m_isTimerRunning = false;
    }


    public void BloodSacrifice()
    {
        if (m_livesLeft > 1)
        {
            LoseLife();
            Sacrifincing();
            // CompletedSequence();
        }
    }

    private void Sacrifincing()
    {
        foreach (var drop in m_bloodDrops)
        {
            drop.SetActive(true);
        }
        CompletedSequence();
    }


    public void ShuffleRuneSequence()
    {
        for (int i = 0; i < m_currentRuneSequence.Length - 1; i++)
        {
            int rnd = UnityEngine.Random.Range(i, m_currentRuneSequence.Length);
            int temp = m_currentRuneSequence[rnd];
            m_currentRuneSequence[rnd] = m_currentRuneSequence[i];
            m_currentRuneSequence[i] = temp;
        }
        Debug.Log(String.Join("-", m_currentRuneSequence) );    //Join("-"))
    }

    private void Failed()
    {
        LoseLife();
        m_counter = 0;
        m_currentIndex = 0;
        AudioManager.Instance.Play("fail");
        UiManager.Instance.ResetScore();
        UiManager.Instance.FailCountDown();
    }


    public void CompletedSequence()
    {
        ShuffleRuneSequence();
        m_currentIndex = 0;
        m_counter=0;
        // print("cool");
        m_currentRoundsScore++;
        if (m_currentRoundsScore > GameManager.Instance.GetRoundsScore())
        {
            UiManager.Instance.AddRoundsScore(1);
        }
        m_newAnnouncer.text = "WELL DONE!";
        AudioManager.Instance.Play("win");
    }

}
