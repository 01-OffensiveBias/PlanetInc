using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebMatrix.Data;

/// <summary>
/// Summary description for Reservation
/// </summary>
public class Reservation
{
    private int clientId;
    private int regionId;
    private DateTime startDate;
    private DateTime endDate;

    SqlConnection connection = new SqlConnection("Server=IISProject.mtchs.org;Database=PlanetInc;Trusted_Connection=Yes");
    public Boolean isReserved;

    public Reservation(int clientId, int regionId, DateTime startDate, DateTime endDate)
    {
        this.clientId = clientId;
        this.regionId = regionId;
        this.startDate = startDate;
        this.endDate = endDate;

        connection.Open();
        isReserved = checkIfReserved();

        if (!isReserved)
        {
            reserve();
        }

        connection.Close();
    }

    private void reserve()
    {
        SqlCommand cmd = new SqlCommand(null, connection);

        cmd.CommandText = "INSERT INTO Reservations (ClientId, RegionId, StartDate, EndDate) " +
            "VALUES (@client, @region, @start, @end);";

        SqlParameter clientParameter = new SqlParameter("@client", SqlDbType.Int);
        SqlParameter regionParameter = new SqlParameter("@region", SqlDbType.Int);
        SqlParameter startParam = new SqlParameter("@start", SqlDbType.Date);
        SqlParameter endParam = new SqlParameter("@end", SqlDbType.Date);
        clientParameter.Value = clientId;
        regionParameter.Value = regionId;
        startParam.Value = startDate;
        endParam.Value = endDate;

        cmd.Parameters.Add(clientParameter);
        cmd.Parameters.Add(regionParameter);
        cmd.Parameters.Add(startParam);
        cmd.Parameters.Add(endParam);

        cmd.ExecuteNonQuery();
    }

    private Boolean checkIfReserved()
    {
        // TODO: this is bullshit
        SqlCommand cmd = new SqlCommand(null, connection);

        cmd.CommandText = "SELECT COUNT(*) " +
            "FROM Reservations " +
            "WHERE RegionId = @region AND (" +
            "@start BETWEEN StartDate AND EndDate OR " +
            "@end BETWEEN StartDate AND EndDate OR " +
            "@start = StartDate AND @end = EndDate);";

        SqlParameter regionParameter = new SqlParameter("@region", SqlDbType.Int);
        SqlParameter startParam = new SqlParameter("@start", SqlDbType.Date);
        SqlParameter endParam = new SqlParameter("@end", SqlDbType.Date);
        regionParameter.Value = regionId;
        startParam.Value = startDate;
        endParam.Value = endDate;

        cmd.Parameters.Add(regionParameter);
        cmd.Parameters.Add(startParam);
        cmd.Parameters.Add(endParam);

        return (int) cmd.ExecuteScalar() != 0;
    }


}