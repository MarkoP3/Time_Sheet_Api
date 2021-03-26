using System;

#nullable disable

namespace timeSheet.Repository.Contract.Entities
{
    public partial class Category
    {
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
