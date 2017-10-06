﻿
namespace sharp.Serene.Northwind.Entities
{
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Northwind"), DisplayName("EmployeeTerritories"), InstanceName("EmployeeTerritories"), TwoLevelCached]
    [ReadPermission(PermissionKeys.General)]
    [ModifyPermission(PermissionKeys.General)]
    public sealed class EmployeeTerritoryRow : Row, IIdRow, INameRow
    {
        [DisplayName("Employee Id"), PrimaryKey, ForeignKey("Employees", "EmployeeID"), LeftJoin("jEmployee")]
        public Int32? EmployeeID
        {
            get { return Fields.EmployeeID[this]; }
            set { Fields.EmployeeID[this] = value; }
        }

        [DisplayName("Territory Id"), Size(20), PrimaryKey, ForeignKey("Territories", "TerritoryID"), LeftJoin("jTerritory"), QuickSearch]
        public String TerritoryID
        {
            get { return Fields.TerritoryID[this]; }
            set { Fields.TerritoryID[this] = value; }
        }

        [DisplayName("Employee Last Name"), Expression("jEmployee.[LastName]")]
        public String EmployeeLastName
        {
            get { return Fields.EmployeeLastName[this]; }
            set { Fields.EmployeeLastName[this] = value; }
        }

        [DisplayName("Employee First Name"), Expression("jEmployee.[FirstName]")]
        public String EmployeeFirstName
        {
            get { return Fields.EmployeeFirstName[this]; }
            set { Fields.EmployeeFirstName[this] = value; }
        }

        [DisplayName("Employee Title"), Expression("jEmployee.[Title]")]
        public String EmployeeTitle
        {
            get { return Fields.EmployeeTitle[this]; }
            set { Fields.EmployeeTitle[this] = value; }
        }

        [DisplayName("Employee Title Of Courtesy"), Expression("jEmployee.TitleOfCourtesy")]
        public String EmployeeTitleOfCourtesy
        {
            get { return Fields.EmployeeTitleOfCourtesy[this]; }
            set { Fields.EmployeeTitleOfCourtesy[this] = value; }
        }

        [DisplayName("Employee Birth Date"), Expression("jEmployee.[BirthDate]")]
        public DateTime? EmployeeBirthDate
        {
            get { return Fields.EmployeeBirthDate[this]; }
            set { Fields.EmployeeBirthDate[this] = value; }
        }

        [DisplayName("Employee Hire Date"), Expression("jEmployee.[HireDate]")]
        public DateTime? EmployeeHireDate
        {
            get { return Fields.EmployeeHireDate[this]; }
            set { Fields.EmployeeHireDate[this] = value; }
        }

        [DisplayName("Employee Address"), Expression("jEmployee.[Address]")]
        public String EmployeeAddress
        {
            get { return Fields.EmployeeAddress[this]; }
            set { Fields.EmployeeAddress[this] = value; }
        }

        [DisplayName("Employee City"), Expression("jEmployee.[City]")]
        public String EmployeeCity
        {
            get { return Fields.EmployeeCity[this]; }
            set { Fields.EmployeeCity[this] = value; }
        }

        [DisplayName("Employee Region"), Expression("jEmployee.[Region]")]
        public String EmployeeRegion
        {
            get { return Fields.EmployeeRegion[this]; }
            set { Fields.EmployeeRegion[this] = value; }
        }

        [DisplayName("Employee Postal Code"), Expression("jEmployee.[PostalCode]")]
        public String EmployeePostalCode
        {
            get { return Fields.EmployeePostalCode[this]; }
            set { Fields.EmployeePostalCode[this] = value; }
        }

        [DisplayName("Employee Country"), Expression("jEmployee.[Country]")]
        public String EmployeeCountry
        {
            get { return Fields.EmployeeCountry[this]; }
            set { Fields.EmployeeCountry[this] = value; }
        }

        [DisplayName("Employee Home Phone"), Expression("jEmployee.[HomePhone]")]
        public String EmployeeHomePhone
        {
            get { return Fields.EmployeeHomePhone[this]; }
            set { Fields.EmployeeHomePhone[this] = value; }
        }

        [DisplayName("Employee Extension"), Expression("jEmployee.[Extension]")]
        public String EmployeeExtension
        {
            get { return Fields.EmployeeExtension[this]; }
            set { Fields.EmployeeExtension[this] = value; }
        }

        [DisplayName("Employee Photo"), Expression("jEmployee.[Photo]")]
        public Stream EmployeePhoto
        {
            get { return Fields.EmployeePhoto[this]; }
            set { Fields.EmployeePhoto[this] = value; }
        }

        [DisplayName("Employee Notes"), Expression("jEmployee.[Notes]")]
        public String EmployeeNotes
        {
            get { return Fields.EmployeeNotes[this]; }
            set { Fields.EmployeeNotes[this] = value; }
        }

        [DisplayName("Employee Reports To"), Expression("jEmployee.[ReportsTo]")]
        public Int32? EmployeeReportsTo
        {
            get { return Fields.EmployeeReportsTo[this]; }
            set { Fields.EmployeeReportsTo[this] = value; }
        }

        [DisplayName("Employee Photo Path"), Expression("jEmployee.[PhotoPath]")]
        public String EmployeePhotoPath
        {
            get { return Fields.EmployeePhotoPath[this]; }
            set { Fields.EmployeePhotoPath[this] = value; }
        }

        [DisplayName("Territory Territory Description"), Expression("jTerritory.[TerritoryDescription]")]
        public String TerritoryTerritoryDescription
        {
            get { return Fields.TerritoryTerritoryDescription[this]; }
            set { Fields.TerritoryTerritoryDescription[this] = value; }
        }

        [DisplayName("Territory Region Id"), Expression("jTerritory.[RegionID]")]
        public Int32? TerritoryRegionID
        {
            get { return Fields.TerritoryRegionID[this]; }
            set { Fields.TerritoryRegionID[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.EmployeeID; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TerritoryID; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EmployeeTerritoryRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field EmployeeID;
            public StringField TerritoryID;

            public StringField EmployeeLastName;
            public StringField EmployeeFirstName;
            public StringField EmployeeTitle;
            public StringField EmployeeTitleOfCourtesy;
            public DateTimeField EmployeeBirthDate;
            public DateTimeField EmployeeHireDate;
            public StringField EmployeeAddress;
            public StringField EmployeeCity;
            public StringField EmployeeRegion;
            public StringField EmployeePostalCode;
            public StringField EmployeeCountry;
            public StringField EmployeeHomePhone;
            public StringField EmployeeExtension;
            public StreamField EmployeePhoto;
            public StringField EmployeeNotes;
            public Int32Field EmployeeReportsTo;
            public StringField EmployeePhotoPath;


            public StringField TerritoryTerritoryDescription;
            public Int32Field TerritoryRegionID;

            public RowFields()
                : base("EmployeeTerritories")
            {
                LocalTextPrefix = "Northwind.EmployeeTerritory";
            }
        }
    }
}