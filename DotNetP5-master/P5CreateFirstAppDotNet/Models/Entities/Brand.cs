using System;
using System.Collections.Generic;
using P5CreateFirstAppAspDotNet.Models.Entities;

namespace P5CreateFirstAppAspDotNet.Models.Entities
{
    public class Brand
    {

        public int BrandId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Une marque possède plusieurs modèles
        public ICollection<Model> Models { get; set; } = new List<Model>();
    }
}