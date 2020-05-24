using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTracker.Models
{
    public class Activity : IValidatableObject
    {
        public int ActivityId { get; set; }

        [MaxLength(100)]
        public string UserId { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Activity name")]
        public string ActivityName { get; set; }

        [Display(Name = "Unit")]
        public int? UnitId { get; set; }

        [Display(Name = "Custom unit")]
        public int? CustomUnitId { get; set; }

        [Required, Display(Name = "Points per unit")]
        [Range(0.01, 9999999999999999.99)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PointsPerUnit { get; set; }

        [Required, Display(Name = "Max points")]
        [Range(0.01, 9999999999999999.99)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxPointsPerDay { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Valid from")]
        public DateTime ActivityValidFrom { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Valid to")]
        public DateTime ActivityValidTo { get; set; }

        public Unit Unit { get; set; }

        [Display(Name = "Custom unit")]
        public CustomUnit CustomUnit { get; set; }
        public List<ActivityLog> ActivityLogs { get; set; }

        [NotMapped]
        [Display(Name = "Unit name")]
        public string UnitName { get; set; }

        public void SetUnitName()
        {
            UnitName = Unit?.UnitName ?? CustomUnit?.CustomUnitName;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (UnitId == null && CustomUnitId == null)
            {
                results.Add(
                    new ValidationResult(
                        "You have to select either a 'Unit' or a 'Custom unit'.",
                        new string[]
                        {
                            "UnitId",
                            "CustomUnitId"
                        })
                    );
            }
            else if (UnitId != null && CustomUnitId != null)
            {
                results.Add(
                    new ValidationResult(
                        "You can't select both 'Unit' and 'Custom unit'.",
                        new string[]
                        {
                            "UnitId",
                            "CustomUnitId"
                        })
                    );
            }

            if (MaxPointsPerDay < PointsPerUnit)
            {
                results.Add(new ValidationResult("The 'Max points' can't be less than 'Points'.", new string[] { "ActivityValidTo" }));
            }

            if (ActivityValidTo < ActivityValidFrom)
            {
                results.Add(new ValidationResult("The 'Valid to' date has to be after the 'Valid from' date.", new string[] { "ActivityValidTo" }));
            }

            return results;
        }
    }
}
