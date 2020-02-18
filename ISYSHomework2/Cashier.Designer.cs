namespace ISYSHomework2
{
    partial class Cashier
    {
        private static byte currentItemCount = 0;
        private static byte currentQuanityLabelCount = 0;
        private static byte currentPriceLabelCount = 0;
        private static byte currentQuanityTextBoxCount = 0;
        private static byte currentPriceTextBoxCount = 0;
        private static byte currentSelectionLabelCount = 0;
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
        public void InitializeComponent()
        {
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblFinalText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(12, 9);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(96, 37);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Menu";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(675, 13);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(91, 40);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.MouseUp += btnCalculate_MouseUp;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(800, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 40);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.MouseUp += btnClear_MouseUp;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(925, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.MouseUp += btnExit_MouseUp;
            // 
            // label1
            // 
            this.lblFinalText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFinalText.Location = new System.Drawing.Point(311, 495);
            this.lblFinalText.Name = "lblFinalText";
            this.lblFinalText.Size = new System.Drawing.Size(384, 96);
            this.lblFinalText.TabIndex = 4;
            this.lblFinalText.Text = "";
            this.lblFinalText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1044, 600);
            this.Controls.Add(this.lblFinalText);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblMenu);
            this.Name = "Cashier";
            this.Text = "Fine Dining Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

            
        public System.Windows.Forms.GroupBox[] GetGroupBoxes()
        {
            return itemGroupBoxes;
        }

        public void SetFinalText(string text)
        {
            this.lblFinalText.Text = text;
        }

        public void IncrementCurrentItemCount()
        {
            currentItemCount++;
        }

        public void addGroupBoxes(int x, int y, string name, int tag, int sizeX, int sizeY)
        {
            itemGroupBoxes[tag] = new System.Windows.Forms.GroupBox();
            itemGroupBoxes[tag].Location = new System.Drawing.Point(x, y);
            itemGroupBoxes[tag].Name = "groupBox" + tag;
            itemGroupBoxes[tag].Size = new System.Drawing.Size(sizeX, sizeY);
            itemGroupBoxes[tag].TabIndex = 0;
            itemGroupBoxes[tag].TabStop = false;
            itemGroupBoxes[tag].Text = name;
            Controls.Add(itemGroupBoxes[tag]);
        }

        public void addRadioButton(int x, int y, string name, int group)
        {
            itemRadioButtons[currentItemCount] = new System.Windows.Forms.RadioButton();
            const string RADIO_BUTTON_CONST = "rdoBtn";
            string radioButtonName = RADIO_BUTTON_CONST + currentItemCount;
            itemRadioButtons[currentItemCount].AutoSize = true;
            itemRadioButtons[currentItemCount].Location = new System.Drawing.Point(x, y);
            itemRadioButtons[currentItemCount].Name = radioButtonName;
            itemRadioButtons[currentItemCount].Text = name;
            itemRadioButtons[currentItemCount].Checked = false;
            itemRadioButtons[currentItemCount].CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            itemGroupBoxes[group].Controls.Add(itemRadioButtons[currentItemCount]);
        }

        public void addPictureBox(int x, int y, string name, System.Drawing.Image image, int group)
        {
            itemPictures[currentItemCount] = new System.Windows.Forms.PictureBox();
            const string PICTURE_BOX_CONST = "picBox";
            string pictureBoxName = PICTURE_BOX_CONST + currentItemCount;
            itemPictures[currentItemCount].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            itemPictures[currentItemCount].Name = pictureBoxName;
            itemPictures[currentItemCount].Image = image;
            itemPictures[currentItemCount].ErrorImage = null;
            itemPictures[currentItemCount].InitialImage = null;
            itemPictures[currentItemCount].Size = new System.Drawing.Size(100, 100);
            itemPictures[currentItemCount].Tag = group;
            itemPictures[currentItemCount].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            itemPictures[currentItemCount].TabStop = false;
            itemPictures[currentItemCount].TabIndex = 1;
            itemPictures[currentItemCount].Location = new System.Drawing.Point(x, y);

            itemGroupBoxes[group].Controls.Add(itemPictures[currentItemCount]);
            
        }

        public void AddQuantityLabel(int x, int y, string text, int group)
        {
            itemQuantityLabels[currentQuanityLabelCount] = new System.Windows.Forms.Label();
            itemQuantityLabels[currentQuanityLabelCount].AutoSize = true;
            itemQuantityLabels[currentQuanityLabelCount].Location = new System.Drawing.Point(x, y);
            itemQuantityLabels[currentQuanityLabelCount].Name = "lblQuantity" + currentQuanityLabelCount;
            itemQuantityLabels[currentQuanityLabelCount].TabIndex = 1;
            itemQuantityLabels[currentQuanityLabelCount].Text = text;
            itemGroupBoxes[group].Controls.Add(itemQuantityLabels[currentQuanityLabelCount]);
            currentQuanityLabelCount++;
        }

        public void AddQuantityTextBox(int x, int y, int group)
        {
            itemQuanitityTextBoxes[currentQuanityTextBoxCount] = new System.Windows.Forms.TextBox();
            itemQuanitityTextBoxes[currentQuanityTextBoxCount].AutoSize = true;
            itemQuanitityTextBoxes[currentQuanityTextBoxCount].Size = new System.Drawing.Size(100, 20);
            itemQuanitityTextBoxes[currentQuanityTextBoxCount].Location = new System.Drawing.Point(x, y);
            itemQuanitityTextBoxes[currentQuanityTextBoxCount].Name = "TxtBoxQuantity" + currentQuanityTextBoxCount;
            itemQuanitityTextBoxes[currentQuanityTextBoxCount].TabIndex = 1;
            itemGroupBoxes[group].Controls.Add(itemQuanitityTextBoxes[currentQuanityTextBoxCount]);
            currentQuanityTextBoxCount++;
        }

        public void AddPriceTextBox(int x, int y, int group)
        {
            itemPriceTextBoxes[currentPriceTextBoxCount] = new System.Windows.Forms.TextBox();
            //itemPriceTextBoxes[currentQuanityLabelCount].AutoSize = true;
            itemPriceTextBoxes[currentPriceTextBoxCount].Enabled = false;
            itemPriceTextBoxes[currentPriceTextBoxCount].Size = new System.Drawing.Size(100, 20);
            itemPriceTextBoxes[currentPriceTextBoxCount].Location = new System.Drawing.Point(x, y);
            itemPriceTextBoxes[currentPriceTextBoxCount].Name = "TxtBoxPrice" + currentPriceTextBoxCount;
            itemPriceTextBoxes[currentPriceTextBoxCount].TabIndex = 1;
            itemGroupBoxes[group].Controls.Add(itemPriceTextBoxes[currentPriceTextBoxCount]);
            currentPriceTextBoxCount++;
        }

        public void AddPriceLabel(int x, int y, string text, int group)
        {
            itemPriceLabels[currentPriceLabelCount] = new System.Windows.Forms.Label();
            itemPriceLabels[currentPriceLabelCount].AutoSize = true;
            itemPriceLabels[currentPriceLabelCount].Location = new System.Drawing.Point(x, y);
            itemPriceLabels[currentPriceLabelCount].Name = "lblPrice" + currentPriceLabelCount;
            itemPriceLabels[currentPriceLabelCount].TabIndex = 1;
            itemPriceLabels[currentPriceLabelCount].Text = text;
            itemGroupBoxes[group].Controls.Add(itemPriceLabels[currentPriceLabelCount]);
            currentPriceLabelCount++;
        }

        public void AddSelectionLabel(int x, int y, int group)
        {
            itemSelectionLabel[currentSelectionLabelCount] = new System.Windows.Forms.Label();
            itemSelectionLabel[currentSelectionLabelCount].AutoSize = true;
            itemSelectionLabel[currentSelectionLabelCount].Location = new System.Drawing.Point(x, y);
            itemSelectionLabel[currentSelectionLabelCount].Name = "lblSelection" + currentSelectionLabelCount;
            itemGroupBoxes[group].Controls.Add(itemSelectionLabel[currentSelectionLabelCount]);
            currentSelectionLabelCount++;
        }


        #endregion
        private System.Windows.Forms.GroupBox[] itemGroupBoxes = new System.Windows.Forms.GroupBox[3];
        private System.Windows.Forms.PictureBox[] itemPictures = new System.Windows.Forms.PictureBox[GraphicalFoodMenu.GetNumOfItems()];                    // Create an array of photos based off of the number of items in the FoodObject array
        private System.Windows.Forms.RadioButton[] itemRadioButtons = new System.Windows.Forms.RadioButton[GraphicalFoodMenu.GetNumOfItems()];              // Create an array of Radio Buttons based off of the number of items in the FoodObject array
        private System.Windows.Forms.TextBox[] itemQuanitityTextBoxes = new System.Windows.Forms.TextBox[3];
        private System.Windows.Forms.TextBox[] itemPriceTextBoxes = new System.Windows.Forms.TextBox[3];
        private System.Windows.Forms.Label[] itemQuantityLabels = new System.Windows.Forms.Label[3];
        private System.Windows.Forms.Label[] itemPriceLabels = new System.Windows.Forms.Label[3];
        private System.Windows.Forms.Label[] itemSelectionLabel = new System.Windows.Forms.Label[3];
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblFinalText;
    }
}