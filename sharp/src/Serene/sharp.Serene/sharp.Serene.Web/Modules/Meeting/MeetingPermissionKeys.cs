﻿
using Serenity.Extensibility;
using System.ComponentModel;

namespace sharp.Serene.Meeting
{
    [NestedPermissionKeys]
    public class PermissionKeys
    {
        [Description("[General]")]
        public const string General = "Meeting:General";

        public const string Management = "Meeting:Management";
    }
}
