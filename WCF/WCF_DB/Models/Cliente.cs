namespace WCF_DB.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Cliente")]
    [DataContract]
    public partial class Cliente
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        [StringLength(50)]
        public string nombre { get; set; }

        [DataMember]
        [StringLength(50)]
        public string direccion { get; set; }

        [DataMember]
        public int? edad { get; set; }
    }
}
