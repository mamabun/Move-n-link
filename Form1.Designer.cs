namespace Move_n_link
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Source = new FolderBrowserDialog();
            Destination = new FolderBrowserDialog();
            Button_src = new Button();
            Button_dest = new Button();
            textBoxDEST = new TextBox();
            textBoxSRC = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            CloseBTN = new Button();
            button3 = new Button();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Source
            // 
            Source.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // Destination
            // 
            Destination.HelpRequest += Destination_HelpRequest;
            // 
            // Button_src
            // 
            Button_src.Location = new Point(30, 87);
            Button_src.Name = "Button_src";
            Button_src.Size = new Size(75, 23);
            Button_src.TabIndex = 2;
            Button_src.Text = "Browse";
            Button_src.UseVisualStyleBackColor = true;
            Button_src.Click += button_src_Click;
            // 
            // Button_dest
            // 
            Button_dest.Location = new Point(30, 177);
            Button_dest.Name = "Button_dest";
            Button_dest.Size = new Size(75, 23);
            Button_dest.TabIndex = 3;
            Button_dest.Text = "Browse";
            Button_dest.UseVisualStyleBackColor = true;
            Button_dest.Click += button_dest_Click;
            // 
            // textBoxDEST
            // 
            textBoxDEST.Location = new Point(30, 148);
            textBoxDEST.Name = "textBoxDEST";
            textBoxDEST.Size = new Size(456, 23);
            textBoxDEST.TabIndex = 4;
            // 
            // textBoxSRC
            // 
            textBoxSRC.Location = new Point(30, 58);
            textBoxSRC.Name = "textBoxSRC";
            textBoxSRC.Size = new Size(456, 23);
            textBoxSRC.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 40);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "Source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 130);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 7;
            label2.Text = "Destination";
            // 
            // button1
            // 
            button1.Location = new Point(22, 255);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Move";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // CloseBTN
            // 
            CloseBTN.Location = new Point(411, 255);
            CloseBTN.Name = "CloseBTN";
            CloseBTN.Size = new Size(75, 23);
            CloseBTN.TabIndex = 9;
            CloseBTN.Text = "Close";
            CloseBTN.UseVisualStyleBackColor = true;
            CloseBTN.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(224, 255);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "Help";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(546, 25);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(44, 22);
            toolStripButton1.Text = "About";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 318);
            Controls.Add(toolStrip1);
            Controls.Add(button3);
            Controls.Add(CloseBTN);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxSRC);
            Controls.Add(textBoxDEST);
            Controls.Add(Button_dest);
            Controls.Add(Button_src);
            Name = "Form1";
            Text = "Move'n'Link";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FolderBrowserDialog Source;
        private FolderBrowserDialog Destination;
        private Button Button_src;
        private Button Button_dest;
        private TextBox textBoxDEST;
        private TextBox textBoxSRC;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button CloseBTN;
        private Button button3;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
    }
}
