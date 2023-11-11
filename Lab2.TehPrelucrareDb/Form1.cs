using System.Data;

namespace Lab2.TehPrelucrareDb
{
    public partial class Form1 : Form
    {
        private AdventureWorksDataAccess _dataAccess;
        private DataRow _currentRow;

        public Form1()
        {
            InitializeComponent();
            PopulateTableNames();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void PopulateTableNames()
        {
            var tableNames = AdventureWorksDataAccess.GetTableNames();
            comboBox1.Items.AddRange(tableNames);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = comboBox1.SelectedItem.ToString();
            _dataAccess = new AdventureWorksDataAccess(selectedTable);

            _currentRow = _dataAccess.GetFirstRecord(selectedTable);
            PopulateFieldsWithData(_currentRow);

            currentRecordCount.Text = "0";

            UpdateCurrentRecordCount();
        }

        private void UpdateCurrentRecordCount()
        {
            int recordNumber = _currentRow != null ? _dataAccess.CurrentIndex + 1 : 0;
            currentRecordCount.Text = recordNumber.ToString();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var result = _dataAccess.ReadNext();
            _currentRow = result.data;
            UpdateCurrentRecordCount();
            PopulateFieldsWithData(_currentRow);
        }


        private void previousButton_Click(object sender, EventArgs e)
        {
            var result = _dataAccess.ReadPrevious();
            _currentRow = result.data;
            UpdateCurrentRecordCount();
            PopulateFieldsWithData(_currentRow);
        }

        private void PopulateFieldsWithData(DataRow dataRow)
        {
            dataFieldsPanel.Controls.Clear();
            dataFieldsPanel.FlowDirection = FlowDirection.TopDown;

            if (dataRow != null)
            {
                foreach (DataColumn column in dataRow.Table.Columns)
                {
                    TableLayoutPanel fieldPanel = new TableLayoutPanel
                    {
                        ColumnCount = 1,
                        RowCount = 2,
                        Width = 200,
                        Height = 50,
                        Margin = new Padding(5) 
                    };
                    fieldPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                    fieldPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
                    fieldPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                    Label label = new Label
                    {
                        Text = column.ColumnName,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.BottomLeft
                    };
                    fieldPanel.Controls.Add(label, 0, 0);

                    TextBox textBox = new TextBox
                    {
                        Name = column.ColumnName, 
                        Text = dataRow[column].ToString(),
                        Dock = DockStyle.Fill,
                        Margin = new Padding(3, 5, 3, 3)
                    };

                    fieldPanel.Controls.Add(textBox, 0, 1); 

                    dataFieldsPanel.Controls.Add(fieldPanel);
                }
            }

            dataFieldsPanel.FlowDirection = FlowDirection.LeftToRight;
            dataFieldsPanel.WrapContents = true;
        }



        private void updateBtn_Click(object sender, EventArgs e)
        {
            DataRow currentRow = _dataAccess.ReadCurrent().data;
            if (currentRow != null)
            {
                foreach (TableLayoutPanel panel in dataFieldsPanel.Controls.OfType<TableLayoutPanel>())
                {
                    TextBox textBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
                    if (textBox != null && currentRow.Table.Columns.Contains(textBox.Name))
                    {
                        currentRow.BeginEdit();
                        currentRow[textBox.Name] = textBox.Text; 
                        currentRow.EndEdit();
                    }
                }
            }
        }



        private void deleteBtn_Click(object sender, EventArgs e)
        {
            _dataAccess.DeleteCurrent();
            var (hasNext, data) = _dataAccess.ReadCurrent();
            _currentRow = data;
            UpdateCurrentRecordCount();
            PopulateFieldsWithData(_currentRow);
        }



        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (_dataAccess == null) return;

            DataRow newRow = _dataAccess.DataTable.NewRow();

            foreach (TableLayoutPanel panel in dataFieldsPanel.Controls.OfType<TableLayoutPanel>())
            {
                TextBox textBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
                if (textBox != null)
                {
                    newRow[textBox.Name] = textBox.Text;
                }
            }

            _dataAccess.InsertRecord(newRow);

        }


    }

}