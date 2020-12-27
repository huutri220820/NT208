//Vo Huu Tri - 18521531 UIT
namespace ModelAndRequest.Account
{
    public class UpdateAccountRequest
    {
        public string fullName { get; set; }
        public bool? isMale { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string avatar { get; set; }
    }
}