using System;
using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Models
{
    public class DailyGoal
	{
		public int DailyGoalId { get; set; }
		public string UserId { get; set; }

		[Required, DataType(DataType.Date), Display(Name = "Goal valid from")]
		public DateTime GoalValidFrom { get; set; }

		[Required, DataType(DataType.Date), Display(Name = "Goal valid to")]
		public DateTime GoalValidTo { get; set; }

		[Required, Display(Name = "Monday goal")]
		public int MondayGoal { get; set; }

		[Required, Display(Name = "Tuesday goal")]
		public int TuesdayGoal { get; set; }

		[Required, Display(Name = "Wednesday goal")]
		public int WednesdayGoal { get; set; }

		[Required, Display(Name = "Thursday goal")]
		public int ThursdayGoal { get; set; }

		[Required, Display(Name = "Friday goal")]
		public int FridayGoal { get; set; }

		[Required, Display(Name = "Saturday goal")]
		public int SaturdayGoal { get; set; }

		[Required, Display(Name = "Sunday goal")]
		public int SundayGoal { get; set; }
	}
}
