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
    
    public partial class BS_Order
    {
        public BS_Order()
        {
            this.BS_OrderDetail = new HashSet<BS_OrderDetail>();
        }
    
        public string Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string PayType { get; set; }
        public string Money { get; set; }
        public Nullable<System.DateTime> OperTime { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
    
        public virtual ICollection<BS_OrderDetail> BS_OrderDetail { get; set; }
        public virtual BS_UserInfo BS_UserInfo { get; set; }
    }
}
