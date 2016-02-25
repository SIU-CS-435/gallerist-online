using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class Art
    {
        public int ArtId { get; set; }
        public string slug { get; set; }
        public ArtType type { get; set; }
        public int fame { get; set; }
        public int numTickets { get; set; }
        public string firstTicketData { get; set; }
        public VisitorTicketType[] firstTicket
        {
            get
            {

                return Array.ConvertAll(firstTicketData.Split(';'), v => (VisitorTicketType)Enum.Parse(typeof(VisitorTicketType), v));
            }
            set
            {
                firstTicketData = String.Join(";", value.Select(v => v.ToString()).ToArray());
            }
        }
        public string secondTicketData { get; set; }
        public VisitorTicketType[] secondTicket
        {
            get
            {

                return Array.ConvertAll(secondTicketData.Split(';'), v => (VisitorTicketType)Enum.Parse(typeof(VisitorTicketType), v));
            }
            set
            {
                secondTicketData = String.Join(";", value.Select(v => v.ToString()).ToArray());
            }
        }
    }
}
