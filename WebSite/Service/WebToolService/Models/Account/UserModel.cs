namespace WebToolService
{
    using System;

    [Serializable]
    public class UserModel : LogOnModel
    {
        public long Id
        {
            get
            {
                return this.UserId;
            }
        }

        public int UserId { get; set; }

        public string UserName
        {
            get;
            set;
        }
    }
}
