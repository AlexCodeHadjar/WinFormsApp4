namespace WinFormsApp4
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            yahctBindingSource = new BindingSource(components);
            yahctBindingSource2 = new BindingSource(components);
            yahctBindingSource1 = new BindingSource(components);
            label1 = new Label();
            button1 = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            numberSeatsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            colourDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
            modelDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
            materialDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
            dopEquipmentDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
            machtaDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
            StatusWork = new DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yahctBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yahctBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yahctBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, numberSeatsDataGridViewTextBoxColumn, colourDataGridViewTextBoxColumn, modelDataGridViewTextBoxColumn, materialDataGridViewTextBoxColumn, dopEquipmentDataGridViewTextBoxColumn, machtaDataGridViewTextBoxColumn, StatusWork });
            dataGridView1.DataSource = yahctBindingSource;
            dataGridView1.Location = new Point(70, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1127, 475);
            dataGridView1.TabIndex = 0;
            // 
            // yahctBindingSource
            // 
            yahctBindingSource.DataSource = typeof(Models.Yahct);
            // 
            // yahctBindingSource2
            // 
            yahctBindingSource2.DataSource = typeof(Models.Yahct);
            // 
            // yahctBindingSource1
            // 
            yahctBindingSource1.DataSource = typeof(Models.Yahct);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(532, -9);
            label1.Name = "label1";
            label1.Size = new Size(150, 50);
            label1.TabIndex = 1;
            label1.Text = "Товары";
            // 
            // button1
            // 
            button1.Location = new Point(1055, 525);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Оформить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            idDataGridViewTextBoxColumn.Width = 51;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // numberSeatsDataGridViewTextBoxColumn
            // 
            numberSeatsDataGridViewTextBoxColumn.DataPropertyName = "NumberSeats";
            numberSeatsDataGridViewTextBoxColumn.HeaderText = "NumberSeats";
            numberSeatsDataGridViewTextBoxColumn.MinimumWidth = 6;
            numberSeatsDataGridViewTextBoxColumn.Name = "numberSeatsDataGridViewTextBoxColumn";
            numberSeatsDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            numberSeatsDataGridViewTextBoxColumn.Width = 125;
            // 
            // colourDataGridViewTextBoxColumn
            // 
            colourDataGridViewTextBoxColumn.DataPropertyName = "Colour";
            colourDataGridViewTextBoxColumn.HeaderText = "Colour";
            colourDataGridViewTextBoxColumn.Items.AddRange(new object[] { "Коричневый", "Белый", "Черный", "Зеленый", "Красный", "Синий" });
            colourDataGridViewTextBoxColumn.MinimumWidth = 6;
            colourDataGridViewTextBoxColumn.Name = "colourDataGridViewTextBoxColumn";
            colourDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            colourDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            colourDataGridViewTextBoxColumn.Width = 125;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            modelDataGridViewTextBoxColumn.HeaderText = "Model";
            modelDataGridViewTextBoxColumn.Items.AddRange(new object[] { "Стандартные модели", "Модели эконом класса", "Модели класса Люкс", "Стандартная комплектация" });
            modelDataGridViewTextBoxColumn.MinimumWidth = 6;
            modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            modelDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            modelDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            modelDataGridViewTextBoxColumn.Width = 125;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            materialDataGridViewTextBoxColumn.HeaderText = "Material";
            materialDataGridViewTextBoxColumn.Items.AddRange(new object[] { "Дуб", "Береза", "Ель", "Сосна", "Лиственница" });
            materialDataGridViewTextBoxColumn.MinimumWidth = 6;
            materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            materialDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            materialDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            materialDataGridViewTextBoxColumn.Width = 125;
            // 
            // dopEquipmentDataGridViewTextBoxColumn
            // 
            dopEquipmentDataGridViewTextBoxColumn.DataPropertyName = "DopEquipment";
            dopEquipmentDataGridViewTextBoxColumn.HeaderText = "DopEquipment";
            dopEquipmentDataGridViewTextBoxColumn.Items.AddRange(new object[] { "Черпак", "Весла", "Навес", "Зонтик", "Холодильник", "Спасательный жилет" });
            dopEquipmentDataGridViewTextBoxColumn.MinimumWidth = 6;
            dopEquipmentDataGridViewTextBoxColumn.Name = "dopEquipmentDataGridViewTextBoxColumn";
            dopEquipmentDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            dopEquipmentDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            dopEquipmentDataGridViewTextBoxColumn.Width = 125;
            // 
            // machtaDataGridViewTextBoxColumn
            // 
            machtaDataGridViewTextBoxColumn.DataPropertyName = "Machta";
            machtaDataGridViewTextBoxColumn.HeaderText = "Machta";
            machtaDataGridViewTextBoxColumn.Items.AddRange(new object[] { "Есть", "Нету" });
            machtaDataGridViewTextBoxColumn.MinimumWidth = 6;
            machtaDataGridViewTextBoxColumn.Name = "machtaDataGridViewTextBoxColumn";
            machtaDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            machtaDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            machtaDataGridViewTextBoxColumn.Width = 125;
            // 
            // StatusWork
            // 
            StatusWork.DataPropertyName = "StatusWork";
            StatusWork.HeaderText = "StatusWork";
            StatusWork.Items.AddRange(new object[] { "Работы не начаты", "Начато производство", "25% готовности", "50% готовности", "75% готовности", "отделка лодки", "Готово" });
            StatusWork.MinimumWidth = 6;
            StatusWork.Name = "StatusWork";
            StatusWork.Resizable = DataGridViewTriState.True;
            StatusWork.SortMode = DataGridViewColumnSortMode.Automatic;
            StatusWork.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 556);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)yahctBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)yahctBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)yahctBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private BindingSource yahctBindingSource;
        private BindingSource yahctBindingSource1;
        private BindingSource yahctBindingSource2;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberSeatsDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn colourDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn modelDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn materialDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn dopEquipmentDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn machtaDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn StatusWork;
    }
}
