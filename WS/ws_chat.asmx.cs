using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WS
{
    /// <summary>
    /// Description résumée de ws_chat
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_chat : System.Web.Services.WebService
    {
        DCDataContext dc = new DCDataContext();

        [WebMethod]
        public List<String> Participer(string pseudo)
        {
            if (!Exists(pseudo))
            {
                Participant participant = new Participant();
                participant.Pseudo = pseudo;
                dc.Participant.InsertOnSubmit(participant);
                dc.SubmitChanges();
                List<String> list = (from x in dc.Participant select x.Pseudo).ToList();
                return list;
            }
            else
                return null;
        }

        public bool Exists(string psesudo)
        {
            var List = (from x in dc.Participant select x).ToList();
            foreach (Participant p in List)
            { if (p.Pseudo.Equals(psesudo))
                    return true;
            }
            return false;
        }
        [WebMethod]
        public void addMessage(string pseudo_em,string pseudo_recep,string text)
        {
            Message message = new Message();
            
            message.ID_emetteur = dc.Participant.FirstOrDefault(p => p.Pseudo == pseudo_em).ID;
            message.ID_recepteur = dc.Participant.FirstOrDefault(p => p.Pseudo == pseudo_recep).ID;
            message.Text = text;
            dc.Message.InsertOnSubmit(message);
            dc.SubmitChanges();
        }
        public class returnList
        {
            public List<string> emipseudos;
            public List<string> texts;
            public List<int> ids;
        }
        [WebMethod]
        public returnList getMessage(string pseudo_recep)
          {
             int ID_recepteur = dc.Participant.FirstOrDefault(p => p.Pseudo == pseudo_recep).ID;
               List<int?> emids = new List<int?>();
            List<int> ids = new List<int>();
            List<string> texts = new List<string>();
            ids= (from m in dc.Message where m.ID_recepteur == ID_recepteur select m.ID).ToList();
            emids = (from m in dc.Message where m.ID_recepteur == ID_recepteur select m.ID_emetteur).ToList();
            List<string> empsuedos = new List<string>();
            foreach(int id in emids)
            {
                empsuedos.Add(dc.Participant.FirstOrDefault(p => p.ID == id).Pseudo);
            }
                texts= (from m in dc.Message where m.ID_recepteur == ID_recepteur select m.Text).ToList();
            
            returnList toReturn = new returnList() {
                emipseudos = empsuedos,
                texts = texts,
            ids=ids};
            return toReturn;
          }


        [WebMethod]
        public void Delete(string pseudo)
        {
            int id = dc.Participant.FirstOrDefault(p => p.Pseudo == pseudo).ID; ;
            foreach (Message message in (from m in dc.Message where m.ID_recepteur == id 
                                         || m.ID_emetteur==id select m).ToList()) { 
            dc.Message.DeleteOnSubmit(message);
            dc.SubmitChanges();
            }
            dc.Participant.DeleteOnSubmit(dc.Participant.FirstOrDefault(p => p.Pseudo == pseudo));
            dc.SubmitChanges();
        }

        [WebMethod]
        public List<String> GetParticipants()
        {
            List<String> list = (from x in dc.Participant select x.Pseudo).ToList();
            return list;
        }
    }
}
