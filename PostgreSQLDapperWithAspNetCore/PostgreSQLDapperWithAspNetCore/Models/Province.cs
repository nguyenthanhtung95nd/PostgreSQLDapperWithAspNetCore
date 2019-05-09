using System.ComponentModel.DataAnnotations;

namespace PostgreSQLDapperWithAspNetCore.Models
{
    public class Province : BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên tỉnh không được để trống")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Tên tỉnh không được để trống")]
        public string Name { get; set; }

        public string ShortName { get; set; }
        public string Slug { get; set; }
        public int? SeqOrder { get; set; }
    }
}