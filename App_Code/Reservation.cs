using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Reservation
/// </summary>
public class Reservation
{
    public Boolean isReserved;

	public Reservation(Database db, int clientId, int regionId, DateTime startDate, DateTime endDate)
	{
	    Database.Open("IISProject");


	}
}