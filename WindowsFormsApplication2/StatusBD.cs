using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using db_transporte_sanitario;

namespace Sistema_Controle
{
    class StatusBD
    {

        string DtHrCiencia, DtHrCienciaReg, DtHrChegadaOrigem, DtHrChegadaOrigemReg, DtHrSaidaOrigem, DtHrSaidaOrigemReg,
            DtHrChegadaDestino, DtHrChegadaDestinoReg, DtHrLiberacaoEquipe, DtHrLiberacaoEquipeReg, DtHrEquipePatio, DtHrEquipePatioReg;
        int idAmbulanciaSol;
        int idSolicitacoesPacientes, IdOutroPaciente;
        int? idSolicitacoes_Ambulancias;
        
        public void puxarLogisticaDaSolicitacaNaAmbulancia(int idPaciente)
        {
            int zero = 0;
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sa in db.solicitacoes_ambulancias
                             where sa.idSolicitacoesPacientes == idPaciente &&
                             sa.SolicitacaoConcluida == zero
                             select new
                             {
                                 sa.idSolicitacoes_Ambulancias,
                                 sa.IdOutroPaciente,
                                 sa.idSolicitacoesPacientes,
                                 sa.DtHrCiencia,
                                 sa.DtHrCienciaReg,
                                 sa.DtHrChegadaOrigem,
                                 sa.DtHrChegadaOrigemReg,
                                 sa.DtHrSaidaOrigem,
                                 sa.DtHrSaidaOrigemReg,
                                 sa.DtHrChegadaDestino,
                                 sa.DtHrChegadaDestinoReg,
                                 sa.DtHrLiberacaoEquipe,
                                 sa.DtHrLiberacaoEquipeReg,
                                 sa.DtHrEquipePatio,
                                 sa.DtHrEquipePatioReg,
                                 sa.idAmbulanciaSol
                             }).FirstOrDefault();
                if (query == null)
                {
                    return;
                }
                idSolicitacoes_Ambulancias = query.idSolicitacoes_Ambulancias;
                IdOutroPaciente = Convert.ToInt32(query.IdOutroPaciente);
                idSolicitacoesPacientes = Convert.ToInt32(query.idSolicitacoesPacientes);
                if (query.DtHrCiencia != null)
                {
                    DtHrCiencia = query.DtHrCiencia.ToString();
                }
                if (query.DtHrCienciaReg != null)
                {
                    DtHrCienciaReg = query.DtHrCienciaReg.ToString();
                }
                if (query.DtHrChegadaOrigem != null)
                {
                    DtHrChegadaOrigem = query.DtHrChegadaOrigem.ToString();
                }
                if (query.DtHrChegadaOrigemReg != null)
                {
                    DtHrChegadaOrigemReg = query.DtHrChegadaOrigemReg.ToString();
                }
                if (query.DtHrSaidaOrigem != null)
                {
                    DtHrSaidaOrigem = query.DtHrSaidaOrigem.ToString();
                }
                if (query.DtHrSaidaOrigemReg != null)
                {
                    DtHrSaidaOrigemReg = query.DtHrSaidaOrigemReg.ToString();
                }
                if (query.DtHrChegadaDestino != null)
                {
                    DtHrChegadaDestino = query.DtHrChegadaDestino.ToString();
                }
                if (query.DtHrChegadaDestinoReg != null)
                {
                    DtHrChegadaDestinoReg = query.DtHrChegadaDestinoReg.ToString();
                }
                if (query.DtHrLiberacaoEquipe != null)
                {
                    DtHrLiberacaoEquipe = query.DtHrLiberacaoEquipe.ToString();
                }
                if (query.DtHrLiberacaoEquipeReg != null)
                {
                    DtHrLiberacaoEquipeReg = query.DtHrLiberacaoEquipeReg.ToString();
                }
                if (query.DtHrEquipePatio != null)
                {
                    DtHrEquipePatio = query.DtHrEquipePatio.ToString();
                }
                if (query.DtHrLiberacaoEquipe != null)
                {
                    DtHrEquipePatioReg = query.DtHrEquipePatioReg;
                }
                idAmbulanciaSol = query.idAmbulanciaSol;
            }
        }
        public void puxarLogisticaDaSolicitacaNaAmbulanciaSelecionadaNaConsulta(int idPaciente, int solicitacaoAmbulancia)
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sa in db.solicitacoes_ambulancias
                             where sa.idSolicitacoesPacientes == idPaciente &&
                             sa.idSolicitacoes_Ambulancias == solicitacaoAmbulancia
                             select new
                             {
                                 sa.idSolicitacoes_Ambulancias,
                                 sa.IdOutroPaciente,
                                 sa.idSolicitacoesPacientes,
                                 sa.DtHrCiencia,
                                 sa.DtHrCienciaReg,
                                 sa.DtHrChegadaOrigem,
                                 sa.DtHrChegadaOrigemReg,
                                 sa.DtHrSaidaOrigem,
                                 sa.DtHrSaidaOrigemReg,
                                 sa.DtHrChegadaDestino,
                                 sa.DtHrChegadaDestinoReg,
                                 sa.DtHrLiberacaoEquipe,
                                 sa.DtHrLiberacaoEquipeReg,
                                 sa.DtHrEquipePatio,
                                 sa.DtHrEquipePatioReg,
                                 sa.idAmbulanciaSol
                             }).FirstOrDefault();
                if (query == null)
                {
                    return;
                }
                IdOutroPaciente = Convert.ToInt32(query.IdOutroPaciente);
                idSolicitacoesPacientes = Convert.ToInt32(query.idSolicitacoesPacientes);
                if (query.DtHrCiencia != null)
                {
                    DtHrCiencia = query.DtHrCiencia.ToString();
                }
                if (query.DtHrCienciaReg != null)
                {
                    DtHrCienciaReg = query.DtHrCienciaReg.ToString();
                }
                if (query.DtHrChegadaOrigem != null)
                {
                    DtHrChegadaOrigem = query.DtHrChegadaOrigem.ToString();
                }
                if (query.DtHrChegadaOrigemReg != null)
                {
                    DtHrChegadaOrigemReg = query.DtHrChegadaOrigemReg.ToString();
                }
                if (query.DtHrSaidaOrigem != null)
                {
                    DtHrSaidaOrigem = query.DtHrSaidaOrigem.ToString();
                }
                if (query.DtHrSaidaOrigemReg != null)
                {
                    DtHrSaidaOrigemReg = query.DtHrSaidaOrigemReg.ToString();
                }
                if (query.DtHrChegadaDestino != null)
                {
                    DtHrChegadaDestino = query.DtHrChegadaDestino.ToString();
                }
                if (query.DtHrChegadaDestinoReg != null)
                {
                    DtHrChegadaDestinoReg = query.DtHrChegadaDestinoReg.ToString();
                }
                if (query.DtHrLiberacaoEquipe != null)
                {
                    DtHrLiberacaoEquipe = query.DtHrLiberacaoEquipe.ToString();
                }
                if (query.DtHrLiberacaoEquipeReg != null)
                {
                    DtHrLiberacaoEquipeReg = query.DtHrLiberacaoEquipeReg.ToString();
                }
                if (query.DtHrEquipePatio != null)
                {
                    DtHrEquipePatio = query.DtHrEquipePatio.ToString();
                }
                if (query.DtHrLiberacaoEquipe != null)
                {
                    DtHrEquipePatioReg = query.DtHrEquipePatioReg;
                }
                idAmbulanciaSol = query.idAmbulanciaSol;
            }
        }

        #region Get&Set
        public int IdAmbulanciaSol
        {
            get { return idAmbulanciaSol; }
            set { idAmbulanciaSol = value; }
        }
        public string DtHrCiencia1
        {
            get { return DtHrCiencia; }
            set { DtHrCiencia = value; }
        }
        public string DtHrChegadaOrigem1
        {
            get { return DtHrChegadaOrigem; }
            set { DtHrChegadaOrigem = value; }
        }
        public string DtHrSaidaOrigem1
        {
            get { return DtHrSaidaOrigem; }
            set { DtHrSaidaOrigem = value; }
        }
        public string DtHrChegadaDestino1
        {
            get { return DtHrChegadaDestino; }
            set { DtHrChegadaDestino = value; }
        }
        public string DtHrLiberacaoEquipe1
        {
            get { return DtHrLiberacaoEquipe; }
            set { DtHrLiberacaoEquipe = value; }
        }
        public string DtHrEquipePatio1
        {
            get { return DtHrEquipePatio; }
            set { DtHrEquipePatio = value; }
        }
        public int? IdSolicitacoes_Ambulancias
        {
            get { return idSolicitacoes_Ambulancias; }
            set { idSolicitacoes_Ambulancias = value; }
        }
        public int IdSolicitacoesPacientes
        {
            get { return idSolicitacoesPacientes; }
            set { idSolicitacoesPacientes = value; }
        }
        #endregion
    }
}

