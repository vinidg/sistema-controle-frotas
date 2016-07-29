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

namespace WindowsFormsApplication2
{
    class StatusBD
    {
        string DtHrCiencia, DtHrCienciaReg, DtHrChegadaOrigem, DtHrChegadaOrigemReg, DtHrSaidaOrigem, DtHrSaidaOrigemReg, 
            DtHrChegadaDestino, DtHrChegadaDestinoReg, DtHrLiberacaoEquipe, DtHrLiberacaoEquipeReg, DtHrEquipePatio, DtHrEquipePatioReg,
            idAmbulanciaSol, Origem, Destino, Condutor, Equipe, MotivoCancelamento, DtHrCancelamento, ResposavelCancelamento, ObsCancelamento;

        public string DtHrCiencia1
        {
            get { return DtHrCiencia; }
            set { DtHrCiencia = value; }
        }

        public string DtHrCienciaReg1
        {
            get { return DtHrCienciaReg; }
            set { DtHrCienciaReg = value; }
        }

        public string DtHrChegadaOrigem1
        {
            get { return DtHrChegadaOrigem; }
            set { DtHrChegadaOrigem = value; }
        }

        public string DtHrChegadaOrigemReg1
        {
            get { return DtHrChegadaOrigemReg; }
            set { DtHrChegadaOrigemReg = value; }
        }

        public string DtHrSaidaOrigem1
        {
            get { return DtHrSaidaOrigem; }
            set { DtHrSaidaOrigem = value; }
        }

        public string DtHrSaidaOrigemReg1
        {
            get { return DtHrSaidaOrigemReg; }
            set { DtHrSaidaOrigemReg = value; }
        }

        public string DtHrChegadaDestino1
        {
            get { return DtHrChegadaDestino; }
            set { DtHrChegadaDestino = value; }
        }

        public string DtHrChegadaDestinoReg1
        {
            get { return DtHrChegadaDestinoReg; }
            set { DtHrChegadaDestinoReg = value; }
        }

        public string DtHrLiberacaoEquipe1
        {
            get { return DtHrLiberacaoEquipe; }
            set { DtHrLiberacaoEquipe = value; }
        }

        public string DtHrLiberacaoEquipeReg1
        {
            get { return DtHrLiberacaoEquipeReg; }
            set { DtHrLiberacaoEquipeReg = value; }
        }

        public string DtHrEquipePatio1
        {
            get { return DtHrEquipePatio; }
            set { DtHrEquipePatio = value; }
        }

        public string DtHrEquipePatioReg1
        {
            get { return DtHrEquipePatioReg; }
            set { DtHrEquipePatioReg = value; }
        }

        public string IdAmbulanciaSol
        {
            get { return idAmbulanciaSol; }
            set { idAmbulanciaSol = value; }
        }

        public string Origem1
        {
            get { return Origem; }
            set { Origem = value; }
        }

        public string Destino1
        {
            get { return Destino; }
            set { Destino = value; }
        }

        public string Condutor1
        {
            get { return Condutor; }
            set { Condutor = value; }
        }

        public string Equipe1
        {
            get { return Equipe; }
            set { Equipe = value; }
        }

        public string MotivoCancelamento1
        {
            get { return MotivoCancelamento; }
            set { MotivoCancelamento = value; }
        }

        public string DtHrCancelamento1
        {
            get { return DtHrCancelamento; }
            set { DtHrCancelamento = value; }
        }

        public string ResposavelCancelamento1
        {
            get { return ResposavelCancelamento; }
            set { ResposavelCancelamento = value; }
        }

        public string ObsCancelamento1
        {
            get { return ObsCancelamento; }
            set { ObsCancelamento = value; }
        }
        int ContadorMaxdePacientes, idSolicitacoesPacientes, idSolicitacoes_Ambulancias, IdOutroPaciente, idPaciente, idSolicitacaoAM;

        public int IdSolicitacaoAM
        {
            get { return idSolicitacaoAM; }
            set { idSolicitacaoAM = value; }
        }

        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public int IdOutroPaciente1
        {
            get { return IdOutroPaciente; }
            set { IdOutroPaciente = value; }
        }

        public int IdSolicitacoes_Ambulancias
        {
            get { return idSolicitacoes_Ambulancias; }
            set { idSolicitacoes_Ambulancias = value; }
        }

        public int IdSolicitacoesPacientes
        {
            get { return idSolicitacoesPacientes; }
            set { idSolicitacoesPacientes = value; }
        }

        public int ContadorMaxdePacientes1
        {
            get { return ContadorMaxdePacientes; }
            set { ContadorMaxdePacientes = value; }
        }

        public void countparaMaxPacientes(int AMSelecionada)
        {
            int zero = 0;
            using(DAHUEEntities db = new DAHUEEntities()){
                var query = from sa in db.solicitacoes_ambulancias
                            where sa.idAmbulanciaSol == AMSelecionada &&
                            sa.SolicitacaoConcluida == zero
                            select sa.idSolicitacoes_Ambulancias;

                var queryCount = query.Count();
                ContadorMaxdePacientes = queryCount;
            }
                    
        }

        public void atualizarStatusOcupado(int CodAM)
        {
            int zero = 0;
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sa in db.solicitacoes_ambulancias
                             where sa.idAmbulanciaSol == CodAM &&
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
                    DtHrEquipePatioReg = query.DtHrEquipePatioReg.ToString();
                    }
                        idAmbulanciaSol = query.idAmbulanciaSol.ToString();
                    
            }
        }
        public void atualizarStatusOcupadoPaciente()
        {
            //atualizar a AM dependendo do status no banco
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sa in db.solicitacoes_paciente
                            where sa.idPaciente_Solicitacoes == idSolicitacoesPacientes
                            select new { sa.Origem, sa.Destino }).FirstOrDefault();
                Origem = query.Origem;
                Destino = query.Destino;
            }
        }

        public void selectEquipeBD(int amcd)
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from eq in db.equipe
                            where eq.idAM == amcd
                            orderby eq.idEquipe descending
                            select eq).FirstOrDefault();

                Condutor = query.Condutor;
                Equipe = query.Enfermeiros;
            }
    }
        }
}
