using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Client
    {
        public string? MomChegada {get; set;}
        public string? DurAtendimento {get; set;}
        public int Id {get; set;}

        public int TempoEspera {get; set;}
        

        public Client()
        {
            
        }
        public Client(string? momChegada, string? durAtendimento, int id)
        {
            MomChegada = momChegada;
            DurAtendimento = durAtendimento;
            Id = id;
        }

        public override string ToString()
        {
            return $"Cliente: {this.Id} \nChegou: {this.MomChegada} \nTempo de atendimento: {this.DurAtendimento}";
        }
        
    }
}