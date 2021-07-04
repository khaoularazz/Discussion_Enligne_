using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

using System.Windows.Forms;

namespace Discussion_Enligne
{
    public partial class Participation : Form
    {
        delegate void AsyncMethodCaller();
        List<string> pseudos = new List<string>();
        List<int> idsold = new List<int>();
        List<string> participantsold = new List<string>();
        public string Mypseudo { get; set; }
        public List<string> participants { get; set; }
        srv.ws_chatSoapClient srvchat = new srv.ws_chatSoapClient();
        public int t = 0;
        public Participation()
        {
            InitializeComponent();
        }
        public Participation(string pseudo, List<string> participants)
        {
            InitializeComponent();
            this.Mypseudo = pseudo;
            this.participants = participants.ToList();
            participantsold = participants;

        }

        private System.Windows.Forms.Timer timer1;
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {  if (t == 0)
           {  string text;
                List<string> ls = srvchat.getMessage(Mypseudo).texts;
                List<string> ls1 = srvchat.getMessage(Mypseudo).emipseudos;
                List<int> ids = srvchat.getMessage(Mypseudo).ids;
                for (int i = 0; i < ls.Count; i++)
                {
                    if (!idsold.Contains(ids[i]))
                    {
                        text = ls1[i] + ":" + ls[i];
                        listBox1.Items.Add(text);
                    }
                }
                idsold = srvchat.getMessage(Mypseudo).ids;
            }
            participants = srvchat.GetParticipants().ToList();
            foreach(string p in participants)
            {
                if (!participantsold.Contains(p)&& !p.Equals(Mypseudo))
                    lstparticipant.Items.Add(p);
            }
            foreach (string p in participantsold)
            {
                if (!participants.Contains(p)&& !p.Equals(Mypseudo))
                    lstparticipant.Items.Remove(p);
            }
            participantsold = srvchat.GetParticipants().ToList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = "";

            foreach (int i in lstparticipant.SelectedIndices)
            {
                selectedItem = lstparticipant.GetItemText(lstparticipant.Items[i]);
                if (!pseudos.Contains(selectedItem))
                    pseudos.Add(selectedItem);
            }
        }

        private void Participation_Load(object sender, EventArgs e)
        {
            string text = "Bienvenue " + Mypseudo;
            label3.Text = text;
            lstparticipant.DisplayMember = "pseudo";
            foreach (string p in participants)
            {
                if (!p.Equals(Mypseudo))
                    lstparticipant.Items.Add(p);
            }
            idsold = srvchat.getMessage(Mypseudo).ids;
            InitTimer();
        }

        private void Participation_Close(object sender, FormClosedEventArgs e)
        {
            if (t != 1) { 
           t = 2; 
           srvchat.Delete(Mypseudo);    
            }
            this.Close();
        }

        private void envoyer_Click(object sender, EventArgs e)
        {
            foreach (string rec_pseudo in pseudos)
            {
                srvchat.addMessage(Mypseudo, rec_pseudo, textBox1.Text);
            }
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            t = 1;
            srvchat.Delete(Mypseudo);
            this.Close();
        }
    }
}
