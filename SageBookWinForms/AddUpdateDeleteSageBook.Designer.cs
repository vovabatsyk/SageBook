
namespace SageBookWinForms
{
    partial class AddUpdateDeleteSageBook
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxSage = new System.Windows.Forms.GroupBox();
            this.listBoxSage = new System.Windows.Forms.ListBox();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.listBoxBook = new System.Windows.Forms.ListBox();
            this.groupBoxSageBook = new System.Windows.Forms.GroupBox();
            this.listBoxSageBook = new System.Windows.Forms.ListBox();
            this.groupBoxSage.SuspendLayout();
            this.groupBoxBook.SuspendLayout();
            this.groupBoxSageBook.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBoxSage
            // 
            this.groupBoxSage.Controls.Add(this.listBoxSage);
            this.groupBoxSage.Location = new System.Drawing.Point(13, 13);
            this.groupBoxSage.Name = "groupBoxSage";
            this.groupBoxSage.Size = new System.Drawing.Size(237, 186);
            this.groupBoxSage.TabIndex = 2;
            this.groupBoxSage.TabStop = false;
            this.groupBoxSage.Text = "Sage";
            // 
            // listBoxSage
            // 
            this.listBoxSage.Enabled = false;
            this.listBoxSage.FormattingEnabled = true;
            this.listBoxSage.Location = new System.Drawing.Point(18, 19);
            this.listBoxSage.Name = "listBoxSage";
            this.listBoxSage.Size = new System.Drawing.Size(201, 147);
            this.listBoxSage.TabIndex = 0;
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.Controls.Add(this.listBoxBook);
            this.groupBoxBook.Location = new System.Drawing.Point(322, 13);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Size = new System.Drawing.Size(237, 186);
            this.groupBoxBook.TabIndex = 3;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "Book";
            // 
            // listBoxBook
            // 
            this.listBoxBook.Enabled = false;
            this.listBoxBook.FormattingEnabled = true;
            this.listBoxBook.Location = new System.Drawing.Point(20, 19);
            this.listBoxBook.Name = "listBoxBook";
            this.listBoxBook.Size = new System.Drawing.Size(201, 147);
            this.listBoxBook.TabIndex = 1;
            // 
            // groupBoxSageBook
            // 
            this.groupBoxSageBook.Controls.Add(this.listBoxSageBook);
            this.groupBoxSageBook.Location = new System.Drawing.Point(13, 218);
            this.groupBoxSageBook.Name = "groupBoxSageBook";
            this.groupBoxSageBook.Size = new System.Drawing.Size(546, 157);
            this.groupBoxSageBook.TabIndex = 4;
            this.groupBoxSageBook.TabStop = false;
            this.groupBoxSageBook.Text = "SageBook";
            // 
            // listBoxSageBook
            // 
            this.listBoxSageBook.Enabled = false;
            this.listBoxSageBook.FormattingEnabled = true;
            this.listBoxSageBook.Location = new System.Drawing.Point(18, 20);
            this.listBoxSageBook.Name = "listBoxSageBook";
            this.listBoxSageBook.Size = new System.Drawing.Size(512, 121);
            this.listBoxSageBook.TabIndex = 0;
            // 
            // AddUpdateDeleteSageBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 436);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxSageBook);
            this.Controls.Add(this.groupBoxBook);
            this.Controls.Add(this.groupBoxSage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddUpdateDeleteSageBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBoxSage.ResumeLayout(false);
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxSageBook.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBoxSage;
        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.GroupBox groupBoxSageBook;
        private System.Windows.Forms.ListBox listBoxSage;
        private System.Windows.Forms.ListBox listBoxBook;
        private System.Windows.Forms.ListBox listBoxSageBook;
    }
}