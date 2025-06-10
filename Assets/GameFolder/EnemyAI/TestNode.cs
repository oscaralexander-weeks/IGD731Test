using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class TestNode : Node
{
    public TestNode()
    {

    }


    public override NodeState Evaluate()
    {
        Debug.Log("Test Code Block");

        state = NodeState.SUCCESS;
        return state;
    }
}
