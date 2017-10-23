using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoftBrands.FourthShift.Transaction;
using System.IO;
using System.Net.Mail;
using System.Diagnostics;

namespace AduanaShipping
{
    public partial class Form1 : Form
    {
        IMTR01 myItem = new IMTR01();
        DataTable table = null;
        TOOLS.Dataloger LOGGER;
        //Sand Box
        //Data_Base_MNG.SQL Cliente_SQL = new Data_Base_MNG.SQL("captest", "FSDBMR", "ac", "capsonic");
        
        //Produccion
        //Data_Base_MNG.SQL Cliente_SQL = new Data_Base_MNG.SQL("192.168.0.9", "FSDBMR", "sa", "6rzq4d1");

        Data_Base_MNG.SQL Cliente_SQL = new Data_Base_MNG.SQL("192.168.0.9", "FSDBMR", "AmalAdmin", "Amalgamma16");//el paso
        string DB_IN_USE = "Manufacturing Data Base In Use ... Please Try Again";

        TOOLS.Email mail = new TOOLS.Email();

        #region FSTI

        string CFG_File = @"m:\mfgsys\fs.cfg";
        string User = "IMPT";
        string Pass = "fstiapp";

        FS4Amalgamma.AmalgammaFSTI FSTI;

        #endregion

        int couterGood = 0;
        int counterBad = 0;
        List<string> errors = new List<string>();

        bool FSTI_Proceed = true;
        bool Proceed_trans = true;

        bool FSTI_initialized = false;
        bool FSTI_loged = false;
        bool FSTI_Error_Flag = false;

        private FSTIClient _fstiClient = null;

        public Form1()
        {
            InitializeComponent();
            
            if (!IsSingleInstance())
            {
                this.Close();
            }
            this.Text = "Customs - Shipping Server V 5.6";
            FSTI = new FS4Amalgamma.AmalgammaFSTI(CFG_File, User, Pass);
            LOGGER = new TOOLS.Dataloger("IntShipLog", "log", "");
            StartButton();
            FSTI_TransButton();
            Up_Since.Text = "Up Since: " + DateTime.Now.ToString("MM/dd/yyy hh:mm tt");
        }

        private bool IsSingleInstance()
        {
            string proceso = "", esta = "", name = "";
            int count = 0;
            foreach (Process process in Process.GetProcesses())
            {
                name = process.ProcessName;
                proceso = process.MainWindowTitle;
                esta = this.Text;
                if (process.MainWindowTitle == this.Text)
                {
                    //MessageBox.Show(name + " " + proceso + " " + esta+" "+count.ToString());
                    count++;
                }
            }
            if (count <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string process()
        {
            string response = "";

            try
            {
                if (FSTI.AmalgammaFSTI_Initialization())
                {
                    if (FSTI.AmalgammaFSTI_Logon())
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            proceed_Fields(i);
                        }
                    }
                    else
                    {
                        //MessageBox.Show(FSTI.ErrorMsg, "Error During Login");
                        ProcessingLog("FSTI-Error During Login - " + FSTI.FSTI_ErrorMsg, "error");
                        response = "FSTI-Error During Login - " + FSTI.FSTI_ErrorMsg;
                        FSTI_Error_Flag = true;
                    }
                }
                else
                {
                    //MessageBox.Show(FSTI.ErrorMsg, "Error During FSTI Inicialitation");
                    ProcessingLog("FSTI-Error During FSTI Inicialitation - " + FSTI.FSTI_ErrorMsg, "error");
                    response = "FSTI-Error During FSTI Inicialitation - " + FSTI.FSTI_ErrorMsg;
                    FSTI_Error_Flag = true;
                }

            }
            catch (Exception ex)
            {
                ProcessingLog("FSTI-Error During FSTI Inicialitation - " + FSTI.FSTI_ErrorMsg, "error");
                response = "FSTI-Error During FSTI Inicialitation - " + FSTI.FSTI_ErrorMsg;
                FSTI_Error_Flag = true;
            }


            return response;
        }
        #region FSTI Functions

        #endregion

        #region Funciones
        private string Browse()
        {
            string text = "";
            //OpenFileDialog Dialogo = new OpenFileDialog();
            FolderBrowserDialog Dialogo = new FolderBrowserDialog();
            //Dialogo.RestoreDirectory = true;
            if (DialogResult.OK == Dialogo.ShowDialog())
            {
                return Dialogo.SelectedPath.ToString();
            }
            else
            {
                return text;
            }
        }
        private void DumpErrorObject(ITransaction transaction, FSTIError fstiErrorObject)
        {
            listResult.Items.Add("Transaction Error:");
            logtxt("Transaction Error:");
            listResult.Items.Add("");
            logtxt("");
            listResult.Items.Add(String.Format("Transaction: {0}", transaction.Name));
            logtxt(String.Format("Transaction: {0}", transaction.Name));
            listResult.Items.Add(String.Format("Description: {0}", fstiErrorObject.Description));
            logtxt(String.Format("Description: {0}", fstiErrorObject.Description));
            listResult.Items.Add(String.Format("MessageFound: {0} ", fstiErrorObject.MessageFound));
            logtxt(String.Format("MessageFound: {0} ", fstiErrorObject.MessageFound));
            listResult.Items.Add(String.Format("MessageID: {0} ", fstiErrorObject.MessageID));
            logtxt(String.Format("MessageID: {0} ", fstiErrorObject.MessageID));
            listResult.Items.Add(String.Format("MessageSource: {0} ", fstiErrorObject.MessageSource));
            logtxt(String.Format("MessageSource: {0} ", fstiErrorObject.MessageSource));
            listResult.Items.Add(String.Format("Number: {0} ", fstiErrorObject.Number));
            logtxt(String.Format("Number: {0} ", fstiErrorObject.Number));
            listResult.Items.Add(String.Format("Fields in Error: {0} ", fstiErrorObject.NumberOfFieldsInError));
            logtxt(String.Format("Fields in Error: {0} ", fstiErrorObject.NumberOfFieldsInError));
            for (int i = 0; i < fstiErrorObject.NumberOfFieldsInError; i++)
            {
                int field = fstiErrorObject.GetFieldNumber(i);
                listResult.Items.Add(String.Format("Field[{0}]: {1}", i, field));
                logtxt(String.Format("Field[{0}]: {1}", i, field));
                ITransactionField myField = transaction.get_Field(field);
                listResult.Items.Add(String.Format("Field name: {0}", myField.Name));
                logtxt(String.Format("Field name: {0}", myField.Name));
            }
        }
        private void StopServer()
        {
            timer1.Stop();
            FSTI_Proceed = false;
            FSTI_Trans.Enabled = false;

            Server_Start.Enabled = true;
            Server_Stop.Enabled = false;

            FSTI_Ini.Enabled = false;
            FSTI_Login.Enabled = false;

            if (_fstiClient != null)
            {
                _fstiClient.Terminate();
                _fstiClient = null;
            } 
            Proceed_trans = false;
 
        }
        private bool proceed(int i)
        {

            string Fields = proceed_Fields(i);

            bool result= FSTI.AmalgammaFSTI_IMTR01(Fields, "");

            return result;
        }
        private string proceed_Fields(int i)
        {
            string fields = "";
            string IntemNumber = "", STK_BINFrom = "", InvCatFrom = "", STK_BINTo = "", InvCatTo = "", Qty = "", LOT_NO="";
            //Item Number
            IntemNumber = table.Rows[i]["ItemNumber"].ToString();

            //from
            STK_BINFrom = table.Rows[i]["StockRoomFrom"].ToString() + "-" + table.Rows[i]["BinFrom"].ToString();

            InvCatFrom = table.Rows[i]["InventoryCat"].ToString();

            //to
            STK_BINTo = table.Rows[i]["StockRoomTo"].ToString() + "-" + table.Rows[i]["BinTo"].ToString();

            InvCatTo = table.Rows[i]["InventoryCat"].ToString();

            //QTY
            Qty = table.Rows[i]["InventoryQTY"].ToString();

            //LOT NO
            LOT_NO = table.Rows[i]["LotNo"].ToString();


            fields = IntemNumber + "," + STK_BINFrom + "," + InvCatFrom + "," + STK_BINTo + "," + InvCatTo + "," + Qty + "," + LOT_NO;

            //return ExecuteTransaction(table.Rows[i]["ItemKey"].ToString());
            return fields;
        }
        private void logtxt(string Line)
        {
            FileStream Archivo = new FileStream(@"ShipFSTI_Log.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter salida = new StreamWriter(Archivo);
            
            salida.WriteLine(Line);
            salida.Close();
        }
        #endregion

        #region FS Functions
        /*
        bool FS_Initialize_Client()
        {
            if (!FSTI_initialized)
            {
                try
                {
                    _fstiClient = new FSTIClient();

                    // call InitializeByConfigFile
                    // second parameter == true is to participate in unified logon
                    // third parameter == false, no support for impersonation is needed

                    _fstiClient.InitializeByConfigFile(textConfig.Text, true, false);

                    FSTI_initialized = true;

                    // Since this program is participating in unified logon, need to
                    // check if a logon is required.

                    if (_fstiClient.IsLogonRequired)
                    {
                        // Logon is required, enable the logon button
                        FSTI_Login.Enabled = true;
                        FSTI_Login.Focus();
                    }
                    else
                    {
                        // Logon is not required (because of unified logon), enable the SubmitItem button
                        //FSTI_Logout.Enabled = true;
                        //FSTI_Logout.Focus();

                        Server_Start.Enabled = true;
                        FSTI_CloseClient.Enabled = true;

                    }
                    // Disable the Initialize button
                    FSTI_Ini.Enabled = false;
                    return true;

                }
                catch (FSTIApplicationException exception)
                {
                    //MessageBox.Show(exception.Message, "FSTIApplication Exception");


                    string EmailTo = "acorrales@capsonic.com";
                    string Subject = "FS Movements Error " + DateTime.Now.ToString("MM-dd-yyy hh-mm"); ;

                    //AlternateView body= 
                    string Body = "Server Error: " + exception.Message;
                    mail.CreateMessage(EmailTo, Subject, Body);
                    mail.SendEmail();

                    _fstiClient.Terminate();
                    _fstiClient = null;
                    return false;
                }
            }

            return true;
        }
        private void FS_Login_Client()
        {
            string message = null;     // used to hold a return message, from the logon
            int status;         // receives the return value from the logon call
            if (!FSTI_loged)
            {
                status = _fstiClient.Logon(FS_User.Text, FS_Pass.Text, ref message);
                if (status > 0)
                {
                    MessageBox.Show("Invalid user id or password");
                }
                else
                {
                    FSTI_Login.Enabled = false;
                    Server_Start.Enabled = true;
                    FSTI_CloseClient.Enabled = true;
                    FSTI_loged = true;
                }
            }
        }
        private void FS_Close_Client()
        {
            if (!HangFS.Checked)
            {
                timer1.Stop();
                Server_Start.Enabled = true;
                Server_Stop.Enabled = false;

                if (_fstiClient != null)
                {
                    _fstiClient.Terminate();
                    _fstiClient = null;
                }
                FSTI_Ini.Enabled = true;
                FSTI_CloseClient.Enabled = false;
                FSTI_initialized = false;
                FSTI_loged = false;
            }
        }
         */
        #endregion

        #region Eventos Server Configuration
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            string update = "";

            string query = "SELECT _CAP_Shipment_Header.ShipmentNumber, _CAP_Shipment_Header.ShipmentType, _CAP_Shipment_Header.ShipmentStatus " +
                ", _CAP_Shipment_Line.ItemNumber, _CAP_Shipment_Line.StockRoomFrom, _CAP_Shipment_Line.BinFrom, _CAP_Shipment_Line.ItemUM " +
                ", _CAP_Shipment_Line.InventoryCat, _CAP_Shipment_Line.InventoryQTY, _CAP_Shipment_Line.FSTI_TransactionStatus " +
                ", _CAP_Shipment_Line.FSTI_TransactionMessage, _CAP_Shipment_Line.StockRoomTo, _CAP_Shipment_Line.BinTo " +
                ", _CAP_Shipment_Line.CapShipmentLineKey, _CAP_Shipment_Line.CapShipmentHeaderKey, _CAP_Shipment_Line.ItemKey, _CAP_Shipment_Line.LotNo " +
                "FROM _CAP_Shipment_Header INNER JOIN _CAP_Shipment_Line ON _CAP_Shipment_Header.CapShipmentHeadertKey = " +
                "_CAP_Shipment_Line.CapShipmentHeaderKey " +
                "WHERE     (_CAP_Shipment_Line.FSTI_TransactionStatus = 0) AND (_CAP_Shipment_Header.ShipmentType = 'Close') " +
                "AND (_CAP_Shipment_Header.ShipmentStatus = 'Shipped')  AND (_CAP_Shipment_Line.IsFSExternal = 0)";
            //string query = "SELECT * FROM _CAP_Shipment_Line";

            //string query2 = "SELECT     _CAP_Shipment_Line.CapShipmentHeaderKey, _CAP_Shipment_Line.ItemNumber, _CAP_Shipment_Line.InventoryQTY, _CAP_Shipment_Line.StockRoomFrom, "+
            //          " _CAP_Shipment_Line.BinFrom, _CAP_Shipment_Line.InventoryCat, _CAP_Shipment_Line.StockRoomTo, _CAP_Shipment_Line.BinTo,  "+
            //          " _CAP_Shipment_Line.IsFSExternal, _CAP_Shipment_Line.FSTI_Error, _CAP_Shipment_Line.FSTI_TransactionStatus,  "+
            //          " _CAP_Shipment_Line.FSTI_TransactionMessage, _CAP_Shipment_Line.ItemKey " +
            //          "   FROM         _CAP_Shipment_Header INNER JOIN "+
            //          "                         _CAP_Shipment_Line ON _CAP_Shipment_Header.CapShipmentHeadertKey = _CAP_Shipment_Line.CapShipmentHeaderKey "+
            //          "   WHERE     (_CAP_Shipment_Header.ShipmentNumber = N'PRIMERA-072213') AND (_CAP_Shipment_Line.IsFSExternal = 0) AND (_CAP_Shipment_Line.FSTI_Error = 0)";

            table = new DataTable();
            table = Cliente_SQL.Execute_Query(query);

            if (table.Rows.Count != dataGridView1.Rows.Count)
            {
                dataGridView1.DataSource = table;
            }
            else
            {
                DataTable DGV = (DataTable)dataGridView1.DataSource;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (table.Rows[i][j].ToString() == DGV.Rows[i][j].ToString())
                        {
                            //MessageBox.Show("Prueba");
                        }
                        else
                        {
                            i = table.Rows.Count;
                            j = table.Columns.Count;
                            dataGridView1.DataSource = table;
                        }
                    }
                }
            }
            //dataGridView1.Rows[0];

            
            bool ServerError = false;
            FSTI_Proceed = true;

            if (table.Rows.Count != 0)
            {
                try
                {

                    if (Proceed_trans == true)
                    {

                        if (FSTI_Proceed == true)
                        {
                            //if (FS_Initialize_Client())
                            #region Initialization
                            if (FSTI.AmalgammaFSTI_Initialization())
                            {
                                #region FSTI Login
                                if (FSTI.AmalgammaFSTI_Logon())
                                {
                                    #region FSTI Transaccion
                                    errors.Clear();
                                    counterBad = 0;
                                    couterGood = 0;
                                    for (int i = 0; i < table.Rows.Count; i++)
                                    {
                                        //if (!ServerError)
                                        //{
                                        //    proceed(i);
                                        //    //ServerError = FSTI.;
                                        //}

                                        if (proceed(i))
                                        {
                                            ProcessingLog("Transaction ended Susccesfully: " + FSTI.CDFResponse, "info");

                                            update = "UPDATE _CAP_Shipment_Line SET [FSTI_TransactionStatus] = 1,[FSTI_Error] = 0" +
                                                ",[FSTI_TransactionMessage] = '" + FSTI.CDFResponse + "' WHERE CapShipmentLineKey=" + table.Rows[i]["CapShipmentLineKey"].ToString();
                                            Cliente_SQL.Execute_Command(update);
                                            couterGood++;
                                        }
                                        else
                                        {
                                            if (DB_IN_USE != FSTI.Trans_Error_Msg)
                                            {
                                                ProcessingLog("Transaction Fail: Error Message:" + FSTI.Trans_Error_Msg + " CDF: " + FSTI.CDFResponse, "error");

                                                update = "UPDATE _CAP_Shipment_Line SET [FSTI_TransactionStatus] = 1" +
                                                    ",[FSTI_Error] = 1" +
                                                    ",[FSTI_TransactionMessage] = 'Error: " + FSTI.Trans_Error_Msg.Replace("'","\"") +// " Transaction: "+myItem.GetString(TransactionStringFormat.fsCDF)+ 
                                                    "' WHERE CapShipmentLineKey=" + table.Rows[i]["CapShipmentLineKey"].ToString();
                                                Cliente_SQL.Execute_Command(update);
                                                counterBad++;
                                                errors.Add("Part Number: " + table.Rows[i]["ItemNumber"].ToString() + " Error Message: " + FSTI.Trans_Error_Msg);
                                            }
                                            else
                                            {
                                                ProcessingLog("Transaction Fail: " + table.Rows[i]["ItemNumber"].ToString() + " - " + FSTI.Trans_Error_Msg, "warning");
                                            }
                                        }

                                    }
                                    string EmailTo = "receiving@capsonic.com,acorrales@capsonic.com";
                                    string Subject = "FS Movements " + DateTime.Now.ToString("MM-dd-yyy hh-mm"); ;

                                    //AlternateView body= 
                                    string Body = "";
                                    string Header = "Succesful: " + couterGood + " Fail: " + counterBad + Environment.NewLine + Environment.NewLine;
                                    for (int k = 0; k < errors.Count; k++)
                                    {
                                        Body = Body + errors[k] + Environment.NewLine;
                                    }

                                    //AlternateView HTMLbody = AlternateView.CreateAlternateViewFromString(Header + Body);
                                    //mail = null;
                                    //mail = new TOOLS.Email();
                                    //mail.CreateMessageHTML(EmailTo, Subject, HTMLbody);
                                    //mail.SendEmail();
                                    #endregion
                                }
                                else
                                {
                                    //MessageBox.Show(FSTI.ErrorMsg, "Error During Login");
                                    ProcessingLog("FSTI-Error During Login - " + FSTI.FSTI_ErrorMsg, "error");
                                    FSTI_Error_Flag = true;
                                }
                            }
                                #endregion
                            else
                            {
                                //MessageBox.Show(FSTI.ErrorMsg, "Error During FSTI Inicialitation");
                                ProcessingLog("FSTI-Error During FSTI Inicialitation - " + FSTI.FSTI_ErrorMsg, "error");
                                FSTI_Error_Flag = true;
                            }
                            //FS_Close_Client();
                            FSTI.AmalgammaFSTI_Stop();
                            #endregion

                        }
                    }
                }
                catch (Exception ex)
                {
                    ProcessingLog("FSTI-Error Exeption - " + ex.Message, "error");
                    //MessageBox.Show(ex.Message, "Error FSTI Exeption");
                    FSTI.AmalgammaFSTI_Stop();
                }
            }

           timer1.Start();
        }

        #region Config Tab
        
        private void StartButton()
        {
            timer1.Start();
            Server_Start.Enabled = false;
            Server_Stop.Enabled = true;
            FSTI_Trans.Enabled = true;        
        }
        private void FSTI_TransButton()
        {
            Proceed_trans = true;
            Procced.Text = "Proceed with FSTI Transactions";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StartButton();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            StopServer();
            Proceed_trans = true;
            Procced.Text = "";
        }
        private void FSTI_Ini_Click(object sender, EventArgs e)
        {

            //FS_Initialize_Client();

            //try
            //{
            //    _fstiClient = new FSTIClient();

            //    // call InitializeByConfigFile
            //    // second parameter == true is to participate in unified logon
            //    // third parameter == false, no support for impersonation is needed

            //    _fstiClient.InitializeByConfigFile(textConfig.Text, true, false);

            //    // Since this program is participating in unified logon, need to
            //    // check if a logon is required.

            //    if (_fstiClient.IsLogonRequired)
            //    {
            //        // Logon is required, enable the logon button
            //        FSTI_Login.Enabled = true;
            //        FSTI_Login.Focus();
            //    }
            //    else
            //    {
            //        // Logon is not required (because of unified logon), enable the SubmitItem button
            //        //FSTI_Logout.Enabled = true;
            //        //FSTI_Logout.Focus();

            //        Server_Start.Enabled = true;
            //        FSTI_CloseClient.Enabled = true;

            //    }
            //    // Disable the Initialize button
            //    FSTI_Ini.Enabled = false;


            //}
            //catch (FSTIApplicationException exception)
            //{
            //    MessageBox.Show(exception.Message, "FSTIApplication Exception");
            //    _fstiClient.Terminate();
            //    _fstiClient = null;
            //}
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialogo = new OpenFileDialog();
            //|Bitmap files (*.bmp)|*.bmp|Gif files (*.gif)|*.gif|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*
            Dialogo.Filter = "CFG files (*.cfg)|*.cfg|All files (*.*)|*.*";
            Dialogo.RestoreDirectory = true;
            if (DialogResult.OK == Dialogo.ShowDialog())
            {
                textConfig.Text = Dialogo.FileName.ToString();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_fstiClient != null)
            {
                _fstiClient.Terminate();
                _fstiClient = null;
            }
        }
        private void FSTI_Login_Click(object sender, EventArgs e)
        {
            //FS_Login_Client();

            //string message = null;     // used to hold a return message, from the logon
            //int status;         // receives the return value from the logon call

            //status = _fstiClient.Logon(FS_User.Text, FS_Pass.Text, ref message);
            //if (status > 0)
            //{
            //    MessageBox.Show("Invalid user id or password");
            //}
            //else
            //{
            //    FSTI_Login.Enabled = false;
            //    Server_Start.Enabled = true;
            //    FSTI_CloseClient.Enabled = true;
            //} 
        }
        private void FSTI_CloseClient_Click(object sender, EventArgs e)
        {

            //FS_Close_Client();

            //timer1.Stop();
            //Server_Start.Enabled = false;
            //Server_Stop.Enabled = false;
            
            //if (_fstiClient != null)
            //{
            //    _fstiClient.Terminate();
            //    _fstiClient = null;
            //}
            //FSTI_Ini.Enabled = true;
            //FSTI_CloseClient.Enabled = false;
        }
        #endregion

        #endregion
        /*
        private bool ExecuteTransaction(string ItemKey)
        {
            string update = "";
            try
            {
                if (_fstiClient.ProcessId(myItem, null))
                {
                    // success, get the response and display it using a list box
                    listResult.Items.Add("Success:");
                    listResult.Items.Add("");
                    listResult.Items.Add(_fstiClient.CDFResponse);
                    update = "UPDATE _CAP_Shipment_Line SET [FSTI_TransactionStatus] = 1,[FSTI_Error] = 0" +
                        ",[FSTI_TransactionMessage] = '" + _fstiClient.CDFResponse + "' WHERE ItemKey=" + ItemKey;
                    Cliente_SQL.Execute_Command(update);
                    couterGood++;
                }
                else
                {
                    // failure, retrieve the error object 
                    // and then dump the information in the list box
                    FSTIError itemError = _fstiClient.TransactionError;
                    DumpErrorObject(myItem, itemError);

                    update = "UPDATE _CAP_Shipment_Line SET [FSTI_TransactionStatus] = 1" +
                        ",[FSTI_Error] = 1" +
                        ",[FSTI_TransactionMessage] = 'Error: " + itemError.Description +// " Transaction: "+myItem.GetString(TransactionStringFormat.fsCDF)+ 
                        "' WHERE ItemKey=" + ItemKey;
                    Cliente_SQL.Execute_Command(update);
                    counterBad++;
                    errors.Add("Part Number: " + myItem.ItemNumber.Value.ToString() + " Error Message: " + itemError.Description);
                }
                return false;
            }
            catch(Exception ex)
            {
                StopServer();


                string EmailTo = "acorrales@capsonic.com";
                string Subject = "FS Movements Error " + DateTime.Now.ToString("MM-dd-yyy hh-mm"); ;

                //AlternateView body= 
                string Body = "Server Error: " + ex.Message;
                mail.CreateMessage(EmailTo, Subject, Body);
                mail.SendEmail();

                //MessageBox.Show(ex.Message,"Server Error");
                return true;
            }
        }
        */
        private void FSTI_Trans_Click(object sender, EventArgs e)
        {
            FSTI_TransButton();
        }

        #region Logger

        private void ProcessingLog(string Log, string type)
        {
            string DateStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            listResult.Items.Add("");
            listResult.Items.Add(DateStamp + " - " + Log);

            switch (type)
            {
                case "error":
                    {
                        LOGGER.WriteLogLine(TOOLS.Dataloger.Category.Error, Log);
                        break;
                    }
                case "info":
                    {
                        LOGGER.WriteLogLine(TOOLS.Dataloger.Category.Info, Log);
                        break;
                    }
                case "warning":
                    {
                        LOGGER.WriteLogLine(TOOLS.Dataloger.Category.Warning, Log);
                        break;
                    }
            }

        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            listResult.Items.Clear();
        }

    }
}
