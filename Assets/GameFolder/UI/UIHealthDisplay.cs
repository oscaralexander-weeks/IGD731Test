using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthDisplay : MonoBehaviour
{
    public FloatVariable variable;
    public FloatVariable variableMax;
    public Slider slider;
    public bool isReset;

    [SerializeField] private float VariableCap;
    private void Start()
    {
        if (isReset)
        {
            variable.Value = variableMax.Value;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (slider != null && variable != null)
        {
            slider.value = variable.Value;
        }

        if(variable.Value > VariableCap)
        {
            variable.Value = VariableCap;
        }

    }


}
