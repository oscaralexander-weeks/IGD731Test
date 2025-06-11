using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableReset : MonoBehaviour
{
    public List<FloatVariable> floatVariables;
    public List<FloatReference> floatReferences;
    //public ItemRuntimeSet ItemRuntimeSet;
    public NewItemRuntimeSet runtimeSet;

    public bool isReset;

    private void Start()
    {
        if (isReset)
        {
            foreach(FloatVariable variable in floatVariables)
            {
                if(variable!= null)
                {
                    variable.Value = 0;
                }
            }

            foreach(FloatReference reference in floatReferences)
            {
                if(reference != null)
                {
                    reference.Variable.Value = 0;
                }
            }

            if (runtimeSet != null)
            {
                runtimeSet.Items.Clear();
            }
        }
    }
}
