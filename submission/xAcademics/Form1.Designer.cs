namespace xAcademics
{
    partial class Form1
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
            DrawingPanel = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            details = new TextBox();
            sundayBtn = new Button();
            mondayBtn = new Button();
            tuesdayBtn = new Button();
            wednesdayBtn = new Button();
            thursdayBtn = new Button();
            SuspendLayout();
            // 
            // DrawingPanel
            // 
            DrawingPanel.BorderStyle = BorderStyle.FixedSingle;
            DrawingPanel.Location = new Point(12, 98);
            DrawingPanel.Name = "DrawingPanel";
            DrawingPanel.Size = new Size(595, 481);
            DrawingPanel.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(277, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(686, 23);
            textBox1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(259, 28);
            label1.TabIndex = 9;
            label1.Text = "Enter Student CRN Numbers";
            // 
            // details
            // 
            details.Location = new Point(630, 151);
            details.Multiline = true;
            details.Name = "details";
            details.Size = new Size(333, 428);
            details.TabIndex = 10;
            // 
            // sundayBtn
            // 
            sundayBtn.BackColor = SystemColors.AppWorkspace;
            sundayBtn.Location = new Point(630, 98);
            sundayBtn.Name = "sundayBtn";
            sundayBtn.Size = new Size(46, 40);
            sundayBtn.TabIndex = 11;
            sundayBtn.Text = "U";
            sundayBtn.UseVisualStyleBackColor = false;
            sundayBtn.Click += dayBtnCLick;
            // 
            // mondayBtn
            // 
            mondayBtn.BackColor = SystemColors.AppWorkspace;
            mondayBtn.Location = new Point(703, 98);
            mondayBtn.Name = "mondayBtn";
            mondayBtn.Size = new Size(46, 40);
            mondayBtn.TabIndex = 12;
            mondayBtn.Text = "M";
            mondayBtn.UseVisualStyleBackColor = false;
            mondayBtn.Click += dayBtnCLick;
            // 
            // tuesdayBtn
            // 
            tuesdayBtn.BackColor = SystemColors.AppWorkspace;
            tuesdayBtn.Location = new Point(775, 98);
            tuesdayBtn.Name = "tuesdayBtn";
            tuesdayBtn.RightToLeft = RightToLeft.No;
            tuesdayBtn.Size = new Size(46, 40);
            tuesdayBtn.TabIndex = 13;
            tuesdayBtn.Text = "T";
            tuesdayBtn.UseVisualStyleBackColor = false;
            tuesdayBtn.Click += dayBtnCLick;
            // 
            // wednesdayBtn
            // 
            wednesdayBtn.BackColor = SystemColors.AppWorkspace;
            wednesdayBtn.Location = new Point(848, 98);
            wednesdayBtn.Name = "wednesdayBtn";
            wednesdayBtn.Size = new Size(46, 40);
            wednesdayBtn.TabIndex = 14;
            wednesdayBtn.Text = "W";
            wednesdayBtn.UseVisualStyleBackColor = false;
            wednesdayBtn.Click += dayBtnCLick;
            // 
            // thursdayBtn
            // 
            thursdayBtn.BackColor = SystemColors.AppWorkspace;
            thursdayBtn.Location = new Point(917, 98);
            thursdayBtn.Name = "thursdayBtn";
            thursdayBtn.Size = new Size(46, 40);
            thursdayBtn.TabIndex = 15;
            thursdayBtn.Text = "R";
            thursdayBtn.UseVisualStyleBackColor = false;
            thursdayBtn.Click += dayBtnCLick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 591);
            Controls.Add(thursdayBtn);
            Controls.Add(wednesdayBtn);
            Controls.Add(tuesdayBtn);
            Controls.Add(mondayBtn);
            Controls.Add(sundayBtn);
            Controls.Add(details);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(DrawingPanel);
            Name = "Form1";
            Text = "Application";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        internal Panel DrawingPanel;
        private TextBox textBox1;
        private Label label1;
        private TextBox details;
        private Button sundayBtn;
        private Button mondayBtn;
        private Button tuesdayBtn;
        private Button wednesdayBtn;
        private Button thursdayBtn;
    }
}