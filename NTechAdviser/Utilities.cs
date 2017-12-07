using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using NTechAdviser.Forms;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Globalization;

namespace NTechAdviser
{
    /// <summary>
    /// 
    /// </summary>
    public class Utilities
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(Utilities));
        /// <summary>
        /// Gets the management information data set.
        /// </summary>
        /// <param name="cmdString">The command string.</param>
        /// <returns></returns>
        public DataSet GetManagementInfoDataSet(string cmdString)
        {
            DataSet ds = new DataSet();
            try
            {
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connection.ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdString);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dataAd = new SqlDataAdapter(cmdString, conn);
                dataAd.Fill(ds);
                dataAd.Dispose();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error when getting ManagementInfo dataset.", ex);
            }
            return ds;
        }

        public DataSet GetCreditDebitInfo()
        {
            DataSet ds = new DataSet();
            try
            {
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connection.ToString());
                conn.Open();

                SqlCommand cmd = new SqlCommand("p_getAccInfoCreDebInfoJoin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
                dataAd.Fill(ds);
                dataAd.Dispose();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error when getting CreditDebit dataset.", ex);
            }
            return ds;
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public UserInfo GetUserDetails(string userName)
        {
            UserInfo retVal = new UserInfo();
            string cmdString = "select * from user_info where username=" + "\'" + userName + "\'";
            DataSet ds = new DataSet();
            try
            {
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connection.ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdString);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dataAd = new SqlDataAdapter(cmdString, conn);
                dataAd.Fill(ds);
                dataAd.Dispose();
                cmd.Dispose();
                conn.Close();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    UserInfo userInfo = new UserInfo();
                    retVal.UserName = GetValueOrNullForString(ds.Tables[0].Rows[0], "UserName");
                    retVal.UserType = GetValueOrNullForInt(ds.Tables[0].Rows[0], "Type");
                    retVal.Password = GetValueOrNullForString(ds.Tables[0].Rows[0], "Password");
                }
                else
                {
                    log.Info("No user details found for this user.");
                    retVal.UserException = "No user found.";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error when getting UserInfo details.", ex);
            }
            return retVal;
        }


        /// <summary>
        /// Gets the unlock key data.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public string GetUnlockKeyData()
        {
            string retVal = string.Empty;
            string cmdString = "select AdminUnlockKey from admin_unlockkey";
            DataSet ds = new DataSet();
            try
            {
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connection.ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdString);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dataAd = new SqlDataAdapter(cmdString, conn);
                dataAd.Fill(ds);
                dataAd.Dispose();
                cmd.Dispose();
                conn.Close();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    retVal = GetValueOrNullForString(ds.Tables[0].Rows[0], "AdminUnlockKey");
                }
                else
                {
                    log.Info("No details found for unlock key.");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error when getting unlock key info details.", ex);
            }
            return retVal;
        }

        public int AddUserInfo(string username, string email, string password, int userType)
        {
            int retVal = 0;
            try
            {
                var connString = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString.ToString());

                SqlCommand cmd = new SqlCommand("p_addUserInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserName", SqlDbType.Text).Value = username;
                cmd.Parameters.Add("@UserEmail", SqlDbType.Text).Value = email;
                cmd.Parameters.Add("@Password", SqlDbType.Text).Value = password;
                cmd.Parameters.Add("@Type", SqlDbType.Int).Value = userType;

                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                conn.Close();

                UpdateCacheData(); //Update the Cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                log.Error("Error when adding Accounts data.", ex);
            }
            return retVal;
        }

        /// <summary>
        /// Executes the add accounts data.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="particulars">The particulars.</param>
        /// <param name="paymentMode">The payment mode.</param>
        /// <param name="payModeRef">The pay mode preference.</param>
        /// <param name="debit">The debit.</param>
        /// <param name="credit">The credit.</param>
        /// <param name="pendingDebit">The pending debit.</param>
        /// <param name="pendingCredit">The pending credit.</param>
        /// <param name="details">The details.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public int ExecuteAddAccountsData(string projectName, string particulars, string paymentMode, string bankDetails, string payModeRef, decimal debit, decimal credit, decimal pendingDebit, decimal pendingCredit, string createdBy, string updatedBy, string details, string tag, string createdDate, string updatedDate)
        {
            int retVal = 0;
            try
            {
                var connString = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString.ToString());

                SqlCommand cmd = new SqlCommand("p_addAccountsData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Project", SqlDbType.Text).Value = projectName;
                cmd.Parameters.Add("@Particulars", SqlDbType.Text).Value = particulars;
                cmd.Parameters.Add("@PayMode", SqlDbType.Text).Value = paymentMode;
                cmd.Parameters.Add("@BankDetails", SqlDbType.Text).Value = bankDetails;
                cmd.Parameters.Add("@PayModeReference", SqlDbType.Text).Value = payModeRef;
                cmd.Parameters.Add("@Debit", SqlDbType.Money).Value = debit;
                cmd.Parameters.Add("@Credit", SqlDbType.Money).Value = credit;
                cmd.Parameters.Add("@PendingDebit", SqlDbType.Money).Value = pendingDebit;
                cmd.Parameters.Add("@PendingCredit", SqlDbType.Money).Value = pendingCredit;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.Text).Value = createdBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Text).Value = updatedBy;
                cmd.Parameters.Add("@Details", SqlDbType.Text).Value = details;
                cmd.Parameters.Add("@Tag", SqlDbType.Text).Value = tag;
                cmd.Parameters.Add("@DateCreated", SqlDbType.Date).Value = createdDate;
                cmd.Parameters.Add("@DateUpdated", SqlDbType.Date).Value = updatedDate;

                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                conn.Close();

                UpdateCacheData(); //Update the Cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                log.Error("Error when adding Accounts data.", ex);
            }
            return retVal;
        }

        /// <summary>
        /// Validates the date.
        /// </summary>
        /// <param name="inputDate">The input date.</param>
        /// <returns></returns>
        public string ValidateDate(string inputDate)
        {
            string retVal = inputDate;
            try
            {
                DateTime dateValue;
                if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateValue))
                {
                    return dateValue.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {

            }
            return retVal;
        }

        /// <summary>
        /// Adds the unlock key data.
        /// </summary>
        /// <param name="adminUserKey">The admin user key.</param>
        /// <returns></returns>
        public int AddUnlockKeyData(string adminUserKey)
        {
            int retVal = 0;
            try
            {
                var connString = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString.ToString());

                SqlCommand cmd = new SqlCommand("p_addUnlockKey", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AdminUnlockKey", SqlDbType.Text).Value = adminUserKey;

                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                conn.Close();

                UpdateCacheData(); //Update the Cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                log.Error("Error when adding Accounts data.", ex);
            }
            return retVal;
        }

        /// <summary>
        /// Executes the add stock data.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="particulars">The particulars.</param>
        /// <param name="paymentMode">The payment mode.</param>
        /// <param name="bankDetails">The bank details.</param>
        /// <param name="payModeRef">The pay mode preference.</param>
        /// <param name="slipNo">The slip no.</param>
        /// <param name="inwardBillNo">The inward bill no.</param>
        /// <param name="volume">The volume.</param>
        /// <param name="debit">The debit.</param>
        /// <param name="credit">The credit.</param>
        /// <param name="item">The item.</param>
        /// <param name="unitsIn">The units information.</param>
        /// <param name="unitsOut">The units out.</param>
        /// <param name="vehicleNo">The vehicle no.</param>
        /// <param name="details">The details.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public int ExecuteAddStockData(string projectName, string particulars, string paymentMode, string bankDetails, string payModeRef, string slipNo, string inwardBillNo, string volume, decimal debit, decimal credit, string item, decimal unitsIn, decimal unitsOut, string itemSize, string vehicleNo, string details, string tag, string createdBy, string updatedBy, string createdDate, string updatedDate)
        {
            int retVal = 0;
            try
            {
                var connString = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString.ToString());

                SqlCommand cmd = new SqlCommand("p_addStockAndAccountsData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Project", SqlDbType.Text).Value = projectName;
                cmd.Parameters.Add("@Particulars", SqlDbType.Text).Value = particulars;

                cmd.Parameters.Add("@Item", SqlDbType.Text).Value = item;
                cmd.Parameters.Add("@UnitsIn", SqlDbType.Float).Value = unitsIn;
                cmd.Parameters.Add("@UnitsOut", SqlDbType.Float).Value = unitsOut;
                cmd.Parameters.Add("@ItemSize", SqlDbType.Text).Value = itemSize;
                cmd.Parameters.Add("@VehicleNo", SqlDbType.Text).Value = vehicleNo;

                cmd.Parameters.Add("@SlipNo", SqlDbType.Text).Value = slipNo;
                cmd.Parameters.Add("@InwardBillNo", SqlDbType.Text).Value = inwardBillNo;
                cmd.Parameters.Add("@Volume", SqlDbType.Text).Value = volume;


                cmd.Parameters.Add("@CreatedBy", SqlDbType.Text).Value = createdBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Text).Value = updatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = createdDate;
                cmd.Parameters.Add("@UpdatedDate", SqlDbType.Date).Value = updatedDate;


                cmd.Parameters.Add("@PayMode", SqlDbType.Text).Value = paymentMode;
                cmd.Parameters.Add("@BankDetails", SqlDbType.Text).Value = bankDetails;
                cmd.Parameters.Add("@PayModeReference", SqlDbType.Text).Value = payModeRef;
                cmd.Parameters.Add("@Debit", SqlDbType.Money).Value = debit;
                cmd.Parameters.Add("@Credit", SqlDbType.Money).Value = credit;
                cmd.Parameters.Add("@Details", SqlDbType.Text).Value = details;
                cmd.Parameters.Add("@Tag", SqlDbType.Text).Value = tag;

                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                conn.Close();

                UpdateCacheData(); //Update the Cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error when adding Stock Data for the record - Project Name - {0}, Particular - {1}, Item - {2}, SlipNo - {3}", projectName, particulars, item, slipNo), "Add Stock Failed for Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error when adding Accounts data.", ex);
            }
            return retVal;
        }

        /// <summary>
        /// Updates the acccounts data.
        /// </summary>
        /// <param name="accInfo">The acc information.</param>
        /// <returns></returns>
        public int UpdateAcccountsData(AccountsInfo accInfo)
        {
            int retVal = 0;
            try
            {
                string cmdText = string.Format("Update accounts_info set DateUpdated=GETDATE(), Project='{0}', Particulars='{1}', Debit={2}, Credit={3}, Details='{4}', Tag='{5}', PayMode='{6}', PayModeReference='{7}', UpdatedBy='{8}', DateUpdated='{9}' where accounts_info.RecordID={10}",
                    accInfo.ProjectName,
                    accInfo.Particulars,
                    accInfo.Debit,
                    accInfo.Credit,
                    accInfo.Details,
                    accInfo.Tag,
                    accInfo.PayMode,
                    accInfo.PayModeReference,
                    accInfo.UpdatedBy,
                    accInfo.UpdatedDate,
                    accInfo.RecordID
                    );
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connection.ToString());
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                UpdateCacheData(); //Update cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                log.Error("Error when updating Accounts data.", ex);
            }
            return retVal;
        }

        /// <summary>
        /// Deletes the acccounts data.
        /// </summary>
        /// <param name="accInfo">The acc information.</param>
        /// <returns></returns>
        public int DeleteAcccountsData(AccountsInfo accInfo)
        {
            int retVal = 0;
            try
            {
                string cmdText = string.Format("delete from accounts_info where accounts_info.RecordID={0}", accInfo.RecordID);
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connection.ToString());
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                UpdateCacheData(); //Update cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when deleting a record.", "Delete?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Error when updating Accounts data.", ex);
            }
            return retVal;
        }

        /// <summary>
        /// Updates the acccounts data.
        /// </summary>
        /// <param name="accInfo">The acc information.</param>
        /// <returns></returns>
        public int AddCreditDebitInfo(CreditDebitInfo creDebInfo)
        {
            int retVal = 0;
            try
            {
                var connString = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString.ToString());

                SqlCommand cmd = new SqlCommand("p_addDebitData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Project", SqlDbType.Text).Value = creDebInfo.Project;
                cmd.Parameters.Add("@Particulars", SqlDbType.Text).Value = creDebInfo.Particulars;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.Text).Value = creDebInfo.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Text).Value = creDebInfo.LastUpdatedBy;

                cmd.Parameters.Add("@DateCreated", SqlDbType.Date).Value = creDebInfo.CreatedDate;
                cmd.Parameters.Add("@DateUpdated", SqlDbType.Date).Value = creDebInfo.LastUpdatedDate;

                cmd.Parameters.Add("@Debit", SqlDbType.Money).Value = creDebInfo.Debit;
                cmd.Parameters.Add("@Credit", SqlDbType.Money).Value = creDebInfo.Credit;
                cmd.Parameters.Add("@Details", SqlDbType.Text).Value = creDebInfo.Details;
                cmd.Parameters.Add("@Tag", SqlDbType.Text).Value = creDebInfo.Tag;

                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                conn.Close();

                UpdateCacheData(); //Update the Cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                log.Error("Error when adding Accounts data.", ex);
            }
            return retVal;
        }

        public int UpdateCreditDebitInfo(CreditDebitInfo creDebInfo)
        {
            int retVal = 0;
            try
            {
                var connString = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString.ToString());

                SqlCommand cmd = new SqlCommand("p_updateDebitData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Project", SqlDbType.Text).Value = creDebInfo.Project;
                cmd.Parameters.Add("@Particulars", SqlDbType.Text).Value = creDebInfo.Particulars;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Text).Value = creDebInfo.LastUpdatedBy;
                cmd.Parameters.Add("@UpdatedDate", SqlDbType.Date).Value = creDebInfo.LastUpdatedDate;
                cmd.Parameters.Add("@Debit", SqlDbType.Money).Value = creDebInfo.Debit;
                cmd.Parameters.Add("@Credit", SqlDbType.Money).Value = creDebInfo.Credit;
                cmd.Parameters.Add("@Details", SqlDbType.Text).Value = creDebInfo.Details;
                cmd.Parameters.Add("@Tag", SqlDbType.Text).Value = creDebInfo.Tag;

                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                conn.Close();

                UpdateCacheData(); //Update the Cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                log.Error("Error when adding Accounts data.", ex);
            }
            return retVal;
        }

        public void UpdateCacheData()
        {
            try
            {
                DataSet dsProjects = GetManagementInfoDataSet("select DISTINCT accounts_info.Project \"Project\" from accounts_info UNION select DISTINCT credit_debit_info.Project from credit_debit_info");
                var projects = dsProjects.Tables[0].AsEnumerable().Select(r => r.Field<string>("Project")).ToList();
                if (projects != null)
                    ApplicationContext.ProjectNames = projects;
            }
            catch (Exception ex)
            {
                log.Error("Error when updating cache data - Projects information.", ex);
            }
            try
            {
                DataSet dsParticulars = GetManagementInfoDataSet("select DISTINCT accounts_info.Particulars \"Particulars\" from accounts_info UNION select DISTINCT credit_debit_info.Particulars from credit_debit_info");
                var particulars = dsParticulars.Tables[0].AsEnumerable().Select(r => r.Field<string>("Particulars")).ToList();
                if (particulars != null)
                    ApplicationContext.ParticularDetails = particulars;
            }
            catch (Exception ex)
            {
                log.Error("Error when updating cache data - Particulars information.", ex);
            }
        }

        internal int UpdateStockInfoData(StockInfo stockInfo)
        {
            int retVal = 0;
            try
            {
                var connString = System.Configuration.ConfigurationManager.ConnectionStrings["info_managementConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString.ToString());

                SqlCommand cmd = new SqlCommand("p_updateStockData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@RecordID", SqlDbType.BigInt).Value = stockInfo.RecordID;
                cmd.Parameters.Add("@Project", SqlDbType.Text).Value = stockInfo.ProjectName;
                cmd.Parameters.Add("@Particulars", SqlDbType.Text).Value = stockInfo.Particulars;
                cmd.Parameters.Add("@Item", SqlDbType.Text).Value = stockInfo.Item;

                cmd.Parameters.Add("@SlipNo", SqlDbType.Text).Value = stockInfo.SlipNo;
                cmd.Parameters.Add("@InwardBillNo", SqlDbType.Text).Value = stockInfo.InwardBillNo;
                cmd.Parameters.Add("@Volume", SqlDbType.Text).Value = stockInfo.Volume;
                cmd.Parameters.Add("@ItemSize", SqlDbType.Text).Value = stockInfo.ItemSize;

                cmd.Parameters.Add("@UnitsIn", SqlDbType.Float).Value = stockInfo.UnitsIn;
                cmd.Parameters.Add("@UnitsOut", SqlDbType.Float).Value = stockInfo.UnitsOut;
                cmd.Parameters.Add("@VehicleNo", SqlDbType.Text).Value = stockInfo.VehicleNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Text).Value = stockInfo.UpdatedBy;
                cmd.Parameters.Add("@UpdatedDate", SqlDbType.Date).Value = stockInfo.DateUpdated;
                cmd.Parameters.Add("@Debit", SqlDbType.Money).Value = stockInfo.Debit;
                cmd.Parameters.Add("@Credit", SqlDbType.Money).Value = stockInfo.Credit;
                cmd.Parameters.Add("@Details", SqlDbType.Text).Value = stockInfo.Details;
                cmd.Parameters.Add("@Tag", SqlDbType.Text).Value = stockInfo.Tag;

                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                conn.Close();

                UpdateCacheData(); //Update the Cache data when some change happens in DB.
            }
            catch (Exception ex)
            {
                log.Error("Error when adding Accounts data.", ex);
            }
            return retVal;
        }

        private string GetValueOrNullForString(DataRow row, string columnName)
        {
            string retVal = string.Empty;
            retVal = (row[columnName] == null) ? string.Empty : row[columnName].ToString();
            return retVal;
        }

        private Decimal GetValueOrNullForDecimal(DataRow row, string columnName)
        {
            Decimal retVal = 0;
            retVal = (row[columnName] == null) ? 0 : Convert.ToDecimal(row[columnName]);
            return retVal;
        }

        private int GetValueOrNullForInt(DataRow row, string columnName)
        {
            int retVal = 0;
            retVal = (row[columnName] == null) ? 0 : Convert.ToInt32(row[columnName]);
            return retVal;
        }

        private DateTime? GetValueOrNullForDate(DataRow row, string columnName)
        {
            DateTime? date = Convert.ToDateTime(row[columnName]);
            return date;
        }

        public string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string Decrypt(string input, string key)
        {
            string retVal = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                retVal = UTF8Encoding.UTF8.GetString(resultArray);
            }
            return retVal;
        }
    }
}
