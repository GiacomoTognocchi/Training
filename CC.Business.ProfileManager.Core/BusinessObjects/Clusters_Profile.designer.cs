﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.38967
//    <NameSpace>CC.Business.ProfileManager.Core.CribisComX</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>True</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net20</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace CC.Business.ProfileManager.Core.CribisComX
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:crif-cribiscom-clusters-2018-06-03")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:crif-cribiscom-clusters-2018-06-03", IsNullable = false)]
    public partial class CP
    {

        private CPDefaultClusters defaultClustersField;

        private CPCustomClusters customClustersField;

        /// <remarks/>
        public CPDefaultClusters DefaultClusters
        {
            get
            {
                return this.defaultClustersField;
            }
            set
            {
                this.defaultClustersField = value;
            }
        }

        /// <remarks/>
        public CPCustomClusters CustomClusters
        {
            get
            {
                return this.customClustersField;
            }
            set
            {
                this.customClustersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:crif-cribiscom-clusters-2018-06-03")]
    public partial class CPDefaultClusters
    {

        private string vField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string V
        {
            get
            {
                return this.vField;
            }
            set
            {
                this.vField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:crif-cribiscom-clusters-2018-06-03")]
    public partial class CPCustomClusters
    {

        private string vField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string V
        {
            get
            {
                return this.vField;
            }
            set
            {
                this.vField = value;
            }
        }
    }
}