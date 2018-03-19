namespace POP3WinForms
{
    partial class MainForm
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
            this.logInPanel = new System.Windows.Forms.Panel();
            this.logInButton = new System.Windows.Forms.Button();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.EmailPanel = new System.Windows.Forms.Panel();
            this.emailView = new System.Windows.Forms.DataGridView();
            this.checkBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.senderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailText = new System.Windows.Forms.RichTextBox();
            this.logInPanel.SuspendLayout();
            this.EmailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailView)).BeginInit();
            this.SuspendLayout();
            // 
            // logInPanel
            // 
            this.logInPanel.Controls.Add(this.logInButton);
            this.logInPanel.Controls.Add(this.userTextBox);
            this.logInPanel.Controls.Add(this.passTextBox);
            this.logInPanel.Location = new System.Drawing.Point(51, 446);
            this.logInPanel.Name = "logInPanel";
            this.logInPanel.Size = new System.Drawing.Size(301, 147);
            this.logInPanel.TabIndex = 2;
            this.logInPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LogInPanel_Paint);
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(166, 107);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(83, 22);
            this.logInButton.TabIndex = 2;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(31, 27);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(220, 20);
            this.userTextBox.TabIndex = 0;
            this.userTextBox.Text = "User";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(31, 67);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(219, 20);
            this.passTextBox.TabIndex = 1;
            this.passTextBox.Text = "Pass";
            // 
            // EmailPanel
            // 
            this.EmailPanel.Controls.Add(this.emailText);
            this.EmailPanel.Controls.Add(this.emailView);
            this.EmailPanel.Location = new System.Drawing.Point(-2, 2);
            this.EmailPanel.Name = "EmailPanel";
            this.EmailPanel.Size = new System.Drawing.Size(1012, 438);
            this.EmailPanel.TabIndex = 3;
            this.EmailPanel.Visible = false;
            // 
            // emailView
            // 
            this.emailView.AllowUserToAddRows = false;
            this.emailView.AllowUserToDeleteRows = false;
            this.emailView.AllowUserToResizeColumns = false;
            this.emailView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emailView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkBoxColumn,
            this.senderColumn});
            this.emailView.Location = new System.Drawing.Point(0, -2);
            this.emailView.MultiSelect = false;
            this.emailView.Name = "emailView";
            this.emailView.RowHeadersVisible = false;
            this.emailView.RowHeadersWidth = 30;
            this.emailView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.emailView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.emailView.Size = new System.Drawing.Size(439, 440);
            this.emailView.TabIndex = 0;
            // 
            // checkBoxColumn
            // 
            this.checkBoxColumn.HeaderText = "";
            this.checkBoxColumn.MinimumWidth = 10;
            this.checkBoxColumn.Name = "checkBoxColumn";
            this.checkBoxColumn.Width = 30;
            // 
            // senderColumn
            // 
            this.senderColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.senderColumn.FillWeight = 5F;
            this.senderColumn.HeaderText = "Sender";
            this.senderColumn.MaxInputLength = 30;
            this.senderColumn.Name = "senderColumn";
            this.senderColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(445, 2);
            this.emailText.Name = "emailText";
            this.emailText.ReadOnly = true;
            this.emailText.Size = new System.Drawing.Size(560, 436);
            this.emailText.TabIndex = 4;
            this.emailText.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 603);
            this.Controls.Add(this.logInPanel);
            this.Controls.Add(this.EmailPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.logInPanel.ResumeLayout(false);
            this.logInPanel.PerformLayout();
            this.EmailPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emailView)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel logInPanel;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Panel EmailPanel;
        private System.Windows.Forms.DataGridView emailView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senderColumn;
        private System.Windows.Forms.RichTextBox emailText;
    }
}

