using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionHistory.Model;

namespace MissionHistory.DataAccessLayer
{
    public class OperationsDal
    {

        public static DataSet GetAllVehicles()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllVehicles", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllNationalities()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllNationalities", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetActiveRescuers()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetActiveRescuers", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetMissionCategories()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllMissionCategories", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllMissionDirections()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllMissionDirections", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllCaseTypes()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllCaseTypes", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static string GetTeamLeaderName(int idTeamLeader)
        {
            object teamLeaderName;
            string connectionString;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetRescuerName", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@RescuerId", SqlDbType.Int).Value = idTeamLeader;

                        //Open DB connection
                        connection.Open();

                        //Return scalar(object)
                        teamLeaderName = command.ExecuteScalar();
                        
                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return teamLeaderName.ToString();
        }

        public static DataSet GetAllCases()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllCases", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllCaseClassifications()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllCaseClassifications", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllAreas()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllAreas", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllHospitals()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllHospitals", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllNursingHomes()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllNursingHomes", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllMissionStatuses()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllMissionStatuses", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetCurrentMissions()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetCurrentMissions", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static int AddMission(int IdVehicle, int Status, DateTime ScheduledTime)
        {
            int newId;
            string connectionString;

            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddNewMission", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@IdVehicle", SqlDbType.Int).Value = IdVehicle;
                        command.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
                        command.Parameters.Add("@ScheduledTime", SqlDbType.DateTime).Value = ScheduledTime;

                        //Open DB connection
                        connection.Open();

                        //Execute procedure
                        newId = command.ExecuteNonQuery();

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return newId;
        }

        public static int AddMission(int IdVehicle, int Status, int IdMissionCategory, int IdMissionDirection, int FromDirectionFlag, int IdFrom, DateTime ScheduledDatetime)
        {
            int newId;
            string connectionString;

            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddMission", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@ScheduledTime", SqlDbType.DateTime).Value = ScheduledDatetime;
                        command.Parameters.Add("@IdVehicle", SqlDbType.Int).Value = IdVehicle;
                        command.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
                        command.Parameters.Add("@IdMissionCategory", SqlDbType.Int).Value = IdMissionCategory;
                        command.Parameters.Add("@IdMissionDirection", SqlDbType.Int).Value = IdMissionDirection;
                        command.Parameters.Add("@FromDirectionFlag", SqlDbType.Int).Value = FromDirectionFlag;
                        command.Parameters.Add("@IdFrom", SqlDbType.Int).Value = IdFrom;

                        //Open DB connection
                        connection.Open();

                        //Execute procedure
                        newId = command.ExecuteNonQuery();

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return newId;
        }

        public static void UpdateVehicleLocation(int idMission, int Status)
        {
            string connectionString;

            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateVehicleLocationAndTiming", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@IdMission", SqlDbType.Int).Value = idMission;
                        command.Parameters.Add("@Status", SqlDbType.Int).Value = Status;

                        //Open DB connection
                        connection.Open();

                        //Execute procedure
                        command.ExecuteNonQuery();

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void UpdateMissionDuration(double totalMinutes, int idMission)
        {
            string connectionString;

            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateMissionDuration", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@IdMission", SqlDbType.Int).Value = idMission;
                        command.Parameters.Add("@MissionDurationInMinutes", SqlDbType.Decimal).Value = totalMinutes;

                        //Open DB connection
                        connection.Open();

                        //Execute procedure
                        command.ExecuteNonQuery();

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetDayMissions()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllDayMissions", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetDayMissions(DateTime DateFrom, DateTime DateTo)
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetDayMissions", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateFrom;
                        command.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTo;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetSpecificMission(int IdMission)
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetSpecificMission", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@IdMission", SqlDbType.Int).Value = IdMission;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static void UpdateMission(Mission selectedMission)
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateMissionDetails", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@IdMission", SqlDbType.Int).Value = selectedMission.ID;
                        command.Parameters.Add("@ScheduledTime", SqlDbType.DateTime).Value = selectedMission.ScheduledTime;
                        command.Parameters.Add("@DepartureToCaseTime", SqlDbType.DateTime).Value = selectedMission.DepartureToCaseTime;
                        command.Parameters.Add("@ArrivalToCaseTime", SqlDbType.DateTime).Value = selectedMission.ArrivalToCaseTime;
                        command.Parameters.Add("@DepartureToDestinationTime", SqlDbType.DateTime).Value = selectedMission.DepartureToDestinationTime;
                        command.Parameters.Add("@ArrivalToDestinationTime", SqlDbType.DateTime).Value = selectedMission.ArrivalToDestinationTime;
                        command.Parameters.Add("@MissionCompletedTime", SqlDbType.DateTime).Value = selectedMission.MissionCompletedTime;
                        command.Parameters.Add("@ReturnToStationTime", SqlDbType.DateTime).Value = selectedMission.ReturnToStationTime;
                        command.Parameters.Add("@MissionDurationInMinutes", SqlDbType.Decimal).Value = selectedMission.MissionDurationInMinutes;
                        command.Parameters.Add("@IdVehicle", SqlDbType.Int).Value = selectedMission.IdVehicle;
                        command.Parameters.Add("@InitialMileage", SqlDbType.Int).Value = selectedMission.InitialMileage;
                        command.Parameters.Add("@FinalMileage", SqlDbType.Int).Value = selectedMission.FinalMileage;
                        command.Parameters.Add("@TraveledDistanceInKm", SqlDbType.Int).Value = selectedMission.TraveledDistanceInKm;
                        command.Parameters.Add("@IdDriver", SqlDbType.Int).Value = selectedMission.IdDriver;
                        command.Parameters.Add("@IdRescuer1", SqlDbType.Int).Value = selectedMission.IdRescuer1;
                        command.Parameters.Add("@IdRescuer2", SqlDbType.Int).Value = selectedMission.IdRescuer2;
                        command.Parameters.Add("@IdRescuer3", SqlDbType.Int).Value = selectedMission.IdRescuer3;
                        command.Parameters.Add("@IdRescuer4", SqlDbType.Int).Value = selectedMission.IdRescuer4;
                        command.Parameters.Add("@IdMissionCategory", SqlDbType.Int).Value = selectedMission.IdMissionCategory;
                        command.Parameters.Add("@IdMissionDirection", SqlDbType.Int).Value = selectedMission.IdMissionDirection;
                        command.Parameters.Add("@IdFromArea", SqlDbType.Int).Value = selectedMission.IdFromArea;
                        command.Parameters.Add("@IdFromHospital", SqlDbType.Int).Value = selectedMission.IdFromHospital;
                        command.Parameters.Add("@IdFromNursingHome", SqlDbType.Int).Value = selectedMission.IdFromNursingHome;
                        command.Parameters.Add("@IdToArea", SqlDbType.Int).Value = selectedMission.IdToArea;
                        command.Parameters.Add("@IdToHospital", SqlDbType.Int).Value = selectedMission.IdToHospital;
                        command.Parameters.Add("@IdToNursingHome", SqlDbType.Int).Value = selectedMission.IdToNursingHome;
                        command.Parameters.Add("@PatientName", SqlDbType.NVarChar).Value = selectedMission.PatientFullName;
                        command.Parameters.Add("@PatientYob", SqlDbType.Int).Value = selectedMission.PatientYob;
                        command.Parameters.Add("@IdPatientNationality", SqlDbType.Int).Value = selectedMission.IdPatientNationality;
                        command.Parameters.Add("@IdCaseType", SqlDbType.Int).Value = selectedMission.IdCaseType;
                        command.Parameters.Add("@IdCase", SqlDbType.Int).Value = selectedMission.IdCase;
                        command.Parameters.Add("@IdCaseClassification", SqlDbType.Int).Value = selectedMission.IdCaseClassification;
                        command.Parameters.Add("@CaseDescription", SqlDbType.NVarChar).Value = selectedMission.CaseDescription;
                        command.Parameters.Add("@PassengerName", SqlDbType.NVarChar).Value = selectedMission.PassengerFullName;
                        command.Parameters.Add("@PassengerYob", SqlDbType.Int).Value = selectedMission.PassengerYob;
                        command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = selectedMission.Notes;
                        command.Parameters.Add("@Status", SqlDbType.Int).Value = selectedMission.Status;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void UpdateVehicleLastMileage(int idVehicle, int finalMileage)
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateVehicleFinalMileage", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@IdVehicle", SqlDbType.Int).Value = idVehicle;
                        command.Parameters.Add("@FinalMileage", SqlDbType.Int).Value = finalMileage;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetSpecificShiftReport(DateTime shiftDateFrom, DateTime shiftDateTo)
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetSpecificShiftReport", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@ShiftDateFrom", SqlDbType.DateTime).Value = shiftDateFrom;
                        command.Parameters.Add("@ShiftDateTo", SqlDbType.DateTime).Value = shiftDateTo;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllTeamLeaders()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllTeamLeaders", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static void AddOrUpdateShiftReport(ShiftReport shiftReport)
        {
            DateTime from = new DateTime(shiftReport.ShiftDate.Year, shiftReport.ShiftDate.Month, shiftReport.ShiftDate.Day, 0, 0, 0);
            DateTime to = new DateTime(shiftReport.ShiftDate.Year, shiftReport.ShiftDate.Month, shiftReport.ShiftDate.Day, 23, 59, 59);

            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddOrUpdateShiftReport", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = from;
                        command.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = to;
                        command.Parameters.Add("@Damaged476", SqlDbType.Bit).Value = shiftReport.IsDamaged476;
                        command.Parameters.Add("@Damaged477", SqlDbType.Bit).Value = shiftReport.IsDamaged477;
                        command.Parameters.Add("@Damaged478", SqlDbType.Bit).Value = shiftReport.IsDamaged478;
                        command.Parameters.Add("@Damaged479", SqlDbType.Bit).Value = shiftReport.IsDamaged479;
                        command.Parameters.Add("@Damaged480", SqlDbType.Bit).Value = shiftReport.IsDamaged480;
                        command.Parameters.Add("@Damaged443", SqlDbType.Bit).Value = shiftReport.IsDamaged443;
                        command.Parameters.Add("@SoinAuCentre", SqlDbType.Int).Value = shiftReport.SoinAuCentre;
                        command.Parameters.Add("@NumberOfRescuers", SqlDbType.Int).Value = shiftReport.NumberOfRescuers;
                        command.Parameters.Add("@NumberOfTeams", SqlDbType.Int).Value = shiftReport.NumberOfTeams;
                        command.Parameters.Add("@IdTeamLeader", SqlDbType.Int).Value = shiftReport.IdTeamLeader;
                        command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = shiftReport.Notes;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetDailyMissionReport(DateTime from, DateTime to)
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetDailyReport", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = from;
                        command.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = to;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static void DeleteMission(int idMission)
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DeleteMission", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@IdMission", SqlDbType.Int).Value = idMission;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetAllStations()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllStations", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static DataSet GetAllBtsCenters()
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllBtsCenters", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsValue;
        }

        public static void UpdateNumberOfInjured(int missionId, int numberOfInjured)
        {
            string connectionString;
            SqlDataAdapter dataAdapter;
            DataSet dsValue;
            try
            {
                //Get the connection string
                connectionString = MissionHistory.Properties.Settings.Default.ConnectionString;

                //Create connection, command and execute stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateNumberOfInjured", connection))
                    {
                        //Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        //Set parameters
                        command.Parameters.Add("@IdMission", SqlDbType.Int).Value = missionId;
                        command.Parameters.Add("@NumberOfInjured", SqlDbType.Int).Value = numberOfInjured;

                        //Use the Sql Data Adapter and link it to the command
                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;

                        //Open DB connection
                        connection.Open();

                        //Fill Dataset
                        dsValue = new DataSet();
                        dataAdapter.Fill(dsValue);

                        //Close DB connection
                        connection.Close();
                    }
                }
            }
            catch (DataException dEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
