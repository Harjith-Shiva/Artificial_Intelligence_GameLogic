
namespace GameApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game_logic gmlc = new Game_logic();
            label1.Text = gmlc.root_node.numbers;
            label9.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string startstring = label1.Text;
            if (startstring != string.Empty)
            {
                if (!startstring.Contains(button2.Text))
                {
                    DialogResult result = MessageBox.Show(this,"The chosen number is no longer avilable... Choose another number", "String Game", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        button1.Focus();
                        return;
                    }
                }
            }
            HelperVariables.humanscore = Convert.ToInt16(label4.Text);
            HelperVariables.computerscore = Convert.ToInt16(label5.Text);
            Font LargeFont = new Font("Arial", 25);
            Game_logic gmlc = new Game_logic();

            if (HelperVariables.humanplay == 1 && label1.Text != String.Empty)
            {
                HelperVariables.user_choice = Convert.ToInt32(button2.Text);
                gmlc.human_play(label1.Text, HelperVariables.humanplay, HelperVariables.parentnode);
                label1.Text = HelperVariables.stringnumber;
                label4.Text = HelperVariables.humanscore.ToString();
            }
            if (HelperVariables.humanplay == 0 && label1.Text != String.Empty)
            {
                label8.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                DialogResult result = MessageBox.Show(this,"Note your score in the score window and now Computer is playing... Click OK", "String Game", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    HelperVariables.humanscore = Convert.ToInt16(label4.Text);
                    gmlc.computer_play(label1.Text, HelperVariables.humanplay, HelperVariables.parentnode);
                    label1.Text = HelperVariables.stringnumber;
                    label5.Text = HelperVariables.computerscore.ToString();
                }
                if (HelperVariables.humanplay == 1 && label1.Text != String.Empty)
                {
                    DialogResult result1 = MessageBox.Show(this,"Note Scores in the score window and now it is your turn... Choose the Number", "String Game", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        label8.Visible = true;
                        button1.Visible = true;
                        button2.Visible = true;
                    }
                }

            }
            if (label1.Text.Equals(string.Empty))
            {
                label8.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                DialogResult result1 = MessageBox.Show(this,"Game Over ... ", "String Game", MessageBoxButtons.OK);
                if (result1 == DialogResult.OK)
                {
                    if (HelperVariables.humanscore > HelperVariables.computerscore)
                        label9.Text = "WINNER IS " + "PLAYER";
                    else if (HelperVariables.humanscore == HelperVariables.computerscore)
                        label9.Text = "IT'S A DRAW...";
                    else if (HelperVariables.humanscore < HelperVariables.computerscore)
                        label9.Text = "WINNER IS " + "COMPUTER";
                }
                label9.Visible = true;
                label9.Font = LargeFont;
                label1.Visible = false;
                label7.Visible = false;
                DialogResult result11 = MessageBox.Show(this,"Do you want to  Play Again?", "String Game", MessageBoxButtons.YesNo);
                Form1 frm1 = new Form1();
                if (result11 == DialogResult.Yes)
                    {
                    this.Hide();
                   
                    frm1.Show();
                    HelperVariables.user_choice = 0;
                    HelperVariables.stringnumber = string.Empty;
                    HelperVariables.humanscore = 0; HelperVariables.human_score = 0;
                    HelperVariables.computerscore = 0; HelperVariables.computer_score = 0;
                    HelperVariables.humanplay = 0;
                    HelperVariables.initialstart = 0;
                    HelperVariables.parentnode = String.Empty;

                    }
                else
                {
                    MessageBox.Show("Thank You... Catch You Another Time...Bye", "String Game");
                    frm1.Close();
                    this.Close();
                    
                }
                   
                }

            }

            private void button1_Click(object sender, EventArgs e)
            {
                string startstring = label1.Text;
                if (startstring != string.Empty)
                {
                    if (!startstring.Contains(button1.Text))
                    {
                        DialogResult result = MessageBox.Show("The chosen number is no longer available... Choose another number", "String Game", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            button2.Focus();
                            return;
                        }
                    }
                }
                HelperVariables.humanscore = Convert.ToInt16(label4.Text);
                Font LargeFont = new Font("Arial", 25);

                Game_logic gmlc = new Game_logic();

                if (HelperVariables.humanplay == 1 && label1.Text != String.Empty)
                {
                    HelperVariables.user_choice = Convert.ToInt32(button1.Text);
                    gmlc.human_play(label1.Text, HelperVariables.humanplay, HelperVariables.parentnode);
                    label1.Text = HelperVariables.stringnumber;
                    label4.Text = HelperVariables.humanscore.ToString();
                }
                if (HelperVariables.humanplay == 0 && label1.Text != String.Empty)
                {
                    label8.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    DialogResult result = MessageBox.Show("Note your score in the score window and now Computer is playing... Click OK", "String Game", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        HelperVariables.computerscore = Convert.ToInt16(label5.Text);
                        gmlc.computer_play(label1.Text, HelperVariables.humanplay, HelperVariables.parentnode);
                        label1.Text = HelperVariables.stringnumber;
                        label5.Text = HelperVariables.computerscore.ToString();
                    }
                    if (HelperVariables.humanplay == 1 && label1.Text != String.Empty)
                    {
                        DialogResult result1 = MessageBox.Show("Note Scores in the score window and now it is your turn... Choose the Number", "String Game", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            label8.Visible = true;
                            button1.Visible = true;
                            button2.Visible = true;
                        }
                    }

                }
                if (label1.Text.Equals(string.Empty))
                {
                    label8.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    DialogResult result1 = MessageBox.Show("Game Over ... ", "String Game", MessageBoxButtons.OK);
                    if (result1 == DialogResult.OK)
                    {
                        if (HelperVariables.humanscore > HelperVariables.computerscore)
                            label9.Text = "WINNER IS " + "PLAYER";
                        else if (HelperVariables.humanscore == HelperVariables.computerscore)
                            label9.Text = "IT'S A DRAW...";
                        else if (HelperVariables.humanscore < HelperVariables.computerscore)
                            label9.Text = "WINNER IS " + "COMPUTER";
                    }
                    label9.Visible = true;
                    label9.Font = LargeFont;
                    label1.Visible = false;
                    label7.Visible = false;
                }

            }

            private void button3_Click(object sender, EventArgs e)
            {
                HelperVariables.parentnode = "A1";
                HelperVariables.initialstart = 1;
                label8.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                HelperVariables.humanplay = 1;
                button3.Visible = false;
                button4.Visible = false;
                label6.Visible = false;

            }

            private void button4_Click(object sender, EventArgs e)
            {
                HelperVariables.parentnode = "A1";
                HelperVariables.initialstart = 0;
                label8.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                HelperVariables.humanplay = 0;
                button3.Visible = false;
                button4.Visible = false;
                label6.Visible = false;

                HelperVariables.humanscore = Convert.ToInt16(label4.Text);

                Game_logic gmlc = new Game_logic();
                if (HelperVariables.humanplay == 0 && label1.Text != String.Empty)
                {
                    DialogResult result = MessageBox.Show("Computer starts playing... Click OK", "String Game", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        HelperVariables.computerscore = Convert.ToInt16(label5.Text);
                        gmlc.computer_play(label1.Text, HelperVariables.humanplay, HelperVariables.parentnode);
                        label1.Text = HelperVariables.stringnumber;
                        label5.Text = HelperVariables.computerscore.ToString();
                    }

                }
            }
        }
    }