﻿namespace BLL.DTO
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }
    }
}
