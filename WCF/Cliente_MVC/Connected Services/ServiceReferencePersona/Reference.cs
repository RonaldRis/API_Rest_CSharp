﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cliente_MVC.ServiceReferencePersona {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persona", Namespace="http://schemas.datacontract.org/2004/07/WCF.Models")]
    [System.SerializableAttribute()]
    public partial class Persona : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Apellido {
            get {
                return this.ApellidoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoField, value) != true)) {
                    this.ApellidoField = value;
                    this.RaisePropertyChanged("Apellido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferencePersona.IWCF_Persona")]
    public interface IWCF_Persona {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCF_Persona/GetAll", ReplyAction="http://tempuri.org/IWCF_Persona/GetAllResponse")]
        Cliente_MVC.ServiceReferencePersona.Persona[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCF_Persona/GetAll", ReplyAction="http://tempuri.org/IWCF_Persona/GetAllResponse")]
        System.Threading.Tasks.Task<Cliente_MVC.ServiceReferencePersona.Persona[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCF_Persona/GetById", ReplyAction="http://tempuri.org/IWCF_Persona/GetByIdResponse")]
        Cliente_MVC.ServiceReferencePersona.Persona GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCF_Persona/GetById", ReplyAction="http://tempuri.org/IWCF_Persona/GetByIdResponse")]
        System.Threading.Tasks.Task<Cliente_MVC.ServiceReferencePersona.Persona> GetByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCF_PersonaChannel : Cliente_MVC.ServiceReferencePersona.IWCF_Persona, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCF_PersonaClient : System.ServiceModel.ClientBase<Cliente_MVC.ServiceReferencePersona.IWCF_Persona>, Cliente_MVC.ServiceReferencePersona.IWCF_Persona {
        
        public WCF_PersonaClient() {
        }
        
        public WCF_PersonaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCF_PersonaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCF_PersonaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCF_PersonaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Cliente_MVC.ServiceReferencePersona.Persona[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<Cliente_MVC.ServiceReferencePersona.Persona[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public Cliente_MVC.ServiceReferencePersona.Persona GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<Cliente_MVC.ServiceReferencePersona.Persona> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
    }
}
