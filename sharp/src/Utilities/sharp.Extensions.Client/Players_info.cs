//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sharp.Extensions.Client
{
    using System;
    using System.Collections.Generic;
    
    public partial class Players_info
    {
        public int PlayerID { get; set; }
        public Nullable<int> Health { get; set; }
    
        public virtual Player Player { get; set; }
    }
}
