using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Classes
{
    public class CalculateRevenu
    {
        private string _JobNumber;
        public string JobNumber
        {
            get
            {
                return _JobNumber;
            }
            set
            {
                _JobNumber = value;
            }
        }
        private int _JobListId;
        public int JobListId
        {
            get
            {
                return _JobListId;
            }
            set
            {
                _JobListId = value;
            }
        }
        private double _TotalCallBillableRateTime;
        public double TotalCallBillableRateTime
        {
            get
            {
                return _TotalCallBillableRateTime;
            }
            set
            {
                _TotalCallBillableRateTime = value;
            }
        }


        public double FillProjectRevenu()
        {
            try
            {
                //Dim query As String = "SELECT    MasterTrackSubItem.nRate  FROM  JobTracking INNER JOIN                      MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id    where (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)  AND JobTracking.TaskHandler in (SELECT PM FROM ImportTimeSheetData WHERE JobNumber='" + JobNumber + "')"
                string query = "SELECT MasterTrackSubItem.nRate  FROM  JobTracking INNER JOIN                      MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id    where (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)  AND JobTracking.TaskHandler in (SELECT Name FROM TS_Time WHERE JobListID=" + JobListId + ")";
                double sumOfProjectRevenue = 0;


                //using (EFDbContext db = new EFDbContext())
                //{
                //    var dt = db.Database.SqlQuery<double>(query).ToList();
                    
                //    //int count = 0;
                //    double total = 0;

                //    foreach (var value in dt)
                //    {
                //        total += value;
                //    }
                //    //for (count = 0; count < dt.Count; count++)
                //    //{
                //    //    total = total + Convert.ToDouble(dt.Rows[count][0].ToString());
                //    //}

                //    double totalProjectRevenu = total;
                //    sumOfProjectRevenue = totalProjectRevenu;
                //}



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var dt = db.Database.SqlQuery<double>(query).ToList();

                        //int count = 0;
                        double total = 0;

                        foreach (var value in dt)
                        {
                            total += value;
                        }
                        //for (count = 0; count < dt.Count; count++)
                        //{
                        //    total = total + Convert.ToDouble(dt.Rows[count][0].ToString());
                        //}

                        double totalProjectRevenu = total;
                        sumOfProjectRevenue = totalProjectRevenu;
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var dt = db.Database.SqlQuery<double>(query).ToList();

                        //int count = 0;
                        double total = 0;

                        foreach (var value in dt)
                        {
                            total += value;
                        }
                        //for (count = 0; count < dt.Count; count++)
                        //{
                        //    total = total + Convert.ToDouble(dt.Rows[count][0].ToString());
                        //}

                        double totalProjectRevenu = total;
                        sumOfProjectRevenue = totalProjectRevenu;
                    }

                }

                return sumOfProjectRevenue;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double CalculateTotlaHoursAndRate()
        {
            try
            {
                //Dim query As String = "SELECT (MasterTrackSubItem.nRate *(SELECT sum(ChangeHours) FROM ImportTimeSheetData WHERE PM=JobTracking.TaskHandler)) FROM JobTracking INNER JOIN MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id where (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)  AND JobTracking.TaskHandler in (SELECT PM FROM ImportTimeSheetData WHERE JobNumber='" + JobNumber + "')"

                string query = "SELECT (MasterTrackSubItem.nRate *(SELECT sum(ChangeHours) FROM ImportTimeSheetData WHERE PM=JobTracking.TaskHandler)) FROM JobTracking INNER JOIN MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id where (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)  AND JobTracking.TaskHandler in (SELECT Name FROM TS_Time WHERE JobListID=" + JobListId + ")";
                double sumOftotalHoursANDRate = 0;
                //DataTable dt = new DataTable();
                //DataAccessLayer DLL = new DataAccessLayer();
                //dt = DLL.Filldatatable(query, dt);


                //using (EFDbContext db = new EFDbContext())
                //{
                //    var dt = db.Database.SqlQuery<double>(query).ToList();
                //    //int count = 0;
                //    double total = 0;
                //    foreach (var value in dt)
                //    {
                //        total += value;
                //    }

                //    //for (count = 0; count < dt.Rows.Count; count++)
                //    //{
                //    //    total = total + Convert.ToDouble(dt.Rows[count][0].ToString());
                //    //}

                //    double totalhoursANDrate = total;

                //    sumOftotalHoursANDRate = totalhoursANDrate;
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var dt = db.Database.SqlQuery<double>(query).ToList();
                        //int count = 0;
                        double total = 0;
                        foreach (var value in dt)
                        {
                            total += value;
                        }

                        //for (count = 0; count < dt.Rows.Count; count++)
                        //{
                        //    total = total + Convert.ToDouble(dt.Rows[count][0].ToString());
                        //}

                        double totalhoursANDrate = total;

                        sumOftotalHoursANDRate = totalhoursANDrate;
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var dt = db.Database.SqlQuery<double>(query).ToList();
                        //int count = 0;
                        double total = 0;
                        foreach (var value in dt)
                        {
                            total += value;
                        }

                        //for (count = 0; count < dt.Rows.Count; count++)
                        //{
                        //    total = total + Convert.ToDouble(dt.Rows[count][0].ToString());
                        //}

                        double totalhoursANDrate = total;

                        sumOftotalHoursANDRate = totalhoursANDrate;
                    }
                }


                return sumOftotalHoursANDRate;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Color setColor()
        {
            double sumOfProjectRevenu = 0;
            double sumOfPMhrNrate = 0;
            sumOfProjectRevenu = FillProjectRevenu();
            sumOfPMhrNrate = CalculateTotlaHoursAndRate();

            if (sumOfPMhrNrate == Convert.ToDouble("0.0"))
            {
                return Color.Transparent;
            }
            else
            {
                if (sumOfProjectRevenu * 0.1 <= sumOfPMhrNrate)
                {
                    return Color.Red;

                }
                else if (sumOfProjectRevenu * 0.75 <= sumOfPMhrNrate)
                {
                    return Color.Yellow;

                }
                else if (sumOfProjectRevenu * 0.75 > sumOfPMhrNrate)
                {
                    return Color.Green;
                }
                else
                {

                    return Color.Transparent;
                    //send your defual button color
                }
            }

        }
        public Color setColorTimeData()
        {
            try
            {
                double sumOfProjectRevenu = 0;
                double sumOfPMhrNrate = 0;
                sumOfProjectRevenu = FillProjectRevenu();
                sumOfPMhrNrate = TotalCallBillableRateTime;

                if (sumOfPMhrNrate == Convert.ToDouble("0.0"))
                {
                    return Color.Transparent;
                }
                else
                {
                    if (sumOfProjectRevenu * 0.1 <= sumOfPMhrNrate)
                    {
                        return Color.Red;

                    }
                    else if (sumOfProjectRevenu * 0.75 <= sumOfPMhrNrate)
                    {
                        return Color.Yellow;

                    }
                    else if (sumOfProjectRevenu * 0.75 > sumOfPMhrNrate)
                    {
                        return Color.Green;
                    }
                    else
                    {

                        return Color.Transparent;
                        //send your defual button color
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return new Color();
        }
    }

    public class JTQuickbookCompaireList
    {
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string StatusDescription { get; set; }
    }

    public class JTQuickbookCompaireList2
    {
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string StatusDescription { get; set; }
        public string InvoiceDate2 { get; set; }
    }
}
