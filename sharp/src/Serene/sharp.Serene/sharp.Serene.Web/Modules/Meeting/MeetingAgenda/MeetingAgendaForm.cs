﻿
namespace sharp.Serene.Meeting.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("Meeting.MeetingAgenda")]
    [BasedOnRow(typeof(Entities.MeetingAgendaRow))]
    public class MeetingAgendaForm
    {
        public Int32 MeetingId { get; set; }
        public Int32 AgendaNumber { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Int32 AgendaTypeId { get; set; }
        public Int32 RequestedByContactId { get; set; }
        public String Images { get; set; }
        public String Attachments { get; set; }
    }
}