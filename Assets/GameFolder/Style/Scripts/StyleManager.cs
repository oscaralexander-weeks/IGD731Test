using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StyleManager : MonoBehaviour
{
    [SerializeField] private FloatVariable style;
    [SerializeField] private Slider styleSlider;
    [SerializeField] private TextMeshProUGUI styleTextComponent;
    [SerializeField] private float StyleSpeedMultipler;

    // Update is called once per frame
    void Update()
    {
        if(style != null && style.Value > 0 && styleSlider != null)
        {
            style.Value -= (float)(Time.deltaTime * StyleSpeedMultipler);
            CheckStyle(styleSlider);
        }

        if(style.Value < 0)
        {
            style.SetValue(0);
        }
    }

    private void CheckStyle(Slider style)
    {
        float v = style.value;
        styleTextComponent.text = v switch
        {
            < 15 => "F",
            < 30 => "E",
            < 45 => "D",
            < 60 => "C",
            < 75 => "B",
            < 90 => "A",
            < 150 => "S",
            _ => styleTextComponent.text // fallback
        };
    }
}
