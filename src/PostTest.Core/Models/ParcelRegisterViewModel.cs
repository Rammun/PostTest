using System.ComponentModel.DataAnnotations;

namespace PostTest.Core.Models
{
    public class ParcelRegisterViewModel
    {
        /// <summary>
        /// Вес
        /// </summary>
        [Required]
        [Display(Name = "Вес")]
        public string Weight { get; set; }

        /// <summary>
        /// Опись
        /// </summary>
        [Display(Name = "Опись")]
        public string Inventory { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        [Required]
        [Display(Name = "Получатель")]
        public MemberViewModel Recipient { get; set; }

        /// <summary>
        /// Отправитель
        /// </summary>
        [Required]
        [Display(Name = "Отправитель")]
        public MemberViewModel Sender { get; set; }
    }
}
