using System;
using System.Linq;
using System.Collections.Generic;

namespace WebStructure
{
    public class Web<T>
    {
        public List<Node<T> > Nodes { get; private set; } = new List<Node<T> >();

        public bool AddNode(string key, T value)
        {
            if (Nodes == null || Nodes.Select(N => N.Key).ToList().Contains(key) ) // If a node with the given key already exists...
            {
                return false; //return false...
            }
            else //otherwise...
            {
                Nodes.Add(new Node<T>(this, key, value)); //create and add the node to the list...
                return true; //and return true.
            }
        }

        public Node<T> NodeByKey(string key)
        {
            return Nodes.Find(N => N.Key == key);
        }

        public void RemoveNode(Node<T> node)
        {
            Nodes.Where(N => N.Links.Contains(node)).ToList().ForEach(N => N.UnlinkFrom(node));
            Nodes.Remove(node);
        }

        public void RemoveNode(string key)
        {
            RemoveNode(NodeByKey(key));
        }

        public void MutualLink(Node<T> node1, Node<T> node2)
        {
            node1.LinkTo(node2);
            node2.LinkTo(node1);
        }

        public void MutualUnlink(Node<T> node1, Node<T> node2)
        {
            node1.UnlinkFrom(node2);
            node2.UnlinkFrom(node1);
        }
    }
}
