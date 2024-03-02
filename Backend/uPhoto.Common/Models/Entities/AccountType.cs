using System.ComponentModel.DataAnnotations;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

public class AccountType : IEntity<byte>
{
    public byte Id { get; set; }

    [MaxLength(10)] public string Type { get; set; }

    public virtual IEnumerable<UserAccount> UserAccounts { get; set; }
}