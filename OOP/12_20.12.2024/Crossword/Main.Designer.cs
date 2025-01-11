namespace Crossword
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            flpInfo = new FlowLayoutPanel();
            lbWelcome = new Label();
            lbQuestions = new Label();
            lbQuestionLevel = new Label();
            flpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // flpInfo
            // 
            flpInfo.BackColor = Color.Transparent;
            flpInfo.BorderStyle = BorderStyle.FixedSingle;
            flpInfo.Controls.Add(lbWelcome);
            flpInfo.Controls.Add(lbQuestions);
            flpInfo.Controls.Add(lbQuestionLevel);
            flpInfo.Location = new Point(453, 0);
            flpInfo.Margin = new Padding(0);
            flpInfo.Name = "flpInfo";
            flpInfo.Size = new Size(331, 455);
            flpInfo.TabIndex = 0;
            // 
            // lbWelcome
            // 
            lbWelcome.BackColor = Color.PeachPuff;
            lbWelcome.BorderStyle = BorderStyle.Fixed3D;
            lbWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbWelcome.ForeColor = SystemColors.ActiveCaptionText;
            lbWelcome.Location = new Point(3, 0);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.Size = new Size(331, 134);
            lbWelcome.TabIndex = 0;
            lbWelcome.Text = "ДОБРЕ ДОШЛИ В КОЛЕДНАТА КРЪСТОСЛОВИЦА";
            lbWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbQuestions
            // 
            lbQuestions.BackColor = Color.LightGray;
            lbQuestions.BorderStyle = BorderStyle.Fixed3D;
            lbQuestions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbQuestions.ForeColor = SystemColors.ActiveCaptionText;
            lbQuestions.Location = new Point(3, 134);
            lbQuestions.Name = "lbQuestions";
            lbQuestions.Size = new Size(331, 134);
            lbQuestions.TabIndex = 0;
            lbQuestions.Text = "КЛИКНИ ЗА ДА ЗАПОЧНЕШ";
            lbQuestions.TextAlign = ContentAlignment.MiddleCenter;
            lbQuestions.MouseDown += Lbquestions_MouseDown;
            lbQuestions.MouseLeave += LbQuestion_MouseLeave;
            lbQuestions.MouseUp += Lbquestions_MouseUp;
            // 
            // lbQuestionLevel
            // 
            lbQuestionLevel.BackColor = Color.PapayaWhip;
            lbQuestionLevel.BorderStyle = BorderStyle.Fixed3D;
            lbQuestionLevel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbQuestionLevel.ForeColor = SystemColors.ActiveCaptionText;
            lbQuestionLevel.Location = new Point(3, 268);
            lbQuestionLevel.Name = "lbQuestionLevel";
            lbQuestionLevel.Size = new Size(331, 186);
            lbQuestionLevel.TabIndex = 0;
            lbQuestionLevel.Text = "ТРУДНОСТ НА ВЪПРОСА";
            lbQuestionLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(782, 453);
            Controls.Add(flpInfo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Christmas Crossword";
            Load += Main_Load;
            flpInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpInfo;
        private Label lbWelcome;
        private Label lbQuestions;
        private Label lbQuestionLevel;
    }
}
