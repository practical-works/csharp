namespace AsyncWinFormsExample
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_msgSync = new System.Windows.Forms.Button();
            this.button_msgAsync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.button_loadImage = new System.Windows.Forms.Button();
            this.button_clearImage = new System.Windows.Forms.Button();
            this.pictureBox_image = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label_imageName = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_msgSync
            // 
            this.button_msgSync.Location = new System.Drawing.Point(23, 39);
            this.button_msgSync.Name = "button_msgSync";
            this.button_msgSync.Size = new System.Drawing.Size(158, 23);
            this.button_msgSync.TabIndex = 0;
            this.button_msgSync.Text = "Show MessageBox";
            this.button_msgSync.UseVisualStyleBackColor = true;
            this.button_msgSync.Click += new System.EventHandler(this.button_msgSync_Click);
            // 
            // button_msgAsync
            // 
            this.button_msgAsync.Location = new System.Drawing.Point(196, 39);
            this.button_msgAsync.Name = "button_msgAsync";
            this.button_msgAsync.Size = new System.Drawing.Size(158, 23);
            this.button_msgAsync.TabIndex = 0;
            this.button_msgAsync.Text = "Show MessageBox (Async)";
            this.button_msgAsync.UseVisualStyleBackColor = true;
            this.button_msgAsync.Click += new System.EventHandler(this.button_msgAsync_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MAIN THREAD";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(23, 93);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(331, 20);
            this.textBox_url.TabIndex = 2;
            this.textBox_url.Text = "https://static.pexels.com/photos/305555/pexels-photo-305555.jpeg";
            // 
            // button_loadImage
            // 
            this.button_loadImage.Location = new System.Drawing.Point(23, 119);
            this.button_loadImage.Name = "button_loadImage";
            this.button_loadImage.Size = new System.Drawing.Size(250, 23);
            this.button_loadImage.TabIndex = 3;
            this.button_loadImage.Text = "Load Image";
            this.button_loadImage.UseVisualStyleBackColor = true;
            this.button_loadImage.Click += new System.EventHandler(this.button_loadImage_Click);
            // 
            // button_clearImage
            // 
            this.button_clearImage.Location = new System.Drawing.Point(279, 119);
            this.button_clearImage.Name = "button_clearImage";
            this.button_clearImage.Size = new System.Drawing.Size(75, 23);
            this.button_clearImage.TabIndex = 4;
            this.button_clearImage.Text = "Clear";
            this.button_clearImage.UseVisualStyleBackColor = true;
            this.button_clearImage.Click += new System.EventHandler(this.button_clearImage_Click);
            // 
            // pictureBox_image
            // 
            this.pictureBox_image.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox_image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_image.Location = new System.Drawing.Point(23, 159);
            this.pictureBox_image.Name = "pictureBox_image";
            this.pictureBox_image.Size = new System.Drawing.Size(331, 201);
            this.pictureBox_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_image.TabIndex = 5;
            this.pictureBox_image.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label_imageName
            // 
            this.label_imageName.AutoSize = true;
            this.label_imageName.BackColor = System.Drawing.Color.Transparent;
            this.label_imageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_imageName.Location = new System.Drawing.Point(33, 168);
            this.label_imageName.Name = "label_imageName";
            this.label_imageName.Size = new System.Drawing.Size(2, 15);
            this.label_imageName.TabIndex = 6;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 383);
            this.Controls.Add(this.label_imageName);
            this.Controls.Add(this.pictureBox_image);
            this.Controls.Add(this.button_clearImage);
            this.Controls.Add(this.button_loadImage);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_msgAsync);
            this.Controls.Add(this.button_msgSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_msgSync;
        private System.Windows.Forms.Button button_msgAsync;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Button button_loadImage;
        private System.Windows.Forms.Button button_clearImage;
        private System.Windows.Forms.PictureBox pictureBox_image;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label_imageName;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

