using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Quiz
{
    class User
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
    public partial class Form1 : Form
    {
        List<User> Users = new List<User>();
        User User = new User();
        //Point point;
        public Form1()
        {
            InitializeComponent();
        }
        bool Control()
        {
            bool ControlBool=false;
            foreach (var item in Controls)
            {
                if(item is TextBox textBox && textBox.Location.Y==110)
                {
                        string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                        ControlBool=Regex.IsMatch(textBox.Text, pattern);
                    User.Mail = textBox.Text;
                    if(!ControlBool)
                    {
                        textBox.BackColor = Color.Red;
                    }
                }
                if (item is TextBox textBox_ && textBox_.Location.Y == 160)
                {
                    string Pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
                    ControlBool = Regex.IsMatch(textBox_.Text, Pattern);
                    User.Password = textBox_.Text;

                    if (!ControlBool)
                    {
                        textBox_.BackColor = Color.Red;
                    }
                }
            }
            return ControlBool;

        }
        void ResetForm()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {


                foreach (var item in Controls)
                {
                    if (item is Button button)
                    {
                      //  button.BackgroundImage.Dispose();
                        button.Dispose();
                    }
                    if (item is TextBox textBox)
                    {
                        textBox.Dispose();
                    }
                    if(item is Panel panel)
                    {
                        panel.BackgroundImage.Dispose();
                        panel.Dispose();
                    }
                    if(item is Label label)
                    {
                        label.Dispose();
                    }

                }
            }
            
        }
        void createButton(string Text,bool  enable)
        {
            //Button button = new Button();
            //button.Size = new Size(75,23);
            //button.Location = new Point(point.X, point.Y);
            //button.Text = Text;
            //button.Enabled = enable;
            //button.Click += Button_Click;

            //this.Controls.Add(button);
            
        }
      
        private void Button_Click(object sender, EventArgs e)
        {

            //Button button = sender as Button;
            //if (button.Text == "Ok")
            //{
            //    User user_ = new User();
            //    bool a = true;
            //    bool b = true;
            //    foreach (var item in Controls)
            //    {
            //        if (item is TextBox textBox)
            //        {
            //            if (textBox.Text != string.Empty && textBox.Name == "Mail")
            //            {
            //                string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            //                string q = Users.FindAll(x => x.Mail == textBox.Text).ToString();

            //                if (Regex.IsMatch(textBox.Text, pattern) && q != "0")
            //                {
            //                    user_.Mail = textBox.Text;
            //                    a = false;

            //                }
            //            }
            //            if (textBox.Text != string.Empty && textBox.Name == "Password")
            //            {
            //                user_.Password = textBox.Text;

            //                b = false;

            //            }
            //        }
            //    }
            //    if (!a && !b)
            //    {
            //        Users.Add(user_);
            //        string json = JsonConvert.SerializeObject(Users);
            //        if (Directory.Exists("User"))
            //        {
            //            System.IO.File.WriteAllText("User.json", json);

            //        }
            //        else
            //        {

            //            System.IO.File.WriteAllText("User.json", json);

            //        }
            //        ResetForm();
            //        Login();
            //    }
            //}
            ////if(button.Text== "Registr")
            //////{
            //    ResetForm();
            //    TextBox textBox = new TextBox();
            //    textBox.Location = new Point(400, 87);
            //    textBox.Size = new Size(400, 20);
            //    textBox.MouseClick += TextBox_MouseClick;
            //    textBox.MouseLeave += TextBox_MouseLeave;
            //    textBox.Text = "Enter Mail";
            //    textBox.Name = "Mail";
            //    this.Controls.Add(textBox);
            //    textBox.Location = new Point(400, 141);
            //    textBox.Size = new Size(400, 20);
            //    textBox.MouseClick += TextBox_MouseClick;
            //    textBox.MouseLeave += TextBox_MouseLeave;
            //    textBox.Text = "Enter Password";
            //    textBox.Name = "Password";
            //    this.Controls.Add(textBox);
            //    point.X = 100;
            //    point.Y = 60;
            //    createButton("Ok", true);
        }
       
        void Register()
        {
            this.BackgroundImage = Image.FromFile("RegBack.jpg");


            Panel panel1 = new Panel();
            panel1.Location = new Point(106, 29);
            panel1.Size = new Size(138, 65);
            panel1.BackgroundImage = Image.FromFile("RegImage.png");
            this.Controls.Add(panel1);

            Panel panel2 = new Panel();
            panel2.Location = new Point(54, 110);
            panel2.Size = new Size(36, 29);
            panel2.BackgroundImage = Image.FromFile("User.png");
            this.Controls.Add(panel2);

            Panel panel3 = new Panel();
            panel3.Location = new Point(54, 160);
            panel3.Size = new Size(36, 29);
            panel3.BackgroundImage = Image.FromFile("Password.png");
            this.Controls.Add(panel3);

            Panel panel4 = new Panel();
            panel4.Location = new Point(255, 160);
            panel4.Size = new Size(23, 29);
            panel4.BackgroundImage = Image.FromFile("DontSee.png");
            panel4.MouseClick += Panel4_MouseClick;
            this.Controls.Add(panel4);

            TextBox textBox1 = new TextBox();
            textBox1.Size = new Size(164, 29);
            textBox1.Location = new Point(90, 110);
            textBox1.MouseClick += TextBox1_MouseClick1;
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Username";
            this.Controls.Add(textBox1);

            TextBox textBox2 = new TextBox();
            textBox2.Size = new Size(164, 29);
            textBox2.Location = new Point(90, 160);
            textBox2.MouseClick += TextBox2_MouseClick;
            textBox2.ForeColor = Color.Gray;
            textBox2.Text = "Password";
            textBox2.PasswordChar = '*';
            this.Controls.Add(textBox2);



            Button button1 = new Button();
            button1.Size = new Size(164, 42);
            button1.Location = new Point(90, 207);
            button1.Click += Button1_Click;
            button1.BackgroundImage = Image.FromFile("RegButton.jpg");
            this.Controls.Add(button1);
        }

        void Login()
        {

            this.BackgroundImage = Image.FromFile("Image.jpg");


            Panel panel1 = new Panel();
            panel1.Location = new Point(106,29);
            panel1.Size = new Size (138,65);
            panel1.BackgroundImage = Image.FromFile("Username.jpg");
            this.Controls.Add(panel1);

            Panel panel2 = new Panel();
            panel2.Location = new Point(54, 110);
            panel2.Size = new Size(36, 29);
            panel2.BackgroundImage = Image.FromFile("User.png");
            this.Controls.Add(panel2);

            Panel panel3 = new Panel();
            panel3.Location = new Point(54, 160);
            panel3.Size = new Size(36, 29);
            panel3.BackgroundImage = Image.FromFile("Password.png");
            this.Controls.Add(panel3);

            Panel panel4 = new Panel();
            panel4.Location = new Point(255, 160);
            panel4.Size = new Size(23, 29);
            panel4.BackgroundImage = Image.FromFile("DontSee.png");
            panel4.MouseClick += Panel4_MouseClick;
            this.Controls.Add(panel4);

            TextBox textBox1 = new TextBox();
            textBox1.Size = new Size(164,29);
            textBox1.Location = new Point(90,110);
            textBox1.MouseClick += TextBox1_MouseClick1;
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Username";
            this.Controls.Add(textBox1);

            TextBox textBox2 = new TextBox();
            textBox2.Size = new Size(164, 29);
            textBox2.Location = new Point(90,160);
            textBox2.MouseClick += TextBox2_MouseClick;
            textBox2.ForeColor = Color.Gray;
            textBox2.Text = "Password";
            textBox2.PasswordChar = '*';
            this.Controls.Add(textBox2);



            Button button1 = new Button();
            button1.Size = new Size(164,42);
            button1.Location = new Point(90,207);
            button1.Click += Button1_Click;
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Text = "Login";
            this.Controls.Add(button1);


            Button button2 = new Button();
            button2.Size = new Size(164,42);
            button2.Location = new Point(90,273);
            button2.Click += Button2_Click;
            button2.BackColor = Color.FromArgb(255, 192, 192);
            button2.Text = "Register";
            this.Controls.Add(button2);

            Label label = new Label();
            label.Size = new Size(18,13);
            label.Location = new Point (162,254);
            label.Text = "Or";
            label.BackColor = SystemColors.ControlLight;
            this.Controls.Add(label);



        }
        bool Panelbool = false;
        private void Panel4_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var item in Controls)
            {
                if(item is Panel panel && panel.Location.X==255)
                {
                    if(!Panelbool)
                    {
                        panel.BackgroundImage = Image.FromFile("See.png");
                        Panelbool = true;
                        foreach (var item_ in Controls)
                        {
                            if (item_ is TextBox textBox && textBox.Location.Y == 160)
                            {
                                textBox.PasswordChar = '\0';
                            }
                        }
                    }
                    else
                    {
                        Panelbool = false;
                        panel.BackgroundImage = Image.FromFile("DontSee.png");
                        foreach (var item_ in Controls)
                        {
                            if(item_ is TextBox textBox && textBox.Location.Y==160)
                            {
                                textBox.PasswordChar = '*';
                            }
                        }
                    }
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {

            foreach (var item in Controls)
            {
                if (item is Button button && button.Text == "Quiz")
                {
                    ResetForm();
                    Form2 form2 = new Form2(this);
                    this.Hide();
                    form2.Show();
                }
                        
            }


            ResetForm();
            Register();
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            foreach (var item in Controls)
            {
                if(item is Button button2 && button2.Text=="Create")
                {
                    ResetForm();
                    this.Hide();
                    Form3 form3 = new Form3(this);

                   form3.Show();
                     
                }
                if(item is TextBox textBox && textBox.Location.Y==110 && textBox.Text==string.Empty)
                {
                    textBox.ForeColor = Color.Gray;
                    textBox.Text = "Username";
                }
                if (item is TextBox textBox_ && textBox_.Location.Y == 160 && textBox_.Text == string.Empty)
                {
                    textBox_.ForeColor = Color.Gray;
                    textBox_.Text = "Password";
                }
                if (item is Button button && button.Text!="Login" && Control())
                {
                    Users.Add(User);
                    string json = JsonConvert.SerializeObject(Users);
                    System.IO.File.WriteAllText("Users.json", json);
                    ResetForm();
                    Login();
                }
                if (item is Button button1 && button1.Text == "Login" && Control())
                {
                   
                    ResetForm();
                    ProgramLoad();
                }

            }

        }
        private void TextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is TextBox textBox && textBox.Location.Y == 160 && textBox.ForeColor == Color.Gray)
                {
                    textBox.Text = string.Empty;
                    textBox.ForeColor = Color.Black;
                }
                if (item is TextBox textBox_ && textBox_.Location.Y == 110 && textBox_.Text==string.Empty)
                {
                    textBox_.Text = "Username";
                    textBox_.ForeColor = Color.Gray;
                }
                if(item is TextBox _textBox && _textBox.Location.Y==160)
                {
                    _textBox.BackColor = Color.White;
                }
            }
        }

        private void TextBox1_MouseClick1(object sender, MouseEventArgs e)
        {
            foreach (var item in Controls)
            {
                if(item is TextBox textBox && textBox.Location.Y==110 && textBox.ForeColor==Color.Gray)
                {
                    textBox.Text = string.Empty;
                    textBox.ForeColor = Color.Black;
                    textBox.BackColor = Color.White;
                }
                if (item is TextBox textBox_ && textBox_.Location.Y == 160 && textBox_.Text == string.Empty)
                {
                    textBox_.Text = "Password";
                    textBox_.ForeColor = Color.Gray;
                }
                if (item is TextBox _textBox && _textBox.Location.Y == 110)
                {
                    _textBox.BackColor = Color.White;
                }
            }
        }
        void ProgramLoad()
        {

            Button button1 = new Button();
            button1.Size = new Size(164, 42);
            button1.Location = new Point(90, 207);
            button1.Click += Button1_Click;
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Text = "Create";
            this.Controls.Add(button1);


            Button button2 = new Button();
            button2.Size = new Size(164, 42);
            button2.Location = new Point(90, 273);
            button2.Click += Button2_Click;
            button2.BackColor = Color.FromArgb(255, 192, 192);
            button2.Text = "Quiz";
            this.Controls.Add(button2);

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(339,355);
            this.FormBorderStyle = FormBorderStyle.None;
            if(File.Exists("User.json"))
            {
                string jsonUsers = File.ReadAllText("Users.json");
                Users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            }
             Login();
            //Form3 form3 = new Form3();
            //form3.Show();
            //ProgramLoad();
            //Form2 form2 = new Form2 ();
            //form2.Show();
        }
        //private void  e)
        //{
        //    e.Effect = DragDrForm1_DragEnter(object sender, DragEventArgsopEffects.Copy;
        //}
        //private void Form1_DragDrop(object sender, DragEventArgs e)
        //{
        //    string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
        //    foreach (var item in droppedFiles)
        //    {
        //        Path = item;
        //    }
        //    FormLoad("");
        //}
    }
}