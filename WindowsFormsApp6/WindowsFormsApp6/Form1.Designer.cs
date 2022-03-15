
namespace WindowsFormsApp6
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
            this.eatNormal = new System.Windows.Forms.Button();
            this.eatDiet = new System.Windows.Forms.Button();
            this.editMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eatNormal
            // 
            this.eatNormal.Font = new System.Drawing.Font("Noto Sans CJK TC Regular", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.eatNormal.Location = new System.Drawing.Point(12, 67);
            this.eatNormal.Name = "eatNormal";
            this.eatNormal.Size = new System.Drawing.Size(239, 72);
            this.eatNormal.TabIndex = 0;
            this.eatNormal.Text = "等等吃什麼(一般餐)";
            this.eatNormal.UseVisualStyleBackColor = true;
            this.eatNormal.Click += new System.EventHandler(this.eatNormal_Click);
            // 
            // eatDiet
            // 
            this.eatDiet.Font = new System.Drawing.Font("Noto Sans CJK TC Regular", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.eatDiet.Location = new System.Drawing.Point(257, 67);
            this.eatDiet.Name = "eatDiet";
            this.eatDiet.Size = new System.Drawing.Size(239, 72);
            this.eatDiet.TabIndex = 1;
            this.eatDiet.Text = "等等吃什麼(減肥餐)";
            this.eatDiet.UseVisualStyleBackColor = true;
            this.eatDiet.Click += new System.EventHandler(this.eatDiet_Click);
            // 
            // editMenu
            // 
            this.editMenu.Font = new System.Drawing.Font("Noto Sans CJK TC Regular", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.editMenu.Location = new System.Drawing.Point(502, 67);
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(239, 72);
            this.editMenu.TabIndex = 2;
            this.editMenu.Text = "編輯餐點";
            this.editMenu.UseVisualStyleBackColor = true;
            this.editMenu.Click += new System.EventHandler(this.editMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK TC Regular", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "You are what you eat";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(757, 158);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editMenu);
            this.Controls.Add(this.eatDiet);
            this.Controls.Add(this.eatNormal);
            this.Name = "Form1";
            this.Text = "Food";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button eatNormal;
        private System.Windows.Forms.Button eatDiet;
        private System.Windows.Forms.Button editMenu;
        private System.Windows.Forms.Label label1;
    }
}

