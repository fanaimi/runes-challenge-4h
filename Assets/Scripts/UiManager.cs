using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// UI manager to control ui score, stars, feedbacks etc
/// </summary>
public class UiManager : MonoBehaviour
{
    private static UiManager s_instance;
    public static UiManager Instance { get { return s_instance; } }

    [SerializeField] private TMP_Text m_coinsText;
    [SerializeField] private TMP_Text m_starsText;
    [SerializeField] private TMP_Text m_roundsText;
    [SerializeField] private TMP_Text m_announcerText;
    [SerializeField] private TMP_Text m_newAnnouncerText;
    [SerializeField] private Transform m_spinningLight1;
    [SerializeField] private Transform m_spinningLight2;
    [SerializeField] [Range(-50f, 50f)] private float m_rotSpeed1;
    [SerializeField] [Range(-50f, 50f)] private float m_rotSpeed2;

    [SerializeField] GameObject[] m_runesButtons;    


    private void Awake()
    {
        if (s_instance != null && s_instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            s_instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
        GetAndShowHighScores();
        // StartCoroutine(ShowQuickAnnouncement("this is a test"));
    }

    private void GetAndShowHighScores()
    {
        int highScore = GameManager.Instance.GetHighScore();
        ShowHighScore(highScore);

        int roundsScore = GameManager.Instance.GetRoundsScore();
        ShowRoundsScore(roundsScore);
    }

    private void ShowHighScore(int highScore)
    {
        m_starsText.text = highScore.ToString();
    }

    private void ShowRoundsScore(int roundsScore)
    {
        m_roundsText.text = roundsScore.ToString();
    }

    // === modified for c8H
    public void AddScore(int score)
    {
        // Debug.Log(m_coinsText.text);
        //int originalScore = int.Parse(m_coinsText.text);
        //int newScore = originalScore + score;

        GameManager.Instance.m_gameCoinsScore += score;
        if (GameManager.Instance.m_gameCoinsScore > GameManager.Instance.GetHighScore()) {
            GameManager.Instance.SetHighScore(GameManager.Instance.m_gameCoinsScore);
            ShowHighScore(GameManager.Instance.GetHighScore());
        }
        m_coinsText.text = GameManager.Instance.m_gameCoinsScore.ToString();
    }


    // === modified for c8H
    public IEnumerator ShowQuickAnnouncement(string msg)
    {
        string prevText = m_newAnnouncerText.text;
        m_newAnnouncerText.text = msg;
        yield return new WaitForSeconds(2);
        m_newAnnouncerText.text = prevText;
    }


    public void AddRoundsScore(int roundsScore)
    {
        // Debug.Log(m_coinsText.text);
        int originalScore = int.Parse(m_roundsText.text);
        int newScore = originalScore + roundsScore;

        // print("before settingRoundscore");
        // print(GameManager.Instance.GetRoundsScore());
        if (newScore > GameManager.Instance.GetRoundsScore())
        {
            // print("settingRoundscore");
            GameManager.Instance.SetRoundsScore(newScore);
            ShowRoundsScore(GameManager.Instance.GetHighScore());
        }
        m_roundsText.text = newScore.ToString();
    }



    public void ResetScore()
    {
        m_coinsText.text = "0";
        Announce("Guess the order!");
    }


    public void Announce(string msg)
    {
        m_announcerText.text = msg;
    }

    // Update is called once per frame
    void Update()
    {
       RotateSpinningLights();
    }

    private void RotateSpinningLights()
    {
        m_spinningLight1.Rotate(Vector3.forward, Time.deltaTime * m_rotSpeed1);
        m_spinningLight2.Rotate(Vector3.forward, Time.deltaTime * m_rotSpeed2);
    }






    public void FailCountDown()
    {
        ToggleButtonsInteractability(false);
        StartCoroutine(ReEnableGame());
    }

    IEnumerator ReEnableGame()
    { 
        yield return StartCoroutine(AnnouncerCoroutine(3, 1));
        m_announcerText.text = "go!";
        ToggleButtonsInteractability(true);
    }


    IEnumerator AnnouncerCoroutine(int count, int delay)
    {
        for (int i = count; i >=0; i--)
        {

            m_announcerText.text = i.ToString();
            yield return new WaitForSeconds(delay);
        }
    }


    private void ToggleButtonsInteractability(bool isActive)
    {
        foreach (var runeBtn in m_runesButtons) {
            runeBtn.GetComponent<Button>().interactable = isActive;
        }
    }




}
