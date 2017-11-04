namespace HeroesOfVuklut.Shared.Clash
{
    public class ClashResource
    {
        public int Amount { get; set; }
        public int Max { get; set; }
        public string Name { get; set; }
        public ClashResourceType ResourceType { get; set; }
        private ClashResource()
        {

        }

        public enum ClashResourceType
        {
            Gold,
            Mana,
            Morale,
            Engineering
        }

        public static ClashResource CreateResource(int amount, int max, ClashResourceType resourceType)
        {
            return new ClashResource
            {
                Name = GetNameForResource(resourceType),
                ResourceType = resourceType,
                Amount = amount,
                Max = max
            };
        }

        private static string GetNameForResource(ClashResourceType resourceType)
        {
            switch (resourceType)
            {
                case ClashResourceType.Gold:
                    return "Gold";
                case ClashResourceType.Mana:
                    return "Mana";
                case ClashResourceType.Morale:
                    return "Morale";
                case ClashResourceType.Engineering:
                    return "Engineering";
                default:
                    break;
            }

            return null;
        }
    }
}
