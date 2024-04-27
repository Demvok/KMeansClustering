namespace KMeansClustering
{
    partial class fData
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
            this.tbM = new System.Windows.Forms.TextBox();
            this.tbN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.tbOut = new System.Windows.Forms.TextBox();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbM
            // 
            this.tbM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbM.Location = new System.Drawing.Point(177, 53);
            this.tbM.Margin = new System.Windows.Forms.Padding(4);
            this.tbM.Name = "tbM";
            this.tbM.Size = new System.Drawing.Size(49, 22);
            this.tbM.TabIndex = 6;
            this.tbM.Text = "1";
            // 
            // tbN
            // 
            this.tbN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbN.Location = new System.Drawing.Point(177, 23);
            this.tbN.Margin = new System.Windows.Forms.Padding(4);
            this.tbN.Name = "tbN";
            this.tbN.Size = new System.Drawing.Size(49, 22);
            this.tbN.TabIndex = 7;
            this.tbN.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Кількість точок M";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Розмірність простору N";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(251, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(537, 432);
            this.dataGridView1.TabIndex = 8;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btnCreateTable);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.tbN);
            this.gb1.Controls.Add(this.tbM);
            this.gb1.Location = new System.Drawing.Point(12, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(233, 126);
            this.gb1.TabIndex = 9;
            this.gb1.TabStop = false;
            this.gb1.Text = "Вручну";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.btnUpload);
            this.gb2.Controls.Add(this.btnOpenFile);
            this.gb2.Controls.Add(this.label3);
            this.gb2.Controls.Add(this.tbFileName);
            this.gb2.Location = new System.Drawing.Point(12, 144);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(233, 91);
            this.gb2.TabIndex = 9;
            this.gb2.TabStop = false;
            this.gb2.Text = "З файлу";
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnCreateTable.Location = new System.Drawing.Point(6, 82);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(220, 35);
            this.btnCreateTable.TabIndex = 8;
            this.btnCreateTable.Text = "Створити таблицю";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            // 
            // tbOut
            // 
            this.tbOut.Location = new System.Drawing.Point(12, 241);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ReadOnly = true;
            this.tbOut.Size = new System.Drawing.Size(233, 197);
            this.tbOut.TabIndex = 10;
            // 
            // tbFileName
            // 
            this.tbFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileName.Location = new System.Drawing.Point(64, 20);
            this.tbFileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(162, 22);
            this.tbFileName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Назва";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "DataFile";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnOpenFile.Location = new System.Drawing.Point(6, 53);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(104, 29);
            this.btnOpenFile.TabIndex = 8;
            this.btnOpenFile.Text = "Відкрити";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnUpload.Location = new System.Drawing.Point(116, 53);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(110, 29);
            this.btnUpload.TabIndex = 8;
            this.btnUpload.Text = "Завантажити";
            this.btnUpload.UseVisualStyleBackColor = true;
            // 
            // fData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 445);
            this.Controls.Add(this.tbOut);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fData";
            this.Text = "fData";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbM;
        private System.Windows.Forms.TextBox tbN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.TextBox tbOut;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnOpenFile;
    }
}