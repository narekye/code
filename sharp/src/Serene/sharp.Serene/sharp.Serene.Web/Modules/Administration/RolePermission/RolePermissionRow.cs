﻿
namespace sharp.Serene.Administration.Entities
{
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("Default"), DisplayName("Role Permissions"), InstanceName("Role Permission"), TwoLevelCached]
    [ReadPermission(PermissionKeys.Security)]
    [ModifyPermission(PermissionKeys.Security)]
    public sealed class RolePermissionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Role Permission Id"), Identity]
        public Int64? RolePermissionId
        {
            get { return Fields.RolePermissionId[this]; }
            set { Fields.RolePermissionId[this] = value; }
        }

        [DisplayName("Role Id"), NotNull, ForeignKey("Roles", "RoleId"), LeftJoin("jRole")]
        public Int32? RoleId
        {
            get { return Fields.RoleId[this]; }
            set { Fields.RoleId[this] = value; }
        }

        [DisplayName("Permission Key"), Size(100), NotNull, QuickSearch]
        public String PermissionKey
        {
            get { return Fields.PermissionKey[this]; }
            set { Fields.PermissionKey[this] = value; }
        }

        [DisplayName("Role Role Name"), Expression("jRole.[RoleName]")]
        public String RoleRoleName
        {
            get { return Fields.RoleRoleName[this]; }
            set { Fields.RoleRoleName[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.RolePermissionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.PermissionKey; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public RolePermissionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field RolePermissionId;
            public Int32Field RoleId;
            public StringField PermissionKey;

            public StringField RoleRoleName;


            public RowFields()
                : base("RolePermissions")
            {
                LocalTextPrefix = "Administration.RolePermission";
            }
        }
    }
}