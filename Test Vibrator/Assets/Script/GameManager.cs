using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    #region Start variable declaration
    [Header("Top Panel")]
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    #endregion

    #region Slider varible declaration
    public Slider slider;
    public Text millisTextSlider;
    #endregion

    #region STARTING GAME

    private void Start()
    {
        getAPiLevel();
        AmplitudeControl();
        DefaultAmplitude();
        PhoneAdeTakVibrator();
        showOrHideWarningPanel();

        if (Vibration.GetApiLevel() < 2)
            Debug.Log("You run in a editor");
    }

    private void getAPiLevel()
    {
        text1.text = "API LEVEL IS " + Vibration.GetApiLevel().ToString();
    }

    private void AmplitudeControl()
    {
        text2.text = "Has Amplitude Control? " + Vibration.HasAmplitudeControl().ToString();
    }

    private void PhoneAdeTakVibrator()
    {
        text4.text = "PHONE HAS VIBRATOR: " + Vibration.HasVibrator().ToString().ToUpper();
    }

    private void DefaultAmplitude()
    {
        text3.text = "Default Ampitude: " + Vibration.GetDefaultAmplitude().ToString();
    }
    #endregion

    #region Slider Vibrator Function
    [Header("SLider panel")]
    public float VibrationToBeApplied = 800f;
    private bool isSnapToTenMs = true;
    public void updateValue()
    {
        float value = slider.value * 1000; //in millis
        //Debug.Log(value);
        float truncatedValue = Mathf.Round(value);

        if (isSnapToTenMs)
        {
            int newVal = (int) FloatExtensions.ToNearestMultiple(truncatedValue, 10);
            millisTextSlider.text = newVal + " ms";
            VibrationToBeApplied = newVal;
        } else //isSnap is off
        {
            millisTextSlider.text = truncatedValue + " ms";
            VibrationToBeApplied = truncatedValue;
        }

    }

    public void SnapTo10ms(bool status)
    {
        isSnapToTenMs = status;
    }

    public void ApplyVibration()
    {
        Vibration.Vibrate((long) VibrationToBeApplied);
        Debug.Log("Vibration applied: " + VibrationToBeApplied);
    }

    /*
     * -Boleh letak message mengatakan if below <30, phone tk support
     */
    #endregion
    
    public void TestVibration()
    {
        Vibration.Vibrate(500);
    }

    public void TestVibration(int millis)
    {
        Vibration.Vibrate(millis);
    }

    #region Predefined effect

    [Header("Predefined panel")]
    public GameObject WarningPanel;

    public void PredefinedSelect(int i)
    {
        switch (i)
        {
            case 1: Predefined1(); Debug.Log("case " + i + " called."); break;
            case 2: Predefined2(); Debug.Log("case " + i + " called."); break;
            case 3: Predefined3(); Debug.Log("case " + i + " called."); break;
            case 4: Predefined4(); Debug.Log("case " + i + " called."); break;
        }
    }

    private void Predefined1()
    {
        Vibration.VibratePredefined(Vibration.PredefinedEffect.EFFECT_CLICK);
    }

    private void Predefined2()
    {
        Vibration.VibratePredefined(Vibration.PredefinedEffect.EFFECT_DOUBLE_CLICK);
    }

    private void Predefined3()
    {
        Vibration.VibratePredefined(Vibration.PredefinedEffect.EFFECT_HEAVY_CLICK);
    }

    private void Predefined4()
    {
        Vibration.VibratePredefined(Vibration.PredefinedEffect.EFFECT_TICK);
    }

    private void showOrHideWarningPanel()
    {
        int currentApi = Vibration.GetApiLevel();
        int minApiRequired = 29;

        if (currentApi < minApiRequired)
        {
            WarningPanel.SetActive(true);
        }
    }

    #endregion
}

