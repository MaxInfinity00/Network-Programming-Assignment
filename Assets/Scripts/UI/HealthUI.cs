using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
   [SerializeField] Image loadingBarImage;
   [SerializeField] Image ShieldBar;
    [SerializeField] Health health;
   /// <summary>
   /// Start is called on the frame when a script is enabled just before
   /// any of the Update methods is called the first time.
   /// </summary>
   void Start()
   {
       health.currentHealth.OnValueChanged += UpdateUI;
       health.shield.OnValueChanged += UpdateUI;
   }

    private void UpdateUI(int previousValue, int newValue)
    {
        loadingBarImage.fillAmount = (float)health.currentHealth.Value / 100;
        ShieldBar.fillAmount = (float)health.shield.Value / 2;
    }
}
