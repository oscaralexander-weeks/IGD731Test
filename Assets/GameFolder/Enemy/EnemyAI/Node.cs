using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    //define the 3 possible states a node can be in during an evaluation
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node
    {
        //protected NodeState that can be reference up & down the tree
        protected NodeState state;

        //parent and children
        public Node parent;
        protected List<Node> children = new List<Node>();

        //private dictionary so data can be shared across the tree 
        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        //empty constructor will return null parent
        public Node()
        {
            parent = null;
        }

        //takes a defined list of children to add onto a parent node e.g. Node A = Node( new List<A1, A2>) this will make A1 and A2 children of A 
        public Node(List<Node> children)
        {
            foreach(Node child in children)
            {
                _Attach(child);
            }
        }

        //attaches a node as a child to the node from where it's called so if Node A calls _Attach(A1) A1 will be a child of A 
        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        //virtual NodeState Evaluate function can be overriding in each Node to define functionality - has to return a NodeState for further processing in the tree
        public virtual NodeState Evaluate() => NodeState.FAILURE;
        
        //simple way to store agnostic data in a shared dictionary 
        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        //if the key is contained within the dictionary it returns the value 
        //otherwise it is called recursively until it either finds the key and returns the value 
        //or it runs out of parent nodes and returns null 
        public object GetData(string key)
        {
            object value = null;
            if (_dataContext.TryGetValue(key, out value))
                return value;

            Node node = parent;

            if (node != null)
                value = node.GetData(key);
            return value;
        }

        //clear data works the same but returns true if the key is found in the dict and removed 
        //or it returns false if the key is not found within the node or parents 
        public bool ClearData(string key)
        {
            bool isCleared = false;

            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;

            if (node != null)
                isCleared = node.ClearData(key);
            return isCleared;
        }
    }
}

