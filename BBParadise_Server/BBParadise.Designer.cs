namespace BBParadise_Server
{
    partial class BBParadise
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lable_status = new System.Windows.Forms.Label();
            this.match_people = new System.Windows.Forms.Label();
            this.GameRoom = new System.Windows.Forms.Label();
            this.Online_People = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lable_status
            // 
            this.lable_status.AutoSize = true;
            this.lable_status.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lable_status.Location = new System.Drawing.Point(14, 29);
            this.lable_status.Name = "lable_status";
            this.lable_status.Size = new System.Drawing.Size(94, 19);
            this.lable_status.TabIndex = 0;
            this.lable_status.Text = "lable_status";
            // 
            // match_people
            // 
            this.match_people.AutoSize = true;
            this.match_people.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.match_people.Location = new System.Drawing.Point(14, 131);
            this.match_people.Name = "match_people";
            this.match_people.Size = new System.Drawing.Size(0, 19);
            this.match_people.TabIndex = 2;
            // 
            // GameRoom
            // 
            this.GameRoom.AutoSize = true;
            this.GameRoom.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GameRoom.Location = new System.Drawing.Point(14, 174);
            this.GameRoom.Name = "GameRoom";
            this.GameRoom.Size = new System.Drawing.Size(0, 19);
            this.GameRoom.TabIndex = 4;
            // 
            // Online_People
            // 
            this.Online_People.AutoSize = true;
            this.Online_People.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Online_People.Location = new System.Drawing.Point(14, 81);
            this.Online_People.Name = "Online_People";
            this.Online_People.Size = new System.Drawing.Size(112, 19);
            this.Online_People.TabIndex = 5;
            this.Online_People.Text = "Online People";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lable_status);
            this.groupBox1.Controls.Add(this.GameRoom);
            this.groupBox1.Controls.Add(this.Online_People);
            this.groupBox1.Controls.Add(this.match_people);
            this.groupBox1.Location = new System.Drawing.Point(26, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 226);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Status";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BBParadise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 499);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(20, 20);
            this.Name = "BBParadise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lable_status;
        private System.Windows.Forms.Label match_people;
        private System.Windows.Forms.Label GameRoom;
        private System.Windows.Forms.Label Online_People;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

