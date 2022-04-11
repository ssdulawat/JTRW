using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
	public class EmailRecord
	{
		public int ID { get; set; }
		public object TableName { get; set; }
		public string NewRecord { get; set; }
		public string UpdateRecord { get; set; }
		public string DeleteRecord { get; set; }
		public Nullable<DateTime> UploadDate { get; set; }
		public bool IsEmailed { get; set; }
	}
}