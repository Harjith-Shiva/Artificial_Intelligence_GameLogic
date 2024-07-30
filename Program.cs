namespace GameApp
{
    class common //the global members used through-out. 
    {
        public static List<node> nodes_generated = new List<node>();
        public static int j = 2;
        public static string number_used;
        public static node current_node;

        public static List<node> nodes = new List<node>();
        public static IDictionary<string, List<string>> numberNames = new Dictionary<string, List<string>>();

        public static List<node> heuristic_nodes = new List<node>();
        public static List<string> level_nodes = new List<string>();
    }
    class node : common      //node of a game tree
    {
        public string id;
        public string numbers;
        public int p1;
        public int p2;
        public int depth;
        public int minimax_val;



    }
    class string_tree : node  // adding nodes and arcs function implementation.
    {


        /*public string_tree()
        {
            List<node> nodes = new List<node>();
            IDictionary<string, List<string>> numberNames = new Dictionary<string, List<string>>();
        }*/
        public void add_node(node n)
        {
            nodes.Add(n);
        }

        public void add_arc(string start_node_id, string end_node_id)
        {
            if (!numberNames.ContainsKey(start_node_id))
            {

                numberNames.Add(start_node_id, new List<string>());
            }
            numberNames[start_node_id].Add(end_node_id);
        }



    }

    class move : string_tree
    {



        public void moves(string move_made, List<node> nodes_generated, node current_node)   // the game moves logic.
        {

            if (move_made == "1")
                number_used = "1";    // the number used in the string
            else if (move_made == "2")
                number_used = "2";   // the number used in the string



            if (current_node.numbers.Contains(number_used))
            {
                string new_id = String.Concat("A", j.ToString());
                ++j;
                string new_string = current_node.numbers;
                int new_p1 = 0;
                int new_p2 = 0;
                if (number_used == "2")
                {
                    int pos = new_string.IndexOf(number_used);
                    new_string = new_string.Remove(pos, 1);
                }
                else
                {
                    int pos = new_string.IndexOf(number_used);
                    new_string = new_string.Remove(pos, 1);
                }

                if (move_made == "1" || move_made == "2")
                {
                    if (current_node.depth % 2 == 0)
                    {
                        new_p1 = current_node.p1;
                        new_p2 = current_node.p2 + Int16.Parse(number_used);
                    }
                    else
                    {
                        new_p1 = current_node.p1 + Int16.Parse(number_used);
                        new_p2 = current_node.p2;
                    }
                }
                int new_depth = current_node.depth + 1;
                node new_node = new node();
                new_node.id = new_id;
                new_node.numbers = new_string;
                new_node.p1 = new_p1;
                new_node.p2 = new_p2;
                new_node.depth = new_depth;

                bool check_redundant = false;
                int i = 0;
                while ((!check_redundant) && (i <= (nodes.Count) - 1))  // while loop for checking whether the node is redundant or not.
                {
                    node check_node = nodes[i];
                    if ((check_node.numbers == new_node.numbers) && (check_node.p1 == new_node.p1) && (check_node.p2 == new_node.p2) && (check_node.depth == new_node.depth))
                    {
                        check_redundant = true;
                        --j;
                    }
                    else
                        ++i;
                }

                if (!check_redundant)   // if it is not redundant it is added both as anew node and arcs for it.
                {
                    move new_move = new move();
                    new_move.add_node(new_node);
                    new_move.add_arc(current_node.id, nodes[i].id);
                    nodes_generated.Add(new_node);
                }
                if (check_redundant)    // if it is redundant it is just added with the existing node's arcs, no new node creation.
                {
                    move new_move = new move();
                    node duplicate_node = nodes[i];
                    new_move.add_arc(current_node.id, duplicate_node.id);
                }





            }


        }
        public void generate_nodes()   // making the moves for a particular node.
        {
            while (nodes_generated.Count > 0)
            {
                current_node = nodes_generated[0];
                move m1 = new move();
                m1.moves("1", nodes_generated, current_node);
                m1.moves("2", nodes_generated, current_node);
                nodes_generated.RemoveAt(0);
            }
        }
        public void display()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine("node id:" + nodes[i].id + "--------" + "present string: " + nodes[i].numbers
                   + "--------" + "player1(score): " + nodes[i].p1 + "-------" + "player2(score): " + nodes[i].p2 + "---------minimax_value: " + nodes[i].minimax_val);
            }
            foreach (var parent in numberNames.Keys)
            {

                var child = numberNames[parent].Count;
                if (child == 1)
                    Console.WriteLine(parent + " only child: " + numberNames[parent][0]);
                if (child == 2)

                {
                    Console.WriteLine(parent + " child 1: " + numberNames[parent][0]);
                    Console.WriteLine(parent + " child 2: " + numberNames[parent][1]);
                }
            }

        }

    }


    class tree_values : move
    {

        public int find_max_depth()
        {
            int max_depth = nodes[0].depth;
            for (int i = 1; i <= (nodes.Count) - 1; i++)
            {
                if (nodes[i].depth > max_depth)
                    max_depth = nodes[i].depth;
            }
            return max_depth;
        }


        public void assign_minimax()
        {
            //int i = (nodes.Count);
            int height = find_max_depth();

            for (int i = (nodes.Count - 1); i > 0; i--)
            {
                if (nodes[i].depth == height)
                {
                    if (nodes[i].p1 > nodes[i].p2)
                    {
                        nodes[i].minimax_val = 1;

                    }
                    else
                    {
                        nodes[i].minimax_val = -1;

                    }

                }


                else
                {
                    foreach (var parent in numberNames.Keys)
                    {
                        if (parent == nodes[i].id)
                        {
                            int child = numberNames[parent].Count;
                            if (child == 1)
                            {
                                string child_1_id = numberNames[parent][0];
                                for (int k = nodes.Count - 1; k >= 0; k--)
                                {
                                    if (child_1_id == nodes[k].id)
                                    {
                                        nodes[i].minimax_val = nodes[k].minimax_val;
                                    }
                                    else
                                        continue;
                                }
                            }
                            else
                            {
                                string child_1_id = numberNames[parent][0];
                                string child_2_id = numberNames[parent][1];
                                int child_1_heuristic = 0;
                                int child_2_heuristic = 0;
                                for (int k = nodes.Count - 1; k >= 0; k--)
                                {
                                    if (child_1_id == nodes[k].id)
                                    {
                                        child_1_heuristic = nodes[k].minimax_val;
                                    }
                                    else
                                        continue;
                                }

                                for (int k = nodes.Count - 1; k >= 0; k--)
                                {
                                    if (child_2_id == nodes[k].id)
                                    {
                                        child_2_heuristic = nodes[k].minimax_val;
                                    }
                                    else
                                        continue;
                                }

                                if (nodes[i].depth % 2 == 0)
                                {
                                    nodes[i].minimax_val = Math.Min(child_1_heuristic, child_2_heuristic);
                                }
                                else
                                {
                                    nodes[i].minimax_val = Math.Max(child_1_heuristic, child_2_heuristic);
                                }
                            }
                        }
                        else
                            continue;
                    }
                }


            }
        }



        internal static class Program
        {
            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
               
                node first_node = new node();
                string_tree root = new string_tree();
                move move_gen = new move();
                tree_values T = new tree_values();

                first_node.id = "A1";
                first_node.numbers = "1112";
                number_used = first_node.numbers;
                first_node.p1 = 0;
                first_node.p2 = 0;
                first_node.depth = 1;
                nodes_generated.Add(first_node);  // adding the first initial input of string and player's scores.
                root.add_node(first_node);
                move_gen.generate_nodes();   // the function to create children for the current node selected.




                T.assign_minimax();
               // move_gen.display();
               
                Application.Run(new Form1());
               
            }
        }
    }
}
