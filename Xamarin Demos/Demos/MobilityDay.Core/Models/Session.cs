using System;

namespace MobilityDay.Core.Models
{
    public class Session
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public string Description { get; set; }

        public Speaker[] Speakers { get; set; }

        public Speaker MainSpeaker { get { return Speakers[0]; } }
    }
}