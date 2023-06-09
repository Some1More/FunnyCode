﻿namespace FunnyCode.Domain.Core.Entities;
/// <summary>
/// Specific user profile entity 
/// </summary>
public class UserProfile : BaseEntity
{
    public string Name { get; set; }

    public DateOnly BirthDate { get; set; }

    public Guid ContactsId { get; set; }

    public Contacts? Contacts { get; set; }

    public Guid WorkSpaceId { get; set; }

    public WorkSpace? WorkSpace { get; set; }

    public Guid ScheduleId { get; set; }

    public Schedule? Schedule { get; set; }

    public List<Vacation> Vacations { get; set; }
}
