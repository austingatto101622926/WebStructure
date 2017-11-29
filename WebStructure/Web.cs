using System;
using System.Linq;
using System.Collections.Generic;

namespace WebStructure
{
    public class Web<T>
    {
        public List<Node> Nodes { get; private set; } = new List<Node>();

        public bool AddNode(string key, T value)
        {
            if (Nodes == null || Nodes.Select(N => N.Key).ToList().Contains(key) ) // If a node with the given key already exists...
            {
                return false; //return false...
            }
            else //otherwise...
            {
                Nodes.Add(new Node(this, key, value)); //create and add the node to the list...
                return true; //and return true.
            }
        }

        public Node NodeByKey(string key)
        {
            return Nodes.Find(N => N.Key == key);
        }

        public void RemoveNode(Node node)
        {
            Nodes.Where(N => N.Links.Contains(node)).ToList().ForEach(N => N.UnlinkFrom(node));
            Nodes.Remove(node);
        }

        public void RemoveNode(string key)
        {
            RemoveNode(NodeByKey(key));
        }

        public void MutualLink(Node node1, Node node2)
        {
            node1.LinkTo(node2);
            node2.LinkTo(node1);
        }

        public void MutualUnlink(Node node1, Node node2)
        {
            node1.UnlinkFrom(node2);
            node2.UnlinkFrom(node1);
        }



        //NODE CLASS 
        public class Node
        {
            public T Value { get; set; }
            public string Key { get; set; }
            public List<Node> Links { get; private set; }

            private Web<T> Parent;

            public Node(Web<T> parent, string key, T value)
            {
                this.Value = value;
                this.Key = key;
                Links = new List<Node>();

                this.Parent = parent;
            }

            public void LinkTo(Node node)
            {
                if (Parent.Nodes.Contains(node)) this.Links.Add(node);
            }

            public void LinkTo(string key)
            {
                this.LinkTo(Parent.NodeByKey(key));
            }

            public void UnlinkFrom(Node node)
            {
                this.Links.Remove(node);
            }            

            public void UnlinkFrom(string key)
            {
                this.UnlinkFrom(Parent.NodeByKey(key));
            }
        }

    }
}
