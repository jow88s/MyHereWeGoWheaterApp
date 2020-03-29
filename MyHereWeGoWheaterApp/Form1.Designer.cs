namespace MyHereWeGoWheaterApp
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
            this._flp = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHechtel = new System.Windows.Forms.Button();
            this.btnAntwerpen = new System.Windows.Forms.Button();
            this.btnOostende = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _flp
            // 
            this._flp.AutoSize = true;
            this._flp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this._flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flp.Location = new System.Drawing.Point(12, 80);
            this._flp.Name = "_flp";
            this._flp.Size = new System.Drawing.Size(0, 0);
            this._flp.TabIndex = 0;
            this._flp.WrapContents = false;
            // 
            // btnHechtel
            // 
            this.btnHechtel.Location = new System.Drawing.Point(12, 12);
            this.btnHechtel.Name = "btnHechtel";
            this.btnHechtel.Size = new System.Drawing.Size(90, 50);
            this.btnHechtel.TabIndex = 1;
            this.btnHechtel.Text = "Hechtel";
            this.btnHechtel.UseVisualStyleBackColor = true;
            this.btnHechtel.Click += new System.EventHandler(this.btnHechtel_Click);
            // 
            // btnAntwerpen
            // 
            this.btnAntwerpen.Location = new System.Drawing.Point(146, 12);
            this.btnAntwerpen.Name = "btnAntwerpen";
            this.btnAntwerpen.Size = new System.Drawing.Size(90, 50);
            this.btnAntwerpen.TabIndex = 2;
            this.btnAntwerpen.Text = "Antwerpen";
            this.btnAntwerpen.UseVisualStyleBackColor = true;
            this.btnAntwerpen.Click += new System.EventHandler(this.btnAntwerpen_Click);
            // 
            // btnOostende
            // 
            this.btnOostende.Location = new System.Drawing.Point(289, 12);
            this.btnOostende.Name = "btnOostende";
            this.btnOostende.Size = new System.Drawing.Size(90, 50);
            this.btnOostende.TabIndex = 3;
            this.btnOostende.Text = "Oostende";
            this.btnOostende.UseVisualStyleBackColor = true;
            this.btnOostende.Click += new System.EventHandler(this.btnOostende_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.btnOostende);
            this.Controls.Add(this.btnAntwerpen);
            this.Controls.Add(this.btnHechtel);
            this.Controls.Add(this._flp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _flp;
        private System.Windows.Forms.Button btnHechtel;
        private System.Windows.Forms.Button btnAntwerpen;
        private System.Windows.Forms.Button btnOostende;
    }
}

