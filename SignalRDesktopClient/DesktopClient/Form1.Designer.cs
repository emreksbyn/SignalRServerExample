namespace DesktopClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.richtxtMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(162, 21);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(204, 27);
            this.txtMessage.TabIndex = 0;
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(162, 218);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(114, 54);
            this.btnConnection.TabIndex = 1;
            this.btnConnection.Text = "Connection";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(383, 21);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(109, 27);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Send";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // richtxtMessages
            // 
            this.richtxtMessages.Location = new System.Drawing.Point(162, 70);
            this.richtxtMessages.Name = "richtxtMessages";
            this.richtxtMessages.Size = new System.Drawing.Size(204, 120);
            this.richtxtMessages.TabIndex = 3;
            this.richtxtMessages.Text = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(525, 361);
            this.Controls.Add(this.richtxtMessages);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.txtMessage);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtMessage;
        private Button btnConnection;
        private Button btnRun;
        private RichTextBox richtxtMessages;
    }
}