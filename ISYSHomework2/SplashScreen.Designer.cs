using System;

namespace ISYSHomework2
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.TBCustomerName = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LEnterName = new System.Windows.Forms.Label();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.LError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBCustomerName
            // 
            this.TBCustomerName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TBCustomerName.Location = new System.Drawing.Point(105, 12);
            this.TBCustomerName.Name = "TBCustomerName";
            this.TBCustomerName.Size = new System.Drawing.Size(86, 20);
            this.TBCustomerName.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // LEnterName
            // 
            this.LEnterName.AutoSize = true;
            this.LEnterName.Location = new System.Drawing.Point(12, 15);
            this.LEnterName.Name = "LEnterName";
            this.LEnterName.Size = new System.Drawing.Size(87, 13);
            this.LEnterName.TabIndex = 1;
            this.LEnterName.Text = "Enter your name:";
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(15, 99);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(75, 23);
            this.BtnEnter.TabIndex = 2;
            this.BtnEnter.Text = "Enter";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.MouseUp += BtnEnter_MouseUp;
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(116, 99);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.MouseUp += BtnExit_MouseUp;
            // 
            // LError
            // 
            this.LError.AutoSize = true;
            this.LError.Location = new System.Drawing.Point(12, 55);
            this.LError.Name = "LError";
            this.LError.Size = new System.Drawing.Size(0, 13);
            this.LError.TabIndex = 4;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(219, 161);
            this.Controls.Add(this.LError);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.LEnterName);
            this.Controls.Add(this.TBCustomerName);
            this.Name = "SplashScreen";
            this.Text = "Customer\'s Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void BtnEnter_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!this.TBCustomerName.Text.Equals(""))
            {
                GraphicalFoodMenu.ChangeScreen(this.TBCustomerName.Text);
            }
            else
            {
                throw new Exception("Username cannot be blank");
            }

        }
            

        private void BtnExit_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GraphicalFoodMenu.BtnExit_MouseUp();
        }

        #endregion

        private System.Windows.Forms.TextBox TBCustomerName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label LEnterName;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label LError;
    }
}

