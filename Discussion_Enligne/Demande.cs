using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discussion_Enligne
{
    public partial class Demande : Form
    {
        srv.ws_chatSoapClient srvchat = new srv.ws_chatSoapClient();
        public Demande()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnparticiper_Click(object sender, EventArgs e)
        {

           List<string> participants= srvchat.Participer(txtpseudo.Text);
           
            if (participants == null)
            {
               pseudo_validation.Text = "votre pseudo est utilisé";
            }
            else
            {
                Participation participation = new Participation(txtpseudo.Text, participants);
                participation.ShowDialog();
            }
        }
    }
}
