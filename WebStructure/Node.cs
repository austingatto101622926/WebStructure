using System;
using System.Collections.Generic;
using System.Text;

namespace WebStructure
{
    public class Node<T>
        {
            public T Value { get; set; }
            public string Key { get; set; }
            public List<Node<T> > Links { get; private set; }

            private Web<T> Parent;

            public Node(Web<T> parent, string key, T value)
            {
            this.Parent = parent;
            this.Key = key;
            this.Value = value;

            Links = new List<Node<T>>();
            }

            public static implicit operator T(Node<T> node)
            {
            T value = node.Value;

            return value;
            }

            public void LinkTo(Node<T> node)
            {
                if (Parent.Nodes.Contains(node)) this.Links.Add(node);
            }

            public void LinkTo(string key)
            {
                this.LinkTo(Parent.NodeByKey(key));
            }

            public void UnlinkFrom(Node<T> node)
            {
                this.Links.Remove(node);
            }            

            public void UnlinkFrom(string key)
            {
                this.UnlinkFrom(Parent.NodeByKey(key));
            }
        }
}
