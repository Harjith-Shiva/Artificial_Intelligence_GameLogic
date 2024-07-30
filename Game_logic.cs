using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
   
   class Game_logic : HelperVariables
    {

        public node root_node = common.nodes[0];
        public void human_play(string rootnode, int humanind,string parent_node)
        {
            string rn = rootnode,referencenode;
            int childcount = 0;
            string Childnode;
            string NodeId = String.Empty, stnumber1 = String.Empty, stnumber2 = String.Empty;
           
            if (humanind == 1)
            {
                int n = rn.IndexOf(user_choice.ToString());
                rn = rn.Remove(n, 1);
                stringnumber = rn;
                humanscore += user_choice;
                HelperVariables.human_score += user_choice;
                for (int k = 0; k <= common.nodes.Count - 1; k++)
                {
                    if (stringnumber.Equals(common.nodes[k].numbers))
                    {
                        if(initialstart == 1)
                        {
                            if (HelperVariables.human_score.Equals(common.nodes[k].p1))
                            {
                                HelperVariables.parentnode = common.nodes[k].id;
                                stringnumber = common.nodes[k].numbers;
                            }
                        }
                        else
                        {
                            if (HelperVariables.human_score.Equals(common.nodes[k].p2))
                            {
                                parentnode = common.nodes[k].id;
                                stringnumber = common.nodes[k].numbers;
                            }
                        }
                    }
                }


                }
            HelperVariables.humanplay = 0;
        }

        public void computer_play(string rootnode, int humanind,string parent_node)
        {
            string rn = rootnode;
            int childcount = 0;
            string Childnode;
            string NodeId = String.Empty, stnumber1 = String.Empty, stnumber2 = String.Empty;
            int Minmaxval1 = 0, Minmaxval2 = 0, score1 =0,score2 =0;
            if (humanind == 0)
            {
                stringnumber = rn;
                
                foreach (var parent in common.numberNames.Keys)
                {
                    
                    if (parent.Equals(parent_node))
                    {
                        childcount = common.numberNames[parent].Count;
                        if (childcount == 1)
                        {
                            Childnode = common.numberNames[parent][0];
                            for (int k = 0; k <= common.nodes.Count - 1; k++)
                            {
                                if (Childnode.Equals(common.nodes[k].id))
                                {
                                    HelperVariables.parentnode = common.nodes[k].id;
                                    if (initialstart == 0)
                                    {
                                        stringnumber = common.nodes[k].numbers;
                                        computerscore =  common.nodes[k].p1;
                                        break;
                                    }
                                    else
                                    {
                                        stringnumber = common.nodes[k].numbers;
                                        computerscore =  common.nodes[k].p2;
                                        break;
                                    }
                                }


                            }
                        }
                        if (childcount == 2)
                        {
                            var child1 = common.numberNames[parent][0];
                            var child2 = common.numberNames[parent][1];
                            for (int k = common.nodes.Count - 1; k >= 0; k--)
                            {
                                if (common.nodes[k].id == child1)
                                {
                                    Minmaxval1 = common.nodes[k].minimax_val;
                                    stnumber1 = common.nodes[k].numbers;
                                    HelperVariables.parentnode = common.nodes[k].id;
                                    if (initialstart == 0)
                                    {
                                        score1 = common.nodes[k].p1;
                                    }
                                    else
                                    {
                                        score1 = common.nodes[k].p2;
                                    }
                                }
                            }
                            for (int k = common.nodes.Count - 1; k >= 0; k--)
                            {
                                if (common.nodes[k].id == child2)
                                {
                                    Minmaxval2 = common.nodes[k].minimax_val;
                                    stnumber2 = common.nodes[k].numbers;
                                    HelperVariables.parentnode = common.nodes[k].id;
                                    if (initialstart == 0)
                                    {
                                        score2 = common.nodes[k].p1;
                                    }
                                    else
                                    {
                                        score2 = common.nodes[k].p2;
                                    }
                                }
                            }
                            
                                if (initialstart == 0)
                                {
                                    if (Minmaxval1 > Minmaxval2)
                                    {
                                        stringnumber = stnumber1;
                                        computerscore = score1;
                                    }
                                    else
                                    {
                                        stringnumber = stnumber2;
                                        computerscore = score2;
                                    }
                                   
                                }
                                else if (initialstart == 1)
                                {
                                    if (Minmaxval1 < Minmaxval2)
                                    {
                                        stringnumber = stnumber1;
                                        computerscore = score1;
                                    }
                                    else
                                    {
                                        stringnumber = stnumber2;
                                        computerscore = score2;
                                    }

                                }


                            

                        }
                        break;
                    }

                   

                }
            }
            HelperVariables.humanplay = 1;


            }

        }
            }
         
        