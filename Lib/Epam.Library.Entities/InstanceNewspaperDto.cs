using System;

namespace Epam.Library.Entities
{
    public class InstanceNewspaperDto
    {
        public int Id { get; set; }
        public DateTime ReliseDate { get; set; }
        public int Number { get; set; }
        public int NumberOfPages { get; set; }
        public int NewspaperId { get; set; }
    }
}
