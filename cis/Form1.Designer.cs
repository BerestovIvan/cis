namespace cis
{
    partial class Form1
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
            this.comboBoxFac = new System.Windows.Forms.ComboBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelFac = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonForm = new System.Windows.Forms.RadioButton();
            this.radioButtonExcel = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxFac
            // 
            this.comboBoxFac.FormattingEnabled = true;
            this.comboBoxFac.Location = new System.Drawing.Point(12, 67);
            this.comboBoxFac.Name = "comboBoxFac";
            this.comboBoxFac.Size = new System.Drawing.Size(211, 24);
            this.comboBoxFac.TabIndex = 0;
            this.comboBoxFac.SelectedIndexChanged += new System.EventHandler(this.comboBoxFuc_SelectedIndexChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(316, 165);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelFac
            // 
            this.labelFac.AutoSize = true;
            this.labelFac.Location = new System.Drawing.Point(63, 47);
            this.labelFac.Name = "labelFac";
            this.labelFac.Size = new System.Drawing.Size(68, 17);
            this.labelFac.TabIndex = 3;
            this.labelFac.Text = "Поиск по";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonForm);
            this.groupBox1.Controls.Add(this.radioButtonExcel);
            this.groupBox1.Location = new System.Drawing.Point(12, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonForm
            // 
            this.radioButtonForm.AutoSize = true;
            this.radioButtonForm.Location = new System.Drawing.Point(7, 62);
            this.radioButtonForm.Name = "radioButtonForm";
            this.radioButtonForm.Size = new System.Drawing.Size(85, 21);
            this.radioButtonForm.TabIndex = 1;
            this.radioButtonForm.Text = "В форму";
            this.radioButtonForm.UseVisualStyleBackColor = true;
            // 
            // radioButtonExcel
            // 
            this.radioButtonExcel.AutoSize = true;
            this.radioButtonExcel.Checked = true;
            this.radioButtonExcel.Location = new System.Drawing.Point(7, 22);
            this.radioButtonExcel.Name = "radioButtonExcel";
            this.radioButtonExcel.Size = new System.Drawing.Size(75, 21);
            this.radioButtonExcel.TabIndex = 0;
            this.radioButtonExcel.TabStop = true;
            this.radioButtonExcel.Text = "В Excel";
            this.radioButtonExcel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelFac);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.comboBoxFac);
            this.Name = "Form1";
            this.Text = "ПЛАН/ЗВІТ ВИДАННЯ НАВЧАЛЬНО-МЕТОДИЧНОЇ ЛІТЕРАТУРИ КАФЕДРИ 603 НА 2019-2020НАВЧАЛЬ" +
    "НІЙ РІК";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFac;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelFac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonForm;
        private System.Windows.Forms.RadioButton radioButtonExcel;
    }
}

