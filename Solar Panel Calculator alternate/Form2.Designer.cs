
namespace Solar_Panel_Calculator_alternate
{
    partial class Form2
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
            this.results = new System.Windows.Forms.RichTextBox();
            this.okay_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // results
            // 
            this.results.Enabled = false;
            this.results.Location = new System.Drawing.Point(28, 12);
            this.results.Name = "results";
            this.results.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.results.Size = new System.Drawing.Size(838, 424);
            this.results.TabIndex = 0;
            this.results.Text = "";
            // 
            // okay_btn
            // 
            this.okay_btn.Location = new System.Drawing.Point(28, 442);
            this.okay_btn.Name = "okay_btn";
            this.okay_btn.Size = new System.Drawing.Size(190, 45);
            this.okay_btn.TabIndex = 1;
            this.okay_btn.Text = "Okay";
            this.okay_btn.UseVisualStyleBackColor = true;
            this.okay_btn.Click += new System.EventHandler(this.okay_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(675, 442);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(191, 45);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "Save as notepad";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 499);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.okay_btn);
            this.Controls.Add(this.results);
            this.Name = "Form2";
            this.Text = "Solar Panel Calculator - Results";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox results;
        private System.Windows.Forms.Button okay_btn;
        private System.Windows.Forms.Button save_btn;
    }
}