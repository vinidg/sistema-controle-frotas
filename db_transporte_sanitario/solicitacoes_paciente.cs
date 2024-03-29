//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace db_transporte_sanitario
{
    using System;
    using System.Collections.Generic;
    
    public partial class solicitacoes_paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public solicitacoes_paciente()
        {
            this.historico = new HashSet<historico>();
            this.solicitacoes_agendamentos = new HashSet<solicitacoes_agendamentos>();
        }
    
        public int idPaciente_Solicitacoes { get; set; }
        public string TipoSolicitacao { get; set; }
        public DateTime? DtHrdoInicio { get; set; }
        public string Agendamento { get; set; }
        public string DtHrAgendamento { get; set; }
        public string NomeSolicitante { get; set; }
        public string LocalSolicitacao { get; set; }
        public string Telefone { get; set; }
        public string Paciente { get; set; }
        public string Genero { get; set; }
        public string Idade { get; set; }
        public string Diagnostico { get; set; }
        public string Motivo { get; set; }
        public string SubMotivo { get; set; }
        public string Prioridade { get; set; }
        public string Origem { get; set; }
        public string EnderecoOrigem { get; set; }
        public string Destino { get; set; }
        public string EnderecoDestino { get; set; }
        public string ObsGerais { get; set; }
        public Nullable<int> AmSolicitada { get; set; }
        public string Registrado { get; set; }
        public string HrRegistro { get; set; }
        public DateTime? DtHrdoAgendamento { get; set; }
        public int? idReagendamento { get; set; }
        public bool Gestante { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historico> historico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<solicitacoes_agendamentos> solicitacoes_agendamentos { get; set; }
    }
}
