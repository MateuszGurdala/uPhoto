namespace uPhoto.Common.Contracts;

public interface ICreatableEntity
{
    DateTime CreatedOn { get; set; }
    Guid CreatedBy { get; set; }
}