//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeautySalonWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BS_UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Level { get; set; }
        public System.DateTime regTime { get; set; }
        public string Lock { get; set; }
    }
}
