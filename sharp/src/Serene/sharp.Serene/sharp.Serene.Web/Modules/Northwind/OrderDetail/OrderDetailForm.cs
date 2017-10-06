﻿
namespace sharp.Serene.Northwind.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("Northwind.OrderDetail")]
    [BasedOnRow(typeof(Entities.OrderDetailRow))]
    public class OrderDetailForm
    {
        public Int32 ProductID { get; set; }
        public Decimal UnitPrice { get; set; }
        public Int32 Quantity { get; set; }
        public Double Discount { get; set; }
    }
}