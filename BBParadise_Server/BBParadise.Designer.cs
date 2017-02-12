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
            this.SuspendLayout();
            // 
            // lable_status
            // 
            this.lable_status.AutoSize = true;
            this.lable_status.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lable_status.Location = new System.Drawing.Point(68, 46);
            this.lable_status.Name = "lable_status";
            this.lable_status.Size = new System.Drawing.Size(94, 19);
            this.lable_status.TabIndex = 0;
            this.lable_status.Text = "lable_status";
            // 
            // match_people
            // 
            this.match_people.AutoSize = true;
            this.match_people.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.match_people.Location = new System.Drawing.Point(68, 106);
            this.match_people.Name = "match_people";
            this.match_people.Size = new System.Drawing.Size(0, 19);
            this.match_people.TabIndex = 2;
            // 
            // GameRoom
            // 
            this.GameRoom.AutoSize = true;
            this.GameRoom.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GameRoom.Location = new System.Drawing.Point(72, 189);
            this.GameRoom.Name = "GameRoom";
            this.GameRoom.Size = new System.Drawing.Size(0, 19);
            this.GameRoom.TabIndex = 4;
            // 
            // Online_People
            // 
            this.Online_People.AutoSize = true;
            this.Online_People.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Online_People.Location = new System.Drawing.Point(68, 280);
            this.Online_People.Name = "Online_People";
            this.Online_People.Size = new System.Drawing.Size(112, 19);
            this.Online_People.TabIndex = 5;
            this.Online_People.Text = "Online People";
            // 
            // BBParadise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 499);
            this.Controls.Add(this.Online_People);
            this.Controls.Add(this.GameRoom);
            this.Controls.Add(this.match_people);
            this.Controls.Add(this.lable_status);
            this.Location = new System.Drawing.Point(20, 20);
            this.Name = "BBParadise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_status;
        private System.Windows.Forms.Label match_people;
        private System.Windows.Forms.Label GameRoom;
        private System.Windows.Forms.Label Online_People;
    }
}

