//Vo Huu Tri - 18521531 UIT
using System;

namespace ModelAndRequest.Account
{
    /// <summary>
    /// get info account
    /// </summary>
    public class AccountModel
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string fullName { get; set; }
        public virtual bool isMale { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
        public bool isDelete { get; set; }
    }
}