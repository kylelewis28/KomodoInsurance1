using KomodoInsuranceApp.Models;

namespace KomodoInsuranceApp.Repositories
{
    public class BadgeRepository
    {
        private Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        public void AddBadge(Badge badge)
        {
            _badgeDictionary[badge.BadgeID] = badge;
        }

        public bool UpdateBadge(int badgeID, List<string> doorNames)
        {
            if (_badgeDictionary.ContainsKey(badgeID))
            {
                _badgeDictionary[badgeID].DoorNames = doorNames;
                return true;
            }
            return false;
        }

        public bool DeleteBadge(int badgeID)
        {
            return _badgeDictionary.Remove(badgeID);
        }

        public Dictionary<int, Badge> GetAllBadges()
        {
            return _badgeDictionary;
        }
    }
}
