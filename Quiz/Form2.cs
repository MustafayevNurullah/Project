using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Quiz
{
    public partial class Form2 : Form
    {
        int question_counter;
        string Path_;
        List<int> Ansvercounter = new List<int>();
        List<string> Asci = new List<string>() {
"A",
"B",
"C",
"D",
"E",
"F",
"G",
"H",
"I",
"J",
"K",
"L",
"M",
"N",
"O",
"P",
"Q",
"R",
"S",
"T",
"U",
"V",
"W",
"X",
"Y",
"Z" };
        List<QuestionBlock> questionBlock = new List<QuestionBlock>();

        List<Class1Q> questionBlocks = new List<Class1Q>();
        List<Class1Q> questionBlocks_ = new List<Class1Q>();
        List<int> vsQuestion = new List<int>();
        List<int> vsAnswer = new List<int>();
        List<int> RandomQuestion = new List<int>();
        List<int> RandomAnswer = new List<int>();
        string color;
        int createQuestionCounter = -1;
        int a = 0;
        int correct = 0;
        int wrong = 0;
        int null_ = 0;
        int YLocation;
        int AsciCounter = 0;
        int counter;
        Point point = new Point();
        List<string> List = new List<string>();
        int radiobuttonconter = 0;
        #region CreateControls
        void PictureBox(string text)
        {
            PictureBox radioButton = new PictureBox();
            radioButton.Size = new Size(20, 20);
            radioButton.Location = new Point(100, point.Y - 5);
            radioButton.Name = Name;
            if (text == "Yes")
            {
                radioButton.Image = System.Drawing.Image.FromFile("Correct.png");
            }
            if (text == "No")
            {
                radioButton.Image = System.Drawing.Image.FromFile("Wrong.png");
            }
            if (text == "")
            {
                radioButton.Location = new Point(180, point.Y - 30);

                radioButton.Image = System.Drawing.Image.FromFile("Answer.png");

            }

            this.Controls.Add(radioButton);
            radioButton.Click += RadioButton_Click;
        }
        void ResetRadiButton()
        {
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is RadioButton label)
                    {
                        //  MessageBox.Show(AsciCounter.ToString());
                        if (label.Name == AsciCounter.ToString())
                        {
                            label.Dispose();
                            //  AsciCounter--;
                        }
                    }

                }
            }

        }
        void ResetAnswerTextBox()
        {
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox label)
                    {

                        //MessageBox.Show(AsciCounter.ToString());
                        if (point.Y == 36)
                        {
                            label.Dispose();
                        }
                        if (label.Location.Y > 100 && label.Name == AsciCounter.ToString())
                        {
                            label.Dispose();
                            ResetRadiButton();
                            //AsciCounter--;
                        }
                    }

                }
            }

        }
        void ResetForm()
        {
            AsciCounter = 0;
            for (int i = 0; i < Controls.Count * 100; i++)
            {
                foreach (var item in Controls)
                {
                  
                    if (item is ListView listView)
                    {
                        listView.Dispose();
                    }
                    if (item is TextBox label)
                    {
                        label.Dispose();
                    }
                    if (item is Button button)
                    {
                        button.Dispose();
                    }
                    if (item is RadioButton radioButton)
                    {
                        radioButton.Dispose();
                    }
                    if (item is PictureBox pictureBox)
                    {
                        pictureBox.Dispose();
                    }
                }
            }
        }
        void CreateTextLabel(string Text, string Name, bool bool_)
        {
            TextBox label = new TextBox();
            YLocation = 0;
            label.Multiline = true;
            if (Text.Length < 60 )
            {
                label.Size = new Size(450, 25);
                YLocation = 0;

            }
            if (Text.Length>60 && Text.Length < 120)
            {
                YLocation = 10;

                label.Size = new Size(450, 35);

            }
            if (Text.Length > 120 && Text.Length < 280)
            {
                YLocation = 20;

                label.Size = new Size(450, 45);

            }
           // label.Size = new Size(450,25);
            label.Location = new Point(127, point.Y);
            label.Name = "Test";
            label.Enabled = bool_;
            label.Text = counter + 1 + Text;
            this.Controls.Add(label);
        }
        void CreateAnswerLabel(string Text, bool bool_)
        {
            TextBox label = new TextBox();
            if(color=="Red")
            {
                label.ForeColor = Color.Red;
            }
            if (color == "Green")
            {
                label.ForeColor = Color.Green;
            }
            label.Multiline = true;
            label.Location = new Point(142, point.Y);
            if (Text.Length < 55)
            {
                label.Size = new Size(435, 25);
                YLocation = 0;
            }
            if (Text.Length > 55 && Text.Length < 110)
            {
                label.Size = new Size(435, 35);
                YLocation = 10;
                point.Y += 10;
            }
            if (Text.Length > 110 && Text.Length < 265)
            {
                point.Y += 20;
                YLocation = 20;
                label.Size = new Size(435, 45);
            }
           // label.Size = new Size(464, 44);
            //  MessageBox.Show(AsciCounter.ToString());
            label.Enabled = bool_;
            label.Enter += Label_Enter;
            label.Leave += Label_Leave;
            label.Name = AsciCounter.ToString();
            label.Text = Asci[AsciCounter] + ". " + Text;
            this.Controls.Add(label);
        }

        private void Label_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Label_Enter(object sender, EventArgs e)
        {
            var a = (sender is TextBox);
            MessageBox.Show(Cursor.Position.ToString());
        }

        void createButton(string Text, bool enable)
        {
            Button button = new Button();
            button.Size = new Size(75, 23);
            button.Location = new Point(point.X, point.Y);
            button.Text = Text;
            button.Enabled = enable;
            this.Controls.Add(button);
            if (Text == "Accept")
            {
                for (int i = 0; i < vsQuestion.Count; i++)
                {
                    if (vsQuestion[i] == questionBlocks[counter].id)
                    {
                        button.Enabled = false;
                    }
                }
            }
            button.Click += Button_Click;

        }
        void createRadioButton(string Name)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Size = new Size(15, 15);
            radioButton.Location = new Point(124, point.Y);
            radioButton.Name = Name;
            for (int i = 0; i < vsQuestion.Count; i++)
            {
                if (vsQuestion[i] == questionBlocks[counter].id)
                {
                    if (vsAnswer[i] == Convert.ToInt32(Name))
                    {
                        radioButton.Checked = true;
                    }
                    radioButton.Enabled = false;
                }
            }
            this.Controls.Add(radioButton);
            radioButton.Click += RadioButton_Click;

        }
        void createTextBoxSum(string Text)
        {
            TextBox label = new TextBox();
            label.Size = new Size(464, 44);
            label.Location = new Point(200, point.Y);
            label.Text = Text;
            this.Controls.Add(label);
        }
        #endregion Create
        #region ControlsClick
        bool AcceptButton()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is Button button)
                    {
                        if (button.Text == "Accept")
                        {
                            return button.Enabled;
                        }
                    }
                }
            }
            return false;

        }
        string ControlRadioButton()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is RadioButton radioButton)
                    {
                        if (radioButton.Checked == true)
                        {
                            return radioButton.Name;
                        }
                    }
                }
            }
            return string.Empty;
        }
        bool ControlButton(string Text)
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is Button radioButton)
                    {
                        if (radioButton.Text == Text)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;

        }
        void RadioButtonEnable()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is RadioButton radioButton)
                    {
                        radioButton.Enabled = false;
                    }
                }
            }
        }
        private void RadioButton_Click(object sender, EventArgs e)
        {
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "Print")
            {
                bool q = false;
                //  File.CreateText("Text.txt");

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                {

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());

                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();


                        for (int i = 0; i < questionBlocks_.Count; i++)
                        {
                            AsciCounter = 0;
                            doc.Add(new iTextSharp.text.Paragraph($"{i + 1}.{questionBlocks_[i].Text}"));
                            for (int j = 0; j < questionBlocks_[i].Answers.Count; j++)
                            {
                                string a = vsQuestion.Find(x => x == questionBlocks_[i].id).ToString();
                                if (a != "0")
                                {
                                    int index = vsQuestion.IndexOf(Convert.ToInt32(a));
                                    int index_ = questionBlocks_[i].Answers[j].IsCorrect.IndexOf("Yes");
                                    string b = questionBlocks_[i].Answers.Find(x => x.id == vsAnswer[index]).ToString();
                                    if (b != string.Empty)
                                    {
                                        if (questionBlocks_[i].Answers[j].id == vsAnswer[index] && questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                                        {
                                            doc.Add(new iTextSharp.text.Paragraph($"You answer->Correct->{Asci[AsciCounter]}) {questionBlocks_[i].Answers[j].Text}"));
                                            AsciCounter++;
                                        }
                                        else if (questionBlocks_[i].Answers[j].id == vsAnswer[index] && questionBlocks_[i].Answers[j].IsCorrect == "No")
                                        {
                                            doc.Add(new iTextSharp.text.Paragraph($"You answer->Wrong->{Asci[AsciCounter]}) {questionBlocks_[i].Answers[j].Text}"));
                                            AsciCounter++;
                                        }
                                        else
                                        {
                                            if (j == index_)
                                            {
                                                doc.Add(new iTextSharp.text.Paragraph($"Correct->{Asci[AsciCounter]}) {questionBlocks_[i].Answers[j].Text}"));
                                                AsciCounter++;
                                            }
                                            else
                                            {



                                                doc.Add(new iTextSharp.text.Paragraph($"{Asci[AsciCounter]}) {questionBlocks_[i].Answers[j].Text}"));
                                                AsciCounter++;
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    if (questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                                    {
                                        doc.Add(new iTextSharp.text.Paragraph($"Correct-->{Asci[AsciCounter]}) {questionBlocks_[i].Answers[j].Text}"));
                                        AsciCounter++;
                                    }
                                    else
                                    {


                                        doc.Add(new iTextSharp.text.Paragraph($"{Asci[AsciCounter]}) {questionBlocks_[i].Answers[j].Text}"));
                                        AsciCounter++;
                                    }
                                }
                            }
                        }

                        //for (int i = 0; i < questionBlocks_.Count; i++)
                        //{
                        //    AsciCounter = 0;
                        //    doc.Add(new iTextSharp.text.Paragraph(questionBlocks_[i].Text));
                        //    for (int j = 0; j < questionBlocks_[i].Answers.Count; j++)
                        //    {
                        //        foreach (var item in vsQuestion)
                        //        {
                        //            for (int t = 0; t < vsQuestion.Count; t++)
                        //            {

                        //                if (vsQuestion[t] == questionBlocks_[i].id)
                        //                {

                        //                    if (vsAnswer[t] == questionBlocks_[i].Answers[j].id)
                        //                    {
                        //                        doc.Add(new iTextSharp.text.Paragraph($"You answer->Correct->{Asci[AsciCounter]}) {questionBlocks_[i].Answers[j].Text}"));
                        //                        AsciCounter++;
                        //                        q = true;
                        //                    }
                        //                }
                        //            else
                        //            {
                        //                doc.Add(new iTextSharp.text.Paragraph($"{Asci[AsciCounter]}) {questionBlocks_[i].Answers[j].Text}"));
                        //                AsciCounter++;
                        //                q = true;
                        //            }
                        //        }
                        //    }
                        //    }
                        //    if(!q)
                        //    {

                        //    }

                        //}





                        doc.Close();
                    }




                }








                //    TextWriter tw = new StreamWriter("Text.txt");
                //int a = 0;
                //int b = 0;
                //foreach (var item in questionBlocks_)
                //{
                //       tw.WriteLine($"{++a}  {item.Text}");
                //    foreach (var item_ in questionBlocks_[item.id].Answers)
                //    {
                //        tw.WriteLine($"{Asci[b]}  {item_.Text}");
                //        b++;

                //    }
                //}







                //for (int i = 0; i < questionBlocks_.Count; i++)
                //{

                //    tw.WriteLine($"{i + 1}  {questionBlocks_[i].Text}");
                //    for (int j = 0; i < questionBlocks_[i].Answers.Count; j++)
                //    {
                //        for (int y = 0; y < vsQuestion.Count; y++)
                //        {



                //            for (int t = 0; t < vsAnswer.Count; t++)
                //            {


                //                if (vsQuestion[y] == questionBlocks_[i].id && vsAnswer[t] == questionBlocks_[i].Answers[j].id && questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                //                {

                //                    tw.WriteLine($" IsCorret {Asci[i]} {questionBlocks_[i].Answers[j].Text}");
                //                    q = true;
                //                }
                //                else
                //                {
                //                    q = true;

                //                    tw.WriteLine($"Wrong {Asci[i]} {questionBlocks_[i].Answers[j].Text}");

                //                }
                //            }

                //        }
                //        if(!q)
                //        {
                //            tw.WriteLine($"Wrong {Asci[j]} {questionBlocks_[i].Answers[j].Text}");
                //        }
                //    }

                //}


                //tw.Close();


            }
            if (button.Text == "Size")
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox textBox)
                    {
                        if (textBox.Text != string.Empty &&
                        int.TryParse(textBox.Text, out question_counter))
                        {
                            ResetForm();
                            this.BackColor = Color.AliceBlue;
                            FormLoad("");
                        }
                    }
                }
            }
            if (button.Text == "Sum")
            {
                ResetForm();
                point.Y = 197;
                PictureBox("Yes");
                createTextBoxSum(correct.ToString());
                point.Y += 70;
                PictureBox("No");
                createTextBoxSum(wrong.ToString());
                point.Y += 70;
                PictureBox("");
                createTextBoxSum(null_.ToString());
                //Button Wbutton = new Button();
                //Wbutton.Text = wrong.ToString();
                //Wbutton.BackColor = Color.Red;
                //wrong = (wrong * 100) / questionBlock.Count;
                //wrong *= 5;
                //if(wrong<40)
                //{
                //Wbutton.Location = new Point(565,230);

                //Wbutton.Size = new Size(50,10);
                //}
                //else
                //{
                //    Wbutton.Location = new Point(565, 230-wrong);

                //    Wbutton.Size = new Size(50, wrong);

                //}
                //this.Controls.Add(Wbutton);

                //Button cbutton = new Button();
                //cbutton.Text = correct.ToString();
                //cbutton.BackColor = Color.Green;
                //correct = (correct * 100) / questionBlock.Count;
                //correct *= 5;
                //if (correct < 40)
                //{
                //cbutton.Location = new Point(493, 230);

                //    cbutton.Size = new Size(50, 10);
                //}
                //else
                //{
                //    cbutton.Location = new Point(493, 230-correct);

                //    cbutton.Size = new Size(50, correct);

                //}
                //cbutton.Size = new Size(50, correct);
                //this.Controls.Add(cbutton);

                //Button nbutton = new Button();
                //nbutton.Text = null_.ToString();
                //nbutton.BackColor = Color.Gray;
                //null_ = (null_ * 100) / questionBlock.Count;
                //null_ *= 5;
                //if (null_ <40 )
                //{
                //nbutton.Location = new Point(413, 230);

                //    cbutton.Size = new Size(50, 10);
                //}
                //else
                //{
                //    if (230 - null_ < 29)
                //    {
                //        nbutton.Location = new Point(413, 29);
                //    nbutton.Size = new Size(50, null_);
                //    }
                //    else
                //    {
                //    nbutton.Size = new Size(50, null_);
                //        nbutton.Location = new Point(413, 230-null_);
                //    }
                //}
                //this.Controls.Add(nbutton);



                point.X = 12;
                point.Y = 12;
                createButton("Print", true);
            }
            if (button.Text == "Next")
            {
                if (!AcceptButton() && !ControlButton("Remove"))
                {
                    vsQuestion.Add(questionBlocks[counter].id);
                    vsAnswer.Add(Convert.ToInt32(ControlRadioButton()));
                    //    questionBlocks.Remove(questionBlocks[counter]);
                    // counter--;
                }
                ResetForm();
                FormLoad("Next");
            }
            if (button.Text == "Back")
            {
                if (!AcceptButton() && !ControlButton("Remove"))
                {
                    vsQuestion.Add(questionBlocks[counter].id);
                    vsAnswer.Add(Convert.ToInt32(ControlRadioButton()));
                    //    questionBlocks.Remove(questionBlocks[counter]);
                }
                ResetForm();
                FormLoad("Back");
            }
            if (button.Text == "Accept")
            {

                for (int i = 0; i < Controls.Count * 5; i++)
                {
                    foreach (var item in Controls)
                    {
                        if (item is RadioButton radioButton)
                        {
                            if (radioButton.Checked == true)
                            {
                                button.Enabled = false;
                                RadioButtonEnable();
                                if (questionBlocks.Count == 1)
                                {
                                    vsQuestion.Add(questionBlocks[counter].id);
                                    vsAnswer.Add(Convert.ToInt32(ControlRadioButton()));
                                    //  questionBlocks.Remove(questionBlocks[counter]);

                                }


                            }
                        }
                    }
                }

            }
            if (button.Text == "Sub")
            {
                null_ = questionBlocks.Count - vsQuestion.Count;
                ResetForm();
                point.Y = 30;
                counter = 0;
                AsciCounter = 0;
                YLocation = 0;
                ////  FormLoad("");
                //for (int i = 0; i < questionBlocks.Count; i++)
                //{


                //    CreateTextLabel(questionBlocks[counter].Text, counter.ToString(), false);
                //    point.Y = YLocation + 70;
                //    foreach (var item in questionBlocks[counter].Answers)
                //    {
                //        CreateAnswerLabel(item.Text, false);
                //        createRadioButton(item.id.ToString());
                //        AsciCounter++;
                //        point.Y += 40;
                //    }
                //    counter++;
                //    AsciCounter = 0;
                //}

                //for (int i = 0; i < questionBlocks_.Count; i++)
                //{
                //    CreateTextLabel(questionBlocks_[i].Text, counter.ToString(), false);
                //        point.Y += 60;
                //    AsciCounter = 0;
                //    for (int j = 0; j < questionBlocks_[i].Answers.Count; j++)
                //    {
                //        createRadioButton(questionBlocks_[i].Answers[j].id.ToString());
                //        RadioButtonEnable();

                //        string  a = vsQuestion.Find(x => x == questionBlocks_[i].id).ToString();
                //        int b = vsQuestion.FindIndex(x => x == questionBlocks_[i].id);
                //        if (a == "0")
                //        {
                //            if (questionBlocks_[i].Answers[j].IsCorrect =="Yes")
                //            {
                //                color = "Green";
                //                CreateAnswerLabel(questionBlocks_[i].Answers[j].Text, false);
                //                AsciCounter++;
                //                point.Y += 40;
                //            }
                //            else
                //            {
                //              //  color = "Red";
                //                CreateAnswerLabel(questionBlocks_[i].Answers[j].Text, false);
                //                AsciCounter++;
                //                point.Y += 40;
                //            }
                //        }
                //        else
                //        {
                //            if(questionBlocks_[i].Answers[j].id==vsAnswer[b] && questionBlocks_[i].Answers[j].IsCorrect=="Yes")
                //            {
                //            color = "Green";
                //            CreateAnswerLabel(questionBlocks_[i].Answers[j].Text, false);
                //            AsciCounter++;
                //            point.Y += 40;
                //            }
                //            //if (questionBlocks_[i].Answers[j].id == vsAnswer[b] && questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                //            //{
                //            //    color = "Green";
                //            //    CreateAnswerLabel(questionBlocks_[i].Answers[j].Text, false);
                //            //    AsciCounter++;
                //            //    point.Y += 40;
                //            //}


                //        }



                //    }


                //}




                for (int i = 0; i < questionBlocks_.Count; i++)
                {
                    CreateTextLabel(questionBlocks_[i].Text, counter.ToString(), false);
                    point.Y += 60;
                    for (int j = 0; j < questionBlocks_[i].Answers.Count; j++)
                    {
                        createRadioButton(questionBlocks_[i].Answers[j].id.ToString());
                        RadioButtonEnable();
                        for (int q = 0; q < vsQuestion.Count; q++)
                        {
                            if (vsQuestion[q] == questionBlocks_[i].id)
                            {
                                if (vsAnswer[q] == questionBlocks_[i].Answers[j].id)
                                {

                                    if (questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                                    {
                                       PictureBox("Yes");
                                        correct++;
                                      //  PictureBox("");
                                      //  color = "Green";
                                    }
                                    else
                                    {
                                      //  PictureBox("");

                                         PictureBox("No");
                                        //color = "Red";

                                        wrong++;
                                        for (int t = 0; t < questionBlocks_[i].Answers.Count; t++)
                                        {
                                            if (questionBlocks_[i].Answers[t].IsCorrect == "Yes")
                                            {
                                                 PictureBox("Yes");
                                               // color = "Green";
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                                {
                                   // color = "Green";

                                     PictureBox("Yes");
                                }
                            }

                        }
                        if (questionBlocks_.Count == questionBlocks.Count)
                        {
                            for (int q = 0; q < questionBlocks.Count; q++)
                            {
                                for (int r = 0; r < questionBlock[q].Answers.Count; r++)
                                {
                                    if (questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                                    {
                                        PictureBox("Yes");
                                        //color = "Red";
                                    }
                                }
                            }
                        }
                        CreateAnswerLabel(questionBlocks_[i].Answers[j].Text, false);
                        AsciCounter++;
                        point.Y += 40;

                    }
                    counter++;
                    AsciCounter = 0;
                }
                createButton("Sum", true);
            }
        }
        #endregion ControlsClick
        void FormLoad(string Text)
        {
            if (a == 0)
            {
                
                StreamReader streamReader = new StreamReader($"Quiz\\{Path_}");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QuestionBlock>));
                var obj = (List<QuestionBlock>)xmlSerializer.Deserialize(streamReader);
                a++;
                questionBlock = obj;

                //  questionBlocks = obj;
                do
                {
                    bool q = false;
                    Random random = new Random();
                    counter = random.Next(0, questionBlock.Count);
                    foreach (var item in RandomQuestion)
                    {
                        if (item == counter)
                        {
                            q = true;
                        }
                    }
                    if (!q)
                    {
                        Class1Q class1Q = new Class1Q();
                        class1Q.Answers = new List<Class1A>();
                        class1Q.id = questionBlock[counter].id;
                        class1Q.Text = questionBlock[counter].Text;
                        RandomQuestion.Add(counter);
                        do
                        {
                            bool qw = false;
                            Class1A class1A = new Class1A();
                            int answercounter;
                            answercounter = random.Next(0, questionBlock[counter].Answers.Count);
                            foreach (var item in RandomAnswer)
                            {
                                if (item == answercounter)
                                {
                                    qw = true;
                                }
                            }
                            if (!qw)
                            {
                                class1A.id = questionBlock[counter].Answers[answercounter].id;
                                class1A.Text = questionBlock[counter].Answers[answercounter].Text;
                                class1A.IsCorrect = questionBlock[counter].Answers[answercounter].IsCorrect;
                                class1Q.Answers.Add(class1A);
                                RandomAnswer.Add(answercounter);
                            }
                        } while (questionBlock[counter].Answers.Count != RandomAnswer.Count);
                        RandomAnswer.Clear();
                        questionBlocks_.Add(class1Q);
                    }
                } while (/*questionBlocks.Count != RandomQuestion.Count || */RandomQuestion.Count < question_counter);
                ListBox listBox = new ListBox();
                listBox.Location = new Point(140, 200);
                listBox.Size = new Size(100, 100);
                questionBlocks = questionBlocks_;
                //for (int i = 0; i < questionBlocks_.Count; i++)
                //{
                //    questionBlocks[i].id = questionBlocks_[i].id;
                //    questionBlocks[i].Text = questionBlocks_[i].Text;
                //    for (int j = 0; j < questionBlocks_[i].Answers.Count; j++)
                //    {
                //        questionBlocks[i].Answers[j].id = questionBlocks_[i].Answers[j].id;
                //        questionBlocks[i].Answers[j].IsCorrect = questionBlocks_[i].Answers[j].IsCorrect;
                //        questionBlocks[i].Answers[j].Text = questionBlocks_[i].Answers[j].Text;
                //    }

                //}
                counter = 0;
            }
            switch (Text)
            {
                case "Next":
                    counter++;
                    break;
                case "Back":
                    counter--;
                    break;
                case "":
                    counter = 0;
                    break;
            }
            point.Y = 30;
            CreateTextLabel(questionBlocks[counter].Text, counter.ToString(), false);
            point.Y = YLocation+ 70;
            foreach (var item in questionBlocks[counter].Answers)
            {
                CreateAnswerLabel(item.Text, false);
                createRadioButton(item.id.ToString());
                AsciCounter++;
                point.Y += 40;
            }
            point.X = 300;

            createButton("Sub", true);
            point.X = 200;
            if (counter == questionBlocks.Count - 1)
            {
                createButton("Next", false);
            }
            else
            {
                createButton("Next", true);
            }
            point.X = 0;
            if (counter == 0)
            {
                createButton("Back", false);
            }
            else
            {
                createButton("Back", true);
            }
            point.X = 100;
            createButton("Accept", true);
        }
        ListView listView = new ListView();
        void SelectBook()
        {
            string[] File;
            listView.Location = new Point(170, 58);
            listView.Size = new Size(408, 199);
            this.Controls.Add(listView);
            listView.SelectedIndexChanged += ListView_SelectedIndexChanged;
            if (Directory.Exists("Quiz"))
            {
                File = Directory.GetFiles("Quiz");
             
                foreach (var item in File)
                {

                    if (item.Contains(".xml"))
                    {
                        string path = Path.GetFileName(item);
                        listView.Items.Add(path);
                     
                    }
                }
            }
        }
        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] File;

            File = Directory.GetFiles("Quiz");

            Path_ = listView.SelectedItems[0].Text.ToString();
            foreach (var item in File)
            {

                if (item.Contains(Path_))
                {
                    Path_ = Path.GetFileName(item);
                }
            }
            ResetForm();
            ControlSizeQuiz();
        }
        void ControlSizeQuiz()
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(282, 140);
            textBox.Size = new Size(100, 20);
            this.Controls.Add(textBox);
            point.X = 256;
            point.Y = 218;
            createButton("Size", true);
        }
        public Form2(Form1 form1)
        {
            InitializeComponent();

            this.Size = new Size (674,340);
            form1.Enabled = false;
            SelectBook();
            // FormLoad("");
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}