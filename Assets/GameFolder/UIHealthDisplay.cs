using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthDisplay : MonoBehaviour
{
    public FloatVariable variable;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        if (slider != null && variable != null)

        slider.value = variable.Value;
    }
}
