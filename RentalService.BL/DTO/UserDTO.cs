namespace RentalService.BL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string RoleId { get; set; }
        public RoleDTO Role { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
