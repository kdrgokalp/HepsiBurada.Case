using Data.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; } = Status.Active;

        public void Active() => Status = Status.Active;
        public void Passive() => Status = Status.Passive;
        public void Deleted() => Status = Status.Deleted;
    }
}
