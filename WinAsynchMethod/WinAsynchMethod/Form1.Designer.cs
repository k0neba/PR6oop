namespace WinAsynchMethod
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
            label1 = new Label();
            label2 = new Label();
            txbA = new TextBox();
            txbB = new TextBox();
            btnRun = new Button();
            btnWork = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 0;
            label1.Text = "Значення А";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 9);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Значення Б";
            // 
            // txbA
            // 
            txbA.Location = new Point(12, 38);
            txbA.Name = "txbA";
            txbA.Size = new Size(100, 23);
            txbA.TabIndex = 3;
            // 
            // txbB
            // 
            txbB.Location = new Point(139, 38);
            txbB.Name = "txbB";
            txbB.Size = new Size(100, 23);
            txbB.TabIndex = 4;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(45, 92);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(67, 26);
            btnRun.TabIndex = 5;
            btnRun.Text = "Сума";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click_1;
            // 
            // btnWork
            // 
            btnWork.Location = new Point(139, 92);
            btnWork.Name = "btnWork";
            btnWork.Size = new Size(67, 26);
            btnWork.TabIndex = 6;
            btnWork.Text = "Робота";
            btnWork.UseVisualStyleBackColor = true;
            btnWork.Click += btnWork_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 157);
            Controls.Add(btnWork);
            Controls.Add(btnRun);
            Controls.Add(txbB);
            Controls.Add(txbA);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Асинхроний запуск";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txbA;
        private TextBox txbB;
        private Button btnRun;
        private Button btnWork;
    }
}
