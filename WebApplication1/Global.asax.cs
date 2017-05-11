using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1.Hubs;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string _connectionString;
        private IHubContext _liveMonitorHub;
        private IHubContext _deviceRegestrationHub;
        private DateTime _deviceRegChangeTimeStamp;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            _connectionString = "Data Source=./;Initial Catalog = Nimas;User Id=sa;Password = ABC123ssi; ";
            SqlDependency.Start(_connectionString);
            ConfigureLiveMonitorDependency();
            ConfigureDeviceRegistrationDependency();
            _liveMonitorHub = GlobalHost.ConnectionManager.GetHubContext<LiveMonitorHub>();
            _deviceRegestrationHub = GlobalHost.ConnectionManager.GetHubContext<DeviceRegestrationHub>();
        }

        protected void Application_End()
        {

            SqlDependency.Stop(_connectionString);
        }



        #region Device Registration Dependency


        private async void ConfigureDeviceRegistrationDependency()
        {

            //// Create connection.
            var sqlConnection = new SqlConnection(_connectionString);
            //// Create command.
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = "SELECT [RegDateTime] FROM [dbo].[DeviceRegistration]",
                Notification = null
            };

            //// Create Sql Dependency.
            var sqlDependency = new SqlDependency(sqlCommand);
            sqlDependency.OnChange += DeviceRegistraationDependency_OnChange; ;
            await sqlCommand.Connection.OpenAsync();
          
            await sqlCommand.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            sqlCommand.Dispose();

            sqlConnection.Dispose();
        }

        private void DeviceRegistraationDependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            var dependency = sender as SqlDependency;
            if (e.Info == SqlNotificationInfo.Insert)
            {

                _deviceRegestrationHub.Clients.All.initDataUpdate();
            }

            if (dependency != null) dependency.OnChange -= DeviceRegistraationDependency_OnChange;
            ConfigureDeviceRegistrationDependency();
        }


        #endregion

        #region Live Monitor Sql Devendency

        private async void ConfigureLiveMonitorDependency()
        {

            //// Create connection.
            var sqlConnection = new SqlConnection(_connectionString);
            //// Create command.
            var sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = "SELECT VGIP, IsUp, PortIndex, NB, StartDate, EndDate FROM [dbo].LinesMonitoring ",
                Notification = null
            };

            //// Create Sql Dependency.
            var sqlDependency = new SqlDependency(sqlCommand);
            sqlDependency.OnChange += SqlDependencyOnChange;
            await sqlCommand.Connection.OpenAsync();
            await sqlCommand.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            sqlCommand.Dispose();

            sqlConnection.Dispose();
        }


        private void SqlDependencyOnChange(object sender, SqlNotificationEventArgs eventArgs)
        {
            var dependency = sender as SqlDependency;
            if (eventArgs.Info == SqlNotificationInfo.Invalid)
            {
                Console.WriteLine("The above notification query is not valid.");

            }
            else
            {
                _liveMonitorHub.Clients.All.initDataUpdate();
            }

            if (dependency != null) dependency.OnChange -= SqlDependencyOnChange;
            ConfigureLiveMonitorDependency();

        }

        #endregion
    }
}
