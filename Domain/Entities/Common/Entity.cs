using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Common
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        //public Entity()
        //{
        //    Id = 1;
        //}

    }
}
