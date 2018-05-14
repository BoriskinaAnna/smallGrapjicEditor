namespace graphicEditor
{
    partial class Lab1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawField = new System.Windows.Forms.PictureBox();
            this.shapeComboBox = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // drawField
            // 
            this.drawField.BackColor = System.Drawing.Color.White;
            this.drawField.Location = new System.Drawing.Point(0, 14);
            this.drawField.Name = "drawField";
            this.drawField.Size = new System.Drawing.Size(670, 286);
            this.drawField.TabIndex = 1;
            this.drawField.TabStop = false;
            this.drawField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawField_MouseClick);
            this.drawField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawField_MouseDown);
            this.drawField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawField_MouseMove);
            this.drawField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawField_MouseUp);
            // 
            // shapeComboBox
            // 
            this.shapeComboBox.FormattingEnabled = true;
            this.shapeComboBox.Items.AddRange(new object[] {
            "Mouse"});
            this.shapeComboBox.Location = new System.Drawing.Point(299, 308);
            this.shapeComboBox.Name = "shapeComboBox";
            this.shapeComboBox.Size = new System.Drawing.Size(121, 21);
            this.shapeComboBox.TabIndex = 2;
            this.shapeComboBox.SelectedIndexChanged += new System.EventHandler(this.shapeComboBox_SelectedIndexChanged);
            this.shapeComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shapeComboBox_KeyDown);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(567, 306);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "collor";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            this.btnColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shapeComboBox_KeyDown);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(441, 309);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown.TabIndex = 5;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shapeComboBox_KeyDown);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 306);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnOpen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shapeComboBox_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shapeComboBox_KeyDown);
            // 
            // Lab1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 339);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.shapeComboBox);
            this.Controls.Add(this.drawField);
            this.Name = "Lab1";
            this.Text = "ООП лаб 1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lab1_KeyDown_1);
            ((System.ComponentModel.ISupportInitialize)(this.drawField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox drawField;
        private System.Windows.Forms.ComboBox shapeComboBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
    }
}

