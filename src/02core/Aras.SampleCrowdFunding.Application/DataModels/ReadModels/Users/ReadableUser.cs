using Atisaz.Core.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Users
{

    public class ReadableUser: IEntity<int>, IAuditableEntity<int>, ISoftDeleteEnabled<int>
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string RandomSalt { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public long CreatorUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifierUserId { get; set; }
    }
}
