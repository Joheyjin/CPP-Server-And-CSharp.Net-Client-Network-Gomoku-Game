﻿namespace Clientt
{
    partial class MultPlayForm
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
            this.boardPicture = new System.Windows.Forms.PictureBox();
            this.roomtextBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.boardPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // boardPicture
            // 
            this.boardPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            this.boardPicture.Location = new System.Drawing.Point(20, 20);
            this.boardPicture.Name = "boardPicture";
            this.boardPicture.Size = new System.Drawing.Size(500, 500);
            this.boardPicture.TabIndex = 0;
            this.boardPicture.TabStop = false;
            this.boardPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.boardPicture_Paint);
            this.boardPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boardPicture_MouseDown);
            // 
            // roomtextBox
            // 
            this.roomtextBox.Location = new System.Drawing.Point(560, 20);
            this.roomtextBox.Name = "roomtextBox";
            this.roomtextBox.Size = new System.Drawing.Size(122, 21);
            this.roomtextBox.TabIndex = 1;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(730, 20);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(100, 40);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "접속하기";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(647, 93);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(100, 40);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "게임시작";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(558, 154);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(272, 15);
            this.status.TabIndex = 4;
            this.status.Text = "방을 입력하여 접속해주세요.";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MultPlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 541);
            this.Controls.Add(this.status);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.roomtextBox);
            this.Controls.Add(this.boardPicture);
            this.Name = "MultPlayForm";
            this.Text = "MultPlayForm";
            ((System.ComponentModel.ISupportInitialize)(this.boardPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boardPicture;
        private System.Windows.Forms.TextBox roomtextBox;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label status;
    }
}