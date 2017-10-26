namespace ProjectTeam3
{
    partial class RealEstateTransactionsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.upperDataGridView = new System.Windows.Forms.DataGridView();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bedrooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bathrooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surfaceArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.houseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperGridDataViewLabel = new System.Windows.Forms.Label();
            this.countTextLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.averagePriceTextLabel = new System.Windows.Forms.Label();
            this.averagePriceLabel = new System.Windows.Forms.Label();
            this.filtersLabel = new System.Windows.Forms.Label();
            this.resetFiltersButton = new System.Windows.Forms.Button();
            this.citiesListView = new System.Windows.Forms.ListView();
            this.columnCities = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bedroomsListView = new System.Windows.Forms.ListView();
            this.columnBedrooms = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bathsListView = new System.Windows.Forms.ListView();
            this.columnBaths = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.houseTypesListView = new System.Windows.Forms.ListView();
            this.columnHouseType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceLabel = new System.Windows.Forms.Label();
            this.minPriceLabel = new System.Windows.Forms.Label();
            this.maxPriceLabel = new System.Windows.Forms.Label();
            this.minPriceTextBox = new System.Windows.Forms.TextBox();
            this.maxPriceTextBox = new System.Windows.Forms.TextBox();
            this.priceCheckBox = new System.Windows.Forms.CheckBox();
            this.surfaceAreaLabel = new System.Windows.Forms.Label();
            this.surfaceCheckBox = new System.Windows.Forms.CheckBox();
            this.maxSurfaceTextBox = new System.Windows.Forms.TextBox();
            this.minSurfaceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.filtersGroupBox = new System.Windows.Forms.GroupBox();
            this.upperGridViewGroupBox = new System.Windows.Forms.GroupBox();
            this.priceRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.surfaceAreaGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectedTransactionsLabel = new System.Windows.Forms.Label();
            this.bottomDataGridView = new System.Windows.Forms.DataGridView();
            this.selectedAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedBedrooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedBathrooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedSurfaceArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedHouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedTransactionsCountTextLabel = new System.Windows.Forms.Label();
            this.selectedAverageCountLabel = new System.Windows.Forms.Label();
            this.averageTransactionsTextLabel = new System.Windows.Forms.Label();
            this.averageSelectedPriceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.upperDataGridView)).BeginInit();
            this.filtersGroupBox.SuspendLayout();
            this.upperGridViewGroupBox.SuspendLayout();
            this.priceRangeGroupBox.SuspendLayout();
            this.surfaceAreaGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // upperDataGridView
            // 
            this.upperDataGridView.AllowUserToAddRows = false;
            this.upperDataGridView.AllowUserToDeleteRows = false;
            this.upperDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.upperDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.upperDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.upperDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.address,
            this.city,
            this.bedrooms,
            this.bathrooms,
            this.surfaceArea,
            this.houseType,
            this.price});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.upperDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.upperDataGridView.Location = new System.Drawing.Point(16, 47);
            this.upperDataGridView.Name = "upperDataGridView";
            this.upperDataGridView.ReadOnly = true;
            this.upperDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.upperDataGridView.RowHeadersWidth = 30;
            this.upperDataGridView.Size = new System.Drawing.Size(720, 123);
            this.upperDataGridView.TabIndex = 0;
            // 
            // address
            // 
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // city
            // 
            this.city.Name = "city";
            this.city.ReadOnly = true;
            // 
            // bedrooms
            // 
            this.bedrooms.Name = "bedrooms";
            this.bedrooms.ReadOnly = true;
            // 
            // bathrooms
            // 
            this.bathrooms.Name = "bathrooms";
            this.bathrooms.ReadOnly = true;
            // 
            // surfaceArea
            // 
            this.surfaceArea.Name = "surfaceArea";
            this.surfaceArea.ReadOnly = true;
            // 
            // houseType
            // 
            this.houseType.Name = "houseType";
            this.houseType.ReadOnly = true;
            // 
            // price
            // 
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // upperGridDataViewLabel
            // 
            this.upperGridDataViewLabel.AutoSize = true;
            this.upperGridDataViewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upperGridDataViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperGridDataViewLabel.Location = new System.Drawing.Point(16, 16);
            this.upperGridDataViewLabel.Name = "upperGridDataViewLabel";
            this.upperGridDataViewLabel.Size = new System.Drawing.Size(100, 15);
            this.upperGridDataViewLabel.TabIndex = 1;
            this.upperGridDataViewLabel.Text = "All Transactions";
            // 
            // countTextLabel
            // 
            this.countTextLabel.AutoSize = true;
            this.countTextLabel.Location = new System.Drawing.Point(72, 199);
            this.countTextLabel.Name = "countTextLabel";
            this.countTextLabel.Size = new System.Drawing.Size(44, 13);
            this.countTextLabel.TabIndex = 2;
            this.countTextLabel.Text = "Count =";
            // 
            // countLabel
            // 
            this.countLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.countLabel.Location = new System.Drawing.Point(122, 199);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(50, 16);
            this.countLabel.TabIndex = 3;
            // 
            // averagePriceTextLabel
            // 
            this.averagePriceTextLabel.AutoSize = true;
            this.averagePriceTextLabel.Location = new System.Drawing.Point(292, 200);
            this.averagePriceTextLabel.Name = "averagePriceTextLabel";
            this.averagePriceTextLabel.Size = new System.Drawing.Size(83, 13);
            this.averagePriceTextLabel.TabIndex = 4;
            this.averagePriceTextLabel.Text = "Average Price =";
            // 
            // averagePriceLabel
            // 
            this.averagePriceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averagePriceLabel.Location = new System.Drawing.Point(381, 200);
            this.averagePriceLabel.Name = "averagePriceLabel";
            this.averagePriceLabel.Size = new System.Drawing.Size(100, 16);
            this.averagePriceLabel.TabIndex = 5;
            // 
            // filtersLabel
            // 
            this.filtersLabel.AutoSize = true;
            this.filtersLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filtersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtersLabel.Location = new System.Drawing.Point(16, 25);
            this.filtersLabel.Name = "filtersLabel";
            this.filtersLabel.Size = new System.Drawing.Size(43, 15);
            this.filtersLabel.TabIndex = 6;
            this.filtersLabel.Text = "Filters";
            // 
            // resetFiltersButton
            // 
            this.resetFiltersButton.Location = new System.Drawing.Point(210, 20);
            this.resetFiltersButton.Name = "resetFiltersButton";
            this.resetFiltersButton.Size = new System.Drawing.Size(75, 23);
            this.resetFiltersButton.TabIndex = 7;
            this.resetFiltersButton.Text = "Reset Filters";
            this.resetFiltersButton.UseVisualStyleBackColor = true;
            this.resetFiltersButton.Click += new System.EventHandler(this.resetFiltersButton_Click);
            // 
            // citiesListView
            // 
            this.citiesListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.citiesListView.CheckBoxes = true;
            this.citiesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnCities});
            this.citiesListView.Location = new System.Drawing.Point(16, 62);
            this.citiesListView.Name = "citiesListView";
            this.citiesListView.Size = new System.Drawing.Size(180, 100);
            this.citiesListView.TabIndex = 8;
            this.citiesListView.UseCompatibleStateImageBehavior = false;
            this.citiesListView.View = System.Windows.Forms.View.List;
            // 
            // columnCities
            // 
            this.columnCities.Text = "Cities";
            this.columnCities.Width = 120;
            // 
            // bedroomsListView
            // 
            this.bedroomsListView.CheckBoxes = true;
            this.bedroomsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnBedrooms});
            this.bedroomsListView.Location = new System.Drawing.Point(246, 62);
            this.bedroomsListView.Name = "bedroomsListView";
            this.bedroomsListView.Size = new System.Drawing.Size(110, 100);
            this.bedroomsListView.TabIndex = 9;
            this.bedroomsListView.UseCompatibleStateImageBehavior = false;
            this.bedroomsListView.View = System.Windows.Forms.View.List;
            // 
            // columnBedrooms
            // 
            this.columnBedrooms.Text = "Bedrooms";
            this.columnBedrooms.Width = 80;
            // 
            // bathsListView
            // 
            this.bathsListView.CheckBoxes = true;
            this.bathsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnBaths});
            this.bathsListView.Location = new System.Drawing.Point(410, 62);
            this.bathsListView.Name = "bathsListView";
            this.bathsListView.Size = new System.Drawing.Size(110, 100);
            this.bathsListView.TabIndex = 10;
            this.bathsListView.UseCompatibleStateImageBehavior = false;
            this.bathsListView.View = System.Windows.Forms.View.List;
            // 
            // columnBaths
            // 
            this.columnBaths.Text = "Baths";
            this.columnBaths.Width = 80;
            // 
            // houseTypesListView
            // 
            this.houseTypesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHouseType});
            this.houseTypesListView.Location = new System.Drawing.Point(570, 62);
            this.houseTypesListView.Name = "houseTypesListView";
            this.houseTypesListView.Size = new System.Drawing.Size(140, 100);
            this.houseTypesListView.TabIndex = 11;
            this.houseTypesListView.UseCompatibleStateImageBehavior = false;
            this.houseTypesListView.View = System.Windows.Forms.View.List;
            // 
            // columnHouseType
            // 
            this.columnHouseType.Text = "HouseTypes";
            this.columnHouseType.Width = 120;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(14, 22);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 12;
            this.priceLabel.Text = "Price";
            // 
            // minPriceLabel
            // 
            this.minPriceLabel.AutoSize = true;
            this.minPriceLabel.Location = new System.Drawing.Point(72, 22);
            this.minPriceLabel.Name = "minPriceLabel";
            this.minPriceLabel.Size = new System.Drawing.Size(24, 13);
            this.minPriceLabel.TabIndex = 13;
            this.minPriceLabel.Text = "Min";
            // 
            // maxPriceLabel
            // 
            this.maxPriceLabel.AutoSize = true;
            this.maxPriceLabel.Location = new System.Drawing.Point(72, 54);
            this.maxPriceLabel.Name = "maxPriceLabel";
            this.maxPriceLabel.Size = new System.Drawing.Size(27, 13);
            this.maxPriceLabel.TabIndex = 14;
            this.maxPriceLabel.Text = "Max";
            // 
            // minPriceTextBox
            // 
            this.minPriceTextBox.Location = new System.Drawing.Point(112, 19);
            this.minPriceTextBox.Name = "minPriceTextBox";
            this.minPriceTextBox.Size = new System.Drawing.Size(122, 20);
            this.minPriceTextBox.TabIndex = 15;
            this.minPriceTextBox.TextChanged += new System.EventHandler(this.minPriceTextBox_TextChanged);
            // 
            // maxPriceTextBox
            // 
            this.maxPriceTextBox.Location = new System.Drawing.Point(112, 51);
            this.maxPriceTextBox.Name = "maxPriceTextBox";
            this.maxPriceTextBox.Size = new System.Drawing.Size(122, 20);
            this.maxPriceTextBox.TabIndex = 16;
            this.maxPriceTextBox.TextChanged += new System.EventHandler(this.maxPriceTextBox_TextChanged);
            // 
            // priceCheckBox
            // 
            this.priceCheckBox.AutoSize = true;
            this.priceCheckBox.Location = new System.Drawing.Point(112, 88);
            this.priceCheckBox.Name = "priceCheckBox";
            this.priceCheckBox.Size = new System.Drawing.Size(102, 17);
            this.priceCheckBox.TabIndex = 17;
            this.priceCheckBox.Text = "Search on Price";
            this.priceCheckBox.UseVisualStyleBackColor = true;
            this.priceCheckBox.CheckedChanged += new System.EventHandler(this.priceCheckBox_CheckedChanged);
            // 
            // surfaceAreaLabel
            // 
            this.surfaceAreaLabel.AutoSize = true;
            this.surfaceAreaLabel.Location = new System.Drawing.Point(6, 21);
            this.surfaceAreaLabel.Name = "surfaceAreaLabel";
            this.surfaceAreaLabel.Size = new System.Drawing.Size(69, 13);
            this.surfaceAreaLabel.TabIndex = 18;
            this.surfaceAreaLabel.Text = "Surface Area";
            // 
            // surfaceCheckBox
            // 
            this.surfaceCheckBox.AutoSize = true;
            this.surfaceCheckBox.Location = new System.Drawing.Point(135, 88);
            this.surfaceCheckBox.Name = "surfaceCheckBox";
            this.surfaceCheckBox.Size = new System.Drawing.Size(140, 17);
            this.surfaceCheckBox.TabIndex = 23;
            this.surfaceCheckBox.Text = "Search on Surface Area";
            this.surfaceCheckBox.UseVisualStyleBackColor = true;
            this.surfaceCheckBox.CheckedChanged += new System.EventHandler(this.surfaceCheckBox_CheckedChanged);
            // 
            // maxSurfaceTextBox
            // 
            this.maxSurfaceTextBox.Location = new System.Drawing.Point(135, 51);
            this.maxSurfaceTextBox.Name = "maxSurfaceTextBox";
            this.maxSurfaceTextBox.Size = new System.Drawing.Size(122, 20);
            this.maxSurfaceTextBox.TabIndex = 22;
            this.maxSurfaceTextBox.TextChanged += new System.EventHandler(this.maxSurfaceTextBox_TextChanged);
            // 
            // minSurfaceTextBox
            // 
            this.minSurfaceTextBox.Location = new System.Drawing.Point(135, 19);
            this.minSurfaceTextBox.Name = "minSurfaceTextBox";
            this.minSurfaceTextBox.Size = new System.Drawing.Size(122, 20);
            this.minSurfaceTextBox.TabIndex = 21;
            this.minSurfaceTextBox.TextChanged += new System.EventHandler(this.minSurfaceTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Max";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Min";
            // 
            // filtersGroupBox
            // 
            this.filtersGroupBox.Controls.Add(this.citiesListView);
            this.filtersGroupBox.Controls.Add(this.filtersLabel);
            this.filtersGroupBox.Controls.Add(this.resetFiltersButton);
            this.filtersGroupBox.Controls.Add(this.bedroomsListView);
            this.filtersGroupBox.Controls.Add(this.bathsListView);
            this.filtersGroupBox.Controls.Add(this.houseTypesListView);
            this.filtersGroupBox.Location = new System.Drawing.Point(15, 240);
            this.filtersGroupBox.Name = "filtersGroupBox";
            this.filtersGroupBox.Size = new System.Drawing.Size(755, 173);
            this.filtersGroupBox.TabIndex = 24;
            this.filtersGroupBox.TabStop = false;
            // 
            // upperGridViewGroupBox
            // 
            this.upperGridViewGroupBox.Controls.Add(this.upperGridDataViewLabel);
            this.upperGridViewGroupBox.Controls.Add(this.upperDataGridView);
            this.upperGridViewGroupBox.Controls.Add(this.countTextLabel);
            this.upperGridViewGroupBox.Controls.Add(this.countLabel);
            this.upperGridViewGroupBox.Controls.Add(this.averagePriceTextLabel);
            this.upperGridViewGroupBox.Controls.Add(this.averagePriceLabel);
            this.upperGridViewGroupBox.Location = new System.Drawing.Point(15, 10);
            this.upperGridViewGroupBox.Name = "upperGridViewGroupBox";
            this.upperGridViewGroupBox.Size = new System.Drawing.Size(755, 226);
            this.upperGridViewGroupBox.TabIndex = 25;
            this.upperGridViewGroupBox.TabStop = false;
            // 
            // priceRangeGroupBox
            // 
            this.priceRangeGroupBox.Controls.Add(this.minPriceTextBox);
            this.priceRangeGroupBox.Controls.Add(this.priceLabel);
            this.priceRangeGroupBox.Controls.Add(this.minPriceLabel);
            this.priceRangeGroupBox.Controls.Add(this.maxPriceLabel);
            this.priceRangeGroupBox.Controls.Add(this.maxPriceTextBox);
            this.priceRangeGroupBox.Controls.Add(this.priceCheckBox);
            this.priceRangeGroupBox.Location = new System.Drawing.Point(15, 420);
            this.priceRangeGroupBox.Name = "priceRangeGroupBox";
            this.priceRangeGroupBox.Size = new System.Drawing.Size(245, 115);
            this.priceRangeGroupBox.TabIndex = 26;
            this.priceRangeGroupBox.TabStop = false;
            // 
            // surfaceAreaGroupBox
            // 
            this.surfaceAreaGroupBox.Controls.Add(this.surfaceAreaLabel);
            this.surfaceAreaGroupBox.Controls.Add(this.label2);
            this.surfaceAreaGroupBox.Controls.Add(this.label1);
            this.surfaceAreaGroupBox.Controls.Add(this.surfaceCheckBox);
            this.surfaceAreaGroupBox.Controls.Add(this.minSurfaceTextBox);
            this.surfaceAreaGroupBox.Controls.Add(this.maxSurfaceTextBox);
            this.surfaceAreaGroupBox.Location = new System.Drawing.Point(287, 420);
            this.surfaceAreaGroupBox.Name = "surfaceAreaGroupBox";
            this.surfaceAreaGroupBox.Size = new System.Drawing.Size(272, 114);
            this.surfaceAreaGroupBox.TabIndex = 27;
            this.surfaceAreaGroupBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectedTransactionsLabel);
            this.groupBox1.Controls.Add(this.bottomDataGridView);
            this.groupBox1.Controls.Add(this.selectedTransactionsCountTextLabel);
            this.groupBox1.Controls.Add(this.selectedAverageCountLabel);
            this.groupBox1.Controls.Add(this.averageTransactionsTextLabel);
            this.groupBox1.Controls.Add(this.averageSelectedPriceLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 540);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 230);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // selectedTransactionsLabel
            // 
            this.selectedTransactionsLabel.AutoSize = true;
            this.selectedTransactionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedTransactionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedTransactionsLabel.Location = new System.Drawing.Point(16, 16);
            this.selectedTransactionsLabel.Name = "selectedTransactionsLabel";
            this.selectedTransactionsLabel.Size = new System.Drawing.Size(136, 15);
            this.selectedTransactionsLabel.TabIndex = 1;
            this.selectedTransactionsLabel.Text = "Selected Transactions";
            // 
            // bottomDataGridView
            // 
            this.bottomDataGridView.AllowUserToAddRows = false;
            this.bottomDataGridView.AllowUserToDeleteRows = false;
            this.bottomDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bottomDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.bottomDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bottomDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedAddress,
            this.selectedCity,
            this.selectedBedrooms,
            this.selectedBathrooms,
            this.selectedSurfaceArea,
            this.selectedHouseType,
            this.selectedPrice});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bottomDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.bottomDataGridView.Location = new System.Drawing.Point(16, 47);
            this.bottomDataGridView.Name = "bottomDataGridView";
            this.bottomDataGridView.ReadOnly = true;
            this.bottomDataGridView.RowHeadersWidth = 30;
            this.bottomDataGridView.Size = new System.Drawing.Size(720, 123);
            this.bottomDataGridView.TabIndex = 0;
            // 
            // selectedAddress
            // 
            this.selectedAddress.Name = "selectedAddress";
            this.selectedAddress.ReadOnly = true;
            // 
            // selectedCity
            // 
            this.selectedCity.Name = "selectedCity";
            this.selectedCity.ReadOnly = true;
            // 
            // selectedBedrooms
            // 
            this.selectedBedrooms.Name = "selectedBedrooms";
            this.selectedBedrooms.ReadOnly = true;
            // 
            // selectedBathrooms
            // 
            this.selectedBathrooms.Name = "selectedBathrooms";
            this.selectedBathrooms.ReadOnly = true;
            // 
            // selectedSurfaceArea
            // 
            this.selectedSurfaceArea.Name = "selectedSurfaceArea";
            this.selectedSurfaceArea.ReadOnly = true;
            // 
            // selectedHouseType
            // 
            this.selectedHouseType.Name = "selectedHouseType";
            this.selectedHouseType.ReadOnly = true;
            // 
            // selectedPrice
            // 
            this.selectedPrice.Name = "selectedPrice";
            this.selectedPrice.ReadOnly = true;
            // 
            // selectedTransactionsCountTextLabel
            // 
            this.selectedTransactionsCountTextLabel.AutoSize = true;
            this.selectedTransactionsCountTextLabel.Location = new System.Drawing.Point(72, 199);
            this.selectedTransactionsCountTextLabel.Name = "selectedTransactionsCountTextLabel";
            this.selectedTransactionsCountTextLabel.Size = new System.Drawing.Size(44, 13);
            this.selectedTransactionsCountTextLabel.TabIndex = 2;
            this.selectedTransactionsCountTextLabel.Text = "Count =";
            // 
            // selectedAverageCountLabel
            // 
            this.selectedAverageCountLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedAverageCountLabel.Location = new System.Drawing.Point(122, 198);
            this.selectedAverageCountLabel.Name = "selectedAverageCountLabel";
            this.selectedAverageCountLabel.Size = new System.Drawing.Size(50, 16);
            this.selectedAverageCountLabel.TabIndex = 3;
            // 
            // averageTransactionsTextLabel
            // 
            this.averageTransactionsTextLabel.AutoSize = true;
            this.averageTransactionsTextLabel.Location = new System.Drawing.Point(292, 199);
            this.averageTransactionsTextLabel.Name = "averageTransactionsTextLabel";
            this.averageTransactionsTextLabel.Size = new System.Drawing.Size(83, 13);
            this.averageTransactionsTextLabel.TabIndex = 4;
            this.averageTransactionsTextLabel.Text = "Average Price =";
            // 
            // averageSelectedPriceLabel
            // 
            this.averageSelectedPriceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averageSelectedPriceLabel.Location = new System.Drawing.Point(381, 199);
            this.averageSelectedPriceLabel.Name = "averageSelectedPriceLabel";
            this.averageSelectedPriceLabel.Size = new System.Drawing.Size(100, 16);
            this.averageSelectedPriceLabel.TabIndex = 5;
            // 
            // RealEstateTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 791);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.surfaceAreaGroupBox);
            this.Controls.Add(this.priceRangeGroupBox);
            this.Controls.Add(this.upperGridViewGroupBox);
            this.Controls.Add(this.filtersGroupBox);
            this.Name = "RealEstateTransactionsForm";
            this.Text = "Assignment 1 Real Estate Transactions";
            this.Load += new System.EventHandler(this.RealEstateTransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upperDataGridView)).EndInit();
            this.filtersGroupBox.ResumeLayout(false);
            this.filtersGroupBox.PerformLayout();
            this.upperGridViewGroupBox.ResumeLayout(false);
            this.upperGridViewGroupBox.PerformLayout();
            this.priceRangeGroupBox.ResumeLayout(false);
            this.priceRangeGroupBox.PerformLayout();
            this.surfaceAreaGroupBox.ResumeLayout(false);
            this.surfaceAreaGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView upperDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn bedrooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn bathrooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn surfaceArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn houseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.Label upperGridDataViewLabel;
        private System.Windows.Forms.Label countTextLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label averagePriceTextLabel;
        private System.Windows.Forms.Label averagePriceLabel;
        private System.Windows.Forms.Label filtersLabel;
        private System.Windows.Forms.Button resetFiltersButton;
        private System.Windows.Forms.ListView citiesListView;
        private System.Windows.Forms.ListView bedroomsListView;
        private System.Windows.Forms.ListView bathsListView;
        private System.Windows.Forms.ListView houseTypesListView;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label minPriceLabel;
        private System.Windows.Forms.Label maxPriceLabel;
        private System.Windows.Forms.TextBox minPriceTextBox;
        private System.Windows.Forms.TextBox maxPriceTextBox;
        private System.Windows.Forms.CheckBox priceCheckBox;
        private System.Windows.Forms.Label surfaceAreaLabel;
        private System.Windows.Forms.CheckBox surfaceCheckBox;
        private System.Windows.Forms.TextBox maxSurfaceTextBox;
        private System.Windows.Forms.TextBox minSurfaceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox filtersGroupBox;
        private System.Windows.Forms.GroupBox upperGridViewGroupBox;
        private System.Windows.Forms.GroupBox priceRangeGroupBox;
        private System.Windows.Forms.GroupBox surfaceAreaGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label selectedTransactionsLabel;
        private System.Windows.Forms.DataGridView bottomDataGridView;
        private System.Windows.Forms.Label selectedTransactionsCountTextLabel;
        private System.Windows.Forms.Label selectedAverageCountLabel;
        private System.Windows.Forms.Label averageTransactionsTextLabel;
        private System.Windows.Forms.Label averageSelectedPriceLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedBedrooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedBathrooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedSurfaceArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedHouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedPrice;
        private System.Windows.Forms.ColumnHeader columnCities;
        private System.Windows.Forms.ColumnHeader columnBedrooms;
        private System.Windows.Forms.ColumnHeader columnBaths;
        private System.Windows.Forms.ColumnHeader columnHouseType;
    }
}

