using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;



/// <summary>
/// @gObj   Canvas > Form
/// @desc   this will handle submission and validation
/// </summary>
public class FormController : MonoBehaviour
{
    [SerializeField] private TMP_Text m_submissionFeedbackMsg;   
    [SerializeField] private TMP_InputField m_NameText;
    [SerializeField] private TMP_InputField m_AgeText;
    [SerializeField] private TMP_InputField m_CityText;
    [SerializeField] private TMP_InputField m_WeightText;
    [SerializeField] private Button m_submitButton;

    private SaveUserData userData;

    private void PopulateForm()
    {
        // Debug.Log(GameManagerC4.Instance.sUserdata);
        var userData = GameManagerC4.Instance.sUserdata;
        // print("populating ");

        if (userData.sd_uName != null)
            m_NameText.text = userData.sd_uName;

        if (userData.sd_uAge != null)
            m_AgeText.text = userData.sd_uAge;

        if (userData.sd_uCity != null)
            m_CityText.text = userData.sd_uCity;

        if (userData.sd_uWeight != null)
            m_WeightText.text = userData.sd_uWeight;


    }

    // Start is called before the first frame update
    void Start()
    {

        ToggleButtonInteractability(m_submitButton, false);
        PopulateForm();
        ValidateForm();
    }


    private void ValidateForm()
    {
        if (m_NameText.text.Length <= 1)  return; 
        if (m_AgeText.text.Length <= 1) return;
        if (m_CityText.text.Length <= 1) return;
        if (m_WeightText.text.Length <= 1) return;
        // Debug.Log(1234);
        ToggleButtonInteractability(m_submitButton, true);
    }

    public void GreenLightField(TMP_InputField field)
    {
        // Debug.Log(field.text.Length);
        if (field.text.Length > 0)
        {
            field.image.color = Color.white;
            ValidateForm();
        }
        else
        {
            field.image.color = new Color(0.9607844f, 0.6862745f, 0.6862745f, 1); // rgba 0 -> 1
            ToggleButtonInteractability(m_submitButton, false);
        }
    }

    public void OnFormSubmit()
    {
        // print(1233);
        ShowMessage("Form has been submitted", Color.green);
        GameManagerC4.Instance.SaveUserInfo(
            m_NameText.text,
            // int.Parse(m_AgeText.text),
            m_AgeText.text,
            m_CityText.text,
            //float.Parse(m_WeightText.text)
            m_WeightText.text
        );
    }

    private void ShowMessage(string msg, Color col)
    {
        m_submissionFeedbackMsg.text = msg;
        m_submissionFeedbackMsg.color = col;
    }

    private void ToggleButtonInteractability(Button btn, bool isActive)
    {
        btn.interactable = isActive;
        string msg = isActive ? "You can now submit the form" : "At least 1 field is missing";
        Color col = isActive ? Color.green : Color.red;
        ShowMessage(msg, col);
    }

}
