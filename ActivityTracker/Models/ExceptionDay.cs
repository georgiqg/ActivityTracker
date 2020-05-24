using System;
using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Models
{
    public class ExceptionDay
	{
		public int ExceptionDayId { get; set; }
		public string UserId { get; set; }

		[Required, DataType(DataType.Date), Display(Name = "Exception date")]
		public DateTime ExceptionDate { get; set; }

		[Required, Display(Name = "Exception date goal")]
		public int ExceptionDateGoal { get; set; }

		[MaxLength(100)]
		public string Reason { get; set; }
	}
}
