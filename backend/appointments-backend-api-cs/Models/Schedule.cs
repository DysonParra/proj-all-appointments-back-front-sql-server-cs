/*
 * @fileoverview    {Schedule}
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
 * TODO: Definición de {@code Schedule}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Schedule {

        [Key]
        public Int64? IntId { get; set; }
        public DateTime? DtFrom { get; set; }
        public DateTime? DtTo { get; set; }
        public Int64? IntEmployeeId { get; set; }

    }

}