namespace Domian.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// документ изначально ничейный
        /// </summary>
        public Guid? UserId { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Document document)
                return Id == document.Id;

            return false;
        }
    }
}
