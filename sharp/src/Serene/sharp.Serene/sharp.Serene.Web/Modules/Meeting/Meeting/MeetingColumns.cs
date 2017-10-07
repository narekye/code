﻿
namespace sharp.Serene.Meeting.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Meeting.Meeting")]
    [BasedOnRow(typeof(Entities.MeetingRow))]
    public class MeetingColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 MeetingId { get; set; }
        [EditLink, Width(250)]
        public String MeetingName { get; set; }
        [Width(125)]
        public String MeetingNumber { get; set; }
        [Width(120), QuickFilter]
        public String MeetingTypeName { get; set; }
        [Width(125), DisplayFormat("g")]
        public DateTime StartDate { get; set; }
        [Width(125), DisplayFormat("g")]
        public DateTime EndDate { get; set; }
        [Width(120), QuickFilter]
        public String LocationName { get; set; }
        [Width(150), QuickFilter]
        public String UnitName { get; set; }
        [Width(150), QuickFilter]
        public String OrganizerContactFullName { get; set; }
        [Width(150), QuickFilter]
        public String ReporterContactFullName { get; set; }
    }
}