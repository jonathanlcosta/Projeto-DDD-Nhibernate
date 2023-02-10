using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        private DateTime _criadoEm;
        public virtual DateTime CriadoEm
        {
            get { return _criadoEm; }
            set { _criadoEm = (value == null ? DateTime.UtcNow: value); 
        }}

        
            public virtual DateTime AtualizadoEm { get; set; }
           
        
    }
}