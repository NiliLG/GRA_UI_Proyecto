namespace FormsGraficos
{
    partial class FrmLanzamientoH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1271, 595);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(1288, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(235, 584);
            listBox1.TabIndex = 1;
            // 
            // FrmLanzamientoH
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1535, 608);
            Controls.Add(listBox1);
            Controls.Add(pictureBox1);
            Name = "FrmLanzamientoH";
            Text = "FrmLanzamientoH";
            Load += FrmLanzamientoH_Load;
            KeyDown += FrmLanzamientoH_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ListBox listBox1;
    }
}