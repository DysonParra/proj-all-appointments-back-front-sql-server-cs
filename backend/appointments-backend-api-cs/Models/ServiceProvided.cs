/*
 * @fileoverview    {ServiceProvided}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code ServiceProvided}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class ServiceProvided {

        [Key]
        public Int64? IntId { get; set; }
        public Decimal? DecPrice { get; set; }
        public Int64? IntAppointmentI { get; set; }
        public Int64? IntServiceId { get; set; }

    }

}