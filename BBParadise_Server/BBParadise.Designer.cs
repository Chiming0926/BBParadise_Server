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
            this.label1 = new System.Windows.Forms.Label();
            this.match_people = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GameRoom = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(68, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "match people";
            // 
            // match_people
            // 
            this.match_people.AutoSize = true;
            this.match_people.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.match_people.Location = new System.Drawing.Point(208, 131);
            this.match_people.Name = "match_people";
            this.match_people.Size = new System.Drawing.Size(0, 19);
            this.match_people.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(72, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "GameRoom";
            // 
            // GameRoom
            // 
            this.GameRoom.AutoSize = true;
            this.GameRoom.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GameRoom.Location = new System.Drawing.Point(212, 214);
            this.GameRoom.Name = "GameRoom";
            this.GameRoom.Size = new System.Drawing.Size(0, 19);
            this.GameRoom.TabIndex = 4;
            // 
            // BBParadise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 499);
            this.Controls.Add(this.GameRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.match_people);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lable_status);
            this.Name = "BBParadise";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label match_people;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GameRoom;
    }
}

