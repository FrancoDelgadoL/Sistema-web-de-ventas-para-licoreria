using System;
using System.ComponentModel.DataAnnotations;

namespace Ezel_Market.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserEmail { get; set; } // Correo del usuario que hizo la reseña

        [Required]
        public string ProductName { get; set; } // Nombre del producto reseñado

        [Required]
        public string Content { get; set; } // Texto de la reseña

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Fecha de creación

        // NUEVO: Calificación del 1 al 5
        [Range(1,5)]
        public int Rating { get; set; }
    }
}
