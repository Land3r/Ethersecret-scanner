namespace NGordat.Ethersecret.Scanner.WinForm.Components
{
    partial class Stats
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usedAddressesValueLinkLabel = new System.Windows.Forms.LinkLabel();
            this.propabilityPerPageValueLabel = new System.Windows.Forms.Label();
            this.propabilityPerPageLabel = new System.Windows.Forms.Label();
            this.totalAddressesValueLabel = new System.Windows.Forms.Label();
            this.totalAddressesLabel = new System.Windows.Forms.Label();
            this.usedAddressesLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pagesParsedLabel = new System.Windows.Forms.Label();
            this.addressesParsedLabel = new System.Windows.Forms.Label();
            this.keysFoundsLabel = new System.Windows.Forms.Label();
            this.pagesParsedValueLabel = new System.Windows.Forms.Label();
            this.addressesParsedValueLabel = new System.Windows.Forms.Label();
            this.keysFoundsValueLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usedAddressesValueLinkLabel);
            this.groupBox1.Controls.Add(this.propabilityPerPageValueLabel);
            this.groupBox1.Controls.Add(this.propabilityPerPageLabel);
            this.groupBox1.Controls.Add(this.totalAddressesValueLabel);
            this.groupBox1.Controls.Add(this.totalAddressesLabel);
            this.groupBox1.Controls.Add(this.usedAddressesLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Probabilities";
            // 
            // usedAddressesValueLinkLabel
            // 
            this.usedAddressesValueLinkLabel.AutoSize = true;
            this.usedAddressesValueLinkLabel.Location = new System.Drawing.Point(181, 23);
            this.usedAddressesValueLinkLabel.Name = "usedAddressesValueLinkLabel";
            this.usedAddressesValueLinkLabel.Size = new System.Drawing.Size(13, 13);
            this.usedAddressesValueLinkLabel.TabIndex = 6;
            this.usedAddressesValueLinkLabel.TabStop = true;
            this.usedAddressesValueLinkLabel.Text = "0";
            this.usedAddressesValueLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.usedAddressesValueLinkLabel_LinkClicked);
            // 
            // propabilityPerPageValueLabel
            // 
            this.propabilityPerPageValueLabel.Location = new System.Drawing.Point(9, 130);
            this.propabilityPerPageValueLabel.Name = "propabilityPerPageValueLabel";
            this.propabilityPerPageValueLabel.Size = new System.Drawing.Size(244, 17);
            this.propabilityPerPageValueLabel.TabIndex = 5;
            this.propabilityPerPageValueLabel.Text = "0";
            this.propabilityPerPageValueLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // propabilityPerPageLabel
            // 
            this.propabilityPerPageLabel.AutoSize = true;
            this.propabilityPerPageLabel.Location = new System.Drawing.Point(6, 105);
            this.propabilityPerPageLabel.Name = "propabilityPerPageLabel";
            this.propabilityPerPageLabel.Size = new System.Drawing.Size(224, 13);
            this.propabilityPerPageLabel.TabIndex = 4;
            this.propabilityPerPageLabel.Text = "Probability of finding non empty account/page";
            // 
            // totalAddressesValueLabel
            // 
            this.totalAddressesValueLabel.Location = new System.Drawing.Point(6, 72);
            this.totalAddressesValueLabel.Name = "totalAddressesValueLabel";
            this.totalAddressesValueLabel.Size = new System.Drawing.Size(247, 33);
            this.totalAddressesValueLabel.TabIndex = 3;
            this.totalAddressesValueLabel.Text = "115792089237316195423570985008687907853269984665640564039457584007913129639935";
            // 
            // totalAddressesLabel
            // 
            this.totalAddressesLabel.AutoSize = true;
            this.totalAddressesLabel.Location = new System.Drawing.Point(6, 49);
            this.totalAddressesLabel.Name = "totalAddressesLabel";
            this.totalAddressesLabel.Size = new System.Drawing.Size(130, 13);
            this.totalAddressesLabel.TabIndex = 2;
            this.totalAddressesLabel.Text = "Number of total addresses";
            // 
            // usedAddressesLabel
            // 
            this.usedAddressesLabel.AutoSize = true;
            this.usedAddressesLabel.Location = new System.Drawing.Point(6, 23);
            this.usedAddressesLabel.Name = "usedAddressesLabel";
            this.usedAddressesLabel.Size = new System.Drawing.Size(138, 13);
            this.usedAddressesLabel.TabIndex = 0;
            this.usedAddressesLabel.Text = "Number of addresses in use";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.keysFoundsValueLabel);
            this.groupBox2.Controls.Add(this.addressesParsedValueLabel);
            this.groupBox2.Controls.Add(this.pagesParsedValueLabel);
            this.groupBox2.Controls.Add(this.keysFoundsLabel);
            this.groupBox2.Controls.Add(this.addressesParsedLabel);
            this.groupBox2.Controls.Add(this.pagesParsedLabel);
            this.groupBox2.Location = new System.Drawing.Point(13, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 112);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // pagesParsedLabel
            // 
            this.pagesParsedLabel.AutoSize = true;
            this.pagesParsedLabel.Location = new System.Drawing.Point(6, 25);
            this.pagesParsedLabel.Name = "pagesParsedLabel";
            this.pagesParsedLabel.Size = new System.Drawing.Size(123, 13);
            this.pagesParsedLabel.TabIndex = 7;
            this.pagesParsedLabel.Text = "Number of pages parsed";
            // 
            // addressesParsedLabel
            // 
            this.addressesParsedLabel.AutoSize = true;
            this.addressesParsedLabel.Location = new System.Drawing.Point(6, 52);
            this.addressesParsedLabel.Name = "addressesParsedLabel";
            this.addressesParsedLabel.Size = new System.Drawing.Size(142, 13);
            this.addressesParsedLabel.TabIndex = 9;
            this.addressesParsedLabel.Text = "Number of addresses parsed";
            // 
            // keysFoundsLabel
            // 
            this.keysFoundsLabel.AutoSize = true;
            this.keysFoundsLabel.Location = new System.Drawing.Point(6, 80);
            this.keysFoundsLabel.Name = "keysFoundsLabel";
            this.keysFoundsLabel.Size = new System.Drawing.Size(116, 13);
            this.keysFoundsLabel.TabIndex = 10;
            this.keysFoundsLabel.Text = "Number of keys founds";
            // 
            // pagesParsedValueLabel
            // 
            this.pagesParsedValueLabel.AutoSize = true;
            this.pagesParsedValueLabel.Location = new System.Drawing.Point(181, 25);
            this.pagesParsedValueLabel.Name = "pagesParsedValueLabel";
            this.pagesParsedValueLabel.Size = new System.Drawing.Size(13, 13);
            this.pagesParsedValueLabel.TabIndex = 11;
            this.pagesParsedValueLabel.Text = "0";
            // 
            // addressesParsedValueLabel
            // 
            this.addressesParsedValueLabel.AutoSize = true;
            this.addressesParsedValueLabel.Location = new System.Drawing.Point(181, 52);
            this.addressesParsedValueLabel.Name = "addressesParsedValueLabel";
            this.addressesParsedValueLabel.Size = new System.Drawing.Size(13, 13);
            this.addressesParsedValueLabel.TabIndex = 12;
            this.addressesParsedValueLabel.Text = "0";
            // 
            // keysFoundsValueLabel
            // 
            this.keysFoundsValueLabel.AutoSize = true;
            this.keysFoundsValueLabel.Location = new System.Drawing.Point(181, 80);
            this.keysFoundsValueLabel.Name = "keysFoundsValueLabel";
            this.keysFoundsValueLabel.Size = new System.Drawing.Size(13, 13);
            this.keysFoundsValueLabel.TabIndex = 13;
            this.keysFoundsValueLabel.Text = "0";
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 299);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Stats";
            this.Text = "Stats";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label totalAddressesValueLabel;
        private System.Windows.Forms.Label totalAddressesLabel;
        private System.Windows.Forms.Label usedAddressesLabel;
        private System.Windows.Forms.Label propabilityPerPageValueLabel;
        private System.Windows.Forms.Label propabilityPerPageLabel;
        private System.Windows.Forms.LinkLabel usedAddressesValueLinkLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label keysFoundsValueLabel;
        private System.Windows.Forms.Label addressesParsedValueLabel;
        private System.Windows.Forms.Label pagesParsedValueLabel;
        private System.Windows.Forms.Label keysFoundsLabel;
        private System.Windows.Forms.Label addressesParsedLabel;
        private System.Windows.Forms.Label pagesParsedLabel;

    }
}