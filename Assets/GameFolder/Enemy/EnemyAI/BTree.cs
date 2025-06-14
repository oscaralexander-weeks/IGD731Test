using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviourTree
{
    public abstract class BTree : MonoBehaviour
    {
        //_root is reference to the total tree of Nodes 
        private Node _root = null;

        //at start the tree is built from the derived Tree Classes 
        protected void Start()
        {
            _root = SetUpTree();
        }

        //constantly calls the Evaluate function of every child in the tree to constantly evaluate decision making by the AI
        private void Update()
        {
            if(_root != null)
            {
                _root.Evaluate();
            }
        }

        //requires the to return at least one Node to build a tree in a derived Tree Class 
        protected abstract Node SetUpTree();
    }
}

