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
    }

    private void reserve()
    {
        
    }

    private Boolean checkIfReserved()
    {
        // TODO: this is bullshit
        SqlCommand cmd = new SqlCommand(null, connection);

        cmd.CommandText = "SELECT COUNT(*) " +
            "FROM Reservations " +
            "WHERE '@start' BETWEEN StartDate AND EndDate OR " +
            "'@end' BETWEEN StartDate AND EndDate OR " +
            "'@start' = StartDate AND '@end' = EndDate;";

        SqlParameter startParam = new SqlParameter("@start", SqlDbType.VarChar);
        SqlParameter endParam = new SqlParameter("@end", SqlDbType.VarChar);
        startParam.Value = startDate.ToShortDateString();
        endParam.Value = endDate.ToShortDateString();

        cmd.Parameters.Add(startParam);
        cmd.Parameters.Add(endParam);

        isReserved = (int) cmd.ExecuteScalar() == 0;

        connection.Close();

        return isReserved;
    }


}