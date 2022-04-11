using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Classes
{
    public class TSTime
    {
        private long _jobid;
        public long JobListId
        {
            get
            {
                return _jobid;
            }
            set
            {
                _jobid = value;
            }
        }
        public DateTime DateAdded { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Handler { get; set; }

        public double Time { get; set; }


        private double _revenue;
        public double Revenue
        {
            get
            {
                return _revenue;
            }
            set
            {
                _revenue = value;
            }
        }

        private double _vecost;
        public double VeCost
        {
            get
            {
                return _vecost;
            }
            set
            {
                _vecost = value;
            }
        }

        public double Difference
        {
            get
            {
                return this.Revenue - this.VeCost;
            }

        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }


        private string _jobNo;
        public string JobNumber
        {
            get
            {
                return _jobNo;
            }
            set
            {
                _jobNo = value;
            }
        }

        public string InvoiceNo { get; set; }
    }
}
