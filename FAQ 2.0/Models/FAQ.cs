using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAQ_2._0.Models
{
    public class FAQ
    {
        public int FAQID { get; set; }

        public string Pergunta { get; set; }

        public string Resposta { get; set; }

        //public string Language { get; set; }

        public bool Premium { get; set; }

        public int Pos { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}