namespace Lab2.TehPrelucrareDb
{
    using System.Data;
    using System.Data.SqlClient;


    public class AdventureWorksDataAccess
    {
        readonly string _connectionString = "Server=localhost;Database=AdventureWorksDW2022;Trusted_Connection=True;";
        private DataTable _dataTable;
        private int _currentIndex = 0;
        public int CurrentIndex => _currentIndex;

        public DataTable DataTable
        {
            get { return _dataTable; }
        }

        public AdventureWorksDataAccess(string tableName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = $"SELECT * FROM {tableName}";
                var adapter = new SqlDataAdapter(query, connection);
                _dataTable = new DataTable();
                adapter.Fill(_dataTable);
            }
        }

        public (bool hasNext, DataRow data) ReadCurrent()
        {
            var hasNext = _currentIndex < _dataTable.Rows.Count - 1;
            var data = _dataTable.Rows.Count > 0 ? _dataTable.Rows[_currentIndex] : null;
            return (hasNext, data);
        }

        public (bool hasNext, DataRow data) ReadNext()
        {
            if (_currentIndex < _dataTable.Rows.Count - 1)
            {
                _currentIndex++;
            }
            return ReadCurrent();
        }

        public (bool hasPrevious, DataRow data) ReadPrevious()
        {
            var hasPrevious = _currentIndex > 0;
            if (hasPrevious)
            {
                _currentIndex--;
            }
            hasPrevious = _currentIndex > 0;

            return  (hasPrevious, _dataTable.Rows.Count > 0 ? _dataTable.Rows[_currentIndex] : null);
        }


        public void UpdateCurrent(DataRow updatedRow)
        {
            if (_currentIndex >= 0 && _currentIndex < _dataTable.Rows.Count)
            {
                var currentRow = _dataTable.Rows[_currentIndex];
                foreach (DataColumn column in _dataTable.Columns)
                {
                    currentRow.BeginEdit();
                    currentRow[column.ColumnName] = updatedRow[column.ColumnName];
                    currentRow.EndEdit(); 
                }
            }
        }


        public void DeleteCurrent()
        {
            if (_currentIndex >= 0 && _currentIndex < _dataTable.Rows.Count)
            {
                _dataTable.Rows[_currentIndex].Delete();

                if (_currentIndex == _dataTable.Rows.Count - 1)
                {
                    _currentIndex--;
                }

                _dataTable = _dataTable.AsEnumerable().Where(row => row.RowState != DataRowState.Deleted).CopyToDataTable();
            }
        }


        public void ResetIndexToLastValid()
        {
            if (_dataTable.Rows.Count > 0)
            {
                _currentIndex = _dataTable.Rows.Count - 1;
            }
            else
            {
                _currentIndex = -1;
            }
        }


        public static string[] GetTableNames()
        {
            List<string> tableNames = new List<string>();
            using (var connection = new SqlConnection("Server=localhost;Database=AdventureWorksDW2022;Trusted_Connection=True;"))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                foreach (DataRow row in schema.Rows)
                {
                    if (row["TABLE_TYPE"].ToString() == "BASE TABLE")
                    {
                        tableNames.Add(row["TABLE_NAME"].ToString());
                    }
                }
            }
            return tableNames.ToArray();
        }

        public DataRow GetFirstRecord(string tableName)
        {
            ReloadData(tableName);
            _currentIndex = 0;
            return _dataTable.Rows.Count > 0 ? _dataTable.Rows[0] : null;
        }

        public void InsertRecord(DataRow newRow)
        {
            if (_dataTable.Columns.Count != newRow.ItemArray.Length)
            {
                throw new ArgumentException("The number of values must match the number of columns in the table.");
            }

            _dataTable.Rows.Add(newRow);
        }



        public void ReloadData(string tableName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = $"SELECT * FROM {tableName}";
                var adapter = new SqlDataAdapter(query, connection);
                var newDataTable = new DataTable();
                adapter.Fill(newDataTable);
                _dataTable = newDataTable;
                _currentIndex = 0;
            }
        }
    }

}
