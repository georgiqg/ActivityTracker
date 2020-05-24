using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTracker.Models
{
    public class ActivityLog
	{
		public int ActivityLogId { get; set; }

		[Required]
		[Display(Name = "Activity")]
		public int ActivityId { get; set; }

		[MaxLength(100)]
		public string UserId { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Log date")]
		public DateTime LogDate { get; set; }

		[Required]
		public int Units { get; set; }

		[Required]
		[Display(Name = "Total points")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal TotalPoints { get; set; }

        public Activity Activity { get; set; }
	}
}
