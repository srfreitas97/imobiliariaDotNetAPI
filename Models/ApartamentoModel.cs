namespace ImobliariaAPI.Models.Apartamento
{
    public class Apartamento{

        public int Id{ get; set; }
        public int Area{ get; set; }
        public int NumQuartos{ get; set;}
        public string Regiao { get; set; }

        public Apartamento(int id,int area,int numQuartos,string regiao)
        {
            Id = id;
            Area = area;
            NumQuartos = numQuartos;
            Regiao = regiao;
            
        }

        public Apartamento()
        {
            
        }
    }
}