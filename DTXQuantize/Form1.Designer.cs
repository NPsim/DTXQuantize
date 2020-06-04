namespace DTXQuantize {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.LoadFileTextBox = new System.Windows.Forms.TextBox();
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.ThresholdTextBox = new System.Windows.Forms.TextBox();
            this.ThresholdHint = new System.Windows.Forms.Button();
            this.LoadFileHint = new System.Windows.Forms.Button();
            this.ExportSnippetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SampleLengthTextBox = new System.Windows.Forms.TextBox();
            this.SampleLengthHint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BarLengthLabel = new System.Windows.Forms.Label();
            this.BarLengthTextbox = new System.Windows.Forms.TextBox();
            this.BarLengthHint = new System.Windows.Forms.Button();
            this.BeatOffsetHint = new System.Windows.Forms.Button();
            this.BeatOffsetTextBox = new System.Windows.Forms.TextBox();
            this.BeatOffsetLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BPMRoundHint = new System.Windows.Forms.Button();
            this.BPMRoundTextBox = new System.Windows.Forms.TextBox();
            this.BPMRoundLabel = new System.Windows.Forms.Label();
            this.ConsoleRichBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(12, 12);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(109, 20);
            this.LoadFileButton.TabIndex = 0;
            this.LoadFileButton.Text = "Load Click Track";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // LoadFileTextBox
            // 
            this.LoadFileTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.LoadFileTextBox.Location = new System.Drawing.Point(127, 13);
            this.LoadFileTextBox.Name = "LoadFileTextBox";
            this.LoadFileTextBox.Size = new System.Drawing.Size(175, 20);
            this.LoadFileTextBox.TabIndex = 1;
            this.LoadFileTextBox.TabStop = false;
            this.LoadFileTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ThresholdLabel
            // 
            this.ThresholdLabel.AutoSize = true;
            this.ThresholdLabel.Location = new System.Drawing.Point(18, 41);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(103, 13);
            this.ThresholdLabel.TabIndex = 2;
            this.ThresholdLabel.Text = "Amplitude Threshold";
            // 
            // ThresholdTextBox
            // 
            this.ThresholdTextBox.Location = new System.Drawing.Point(127, 38);
            this.ThresholdTextBox.Name = "ThresholdTextBox";
            this.ThresholdTextBox.Size = new System.Drawing.Size(175, 20);
            this.ThresholdTextBox.TabIndex = 3;
            this.ThresholdTextBox.Text = "0.10";
            this.ThresholdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ThresholdHint
            // 
            this.ThresholdHint.Location = new System.Drawing.Point(308, 37);
            this.ThresholdHint.Name = "ThresholdHint";
            this.ThresholdHint.Size = new System.Drawing.Size(20, 20);
            this.ThresholdHint.TabIndex = 4;
            this.ThresholdHint.Text = "?";
            this.ThresholdHint.UseVisualStyleBackColor = true;
            this.ThresholdHint.Click += new System.EventHandler(this.ThresholdHint_Click);
            // 
            // LoadFileHint
            // 
            this.LoadFileHint.Location = new System.Drawing.Point(308, 12);
            this.LoadFileHint.Name = "LoadFileHint";
            this.LoadFileHint.Size = new System.Drawing.Size(20, 20);
            this.LoadFileHint.TabIndex = 5;
            this.LoadFileHint.Text = "?";
            this.LoadFileHint.UseVisualStyleBackColor = true;
            this.LoadFileHint.Click += new System.EventHandler(this.LoadFileHint_Click);
            // 
            // ExportSnippetButton
            // 
            this.ExportSnippetButton.Location = new System.Drawing.Point(12, 169);
            this.ExportSnippetButton.Name = "ExportSnippetButton";
            this.ExportSnippetButton.Size = new System.Drawing.Size(319, 42);
            this.ExportSnippetButton.TabIndex = 6;
            this.ExportSnippetButton.Text = "Export Blank DTX";
            this.ExportSnippetButton.UseVisualStyleBackColor = true;
            this.ExportSnippetButton.Click += new System.EventHandler(this.ExportSnippetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Click Length";
            // 
            // SampleLengthTextBox
            // 
            this.SampleLengthTextBox.Location = new System.Drawing.Point(127, 142);
            this.SampleLengthTextBox.Name = "SampleLengthTextBox";
            this.SampleLengthTextBox.Size = new System.Drawing.Size(151, 20);
            this.SampleLengthTextBox.TabIndex = 8;
            this.SampleLengthTextBox.Text = "10000";
            this.SampleLengthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SampleLengthHint
            // 
            this.SampleLengthHint.Location = new System.Drawing.Point(308, 141);
            this.SampleLengthHint.Name = "SampleLengthHint";
            this.SampleLengthHint.Size = new System.Drawing.Size(20, 20);
            this.SampleLengthHint.TabIndex = 9;
            this.SampleLengthHint.Text = "?";
            this.SampleLengthHint.UseVisualStyleBackColor = true;
            this.SampleLengthHint.Click += new System.EventHandler(this.SampleLengthHint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "μs";
            // 
            // BarLengthLabel
            // 
            this.BarLengthLabel.AutoSize = true;
            this.BarLengthLabel.Location = new System.Drawing.Point(50, 67);
            this.BarLengthLabel.Name = "BarLengthLabel";
            this.BarLengthLabel.Size = new System.Drawing.Size(71, 13);
            this.BarLengthLabel.TabIndex = 11;
            this.BarLengthLabel.Text = "Beats per Bar";
            // 
            // BarLengthTextbox
            // 
            this.BarLengthTextbox.Location = new System.Drawing.Point(127, 64);
            this.BarLengthTextbox.Name = "BarLengthTextbox";
            this.BarLengthTextbox.Size = new System.Drawing.Size(175, 20);
            this.BarLengthTextbox.TabIndex = 12;
            this.BarLengthTextbox.Text = "4";
            this.BarLengthTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BarLengthHint
            // 
            this.BarLengthHint.Location = new System.Drawing.Point(308, 63);
            this.BarLengthHint.Name = "BarLengthHint";
            this.BarLengthHint.Size = new System.Drawing.Size(20, 20);
            this.BarLengthHint.TabIndex = 13;
            this.BarLengthHint.Text = "?";
            this.BarLengthHint.UseVisualStyleBackColor = true;
            this.BarLengthHint.Click += new System.EventHandler(this.BarLengthHint_Click);
            // 
            // BeatOffsetHint
            // 
            this.BeatOffsetHint.Location = new System.Drawing.Point(308, 115);
            this.BeatOffsetHint.Name = "BeatOffsetHint";
            this.BeatOffsetHint.Size = new System.Drawing.Size(20, 20);
            this.BeatOffsetHint.TabIndex = 16;
            this.BeatOffsetHint.Text = "?";
            this.BeatOffsetHint.UseVisualStyleBackColor = true;
            this.BeatOffsetHint.Click += new System.EventHandler(this.BeatOffsetHint_Click);
            // 
            // BeatOffsetTextBox
            // 
            this.BeatOffsetTextBox.Location = new System.Drawing.Point(127, 116);
            this.BeatOffsetTextBox.Name = "BeatOffsetTextBox";
            this.BeatOffsetTextBox.Size = new System.Drawing.Size(151, 20);
            this.BeatOffsetTextBox.TabIndex = 15;
            this.BeatOffsetTextBox.Text = "-5";
            this.BeatOffsetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BeatOffsetLabel
            // 
            this.BeatOffsetLabel.AutoSize = true;
            this.BeatOffsetLabel.Location = new System.Drawing.Point(61, 120);
            this.BeatOffsetLabel.Name = "BeatOffsetLabel";
            this.BeatOffsetLabel.Size = new System.Drawing.Size(60, 13);
            this.BeatOffsetLabel.TabIndex = 14;
            this.BeatOffsetLabel.Text = "Beat Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "ms";
            // 
            // BPMRoundHint
            // 
            this.BPMRoundHint.Location = new System.Drawing.Point(308, 89);
            this.BPMRoundHint.Name = "BPMRoundHint";
            this.BPMRoundHint.Size = new System.Drawing.Size(20, 20);
            this.BPMRoundHint.TabIndex = 20;
            this.BPMRoundHint.Text = "?";
            this.BPMRoundHint.UseVisualStyleBackColor = true;
            this.BPMRoundHint.Click += new System.EventHandler(this.BPMRoundHint_Click);
            // 
            // BPMRoundTextBox
            // 
            this.BPMRoundTextBox.Location = new System.Drawing.Point(127, 90);
            this.BPMRoundTextBox.Name = "BPMRoundTextBox";
            this.BPMRoundTextBox.Size = new System.Drawing.Size(175, 20);
            this.BPMRoundTextBox.TabIndex = 19;
            this.BPMRoundTextBox.Text = "3";
            this.BPMRoundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BPMRoundLabel
            // 
            this.BPMRoundLabel.AutoSize = true;
            this.BPMRoundLabel.Location = new System.Drawing.Point(56, 93);
            this.BPMRoundLabel.Name = "BPMRoundLabel";
            this.BPMRoundLabel.Size = new System.Drawing.Size(65, 13);
            this.BPMRoundLabel.TabIndex = 18;
            this.BPMRoundLabel.Text = "Round BPM";
            // 
            // ConsoleRichBox
            // 
            this.ConsoleRichBox.BackColor = System.Drawing.SystemColors.Window;
            this.ConsoleRichBox.Location = new System.Drawing.Point(12, 217);
            this.ConsoleRichBox.Name = "ConsoleRichBox";
            this.ConsoleRichBox.ReadOnly = true;
            this.ConsoleRichBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ConsoleRichBox.Size = new System.Drawing.Size(319, 106);
            this.ConsoleRichBox.TabIndex = 21;
            this.ConsoleRichBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 335);
            this.Controls.Add(this.ConsoleRichBox);
            this.Controls.Add(this.BPMRoundHint);
            this.Controls.Add(this.BPMRoundTextBox);
            this.Controls.Add(this.BPMRoundLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BeatOffsetHint);
            this.Controls.Add(this.BeatOffsetTextBox);
            this.Controls.Add(this.BeatOffsetLabel);
            this.Controls.Add(this.BarLengthHint);
            this.Controls.Add(this.BarLengthTextbox);
            this.Controls.Add(this.BarLengthLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SampleLengthHint);
            this.Controls.Add(this.SampleLengthTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportSnippetButton);
            this.Controls.Add(this.LoadFileHint);
            this.Controls.Add(this.ThresholdHint);
            this.Controls.Add(this.ThresholdTextBox);
            this.Controls.Add(this.ThresholdLabel);
            this.Controls.Add(this.LoadFileTextBox);
            this.Controls.Add(this.LoadFileButton);
            this.MaximumSize = new System.Drawing.Size(359, 374);
            this.MinimumSize = new System.Drawing.Size(359, 374);
            this.Name = "Form1";
            this.Text = "DTXQuantize 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.TextBox LoadFileTextBox;
        private System.Windows.Forms.Label ThresholdLabel;
        private System.Windows.Forms.TextBox ThresholdTextBox;
        private System.Windows.Forms.Button ThresholdHint;
        private System.Windows.Forms.Button LoadFileHint;
        private System.Windows.Forms.Button ExportSnippetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SampleLengthTextBox;
        private System.Windows.Forms.Button SampleLengthHint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BarLengthLabel;
        private System.Windows.Forms.TextBox BarLengthTextbox;
        private System.Windows.Forms.Button BarLengthHint;
        private System.Windows.Forms.Button BeatOffsetHint;
        private System.Windows.Forms.TextBox BeatOffsetTextBox;
        private System.Windows.Forms.Label BeatOffsetLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BPMRoundHint;
        private System.Windows.Forms.TextBox BPMRoundTextBox;
        private System.Windows.Forms.Label BPMRoundLabel;
        private System.Windows.Forms.RichTextBox ConsoleRichBox;
    }
}

