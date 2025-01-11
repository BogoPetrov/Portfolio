namespace Crossword
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private readonly List<RichTextBox[]> charBoxes = [];
        private readonly string[] words = ["в", "мед", "с", "век", "или", "квант", "цикъл", "саботаж", "топлина", "множество", "д", "а"];
        private readonly string[] questions =
        [
            "Кой е символът съответстващ на клавиша 'L' на клавиатурата?",
            "От какъв материал са направени проводниците в кабелите",
            "Кой е сиволът съответстващ на клавиша 'I' на клавиатурата?",
            "Означение на определен период от историята (като времетраене).",
            "Друго наименовение на логическото събиране в програмирането.",
            "Дума част от 'кватнов компютър'.",
            "Основна структурна единица в програмирането, която може да повтаря определен път тялото си.",
            "Дума която е свързана с събитието, когато група от хора предприемат подло действие с цел разваляне на нещо свързано с бизнес.",
            "Какво осещаме, когато се греем на огън.",
            "Съвкупност от предмети или събития, които са обединени под обща дума?",
            "Кой е символът съответстващ на клавиша 'O' на клавиатурата?",
            "Кой е символът съответстващ на клавиша 'D' на клавиатурата?",
        ];

        private void LoadData()
        {
            byte[] rows = [1, 3, 1, 3, 3, 5, 5, 7, 7, 9, 1, 1];

            byte index = 0;
            foreach (byte row in rows)
            {
                charBoxes.Add(new RichTextBox[row]);
                for (int i = 0; i < row; i++)
                {
                    charBoxes[index][i] = new RichTextBox()
                    {
                        Size = new Size(30, 30),
                        SelectionAlignment = HorizontalAlignment.Center,
                        AcceptsTab = true,
                        BackColor = Color.DarkSeaGreen,
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0),
                        ForeColor = Color.White,
                        MaxLength = 1,
                        Multiline = false,
                        ScrollBars = RichTextBoxScrollBars.None
                    };
                    charBoxes[index][i].MouseEnter += CharBox_MouseEnter!;
                    charBoxes[index][i].MouseLeave += CharBox_MouseLeave!;
                    charBoxes[index][i].TextChanged += CharBox_TextChanged!;
                    charBoxes[index][i].GotFocus += CharBox_GotFocus!;
                    charBoxes[index][i].LostFocus += CharBox_LostFocus!;
                }
                index++;
            }
        }

        private void CharBox_MouseEnter(object sender, EventArgs e)
        {
            foreach (RichTextBox[] richTextBoxRow in charBoxes)
            {
                foreach (RichTextBox richTextBox in richTextBoxRow)
                {
                    if (richTextBox == (RichTextBox)sender && richTextBox.Text.Length == 0)
                    {
                        richTextBox.BackColor = Color.LightCoral;
                        lbQuestions.Text = questions[charBoxes.IndexOf(richTextBoxRow)];
                        switch (richTextBoxRow.Length)
                        {
                            case 1:
                            case 3:
                                lbQuestionLevel.Text = "ЛЕСЕНО НИВО";
                                lbQuestionLevel.BackColor = Color.LightGreen;
                                break;
                            case 5:
                            case 7:
                                lbQuestionLevel.Text = "СРЕДНО НИВО";
                                lbQuestionLevel.BackColor = Color.Khaki;
                                break;
                            case 9:
                                lbQuestionLevel.Text = "ТРУДНО НИВО";
                                lbQuestionLevel.BackColor = Color.LightCoral;
                                break;
                            default:
                                lbQuestionLevel.Text = "ТРУДНОСТ НА ВЪПРОСА";
                                lbQuestionLevel.BackColor = Color.PapayaWhip;
                                break;
                        }
                        return;
                    }
                }
            }
        }

        private void CharBox_GotFocus(object sender, EventArgs e)
        {
            foreach (RichTextBox[] richTextBoxRow in charBoxes)
            {
                foreach (RichTextBox richTextBox in richTextBoxRow)
                {
                    if (richTextBox == (RichTextBox)sender && richTextBox.Text.Length == 0)
                    {
                        richTextBox.BackColor = Color.LightCoral;
                        lbQuestions.Text = questions[charBoxes.IndexOf(richTextBoxRow)];
                        switch (richTextBoxRow.Length)
                        {
                            case 1:
                            case 3:
                                lbQuestionLevel.Text = "ЛЕСЕНО НИВО";
                                lbQuestionLevel.BackColor = Color.LightGreen;
                                break;
                            case 5:
                            case 7:
                                lbQuestionLevel.Text = "СРЕДНО НИВО";
                                lbQuestionLevel.BackColor = Color.Khaki;
                                break;
                            case 9:
                                lbQuestionLevel.Text = "ТРУДНО НИВО";
                                lbQuestionLevel.BackColor = Color.LightCoral;
                                break;
                            default:
                                lbQuestionLevel.Text = "ТРУДНОСТ НА ВЪПРОСА";
                                lbQuestionLevel.BackColor = Color.PapayaWhip;
                                break;
                        }
                        return;
                    }
                }
            }
        }

        private void CharBox_LostFocus(object sender, EventArgs e)
        {
            foreach (RichTextBox[] richTextBoxRow in charBoxes)
            {
                foreach (RichTextBox richTextBox in richTextBoxRow)
                {
                    if (richTextBox == (RichTextBox)sender && richTextBox.Text.Length == 0)
                    {
                        richTextBox.BackColor = Color.DarkSeaGreen;
                        lbQuestions.Text = questions[charBoxes.IndexOf(richTextBoxRow)];
                        switch (richTextBoxRow.Length)
                        {
                            case 1:
                            case 3:
                                lbQuestionLevel.Text = "ЛЕСЕНО НИВО";
                                lbQuestionLevel.BackColor = Color.LightGreen;
                                break;
                            case 5:
                            case 7:
                                lbQuestionLevel.Text = "СРЕДНО НИВО";
                                lbQuestionLevel.BackColor = Color.Khaki;
                                break;
                            case 9:
                                lbQuestionLevel.Text = "ТРУДНО НИВО";
                                lbQuestionLevel.BackColor = Color.LightCoral;
                                break;
                            default:
                                lbQuestionLevel.Text = "ТРУДНОСТ НА ВЪПРОСА";
                                lbQuestionLevel.BackColor = Color.PapayaWhip;
                                break;
                        }
                        return;
                    }
                }
            }
        }

        private void CharBox_MouseLeave(object sender, EventArgs e)
        {
            foreach (RichTextBox[] richTextBoxRow in charBoxes)
            {
                foreach (RichTextBox richTextBox in richTextBoxRow)
                {
                    if (richTextBox == (RichTextBox)sender && richTextBox.Text.Length == 0)
                    {
                        richTextBox.BackColor = Color.DarkSeaGreen;
                        return;
                    }
                }
            }
        }

        private void CharBox_TextChanged(object sender, EventArgs e)
        {
            short indexOfRow;
            short indexOfElement;
            foreach (RichTextBox[] richTextBoxRow in charBoxes)
            {
                foreach (RichTextBox richTextBox in richTextBoxRow)
                {
                    if (richTextBox == (RichTextBox)sender)
                    {
                        indexOfRow = (short)(charBoxes.IndexOf(richTextBoxRow));
                        indexOfElement = (short)richTextBoxRow.ToList().IndexOf(richTextBox);
                        string answer = words[indexOfRow][indexOfElement].ToString();
                        string textFromBox = richTextBox!.Text;

                        if (textFromBox != "")
                        {
                            if (textFromBox.Equals(answer, StringComparison.OrdinalIgnoreCase))
                            {
                                richTextBox.BackColor = Color.Green;
                                richTextBox.ReadOnly = true;
                            }
                            else
                            {
                                richTextBox.BackColor = Color.Red;
                            }
                        }
                        return;
                    }
                }
            }
        }

        private void Lbquestions_MouseDown(object sender, EventArgs e)
        {
            lbQuestions.BackColor = Color.Silver;
        }

        private void Lbquestions_MouseUp(object sender, MouseEventArgs e)
        {
            lbQuestions.Text = "";
            lbQuestions.BackColor = Color.Transparent;
            lbQuestions.TextAlign = ContentAlignment.MiddleLeft;
            lbQuestions.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        private void LbQuestion_MouseLeave(object sender, EventArgs e)
        {
            if (lbQuestions.BackColor == Color.Transparent && lbQuestions.Text == "" && charBoxes[0][0].Visible == false)
            {
                foreach (RichTextBox[] richTextBoxRow in charBoxes)
                {
                    for (int countElement = 0; countElement < richTextBoxRow.Length; countElement++)
                    {
                        richTextBoxRow[countElement].Visible = true;
                    }
                    Thread.Sleep(10);
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadData();
            const short xStartLocation = 175;
            const short yStartLocation = 10;

            byte indexRow = 0;
            foreach (RichTextBox[] richTextBoxRow in charBoxes)
            {
                short y = (short)(yStartLocation + indexRow * 35);
                for (int countElement = 0; countElement < richTextBoxRow.Length; countElement++)
                {
                    short x = (short)(xStartLocation - ((((richTextBoxRow.Length - 1) / 2) - countElement) * 35));
                    richTextBoxRow[countElement].Location = new Point(x, y);
                    richTextBoxRow[countElement].Visible = false;
                    Controls.Add(richTextBoxRow[countElement]);
                }
                indexRow++;
            }
        }
    }
}
