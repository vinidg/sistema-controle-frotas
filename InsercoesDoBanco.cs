using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db_transporte_sanitario;
using System.Windows.Forms;

namespace Sistema_Controle
{
    public class InsercoesDoBanco
    {

        public void inserirSolicitacaoDoPaciente(string TipoSolicitacao, DateTime DtHrdoInicio, string Agendamento, DateTime DtHrdoAgendamento,
            string NomeSolicitante, string LocalSolicitacao, string Telefone, string Paciente, string Genero, string Idade,string Diagnostico, 
            string Motivo, string SubMotivo, string Prioridade, string Origem, string EnderecoOrigem, string Destino, string EnderecoDestino, 
            string ObsGerais, int AmSolicitada, string usuario)
        {

            using (DAHUEEntities dahue = new DAHUEEntities())
            {

                solicitacoes_paciente solicitacoesPaciente = new solicitacoes_paciente();

                solicitacoesPaciente.TipoSolicitacao = TipoSolicitacao;
                solicitacoesPaciente.DtHrdoInicio = DtHrdoInicio;
                solicitacoesPaciente.Agendamento = Agendamento;
                solicitacoesPaciente.DtHrdoAgendamento = DtHrdoAgendamento;
                solicitacoesPaciente.NomeSolicitante = NomeSolicitante;
                solicitacoesPaciente.LocalSolicitacao = LocalSolicitacao;
                solicitacoesPaciente.Telefone = Telefone;
                solicitacoesPaciente.Paciente = Paciente;
                solicitacoesPaciente.Genero = Genero;
                solicitacoesPaciente.Idade = Idade;
                solicitacoesPaciente.Diagnostico = Diagnostico;
                solicitacoesPaciente.Motivo = Motivo;
                solicitacoesPaciente.SubMotivo = SubMotivo;
                solicitacoesPaciente.Prioridade = Prioridade;
                solicitacoesPaciente.Origem = Origem;
                solicitacoesPaciente.EnderecoOrigem = EnderecoOrigem;
                solicitacoesPaciente.Destino = Destino;
                solicitacoesPaciente.EnderecoDestino = EnderecoDestino;
                solicitacoesPaciente.ObsGerais = ObsGerais;
                solicitacoesPaciente.AmSolicitada = AmSolicitada;
                if(Agendamento == "Sim")
                {
                    solicitacoesPaciente.Registrado = "Aguardando resposta do controle";
                }
                else
                {
                    solicitacoesPaciente.Registrado = "Sim";
                }


                historico hi = new historico();
                hi.Usuario = usuario;
                hi.DtHrRegistro = DtHrdoInicio;

                dahue.solicitacoes_paciente.Add(solicitacoesPaciente);
                dahue.historico.Add(hi);
                dahue.SaveChanges();
            }
            MessageBox.Show("Solicitação salva com sucesso !!!");
        }

        public void inserirEquipeNaAmbulancia(string condutor, string enfermeiros, DateTime dtEscala, int idAM)
        {
            using(DAHUEEntities db = new DAHUEEntities()){
                equipe equ = new equipe();
                equ.Condutor = condutor;
                equ.Enfermeiros = enfermeiros;
                equ.DtEscala = dtEscala;
                equ.idAM = idAM;

                db.equipe.Add(equ);
                db.SaveChanges();
            }
        }

        public void inserirEquipeAmOcupada(int idequipe, int idSolAM)
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                equipe_solam es = new equipe_solam();
                es.idequipe = idequipe;
                es.idSolAM = idSolAM;
                
                db.equipe_solam.Add(es);
                db.SaveChanges();
            }
        }

        public void inserirBloqueioDaAm(string DtHrStatus, string Registrado, string Motivo, int FkAM)
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                bloqueio bq = new bloqueio();
                bq.DtHrStatus = DtHrStatus;
                bq.Registrado = Registrado;
                bq.Motivo = Motivo;
                bq.FkAM = FkAM;

                db.bloqueio.Add(bq);

                ambulancia am = db.ambulancia.First(p => p.idAmbulancia == FkAM);
                am.StatusAmbulancia = "BLOQUEADA";
                
                db.SaveChanges();
        
            }
        }

        public void inserirDesloqueioDaAm(string Registrado, string DthrDesblo, int FkAMd)
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                desbloqueioam dbq = new desbloqueioam();
                dbq.Registrado = Registrado;
                dbq.DthrDesblo = DthrDesblo;
                dbq.fkAMd = FkAMd;

                db.desbloqueioam.Add(dbq);

                ambulancia am = db.ambulancia.First(p => p.idAmbulancia == FkAMd);
                am.StatusAmbulancia = "DISPONIVEL";

                db.SaveChanges();

            }
        }

        public void cancelarSolicitacao(int idPaciente, int idSolicitacaoAM, string MotivoCancelamento, string DtHrCancelamento, string ResposavelCancelamento, string ObsCancelamento)
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                cancelados_pacientes cancelados = new cancelados_pacientes();
                cancelados.idPaciente = idPaciente;
                cancelados.idSolicitacaoAM = idSolicitacaoAM;
                cancelados.MotivoCancelamento = MotivoCancelamento;
                cancelados.DtHrCancelamento = DtHrCancelamento;
                cancelados.ResposavelCancelamento = ResposavelCancelamento;
                cancelados.ObsCancelamento = ObsCancelamento;

                db.cancelados_pacientes.Add(cancelados);

                db.SaveChanges();
            }
        }

        public void updateNasTabelasParaCancelar(int idPaciente, int AMocup, int idSolicitacaoAM)
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                if(idSolicitacaoAM != 0)
                {
                    solicitacoes_ambulancias sa = db.solicitacoes_ambulancias.First(p => p.idSolicitacoes_Ambulancias == idSolicitacaoAM);
                    sa.SolicitacaoConcluida = 1;
                }

                    solicitacoes_paciente sp = db.solicitacoes_paciente.First(s => s.idPaciente_Solicitacoes == idPaciente);
                    sp.AmSolicitada = 1;

                var contemPaciente = (from soa in db.solicitacoes_ambulancias
                                      where soa.idAmbulanciaSol == AMocup && soa.SolicitacaoConcluida == 0
                                      select soa).Count();

                if (contemPaciente == 1)
                {
                    ambulancia am = db.ambulancia.First(a => a.idAmbulancia == AMocup);
                    am.StatusAmbulancia = "DISPONIVEL";
                }
                db.SaveChanges();
            }
        }

        public void confirmarAmbulanciaNaSolicitacao(int IDPaciente, int idAmbu)
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_ambulancias sa = new solicitacoes_ambulancias();
                sa.idSolicitacoesPacientes = IDPaciente;
                sa.idAmbulanciaSol = idAmbu;
                sa.SolicitacaoConcluida = 0;

                db.solicitacoes_ambulancias.Add(sa);

                ambulancia am = db.ambulancia.First(a => a.idAmbulancia == idAmbu);
                am.StatusAmbulancia = "OCUPADA";

                solicitacoes_paciente sp = db.solicitacoes_paciente.First(p => p.idPaciente_Solicitacoes == IDPaciente);
                sp.AmSolicitada = 1;

                db.SaveChanges();
            }
        }

        public void alterarCamposDaSolicitacao(int idPaciente, string tipoAM, string agendamento, string DtHrdoAgendamento, string nomeSolicitante, string localSolicitante,
            string telefone, string nomePaciente, string sexo, string idade, string diagnostico, string motivoChamado, string tipoMotivoChamado, string prioridade, string origem, string enderecoOrigem,
            string destino, string enderecoDestino, string registrado, string horaRegistrado, string obsGerais)
        {

            using(DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_paciente sp = db.solicitacoes_paciente.First(p => p.idPaciente_Solicitacoes == idPaciente);
                sp.TipoSolicitacao = tipoAM;
                sp.Agendamento = agendamento;
                sp.DtHrdoAgendamento = Convert.ToDateTime(DtHrdoAgendamento);
                sp.NomeSolicitante = nomeSolicitante;
                sp.LocalSolicitacao = localSolicitante;
                sp.Telefone = telefone;
                sp.Paciente = nomePaciente;
                sp.Genero = sexo;
                sp.Idade = idade;
                sp.Diagnostico = diagnostico;
                sp.Motivo = motivoChamado;
                sp.SubMotivo = tipoMotivoChamado;
                sp.Prioridade = prioridade;
                sp.Origem = origem;
                sp.EnderecoOrigem = enderecoOrigem;
                sp.Destino = destino;
                sp.EnderecoDestino = enderecoDestino;
                sp.Registrado = registrado;
                sp.HrRegistro = horaRegistrado;
                sp.ObsGerais = obsGerais;

                db.SaveChanges();
            }
        }

   

    }
}
