namespace RecursiveDrawings
{
    partial class formSize
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.grpRatio = new System.Windows.Forms.GroupBox();
            this.opt43 = new System.Windows.Forms.RadioButton();
            this.opt1610 = new System.Windows.Forms.RadioButton();
            this.opt169 = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.opt11 = new System.Windows.Forms.RadioButton();
            this.opt0 = new System.Windows.Forms.RadioButton();
            this.grpRatio.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(84, 21);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(71, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "1920";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(84, 48);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(71, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "1080";
            // 
            // grpRatio
            // 
            this.grpRatio.Controls.Add(this.opt0);
            this.grpRatio.Controls.Add(this.opt11);
            this.grpRatio.Controls.Add(this.opt43);
            this.grpRatio.Controls.Add(this.opt1610);
            this.grpRatio.Controls.Add(this.opt169);
            this.grpRatio.Location = new System.Drawing.Point(26, 83);
            this.grpRatio.Name = "grpRatio";
            this.grpRatio.Size = new System.Drawing.Size(129, 148);
            this.grpRatio.TabIndex = 4;
            this.grpRatio.TabStop = false;
            this.grpRatio.Text = "Aspect ratio";
            // 
            // opt43
            // 
            this.opt43.AutoSize = true;
            this.opt43.Location = new System.Drawing.Point(6, 74);
            this.opt43.Name = "opt43";
            this.opt43.Size = new System.Drawing.Size(40, 17);
            this.opt43.TabIndex = 2;
            this.opt43.Text = "4:3";
            this.opt43.UseVisualStyleBackColor = true;
            // 
            // opt1610
            // 
            this.opt1610.AutoSize = true;
            this.opt1610.Location = new System.Drawing.Point(6, 51);
            this.opt1610.Name = "opt1610";
            this.opt1610.Size = new System.Drawing.Size(52, 17);
            this.opt1610.TabIndex = 1;
            this.opt1610.Text = "16:10";
            this.opt1610.UseVisualStyleBackColor = true;
            // 
            // opt169
            // 
            this.opt169.AutoSize = true;
            this.opt169.Checked = true;
            this.opt169.Location = new System.Drawing.Point(6, 28);
            this.opt169.Name = "opt169";
            this.opt169.Size = new System.Drawing.Size(46, 17);
            this.opt169.TabIndex = 0;
            this.opt169.TabStop = true;
            this.opt169.Text = "16:9";
            this.opt169.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(183, 208);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(183, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // opt11
            // 
            this.opt11.AutoSize = true;
            this.opt11.Location = new System.Drawing.Point(6, 97);
            this.opt11.Name = "opt11";
            this.opt11.Size = new System.Drawing.Size(40, 17);
            this.opt11.TabIndex = 3;
            this.opt11.TabStop = true;
            this.opt11.Text = "1:1";
            this.opt11.UseVisualStyleBackColor = true;
            // 
            // opt0
            // 
            this.opt0.AutoSize = true;
            this.opt0.Location = new System.Drawing.Point(6, 120);
            this.opt0.Name = "opt0";
            this.opt0.Size = new System.Drawing.Size(63, 17);
            this.opt0.TabIndex = 4;
            this.opt0.TabStop = true;
            this.opt0.Text = "Arbitrary";
            this.opt0.UseVisualStyleBackColor = true;
            // 
            // formSize
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(270, 245);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpRatio);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "formSize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set canvas size";
            this.grpRatio.ResumeLayout(false);
            this.grpRatio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.GroupBox grpRatio;
        private System.Windows.Forms.RadioButton opt43;
        private System.Windows.Forms.RadioButton opt1610;
        private System.Windows.Forms.RadioButton opt169;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton opt0;
        private System.Windows.Forms.RadioButton opt11;
    }
}