namespace TelBook
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.TextBox();
            this.rightBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.nameText = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.numberText = new System.Windows.Forms.TextBox();
            this.telNumberLbl = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.sortAsc = new System.Windows.Forms.Button();
            this.sortDesc = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid.GridColor = System.Drawing.SystemColors.Window;
            this.grid.Location = new System.Drawing.Point(19, 53);
            this.grid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grid.Name = "grid";
            this.grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid.RowTemplate.Height = 25;
            this.grid.Size = new System.Drawing.Size(450, 406);
            this.grid.TabIndex = 0;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.WhiteSmoke;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.search.Location = new System.Drawing.Point(19, 12);
            this.search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.search.Multiline = true;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(451, 33);
            this.search.TabIndex = 1;
            this.search.TextChanged += new System.EventHandler(this.Search);
            // 
            // rightBtn
            // 
            this.rightBtn.BackColor = System.Drawing.Color.Transparent;
            this.rightBtn.Location = new System.Drawing.Point(469, 53);
            this.rightBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(15, 406);
            this.rightBtn.TabIndex = 3;
            this.rightBtn.Text = ">";
            this.rightBtn.UseVisualStyleBackColor = false;
            this.rightBtn.Click += new System.EventHandler(this.RightClick);
            // 
            // leftBtn
            // 
            this.leftBtn.BackColor = System.Drawing.Color.Transparent;
            this.leftBtn.Location = new System.Drawing.Point(4, 53);
            this.leftBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(15, 406);
            this.leftBtn.TabIndex = 4;
            this.leftBtn.Text = "<";
            this.leftBtn.UseVisualStyleBackColor = false;
            this.leftBtn.Click += new System.EventHandler(this.LeftClick);
            // 
            // nameText
            // 
            this.nameText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nameText.Location = new System.Drawing.Point(488, 73);
            this.nameText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameText.Multiline = true;
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(180, 26);
            this.nameText.TabIndex = 5;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(488, 57);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(38, 13);
            this.nameLbl.TabIndex = 6;
            this.nameLbl.Text = "Name:";
            // 
            // numberText
            // 
            this.numberText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numberText.Location = new System.Drawing.Point(488, 118);
            this.numberText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numberText.Multiline = true;
            this.numberText.Name = "numberText";
            this.numberText.Size = new System.Drawing.Size(180, 26);
            this.numberText.TabIndex = 7;
            // 
            // telNumberLbl
            // 
            this.telNumberLbl.AutoSize = true;
            this.telNumberLbl.Location = new System.Drawing.Point(488, 102);
            this.telNumberLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.telNumberLbl.Name = "telNumberLbl";
            this.telNumberLbl.Size = new System.Drawing.Size(47, 13);
            this.telNumberLbl.TabIndex = 8;
            this.telNumberLbl.Text = "Number:";
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.Color.Snow;
            this.createBtn.Location = new System.Drawing.Point(516, 145);
            this.createBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(120, 28);
            this.createBtn.TabIndex = 9;
            this.createBtn.Text = "Create New Number";
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.CreateClick);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Snow;
            this.deleteBtn.Location = new System.Drawing.Point(516, 179);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 28);
            this.deleteBtn.TabIndex = 11;
            this.deleteBtn.Text = "Delete Number";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteClick);
            // 
            // sortAsc
            // 
            this.sortAsc.BackColor = System.Drawing.Color.Snow;
            this.sortAsc.Location = new System.Drawing.Point(518, 30);
            this.sortAsc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sortAsc.Name = "sortAsc";
            this.sortAsc.Size = new System.Drawing.Size(52, 24);
            this.sortAsc.TabIndex = 12;
            this.sortAsc.Text = "ASC";
            this.sortAsc.UseVisualStyleBackColor = false;
            this.sortAsc.Click += new System.EventHandler(this.SortClickAsc);
            // 
            // sortDesc
            // 
            this.sortDesc.BackColor = System.Drawing.Color.Snow;
            this.sortDesc.Location = new System.Drawing.Point(575, 30);
            this.sortDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sortDesc.Name = "sortDesc";
            this.sortDesc.Size = new System.Drawing.Size(52, 24);
            this.sortDesc.TabIndex = 13;
            this.sortDesc.Text = "DESC";
            this.sortDesc.UseVisualStyleBackColor = false;
            this.sortDesc.Click += new System.EventHandler(this.SortClickDesc);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Snow;
            this.saveBtn.Location = new System.Drawing.Point(516, 212);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(120, 28);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save Changes";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.SaveClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 468);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.sortDesc);
            this.Controls.Add(this.sortAsc);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.telNumberLbl);
            this.Controls.Add(this.numberText);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.search);
            this.Controls.Add(this.grid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Main";
            this.Text = "TelBook";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.Button leftBtn;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox numberText;
        private System.Windows.Forms.Label telNumberLbl;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button sortAsc;
        private System.Windows.Forms.Button sortDesc;
        private System.Windows.Forms.Button saveBtn;
    }
}