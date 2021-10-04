using MySql.Data.MySqlClient;


namespace DataBaseSQL
{
    internal sealed class DataBase
    {
        #region Fields

        private MySqlConnection _connection = new MySqlConnection(Constants.TheFollowingConnectionParameters);

        #endregion


        #region Methods

        public void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        #endregion
    }
}
