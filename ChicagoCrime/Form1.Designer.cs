namespace ChicagoCrime
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
            this.cmdByYear = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.cmdArrestPct = new System.Windows.Forms.Button();
            this.cmdByCrime = new System.Windows.Forms.Button();
            this.crimeCodeTextBox = new System.Windows.Forms.TextBox();
            this.cmdByArea = new System.Windows.Forms.Button();
            this.byAreaTextBox = new System.Windows.Forms.TextBox();
            this.cmdChicago = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdByYear
            // 
            this.cmdByYear.Location = new System.Drawing.Point(12, 12);
            this.cmdByYear.Name = "cmdByYear";
            this.cmdByYear.Size = new System.Drawing.Size(95, 62);
            this.cmdByYear.TabIndex = 0;
            this.cmdByYear.Text = "By Year";
            this.cmdByYear.UseVisualStyleBackColor = true;
            this.cmdByYear.Click += new System.EventHandler(this.cmdByYear_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.BackColor = System.Drawing.Color.White;
            this.graphPanel.Location = new System.Drawing.Point(123, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(769, 454);
            this.graphPanel.TabIndex = 1;
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilename.Location = new System.Drawing.Point(123, 474);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(769, 30);
            this.txtFilename.TabIndex = 2;
            this.txtFilename.Text = "Crimes.csv";
            // 
            // cmdArrestPct
            // 
            this.cmdArrestPct.Location = new System.Drawing.Point(13, 90);
            this.cmdArrestPct.Name = "cmdArrestPct";
            this.cmdArrestPct.Size = new System.Drawing.Size(94, 65);
            this.cmdArrestPct.TabIndex = 3;
            this.cmdArrestPct.Text = "Arrest %";
            this.cmdArrestPct.UseVisualStyleBackColor = true;
            this.cmdArrestPct.Click += new System.EventHandler(this.cmdArrestPct_Click);
            // 
            // cmdByCrime
            // 
            this.cmdByCrime.Location = new System.Drawing.Point(13, 172);
            this.cmdByCrime.Name = "cmdByCrime";
            this.cmdByCrime.Size = new System.Drawing.Size(94, 65);
            this.cmdByCrime.TabIndex = 4;
            this.cmdByCrime.Text = "By Crime";
            this.cmdByCrime.UseVisualStyleBackColor = true;
            this.cmdByCrime.Click += new System.EventHandler(this.cmdByCrime_Click);
            // 
            // crimeCodeTextBox
            // 
            this.crimeCodeTextBox.Location = new System.Drawing.Point(13, 243);
            this.crimeCodeTextBox.Name = "crimeCodeTextBox";
            this.crimeCodeTextBox.Size = new System.Drawing.Size(94, 34);
            this.crimeCodeTextBox.TabIndex = 5;
            // 
            // cmdByArea
            // 
            this.cmdByArea.Location = new System.Drawing.Point(12, 297);
            this.cmdByArea.Name = "cmdByArea";
            this.cmdByArea.Size = new System.Drawing.Size(94, 51);
            this.cmdByArea.TabIndex = 6;
            this.cmdByArea.Text = "By Area";
            this.cmdByArea.UseVisualStyleBackColor = true;
            this.cmdByArea.Click += new System.EventHandler(this.cmdByArea_Click);
            // 
            // byAreaTextBox
            // 
            this.byAreaTextBox.Location = new System.Drawing.Point(12, 354);
            this.byAreaTextBox.Name = "byAreaTextBox";
            this.byAreaTextBox.Size = new System.Drawing.Size(94, 34);
            this.byAreaTextBox.TabIndex = 7;
            // 
            // button1
            // 
            this.cmdChicago.Location = new System.Drawing.Point(13, 418);
            this.cmdChicago.Name = "cmdChicago";
            this.cmdChicago.Size = new System.Drawing.Size(94, 78);
            this.cmdChicago.TabIndex = 8;
            this.cmdChicago.Text = "Chicago";
            this.cmdChicago.UseVisualStyleBackColor = true;
            this.cmdChicago.Click += new System.EventHandler(this.cmdChicago_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 508);
            this.Controls.Add(this.cmdChicago);
            this.Controls.Add(this.byAreaTextBox);
            this.Controls.Add(this.cmdByArea);
            this.Controls.Add(this.crimeCodeTextBox);
            this.Controls.Add(this.cmdByCrime);
            this.Controls.Add(this.cmdArrestPct);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.cmdByYear);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chicago Crime Analysis";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdByYear;
    private System.Windows.Forms.Panel graphPanel;
    private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button cmdArrestPct;
        private System.Windows.Forms.Button cmdByCrime;
        private System.Windows.Forms.TextBox crimeCodeTextBox;
        private System.Windows.Forms.Button cmdByArea;
        private System.Windows.Forms.TextBox byAreaTextBox;
        private System.Windows.Forms.Button cmdChicago;
    }
}

