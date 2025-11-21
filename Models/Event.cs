using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingApp.Models
{

    [Table("event")]
    public class EventItem
    {
        [Key]
        public long EventID { get; set; }

        [Display(Name = "تاريخ الإنشاء")]
        public DateTime created_at { get; set; }
        public int? tenant_id { get; set; }
        
        [Display(Name = "عنوان الفعالية")]
        public string? Event_Title { get; set; }

        [Display(Name = "تاريخ الفعالية")]
        public DateTime Event_Date { get; set; }


        [Display(Name = "مكان الفعالية")]
        public string? venue { get; set; }

        [Display(Name = "الحالة")]
        public string? Event_Status { get; set; }

        [Display(Name = "عدد التذاكر")]
        public int? NoofTickets { get; set; }


        [Display(Name = "تم الانشاء بواسطة")]
        public string? createdby { get; set; }

        [Display(Name = "موقع المكان")]
        public string? Venue_Location { get; set; }
    }



    [Table("ticket")]
    public class Ticket
    {
        [Key]
        [Display(Name = "معرف التذكرة")]
        public string Ticket_id { get; set; }// = Guid.NewGuid().ToString(); // Initialize with a new UUID

        [Display(Name = "معرف الفعالية")]
        public long EventID { get; set; }

        [Required]
        [Display(Name = "الاسم الأول")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "اسم العائلة")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "رقم الهاتف")]
        public string? phoneNo { get; set; }

        [Required]
        [Display(Name = "البريد الإلكتروني")]
        public string? email { get; set; }

        [Display(Name = "الحالة")]
        public string? status { get; set; }

        [Display(Name = "تاريخ الإنشاء")]
        public DateTime created_at { get; set; }

        [Display(Name = "تاريخ الاستخدام")]
        public DateTime? used_at { get; set; }

        [Display(Name = "تم الاستخدام بواسطة")]
        public string? usedby { get; set; }

        [Required]
        [Display(Name = "رمز التذكرة")]
        public string? ticket_code { get; set; }
    }

}
