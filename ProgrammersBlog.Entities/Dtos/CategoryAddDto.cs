using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgrammersBlog.Entities.Dtos
{
   public class CategoryAddDto
    {
        // Dto => Data transfer Object dir
        // neden dto kullanırız?
        // fonksiyonlar tam anlamıyla tüm verileri sınıflar aracılığıyla taşınmaz
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} boş geçilmemelidir.")] // {0} => DisplayName deki değeri içerisine atmaktadır.
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] // {0}=> DisplayName {1} => 70
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")] // {0}=> DisplayName {1} => 3
        public string Name { get; set; }
        [DisplayName("Kategori Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")] // {0}=> DisplayName {1} => 70
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")] // {0}=> DisplayName {1} => 3
        public string Description { get; set; }
        [DisplayName("Kategori Özel Not alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır")] // {0}=> DisplayName {1} => 70
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")] // {0}=> DisplayName {1} => 3
        public string Note { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir")]
        public bool IsActive { get; set; } 
    }
}
