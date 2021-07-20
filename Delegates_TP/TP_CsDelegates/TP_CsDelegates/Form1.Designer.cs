namespace TP_CsDelegates
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_zone = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_calculate = new System.Windows.Forms.Button();
            this.textBox_itemPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_zone
            // 
            this.comboBox_zone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_zone.FormattingEnabled = true;
            this.comboBox_zone.Items.AddRange(new object[] {
            "Zone1",
            "Zone2",
            "Zone3",
            "Zone4"});
            this.comboBox_zone.Location = new System.Drawing.Point(34, 45);
            this.comboBox_zone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_zone.Name = "comboBox_zone";
            this.comboBox_zone.Size = new System.Drawing.Size(199, 23);
            this.comboBox_zone.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zone :";
            // 
            // button_calculate
            // 
            this.button_calculate.Location = new System.Drawing.Point(38, 154);
            this.button_calculate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(196, 25);
            this.button_calculate.TabIndex = 2;
            this.button_calculate.Text = "Calculate zone fees";
            this.button_calculate.UseVisualStyleBackColor = true;
            this.button_calculate.Click += new System.EventHandler(this.button_calculate_Click);
            // 
            // textBox_itemPrice
            // 
            this.textBox_itemPrice.Location = new System.Drawing.Point(38, 109);
            this.textBox_itemPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_itemPrice.Name = "textBox_itemPrice";
            this.textBox_itemPrice.Size = new System.Drawing.Size(195, 24);
            this.textBox_itemPrice.TabIndex = 3;
            this.textBox_itemPrice.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Item price ($) :";
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(38, 223);
            this.textBox_result.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.Size = new System.Drawing.Size(195, 24);
            this.textBox_result.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Zone fees :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 275);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.textBox_itemPrice);
            this.Controls.Add(this.button_calculate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_zone);
            this.Font = new System.Drawing.Font("SimSun", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Item zone fees";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_zone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_calculate;
        private System.Windows.Forms.TextBox textBox_itemPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Label label3;
    }
}

