﻿using System.Collections;
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
    [Header("Slider panel")]
    public float VibrationToBeApplied = 800f;
    private bool isSnapToTenMs = true;
    public Slider slider;
    public Text millisTextSlider;
    public GameObject warningText;
    public void updateValue()
    {
        float value = slider.value * 1000; //in millis
        if (value < 30)
            warningText.SetActive(true);
        else
            warningText.SetActive(false);

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

        updateButtonRunAmp((int)VibrationToBeApplied);
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

    /*public void TestVibration()
    {
        Vibration.Vibrate(500);
    }

    public void TestVibration(int millis)
    {
        Vibration.Vibrate(millis);
    }*/

    #region Vibrate amplitude
    [Header("Amplitude panel")]
    public Slider sliderAmp;
    public Text ampTextSlider;
    public Text buttonText;
    private int AmplitudeToBeApplied = 255;
    private bool isSnapToTenMsAmp = false;
    public GameObject warningAmpPanel;
    
    public void updateValueAmp()
    {
        int valueAmp = (int) sliderAmp.value;

        if (isSnapToTenMsAmp)
        {
            int newVal = IntRoundExtension.RoundOff(valueAmp);
            newVal = Mathf.Clamp(newVal, 0, 255);
            ampTextSlider.text = newVal + " Unit";
            AmplitudeToBeApplied = newVal;
        }
        else //isSnap is off
        {
            ampTextSlider.text = valueAmp + " Unit";
            AmplitudeToBeApplied = valueAmp;
        }

        updateButtonRunAmp((int)VibrationToBeApplied, AmplitudeToBeApplied);
    }

    public void updateButtonRunAmp(int ms, int amp = 255)
    {
        buttonText.text = "RUN " + ms + " ms" + " AND AMPLITUDE " + amp;
    }

    public void SnapTo10msAmp(bool status)
    {
        isSnapToTenMsAmp = status;
    }

    public void ApplyVibrationAmp()
    {
        Vibration.Vibrate((long)VibrationToBeApplied, AmplitudeToBeApplied);
        Debug.Log("Vibration applied: " + VibrationToBeApplied + " with amplitude " + AmplitudeToBeApplied);
    }
	#endregion

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

        bool supportAmplitude = Vibration.HasAmplitudeControl();

        if (currentApi < minApiRequired)
        {
            WarningPanel.SetActive(true);
        }

        if (!supportAmplitude)
            warningAmpPanel.SetActive(true);
    }

	#endregion

}

