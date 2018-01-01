using BlogWeb.Models;

namespace BlogWeb.ViewModels
{
    public class PostsPorMesModel
    {
        public int Mes { get; set; }

        public string MesTexto => NomeMes(Mes);

        public int Ano { get; set; }

        public long Quantidade { get; set; }
        
        public PostsPorMesModel(PostsPorMes postsPorMes)
        {
            Mes = postsPorMes.Mes;
            Ano = postsPorMes.Ano;
            Quantidade = postsPorMes.Quantidade;
        }

        public override string ToString()
        {
            return $"{MesTexto}/{Ano} ({Quantidade})";
        }

        private string NomeMes(int mes)
        {
            var nomeMes = "";

            switch (mes)
            {
                case 1:
                    nomeMes = "Janeiro";
                    break;
                case 2:
                    nomeMes = "Fevereiro";
                    break;
                case 3:
                    nomeMes = "Março";
                    break;
                case 4:
                    nomeMes = "Abril";
                    break;
                case 5:
                    nomeMes = "Maio";
                    break;
                case 6:
                    nomeMes = "Junho";
                    break;
                case 7:
                    nomeMes = "Julho";
                    break;
                case 8:
                    nomeMes = "Agosto";
                    break;
                case 9:
                    nomeMes = "Setembro";
                    break;
                case 10:
                    nomeMes = "Outubro";
                    break;
                case 11:
                    nomeMes = "Novembro";
                    break;
                case 12:
                    nomeMes = "Dezembro";
                    break;
                default:
                    break;
            }

            return nomeMes;
        }
    }
}