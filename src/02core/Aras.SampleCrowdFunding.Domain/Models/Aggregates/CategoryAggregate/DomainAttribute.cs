using Aras.SampleCrowdFunding.SharedKernel.Abstractions;
using Aras.SampleCrowdFunding.SharedKernel.DomainExceptions;

namespace Aras.SampleCrowdFunding.Domain.Models.Aggregates.CategoryAggregate
{
    public class DomainAttribute : DomainEntity<long>
    {
        //public string Name { get; set; }
        //public long CategoryId { get; set; }
        //public long? CreatorUserId { get; set; }
        //public long? ModifierUserId { get; set; }

        //public DomainAttribute(string name, long categoryId, long? creatorUserId, long? modifierUserId)
        //{
        //    if (string.IsNullOrWhiteSpace(name)) throw new DomainException(1, "Name is null, empty or white space.");

        //    Name = name;
        //    CategoryId = categoryId;
        //}
    }
}

