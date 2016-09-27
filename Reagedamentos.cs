using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using db_transporte_sanitario;

namespace Sistema_Controle
{
    public partial class Reagedamentos : Form
    {
        public Reagedamentos(int IdPaciente)
        {
            InitializeComponent();

            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sad in db.solicitacoes_agendamentos
                             join sp in db.solicitacoes_paciente
                             on sad.idSolicitacao_paciente equals sp.idPaciente_Solicitacoes into sad_join from sp in sad_join.DefaultIfEmpty() 
                             where sad.idSolicitacao_paciente == IdPaciente
                             select new { 
                                ID = sad.idSolicitacaoAgendamento, 
                                 sad.DtHrAgendamento }).ToList();
                ListaReagementos.DataSource = query;
                ListaReagementos.Refresh();
            }
        }
    }
}
