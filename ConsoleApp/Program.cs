using System;
using WebStructure;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Web<string> myWeb = new Web<string>();

            myWeb.AddNode("0", "0011");
            myWeb.AddNode("A", "ABRACADABRA");
            myWeb.AddNode("Z", "ZELOUS");

            myWeb.AddNode("B", "BAD");
            myWeb.AddNode("C", "CATS");
            myWeb.AddNode("D", "DON'T");
            myWeb.AddNode("E", "ELEVATE");

            myWeb.NodeByKey("A").LinkTo(myWeb.NodeByKey("B"));
            myWeb.NodeByKey("B").LinkTo(myWeb.NodeByKey("C"));
            myWeb.NodeByKey("C").LinkTo(myWeb.NodeByKey("D"));
            myWeb.NodeByKey("D").LinkTo(myWeb.NodeByKey("Z"));
            myWeb.NodeByKey("D").LinkTo(myWeb.NodeByKey("E"));
            myWeb.NodeByKey("E").LinkTo(myWeb.NodeByKey("A"));

            myWeb.MutualLink(myWeb.NodeByKey("0"), myWeb.NodeByKey("A"));
            myWeb.MutualLink(myWeb.NodeByKey("Z"), myWeb.NodeByKey("A"));

            Node<string> currentNode = myWeb.NodeByKey("A");

            Console.WriteLine(myWeb.NodeByKey("D"));

            while (true)
            {
                //Console.Clear();
                currentNode.Links.ForEach(L => Console.WriteLine("{0} = {1}", L.Key, L.Value));

                string input = Console.ReadLine();

                if (currentNode.Links.Contains(myWeb.NodeByKey(input)))
                {
                    currentNode = myWeb.NodeByKey(input);
                    currentNode.LinkTo(currentNode);
                }
            }
        }
    }
}
