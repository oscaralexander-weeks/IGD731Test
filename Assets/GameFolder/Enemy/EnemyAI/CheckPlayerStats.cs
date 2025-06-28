using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class CheckPlayerStats : Node
{

    private PlayerControllerWASD _player;

    public CheckPlayerStats(PlayerControllerWASD player)
    {
        _player = player;
    }

    public override NodeState Evaluate()
    {
        if (_player != null)
        {
            if (_player.IsStealth)
            {
                parent.parent.ClearData("target");
                state = NodeState.FAILURE;
                return state;
            }
        }

        state = NodeState.SUCCESS;
        return state;
    }

}
