/*
 * @fileoverview    {Appointment}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Appointment}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Appointment {

        [Key]
        public Int64? IntId { get; set; }
        public DateTime? DtDateCreated { get; set; }
        public String? StrClientName { get; set; }
        public String? StrClientContact { get; set; }
        public DateTime? DtStartTime { get; set; }
        public DateTime? DtEndTimeExpected { get; set; }
        public DateTime? DtEndTime { get; set; }
        public Decimal? DecPriceExpected { get; set; }
        public Decimal? DecPriceFull { get; set; }
        public Decimal? DecDiscount { get; set; }
        public Decimal? DecPriceFinal { get; set; }
        public Boolean? BitCanceled { get; set; }
        public String? TxtCancelationReason { get; set; }
        public Int64? IntClientId { get; set; }
        public Int64? IntEmployeeCreated { get; set; }
        public Int64? IntEmployeeId { get; set; }

    }

}