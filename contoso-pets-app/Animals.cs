namespace Animals
{
    public class Animal
    {
        public required string Species { get; set; }
        public required string ID { get; set; }
        public required string Age { get; set; }
        public required string PhysicalDescription { get; set; }
        public required string PersonalityDescription { get; set; }
        public required string Nickname { get; set; }

        public required string SuggestedDonation { get; set; }

        public string Details()
        {
            return $"""
                    ID: {ID}
                    Nickname: {Nickname}
                    Species: {Species}
                    Age: {Age}
                    Physical description: {PhysicalDescription}
                    Personality: {PersonalityDescription}
                    Suggested Donation: {SuggestedDonation:C2}

                    """;
        }
    }
}

