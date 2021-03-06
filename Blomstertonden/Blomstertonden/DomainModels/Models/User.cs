using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenericsLibrary;

namespace Blomstertonden
{
    [Table("User")]
    public partial class User : IKey<int>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public int FK_Role { get; set; }
        public virtual Role Role { get; set; }
        public int Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
