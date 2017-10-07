﻿
namespace sharp.Serene.Northwind.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("Northwind"), TableName("Territories"), DisplayName("Territories"), InstanceName("Territory"), TwoLevelCached]
    [ReadPermission(PermissionKeys.General)]
    [ModifyPermission(PermissionKeys.General)]
    [LookupScript("Northwind.Territory")]
    public sealed class TerritoryRow : Row, IIdRow, INameRow
    {
        [DisplayName("ID"), Identity]
        public Int32? ID
        {
            get { return Fields.ID[this]; }
            set { Fields.ID[this] = value; }
        }

        [DisplayName("Territory ID"), Size(20), PrimaryKey, NotNull, QuickSearch, Updatable(false)]
        public String TerritoryID
        {
            get { return Fields.TerritoryID[this]; }
            set { Fields.TerritoryID[this] = value; }
        }

        [DisplayName("Territory Description"), Size(50), NotNull, QuickSearch, LookupInclude]
        public String TerritoryDescription
        {
            get { return Fields.TerritoryDescription[this]; }
            set { Fields.TerritoryDescription[this] = value; }
        }

        [DisplayName("Region"), NotNull, ForeignKey(typeof(RegionRow)), LeftJoin("jRegion")]
        public Int32? RegionID
        {
            get { return Fields.RegionID[this]; }
            set { Fields.RegionID[this] = value; }
        }

        [Origin("jRegion"), DisplayName("Region"), QuickSearch, LookupInclude]
        public String RegionDescription
        {
            get { return Fields.RegionDescription[this]; }
            set { Fields.RegionDescription[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ID; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TerritoryID; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TerritoryRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ID;
            public StringField TerritoryID;
            public StringField TerritoryDescription;
            public Int32Field RegionID;

            public StringField RegionDescription;

            public RowFields()
            {
                LocalTextPrefix = "Northwind.Territory";
            }
        }
    }
}