namespace KomodoInsuranceApp.Models
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public string Name { get; set; }

        public Badge()
        {
            DoorNames = new List<string>();
        }
    }
}
