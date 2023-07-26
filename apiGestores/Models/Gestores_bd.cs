﻿using System.ComponentModel.DataAnnotations;

namespace apiGestores.Models
{
    public class Gestores_bd
    {
        //----modelo----
        [Key]
        public int id { get; set; }

        public string nombre { get; set; }

        public int lanzamiento { get; set; }

        public string desarrollador { get; set; }

    }
}
