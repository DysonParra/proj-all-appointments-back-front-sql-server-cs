/*
 * @fileoverview    {Client}
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
 * TODO: Definición de {@code Client}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Client {

        [Key]
        public Int64? IntId { get; set; }
        public String? StrClientName { get; set; }
        public String? StrContactMobile { get; set; }
        public String? StrContactMail { get; set; }

    }

}