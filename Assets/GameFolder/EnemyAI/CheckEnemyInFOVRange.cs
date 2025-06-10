using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
using Unity.VisualScripting;

public class CheckEnemyInFOVRange : Node 
{
    //changed to public to test an attack Node
    public static int _enemyLayer = 1 << 6;

    private Transform _transform;

    public CheckEnemyInFOVRange(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        
        if(t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position,GuardBT.fovRange ,_enemyLayer);

            if(colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }
            else
            {
                state = NodeState.FAILURE;
                return state;
            }
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
