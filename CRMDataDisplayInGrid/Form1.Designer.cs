namespace CRMDataDisplayInGrid
{
    partial class Frm_DataManagement
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
            this.btnShow = new System.Windows.Forms.Button();
            this.dGV_DataContent = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rB_AttributeName = new System.Windows.Forms.RadioButton();
            this.rB_SQL = new System.Windows.Forms.RadioButton();
            this.rb_Data = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_DataContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(246, 537);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(99, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dGV_DataContent
            // 
            this.dGV_DataContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_DataContent.Location = new System.Drawing.Point(246, 46);
            this.dGV_DataContent.Name = "dGV_DataContent";
            this.dGV_DataContent.Size = new System.Drawing.Size(967, 485);
            this.dGV_DataContent.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 46);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(240, 514);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // rB_AttributeName
            // 
            this.rB_AttributeName.AutoSize = true;
            this.rB_AttributeName.Checked = true;
            this.rB_AttributeName.Location = new System.Drawing.Point(246, 13);
            this.rB_AttributeName.Name = "rB_AttributeName";
            this.rB_AttributeName.Size = new System.Drawing.Size(95, 17);
            this.rB_AttributeName.TabIndex = 4;
            this.rB_AttributeName.TabStop = true;
            this.rB_AttributeName.Text = "Attribute Name";
            this.rB_AttributeName.UseVisualStyleBackColor = true;
            // 
            // rB_SQL
            // 
            this.rB_SQL.AutoSize = true;
            this.rB_SQL.Location = new System.Drawing.Point(458, 13);
            this.rB_SQL.Name = "rB_SQL";
            this.rB_SQL.Size = new System.Drawing.Size(99, 17);
            this.rB_SQL.TabIndex = 5;
            this.rB_SQL.TabStop = true;
            this.rB_SQL.Text = "Run SQL Script";
            this.rB_SQL.UseVisualStyleBackColor = true;
            // 
            // rb_Data
            // 
            this.rb_Data.AutoSize = true;
            this.rb_Data.Location = new System.Drawing.Point(378, 13);
            this.rb_Data.Name = "rb_Data";
            this.rb_Data.Size = new System.Drawing.Size(48, 17);
            this.rb_Data.TabIndex = 6;
            this.rb_Data.TabStop = true;
            this.rb_Data.Text = "Data";
            this.rb_Data.UseVisualStyleBackColor = true;
            // 
            // Frm_DataManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 581);
            this.Controls.Add(this.rb_Data);
            this.Controls.Add(this.rB_SQL);
            this.Controls.Add(this.rB_AttributeName);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dGV_DataContent);
            this.Controls.Add(this.btnShow);
            this.Name = "Frm_DataManagement";
            this.Text = "Data Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_DataContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dGV_DataContent;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.RadioButton rB_AttributeName;
        private System.Windows.Forms.RadioButton rB_SQL;
        private System.Windows.Forms.RadioButton rb_Data;
    }
}

