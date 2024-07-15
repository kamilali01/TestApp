namespace WindowsFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.NumericUpDown numericUpDownFrequency;
        private System.Windows.Forms.ListBox listBoxTrades;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.numericUpDownFrequency = new System.Windows.Forms.NumericUpDown();
            this.listBoxTrades = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequency)).BeginInit();
            this.SuspendLayout();

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(12, 38);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // textBoxPath
            this.textBoxPath.Location = new System.Drawing.Point(12, 12);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(300, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Text = "C:\\path\\to\\input\\directory";

            // numericUpDownFrequency
            this.numericUpDownFrequency.Location = new System.Drawing.Point(93, 39);
            this.numericUpDownFrequency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownFrequency.Name = "numericUpDownFrequency";
            this.numericUpDownFrequency.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownFrequency.TabIndex = 2;
            this.numericUpDownFrequency.Value = new decimal(new int[] { 5, 0, 0, 0 });

            // listBoxTrades
            this.listBoxTrades.FormattingEnabled = true;
            this.listBoxTrades.Location = new System.Drawing.Point(12, 67);
            this.listBoxTrades.Name = "listBoxTrades";
            this.listBoxTrades.Size = new System.Drawing.Size(600, 368);
            this.listBoxTrades.TabIndex = 3;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.listBoxTrades);
            this.Controls.Add(this.numericUpDownFrequency);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "Trade Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

