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
            this.deleteButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.emailText = new System.Windows.Forms.RichTextBox();
            this.emailView = new System.Windows.Forms.DataGridView();
            this.checkBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.senderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.logInPanel.Location = new System.Drawing.Point(12, 509);
            this.logInPanel.Name = "logInPanel";
            this.logInPanel.Size = new System.Drawing.Size(226, 82);
            this.logInPanel.TabIndex = 2;
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(139, 55);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(83, 22);
            this.logInButton.TabIndex = 2;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(3, 3);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(220, 20);
            this.userTextBox.TabIndex = 0;
            this.userTextBox.Text = "s1610650";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(3, 29);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(219, 20);
            this.passTextBox.TabIndex = 1;
            this.passTextBox.Text = "Pass";
            // 
            // EmailPanel
            // 
            this.EmailPanel.Controls.Add(this.deleteButton);
            this.EmailPanel.Controls.Add(this.nextButton);
            this.EmailPanel.Controls.Add(this.previousButton);
            this.EmailPanel.Controls.Add(this.ExitButton);
            this.EmailPanel.Controls.Add(this.emailText);
            this.EmailPanel.Controls.Add(this.emailView);
            this.EmailPanel.Location = new System.Drawing.Point(-2, 2);
            this.EmailPanel.Name = "EmailPanel";
            this.EmailPanel.Size = new System.Drawing.Size(1012, 474);
            this.EmailPanel.TabIndex = 3;
            this.EmailPanel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(325, 444);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(129, 444);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(88, 23);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = "Next page";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(14, 444);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(109, 23);
            this.previousButton.TabIndex = 6;
            this.previousButton.Text = "Previuos page";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(817, 444);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(85, 23);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
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
            // emailView
            // 
            this.emailView.AllowUserToAddRows = false;
            this.emailView.AllowUserToDeleteRows = false;
            this.emailView.AllowUserToResizeColumns = false;
            this.emailView.AllowUserToResizeRows = false;
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
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
    }
}

