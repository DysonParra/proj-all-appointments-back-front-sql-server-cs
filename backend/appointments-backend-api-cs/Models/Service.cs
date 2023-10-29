/*
 * @fileoverview    {Service}
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
 * TODO: Description of {@code Service}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Service {

        [Key]
        public Int64? IntId { get; set; }
        public String? StrServiceName { get; set; }
        public Int64? IntDuration { get; set; }
        public Decimal? DecPrice { get; set; }

    }

}