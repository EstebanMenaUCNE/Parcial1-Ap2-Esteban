﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }

        public Categoria()
        {

        }

        public Categoria(int categoriaId, string descripcion)
        {
            CategoriaId = categoriaId;
            Descripcion = descripcion;
        }
    }
}
