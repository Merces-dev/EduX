using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoEduX.Domains
{
    public partial class Dica
    {
        public Dica()
        {
            Curtida = new HashSet<Curtida>();
        }

        public Guid IdDica { get; set; }
        public string Texto { get; set; }
        public Guid IdUsuario { get; set; }

        //public string Imagem { get; set; }


        [NotMapped]
        [JsonIgnore]
        
        public IFormFile Imagem { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string UrlImagem { get; set; }



   
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
    }
}
