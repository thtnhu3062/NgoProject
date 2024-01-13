using MessagePack;
using NgoProject.Models;

namespace NgoProject.ViewModel
{
    public class DonateViewModel
    {
        public int DonateId { get; set; }

        public int? NewsId { get; set; } 

        public DateTime? DonateDate { get; set; }=DateTime.Now;

        public string? UserName { get; set; }
        public string? DonateMoney { get; set; }
        public int? Stastus { get; set; } = 0;

        public int? UserId { get; set; }

        public virtual News? News { get; set; }

        public virtual User? User { get; set; }

    }
}
