using System.ComponentModel.DataAnnotations;

namespace ANYAR_WEBSITE.ViewModels.Account
{
    public class RegisterVm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string Surname { get; set; }
    }
}
