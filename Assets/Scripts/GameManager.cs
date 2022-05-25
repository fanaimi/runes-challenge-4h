using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//[System.Serializable] will serialise the class
public struct SaveData
{
    public int sd_highScore;
    public int sd_roundsScore;
    public int sd_startingLives;
}

/// <summary>
/// @gObj GameManager
/// </summary>
public class GameManager : MonoBehaviour
{

    private static GameManager s_instance;
    public static GameManager Instance { get { return s_instance;  } }

    #region local references to stored data
        private int m_highScore;
        private int m_roundsScore;
        // ========= challenge 8H
        public int m_startingLives = 15;
    #endregion

    // ========= challenge 8H
    [SerializeField] public int m_extraLifePrice = 50;
    public int m_gameCoinsScore = 0;
    public bool m_isAlive;

    private void Awake()
    {
        // singleton
        if (s_instance != null && s_instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            s_instance = this;
        }
        DontDestroyOnLoad(gameObject);

        LoadData();

    }

    // Start is called before the first frame update
    void Start()
    {
        UiManager.Instance.ResetScore();
        //SetHighScore(0);
    }



    public int GetHighScore()
    {
        return m_highScore;
    }


    public int GetRoundsScore()
    {
        return m_roundsScore;
    }


    // ========= challenge 8H
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("runesData"))
        {
            // getting JSON to PlayerPref
            string savedJSON = PlayerPrefs.GetString("runesData", "{}");

            // deserialising JSON into SaveData obj
            SaveData saveData = JsonUtility.FromJson<SaveData>(savedJSON);

            // populating game data with SaveData obj
            m_highScore = saveData.sd_highScore;
            m_roundsScore = saveData.sd_roundsScore;

            // ========= challenge 8H
            m_startingLives = saveData.sd_startingLives;
            //m_startingLives = 15;

            print($"LOAD DATA: {m_highScore}, {m_roundsScore} , {m_startingLives}");
        }
        else 
        {

            m_highScore = 0;
            m_roundsScore = 0;
            m_startingLives = 15;
        }
    }

    public void SetHighScore(int score)
    {
        // creating a SaveData obj
        SaveData saveData = new SaveData();

        // populating SaveData obj
        saveData.sd_highScore = score;
        saveData.sd_roundsScore = m_roundsScore;
        saveData.sd_startingLives = m_startingLives;
        // serialising SaveData with JSON
        string savedJSON = JsonUtility.ToJson(saveData);

        // saving JSON to PlayerPref
        PlayerPrefs.SetString("runesData", savedJSON);

        m_highScore = score;
    }

    public void SetRoundsScore(int roundsScore)
    {
        // creating a SaveData obj
        SaveData saveData = new SaveData();

        // populating SaveData obj
        saveData.sd_highScore = m_highScore;
        saveData.sd_roundsScore = roundsScore;
        saveData.sd_startingLives = m_startingLives;
        // serialising SaveData with JSON
        string savedJSON = JsonUtility.ToJson(saveData);

        // saving JSON to PlayerPref
        PlayerPrefs.SetString("runesData", savedJSON);

        m_roundsScore = roundsScore;
    }


    // ===== c8H
    public void IncreaseStartingLives()
    {
        m_startingLives++;
        // creating a SaveData obj
        SaveData saveData = new SaveData();

        // populating SaveData obj
        saveData.sd_highScore = m_highScore;
        saveData.sd_roundsScore = m_roundsScore;
        saveData.sd_startingLives = m_startingLives;
        // serialising SaveData with JSON
        string savedJSON = JsonUtility.ToJson(saveData);

        // saving JSON to PlayerPref
        PlayerPrefs.SetString("runesData", savedJSON);

    }
    // TODO: refactor and merge
    // SetHighScore, SetRoundsScore, IncreaseStartingLives
    // in one method


    private void OnApplicationQuit__()
    {}


}
