using System.ComponentModel.DataAnnotations;

namespace uPhoto.Common.Contracts;

public interface IEntity
{
}

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}