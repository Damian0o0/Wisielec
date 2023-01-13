using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Wisielec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string word = "";
        int amount = 0;
        List<Label> labels = new List<Label>();
        enum BodyParts 
        {
            Head,
            Left_Eye,
            Right_Eye,
            Mouth,
            Right_Arm,
            Left_Arm,
            Body,
            Right_Leg,
            Left_Leg,
        }

        void DrawHangPost()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Brown, 10);
            g.DrawLine(p, new Point(130, 248), new Point(130, 10));
            g.DrawLine(p, new Point(135, 5), new Point(65, 5));
            g.DrawLine(p, new Point(60, 0), new Point(60, 50));
           
            DrawBodyPart(BodyParts.Head);
            DrawBodyPart(BodyParts.Left_Eye);
            DrawBodyPart(BodyParts.Right_Eye);
            DrawBodyPart(BodyParts.Mouth);
            DrawBodyPart(BodyParts.Body);
            DrawBodyPart(BodyParts.Left_Arm);
            DrawBodyPart(BodyParts.Right_Arm);
            DrawBodyPart(BodyParts.Left_Leg);
            DrawBodyPart(BodyParts.Right_Leg);
            MessageBox.Show(GetRandomWord());
        }
        void DrawBodyPart(BodyParts bp)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 2);
            if (bp == BodyParts.Head)
            {
                g.DrawEllipse(p, 40, 50, 40, 40);
            }
            else if (bp == BodyParts.Left_Eye)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 50, 60, 5, 5);

            }
            else if (bp == BodyParts.Right_Eye)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 63, 60, 5, 5);
            }
            else if (bp == BodyParts.Mouth)
            {
                g.DrawArc(p, 50, 60, 20, 20, 45, 90);
            }
            else if (bp == BodyParts.Body)
            {
                g.DrawLine(p, new Point(60, 90), new Point(60, 170));
            }
            else if (bp == BodyParts.Left_Arm)
            {
                g.DrawLine(p, new Point(60, 100), new Point(30, 85));
            }
            else if (bp == BodyParts.Right_Arm)
            {
                g.DrawLine(p, new Point(60, 100), new Point(90, 85));
            }
            else if (bp == BodyParts.Left_Leg)
            {
                g.DrawLine(p, new Point(60, 170), new Point(30, 190));
            }
            else if (bp == BodyParts.Right_Leg)
            {
                g.DrawLine(p, new Point(60, 170), new Point(90, 190));
            }
        }

        void MakeLabels()
        {
          word = GetRandomWord();
          char[] chars = word.ToCharArray();
          int between = 330 / chars.Length - 1;
          for (int i = 0; i < chars.Length; i++)
            {
                labels.Add(new Label());
                labels[i].Location = new Point((i * between) + 10, 80);
                labels[i].Text = "_";
                labels[i].Parent = groupBox2;
                labels[i].BringToFront();
                labels[i].CreateControl();
            }
            label1.Text = "Długość wyrazu" +(chars.Length - 1).ToString() ;
        }
        string GetRandomWord()
        {
            string[] wordlist = { "jablko", "gruszka", "banan", "winogrono", "kiwi"};
           
            Random ran = new Random();
            return wordlist[ran.Next(0,wordlist.Length-1)];
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Brown, 10);
            g.DrawLine(p, new Point(130, 248), new Point(130, 10));
            g.DrawLine(p, new Point(135, 5), new Point(65, 5));
            g.DrawLine(p, new Point(60, 0), new Point(60, 50));
            MakeLabels();
            Console.ForegroundColor = ConsoleColor.Green;
            
        }


      
        private void button1_Click(object sender, EventArgs e)
        {
            Textboxenter();
        }

        public void Textboxenter()
        {

            if (textBox1.Text.Length >= 1)
            {
                char letter = textBox1.Text.ToLower().ToCharArray()[0];
                if (!char.IsLetter(letter))
                {
                    MessageBox.Show("Możesz podać tylko litery", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (word.Contains(letter))
                {
                    char[] letters = word.ToCharArray();
                    for (int i = 0; i < letters.Length; i++)
                    {
                        if (letters[i] == letter)
                        {
                            labels[i].Text = letter.ToString();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Litera, którą podałes nie znajduje się w tym wyrazie!");
                    
                    label2.Text += " " + letter.ToString() + ",";
                    DrawBodyPart((BodyParts)amount);
                    amount++;
                    if (amount == 8)
                    {
                        MessageBox.Show("Przegrałeś!");
                        Environment.Exit(0);
                    }
                }
            }
            textBox1.Text = "";
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode==Keys.Enter)
            {
                Textboxenter();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

