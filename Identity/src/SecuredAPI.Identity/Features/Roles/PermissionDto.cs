namespace SecuredAPI.Identity.Features.Roles
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public bool Value { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
    }
}
