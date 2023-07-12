﻿using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities
{
    public class Seminar : Activity
    {
        public ICollection<Participant>? Participants { get; set; }
        public UserProfile UserProfile { get; set; }
        public int UserProfileId { get; set; }

    }
}
