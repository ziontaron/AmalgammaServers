
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data_Base_MNG
{
    public class SQL
    {
        //sql_con = "Data Source=" + server + ";Initial Catalog=FSDBMR;Persist Security Info=True;User ID=" + user + ";Password=" + pass;
        #region Variables Privadas
        private string _server = "";
        private string _user = "";
        private string _pass = "";
        private string _dbname = "";
        private string _sql_con_str = "";
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        private List<SqlParameter> _parameters = new List<SqlParameter>();
		private List<SqlParameter> _parametersOutput = new List<SqlParameter>();

        //private SqlParameter[] _parameters;
        private SqlCommand _command;
        private string _script = "";
        private string _error_mjs = "";
        private SqlDataAdapter _adapter;
        private bool ErrorFlag = false;
        #endregion

        #region Variales Publicas
        //public SqlDataAdapter Open_adapter;
        public string Command
        {
            get
            {
                return _script;
            }
            set
            {
                if (value != _script) _script = value;
            }
        }
        public string Server
        {
            get
            {
                return _server;
            }
            set
            {
                if (value != _server) _server = value;
            }
        }
        public string DB_Name
        {
            get
            {
                return _dbname;
            }
            set
            {
                if (value != _dbname) _dbname = value;
            }
        }
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                if (value != _user) _user = value;
            }
        }
        public string Pass
        {
            get
            {
                return _pass;
            }
            set
            {
                if (value != _pass) _pass = value;
            }
        }
        public string Error_Mjs
        {
            get
            {
                return _error_mjs;
            }
            set
            {
                //if (value != _error_mjs) _error_mjs = value;
            }
        }
        public bool ErrorOccur
        {
            get
            {
                return ErrorFlag;
            }
            set
            {
            } 
        }
        #endregion

        #region Constructores
        public SQL(string SQL_Connection_String)
        {
            _sql_con_str = SQL_Connection_String;
            _connection = new SqlConnection(_sql_con_str);
        }
        public SQL(string Server, string DBname, string User, string Pass)
        {
            _sql_con_str = "Data Source=" + Server + ";Initial Catalog=" + DBname +
                ";Persist Security Info=True;User ID=" + User + ";Password=" + Pass;
            _connection = new SqlConnection(_sql_con_str);
        }
        #endregion

        #region Funciones Privadas
        private void Start_Connection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }
        private void Start_Connection_BeginTransaction(string TransactionName)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction(TransactionName);
            }
        }
        private void Commit()
        {
            try
            {
                ErrorFlag = false;
                _error_mjs = "";
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                ErrorFlag = true;
                _error_mjs = ex.Message;
                try
                {
                    _transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    _error_mjs = ex.Message + " RollBack Error: " + ex2.Message;
                }
            } 
        }

        public void RollBack()
        {
            ErrorFlag = false;
            _error_mjs = "";
            try
            {
                _transaction.Rollback();
            }
            catch (Exception ex)
            {
                ErrorFlag = true;
                _error_mjs = ex.Message;
            }
        }
        private void Stop_Connection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        private void Build_Adapter()
        {
            _adapter = new SqlDataAdapter(_script, _connection);
        }
        private void Build_Command()
        {
            _command = new SqlCommand(_script, _connection);
        }
        private void Build_Command(string Command)
        {
            _script = Command;
            _command = new SqlCommand(_script, _connection);
        }
        private object Execute_Scalar_Object(string Command)
        {
            object result = null;
            Build_Command(Command);
            try
            {
                Start_Connection();
                result = _command.ExecuteScalar();
                Stop_Connection();
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                result = null;
            }
            return result;
        }
        private object Execute_Scalar_Object_OpenConnection(string Command)
        {
            object result = null;
            Build_Command(Command);
            try
            {
                //Start_Connection();
                result = _command.ExecuteScalar();
                Stop_Connection();
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                //Stop_Connection();
                result = null;
            }
            return result;
        }
        #endregion

        #region Funciones publicas
        ///ejecuta Querys
        public void Close_Open_Connection()
        {
            Stop_Connection();
        }
        public void Open_Connection()
        {
            Start_Connection();
        }
        public void Open_Connection(string TransactionName)
        {
            Start_Connection_BeginTransaction(TransactionName);
        }
        public void CommitTransaction()
        {
            Commit();
        }
        public bool Execute_Command()
        {
            bool result = false;
            Build_Command();
            try
            {
                Start_Connection();
                ///
                _command.ExecuteNonQuery();
                Stop_Connection();
                ErrorFlag = false;
                result = true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                result = false;
            }
            return result;
        }
        public bool Execute_Command(string Command)
        {
            bool result = false;
            Build_Command(Command);
            try
            {
                Start_Connection();
                ///
                _command.ExecuteNonQuery();
                Stop_Connection();
                ErrorFlag = false;
                result = true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                result = false;
            }
            return result;
        }
        public bool Execute_Command_Open_Connection(string Command)
        {
            Build_Command(Command);
            try
            {
				_command.Transaction = _transaction;
                _command.ExecuteNonQuery();
                //Stop_Connection();
                ErrorFlag = false;
                return true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;                
                ErrorFlag = true;

                try
                {
                    _transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    _error_mjs = ex.Message + " RollBack Error: " + ex2.Message;
                }
            }
            return false;
        }
        public DataTable Execute_Query()
        {
            DataTable tabla = new DataTable();
            Build_Command();
            try
            {
                Start_Connection();
                _adapter = new SqlDataAdapter(_command);
                _adapter.Fill(tabla);
                Stop_Connection();
                ErrorFlag = false;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
            }
            return tabla;
        }
        public DataTable Execute_Query(string Query)
        {
            DataTable tabla = new DataTable();
            Build_Command(Query);
            try
            {
                Start_Connection();
                _adapter = new SqlDataAdapter(_command);
                _adapter.Fill(tabla);
                Stop_Connection();
                ErrorFlag = false;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
            }
            return tabla;
        }
        public bool Execute_Query(string Query, out DataTable Table2Fill)
        {
            Table2Fill = new DataTable();
            Build_Command(Query);
            try
            {
                Start_Connection();
                _adapter = new SqlDataAdapter(_command);
                _adapter.Fill(Table2Fill);
                Stop_Connection();
                ErrorFlag = false;
                return true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                return false;
            }
        }
        public bool Execute_Query(out DataTable Table2Fill)
        {
            Table2Fill = new DataTable();
            Build_Command();
            try
            {
                Start_Connection();
                _adapter = new SqlDataAdapter(_command);
                _adapter.Fill(Table2Fill);
                Stop_Connection();
                ErrorFlag = false;
                return true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                return false;
            }
        }
        public bool Execute_Query_Open_Connection(string Query, out DataTable Table2Fill)
        {
            Table2Fill = new DataTable();
            Build_Command(Query);
            try
            {
                //Start_Connection();
                _adapter = new SqlDataAdapter(_command);
                _adapter.Fill(Table2Fill);
                //Stop_Connection();
                ErrorFlag = false;
                return true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                return false;
            }
        }
        public bool Execute_Query_Open_Connection(out DataTable Table2Fill)
        {
            Table2Fill = new DataTable();
            Build_Command();
            try
            {
                //Start_Connection();
                _adapter = new SqlDataAdapter(_command);
                _adapter.Fill(Table2Fill);
                //Stop_Connection();
                ErrorFlag = false;
                return true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                return false;
            }
        }
        public bool Execute_Table_Update(out DataTable Table2Fill)
        {
            Table2Fill = new DataTable();
            try
            {
                _adapter.Update(Table2Fill);

                ErrorFlag = false;
                return true;
            }
            catch (Exception ex)
            {
                Error_Mjs = ex.Message;
                ErrorFlag = true;
                return false;
            }
        }
        public void Load_SP_Parameters(string ParameterName, string ParameterValue)
        {
            SqlParameter param = new SqlParameter(ParameterName, ParameterValue);
            _parameters.Add(param);
        }
        public void Load_SP_Parameters_Output(string ParameterName, SqlDbType type, int length)
        {
            SqlParameter param = new SqlParameter(ParameterName, type,length);
            param.Direction = ParameterDirection.Output;
            _parametersOutput.Add(param);
        }
        public void Load_SP_Parameters_Output(string ParameterName, SqlDbType type)
        {
            SqlParameter param = new SqlParameter(ParameterName, type);
            param.Direction = ParameterDirection.Output;
            _parametersOutput.Add(param);
        }
        public string getOutputParameter(string param)
        {
            return _command.Parameters[param].Value.ToString();
        }
        public void clearOutputParameters()
        {
            _parametersOutput.Clear();
        }
        public bool Execute_StoreProcedure(string Command, bool ParametersNeeded)
        {
            bool result = false;
            Build_Command(Command);
            _command.CommandType = CommandType.StoredProcedure;
            try
            {
                Start_Connection();
                ///

                if (ParametersNeeded)
                {

                    _command.Parameters.AddRange(_parameters.ToArray());
                }
                _command.ExecuteNonQuery();
                Stop_Connection();
                ErrorFlag = false;
                result = true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                result = false;
            }
            return result;
        }
        public string Execute_StoreProcedure_Scalar(string Command, bool ParametersNeeded)
        {
            string result = "";
            Build_Command(Command);
            _command.CommandType = CommandType.StoredProcedure;
            try
            {
                Start_Connection();
                ///

                if (ParametersNeeded)
                {

                    _command.Parameters.AddRange(_parameters.ToArray());
                }
                result = _command.ExecuteScalar().ToString();
                Stop_Connection();
                ErrorFlag = false;
                //result = true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                result = "";
            }
            return result;
        }
        public DataTable Execute_StoreProcedure_Table(string Command, bool ParametersNeeded)
        {
            DataTable result = new DataTable();
            Build_Command(Command);
            _command.CommandType = CommandType.StoredProcedure;
            
            try
            {
                Start_Connection();
                ///

                if (ParametersNeeded)
                {

                    _command.Parameters.AddRange(_parameters.ToArray());
                }
                _adapter = new SqlDataAdapter(_command);

                _adapter.Fill(result);
                Stop_Connection();
                ErrorFlag = false;
                //result = true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                Stop_Connection();
                ErrorFlag = true;
                result = null;
            }
            return result;
        }
        public bool Execute_StoreProcedure_Open_Conn(string Command, bool ParametersNeeded)
        {
            bool result = false;
            Build_Command(Command);
            _command.CommandType = CommandType.StoredProcedure;
            try
            {
                //Start_Connection();
                ///

                if (ParametersNeeded)
                {

                    _command.Parameters.AddRange(_parameters.ToArray());
                }
                _command.Transaction = _transaction;
                _command.ExecuteNonQuery();                
                _command.Parameters.Clear();
                _parameters.Clear();
               
                //Stop_Connection();
                ErrorFlag = false;
                result = true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                //Stop_Connection();
                ErrorFlag = true;
                result = false;
            }
            return result;
        }
        public string Execute_StoreProcedure_Scalar_Open_Conn(string Command, bool ParametersNeeded)
        {
            string result = "";
            Build_Command(Command);
            _command.CommandType = CommandType.StoredProcedure;
            try
            {
                //Start_Connection();
                ///

                if (ParametersNeeded)


                {                   
                    _command.Parameters.AddRange(_parameters.ToArray());
                }
                _command.Transaction = _transaction;
                result = _command.ExecuteScalar().ToString();
                _command.Parameters.Clear();
                _parameters.Clear();
                //Stop_Connection();
                ErrorFlag = false;
                //result = true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                //Stop_Connection();
                ErrorFlag = true;
                result = "";

                try
                {
                    _transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    _error_mjs = ex.Message + " RollBack Error: " + ex2.Message;
                }
            }
            return result;
        }
public bool Execute_StoreProcedure_Use_Output_Parameters_Open_Conn(string Command, bool ParametersNeeded)
        {
            bool result = false;
            Build_Command(Command);
            _command.CommandType = CommandType.StoredProcedure;
            try
            {
                //Start_Connection();
                ///
                _command.Parameters.Clear();
                if (ParametersNeeded)
                {
                    _command.Parameters.AddRange(_parameters.ToArray());
                    _command.Parameters.AddRange(_parametersOutput.ToArray());
                }
                _command.Transaction = _transaction;
                _command.ExecuteNonQuery();
                
                _parameters.Clear();
                //Stop_Connection();
                ErrorFlag = false;
                result = true;
            }
            catch (Exception ex)
            {

                _error_mjs = ex.Message;
                //Stop_Connection();
                ErrorFlag = true;
                result = false;

                try
                {
                    _transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    _error_mjs = ex.Message + " RollBack Error: " + ex2.Message;
                }
            }
            return result;
        }
        public DataTable Execute_StoreProcedure_Table_Open_Conn(string Command, bool ParametersNeeded)
        {
            DataTable result = new DataTable();
            Build_Command(Command);
            _command.CommandType = CommandType.StoredProcedure;

            try
            {
                //Start_Connection();
                ///

                if (ParametersNeeded)
                {

                    _command.Parameters.AddRange(_parameters.ToArray());
                }
                _adapter = new SqlDataAdapter(_command);

                _adapter.Fill(result);
                //Stop_Connection();
                ErrorFlag = false;
                //result = true;
            }
            catch (Exception ex)
            {
                _error_mjs = ex.Message;
                //Stop_Connection();
                ErrorFlag = true;
                result = null;
            }
            return result;
        }

        public bool Update_Open_Connection( out DataTable Table2Update)
        {
            Table2Update = new DataTable();       
            try
            {
                _adapter.Update(Table2Update);
                ErrorFlag = false;
                return true;
            }
            catch(Exception ex)
            {
                _error_mjs = ex.Message;
                ErrorFlag = true;
                return false;
            }
        }
        public string Execute_Scalar(string Query)
        {
            object objeto = null;
            string Dato = "";
            try
            {
                objeto = Execute_Scalar_Object(Query);
                Dato = objeto.ToString();
                ErrorFlag = false;
                return Dato;
            }
            catch (Exception ex)
            {
                Error_Mjs = ex.Message;
                ErrorFlag = true;
                return "";
            }
        }
        public string Execute_Scalar_Open_Conn(string Query)
        {
            object objeto = null;
            string Dato = "";
            try
            {
                objeto = Execute_Scalar_Object_OpenConnection(Query);
                Dato = objeto.ToString();
                ErrorFlag = false;
                return Dato;
            }
            catch (Exception ex)
            {
                Error_Mjs = ex.Message;
                ErrorFlag = true;
                return "";
            }
        }
        #endregion
    }
}
