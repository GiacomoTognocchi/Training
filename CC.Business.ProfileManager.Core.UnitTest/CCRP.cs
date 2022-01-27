 using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.Collections.Generic;


    /// <summary>
    /// Custom Company Report Profile
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:crif-cribiscom-companyreport-2010-11-24")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:crif-cribiscom-companyreport-2010-11-24", IsNullable = false)]
    public partial class CCRP
    {

        private ReportDefinition sLOT1Field;

        private ReportDefinition sLOT2Field;

        private ReportDefinition sLOT3Field;

        private ReportDefinition sLOT4Field;

        private ReportDefinition sLOT5Field;

        private ReportDefinition sLOT6Field;

        private ReportDefinition sLOT7Field;

        private ReportDefinition sLOT8Field;

        /// <summary>
        /// CCRP class constructor
        /// </summary>
        public CCRP()
        {
            this.sLOT8Field = new ReportDefinition();
            this.sLOT7Field = new ReportDefinition();
            this.sLOT6Field = new ReportDefinition();
            this.sLOT5Field = new ReportDefinition();
            this.sLOT4Field = new ReportDefinition();
            this.sLOT3Field = new ReportDefinition();
            this.sLOT2Field = new ReportDefinition();
            this.sLOT1Field = new ReportDefinition();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ReportDefinition SLOT1
        {
            get
            {
                return this.sLOT1Field;
            }
            set
            {
                this.sLOT1Field = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ReportDefinition SLOT2
        {
            get
            {
                return this.sLOT2Field;
            }
            set
            {
                this.sLOT2Field = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public ReportDefinition SLOT3
        {
            get
            {
                return this.sLOT3Field;
            }
            set
            {
                this.sLOT3Field = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public ReportDefinition SLOT4
        {
            get
            {
                return this.sLOT4Field;
            }
            set
            {
                this.sLOT4Field = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public ReportDefinition SLOT5
        {
            get
            {
                return this.sLOT5Field;
            }
            set
            {
                this.sLOT5Field = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public ReportDefinition SLOT6
        {
            get
            {
                return this.sLOT6Field;
            }
            set
            {
                this.sLOT6Field = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public ReportDefinition SLOT7
        {
            get
            {
                return this.sLOT7Field;
            }
            set
            {
                this.sLOT7Field = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public ReportDefinition SLOT8
        {
            get
            {
                return this.sLOT8Field;
            }
            set
            {
                this.sLOT8Field = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:crif-cribiscom-companyreport-2010-11-24")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:crif-cribiscom-companyreport-2010-11-24", IsNullable = true)]
    public partial class ReportDefinition
    {

        private string pcField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PC
        {
            get
            {
                return this.pcField;
            }
            set
            {
                this.pcField = value;
            }
        }
    }