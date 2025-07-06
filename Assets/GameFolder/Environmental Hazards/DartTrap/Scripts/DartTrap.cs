using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : TrapTrigger
{

    public override void TrapTriggered()
    {
        OnTrapTrigger?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerControllerWASD player = other.GetComponent<PlayerControllerWASD>();

        if(player != null)
        {
            TrapTriggered();
        }
    }


}
