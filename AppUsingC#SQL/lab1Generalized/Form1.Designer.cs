namespace lab1
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
            this.ParinteGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxParinte = new System.Windows.Forms.GroupBox();
            this.groupBoxFiu = new System.Windows.Forms.GroupBox();
            this.FiuGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxOptiuni = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panouControl = new System.Windows.Forms.Panel();
            this.conectareButton = new System.Windows.Forms.Button();
            this.groupBoxFields = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ParinteGridView)).BeginInit();
            this.groupBoxParinte.SuspendLayout();
            this.groupBoxFiu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FiuGridView)).BeginInit();
            this.groupBoxOptiuni.SuspendLayout();
            this.groupBoxFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParinteGridView
            // 
            this.ParinteGridView.AllowUserToAddRows = false;
            this.ParinteGridView.AllowUserToDeleteRows = false;
            this.ParinteGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ParinteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParinteGridView.Location = new System.Drawing.Point(1, 25);
            this.ParinteGridView.Name = "ParinteGridView";
            this.ParinteGridView.ReadOnly = true;
            this.ParinteGridView.RowTemplate.Height = 24;
            this.ParinteGridView.Size = new System.Drawing.Size(568, 248);
            this.ParinteGridView.TabIndex = 0;
            this.ParinteGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParinteGridView_CellClick);
            // 
            // groupBoxParinte
            // 
            this.groupBoxParinte.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBoxParinte.Controls.Add(this.ParinteGridView);
            this.groupBoxParinte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxParinte.Location = new System.Drawing.Point(11, 85);
            this.groupBoxParinte.Name = "groupBoxParinte";
            this.groupBoxParinte.Size = new System.Drawing.Size(575, 279);
            this.groupBoxParinte.TabIndex = 1;
            this.groupBoxParinte.TabStop = false;
            this.groupBoxParinte.Text = "Tabela parinte";
            // 
            // groupBoxFiu
            // 
            this.groupBoxFiu.Controls.Add(this.FiuGridView);
            this.groupBoxFiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFiu.Location = new System.Drawing.Point(609, 85);
            this.groupBoxFiu.Name = "groupBoxFiu";
            this.groupBoxFiu.Size = new System.Drawing.Size(722, 279);
            this.groupBoxFiu.TabIndex = 2;
            this.groupBoxFiu.TabStop = false;
            this.groupBoxFiu.Text = "Tabela fiu";
            // 
            // FiuGridView
            // 
            this.FiuGridView.AllowUserToAddRows = false;
            this.FiuGridView.AllowUserToDeleteRows = false;
            this.FiuGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FiuGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FiuGridView.Location = new System.Drawing.Point(17, 26);
            this.FiuGridView.Name = "FiuGridView";
            this.FiuGridView.ReadOnly = true;
            this.FiuGridView.RowTemplate.Height = 24;
            this.FiuGridView.Size = new System.Drawing.Size(699, 247);
            this.FiuGridView.TabIndex = 0;
            this.FiuGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FiuGridView_CellClick);
            // 
            // groupBoxOptiuni
            // 
            this.groupBoxOptiuni.Controls.Add(this.button3);
            this.groupBoxOptiuni.Controls.Add(this.button1);
            this.groupBoxOptiuni.Controls.Add(this.button2);
            this.groupBoxOptiuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOptiuni.Location = new System.Drawing.Point(609, 474);
            this.groupBoxOptiuni.Name = "groupBoxOptiuni";
            this.groupBoxOptiuni.Size = new System.Drawing.Size(215, 213);
            this.groupBoxOptiuni.TabIndex = 4;
            this.groupBoxOptiuni.TabStop = false;
            this.groupBoxOptiuni.Text = "Optiuni";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button3.Location = new System.Drawing.Point(33, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "Modifica";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Location = new System.Drawing.Point(33, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button2.Location = new System.Drawing.Point(33, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Sterge";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panouControl
            // 
            this.panouControl.Location = new System.Drawing.Point(16, 27);
            this.panouControl.Name = "panouControl";
            this.panouControl.Size = new System.Drawing.Size(375, 318);
            this.panouControl.TabIndex = 5;
            // 
            // conectareButton
            // 
            this.conectareButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.conectareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conectareButton.Location = new System.Drawing.Point(12, 12);
            this.conectareButton.Name = "conectareButton";
            this.conectareButton.Size = new System.Drawing.Size(128, 41);
            this.conectareButton.TabIndex = 7;
            this.conectareButton.Text = "Conectare";
            this.conectareButton.UseVisualStyleBackColor = false;
            this.conectareButton.Click += new System.EventHandler(this.conectareButton_Click);
            // 
            // groupBoxFields
            // 
            this.groupBoxFields.Controls.Add(this.panouControl);
            this.groupBoxFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFields.Location = new System.Drawing.Point(17, 405);
            this.groupBoxFields.Name = "groupBoxFields";
            this.groupBoxFields.Size = new System.Drawing.Size(427, 371);
            this.groupBoxFields.TabIndex = 8;
            this.groupBoxFields.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 796);
            this.Controls.Add(this.groupBoxFields);
            this.Controls.Add(this.conectareButton);
            this.Controls.Add(this.groupBoxOptiuni);
            this.Controls.Add(this.groupBoxFiu);
            this.Controls.Add(this.groupBoxParinte);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ParinteGridView)).EndInit();
            this.groupBoxParinte.ResumeLayout(false);
            this.groupBoxFiu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FiuGridView)).EndInit();
            this.groupBoxOptiuni.ResumeLayout(false);
            this.groupBoxFields.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ParinteGridView;
        private System.Windows.Forms.GroupBox groupBoxParinte;
        private System.Windows.Forms.GroupBox groupBoxFiu;
        private System.Windows.Forms.DataGridView FiuGridView;
        private System.Windows.Forms.GroupBox groupBoxOptiuni;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panouControl;
        private System.Windows.Forms.Button conectareButton;
        private System.Windows.Forms.GroupBox groupBoxFields;
    }
}

