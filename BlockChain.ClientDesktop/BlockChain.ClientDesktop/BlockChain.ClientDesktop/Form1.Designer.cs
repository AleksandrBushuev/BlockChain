
namespace BlockChain.ClientDesktop
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
            this.btnAuth = new System.Windows.Forms.Button();
            this.textBoxLogger = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gridDataChain = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textContent = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataChain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(412, 86);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(221, 34);
            this.btnAuth.TabIndex = 0;
            this.btnAuth.Text = "Авторизоваться";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // textBoxLogger
            // 
            this.textBoxLogger.Location = new System.Drawing.Point(12, 854);
            this.textBoxLogger.Multiline = true;
            this.textBoxLogger.Name = "textBoxLogger";
            this.textBoxLogger.ReadOnly = true;
            this.textBoxLogger.Size = new System.Drawing.Size(1874, 110);
            this.textBoxLogger.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(540, 31);
            this.txtPassword.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(93, 11);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(540, 31);
            this.txtAddress.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 11);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 25);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Адрес";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 48);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 25);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Пароль";
            // 
            // gridDataChain
            // 
            this.gridDataChain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDataChain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.DateRecord,
            this.UserId,
            this.Content,
            this.Hash,
            this.PrevHash});
            this.gridDataChain.Location = new System.Drawing.Point(12, 126);
            this.gridDataChain.Name = "gridDataChain";
            this.gridDataChain.RowHeadersWidth = 62;
            this.gridDataChain.RowTemplate.Height = 33;
            this.gridDataChain.Size = new System.Drawing.Size(1874, 707);
            this.gridDataChain.TabIndex = 7;
            // 
            // Number
            // 
            this.Number.HeaderText = "Номер";
            this.Number.MinimumWidth = 50;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 80;
            // 
            // DateRecord
            // 
            this.DateRecord.HeaderText = "Дата";
            this.DateRecord.MinimumWidth = 8;
            this.DateRecord.Name = "DateRecord";
            this.DateRecord.ReadOnly = true;
            this.DateRecord.Width = 150;
            // 
            // UserId
            // 
            this.UserId.HeaderText = "Пользователь";
            this.UserId.MinimumWidth = 8;
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Width = 300;
            // 
            // Content
            // 
            this.Content.HeaderText = "Данные";
            this.Content.MinimumWidth = 8;
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.Width = 400;
            // 
            // Hash
            // 
            this.Hash.HeaderText = "Хэш";
            this.Hash.MinimumWidth = 8;
            this.Hash.Name = "Hash";
            this.Hash.ReadOnly = true;
            this.Hash.Width = 450;
            // 
            // PrevHash
            // 
            this.PrevHash.HeaderText = "Хэш предыдущего блока";
            this.PrevHash.MinimumWidth = 8;
            this.PrevHash.Name = "PrevHash";
            this.PrevHash.ReadOnly = true;
            this.PrevHash.Width = 450;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(674, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Данные";
            // 
            // textContent
            // 
            this.textContent.Location = new System.Drawing.Point(802, 48);
            this.textContent.Name = "textContent";
            this.textContent.Size = new System.Drawing.Size(221, 31);
            this.textContent.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(802, 86);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(221, 34);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(674, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Пользователь";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(802, 11);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(0, 25);
            this.lbUser.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridDataChain);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.textBoxLogger);
            this.Controls.Add(this.btnAuth);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridDataChain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.TextBox textBoxLogger;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.DataGridView gridDataChain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textContent;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUser;
    }
}

