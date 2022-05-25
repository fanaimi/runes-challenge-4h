using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public struct SaveUserData
{
    public string sd_uName;
    public string sd_uAge;
    public string sd_uCity;
    public string sd_uWeight;
}


/// <summary>
/// @gObj   Challenge4 > GameManagerC4 
/// @desc   singleton, will save and load user data
/// </summary>
public class GameManagerC4: MonoBehaviour
{
    private static GameManagerC4 s_instance;
    public static GameManagerC4 Instance { get { return s_instance; } }


    public SaveUserData sUserdata; 


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

        sUserdata = LoadUserInfo();
    }

    public SaveUserData LoadUserInfo()
    {

        if (PlayerPrefs.HasKey("userData"))
        {
            // getting JSON to PlayerPref
            string savedJSON = PlayerPrefs.GetString("userData", "{}");

            // deserialising JSON into SaveData obj
            SaveUserData userData = JsonUtility.FromJson<SaveUserData>(savedJSON);
            // print("got user");
            return userData;
        }
        // print("got nothing");
        return default; // empty SaveUserData

    }

    public void SaveUserInfo(
        string uName,
        string uAge,
        string uCity,
        string uWeight
    )
    {
        // creating a SaveData obj
        SaveUserData userData = new SaveUserData();

        // populating SaveData obj
        userData.sd_uName = uName;
        userData.sd_uAge = uAge;
        userData.sd_uCity = uCity;
        userData.sd_uWeight = uWeight;
        // serialising SaveData with JSON
        string savedJSON = JsonUtility.ToJson(userData);

        // saving JSON to PlayerPref
        PlayerPrefs.SetString("userData", savedJSON);
        // print("user saved");
    }


}
