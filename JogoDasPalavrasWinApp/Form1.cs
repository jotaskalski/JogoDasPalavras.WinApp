using System.Text;

namespace JogoDasPalavrasWinApp
{
    public partial class Form1 : Form
    {
        private string palavraSecreta;
        private string palpiteUsuario;
        private List<Label> labels = new List<Label>();
        private int linha = 1;
        private int coluna = 0;

        public Form1()
        {
            InitializeComponent();
            RegistrarEventos();
            PalavraSecreta();
        }
        private void RegistrarEventos()
        {
            foreach (Button botao in pnlBotoes.Controls)
            {
                botao.Click += Palpite;
            }
            btnReiniciar.Click += Reiniciar;
        }

        private void Reiniciar(object? sender, EventArgs e)
        {
            PalavraSecreta();
            palpiteUsuario = "";
            labels.Clear();
            linha = 1;
            coluna = 0;

            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Label label = (Label)tableLayoutPanel1.GetControlFromPosition(i, j);
                    label.Text = "";
                    label.BackColor = Color.LightGray;
                    label.ForeColor = Color.Black;
                }
            }
            btnReiniciar.Visible = false;
            pnlBotoes.Enabled = true;
        }

        private void Palpite(object? sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;
            string palpite = botaoClicado.Text;
            palpiteUsuario += palpite;
            Label label = (Label)tableLayoutPanel1.GetControlFromPosition(coluna, linha - 1);
            label.Text = palpite;
            labels.Add(label);
            coluna++;
            if (palpiteUsuario.Length != 5)
                return;
            VerificarLetras();
            VerificarStatus();
        }

        private void VerificarLetras()
        {
            int contador = 0;
            labels.ForEach(label =>
            {
                label.ForeColor = Color.White;
                if (!palavraSecreta.Contains(label.Text))
                {
                    label.BackColor = Color.DarkGray;
                }
                else if (label.Text == palavraSecreta[contador].ToString())
                {
                    label.BackColor = Color.Green;
                }
                else
                {
                    label.BackColor = Color.Yellow;
                }
                contador++;
            });
        }

        public bool JogadorAcertou()
        {
            bool jogadorVenceu = false;

            if (palpiteUsuario == palavraSecreta)
            {
                pnlBotoes.Enabled = false;
                MessageBox.Show("Você venceu, parabéns!");
                jogadorVenceu = true;
                btnReiniciar.Visible = true;
            }
            if (linha == 5 && palpiteUsuario != palavraSecreta)
            {
                pnlBotoes.Enabled = false;
                MessageBox.Show("Você perdeu! :(");
                MessageBox.Show($"A palavra era: {palavraSecreta}");
                jogadorVenceu = false;
                btnReiniciar.Visible = true;

            }
            return jogadorVenceu;
        }
        private void VerificarStatus()
        {
            if (JogadorAcertou())
                return;

            linha += 1;
            coluna = 0;
            labels.Clear();
            palpiteUsuario = "";


        }
        private void PalavraSecreta()
        {
            string[] palavras = new string[]
            {
                "acido", "adiar", "impar", "algar", "amado", "amigo", "anexo", "anuir", "aonde", "apelo",
                "aquem", "argil", "arroz", "assar", "atras", "avido", "azeri", "babar", "bagre", "banho",
                "barco", "bicho", "bolor", "brasa", "brava", "brisa", "bruto", "bulir", "caixa", "cansa",
                "chato", "chave", "chefe", "choro", "chulo", "claro", "cobre", "corte", "curar", "deixo",
                "dizer", "dogma", "dores", "duque", "enfim", "estou", "exame", "falar", "fardo", "farto",
                "fatal", "feliz", "ficar", "fogue", "força", "forno", "fraco", "fugir", "fundo", "furia",
                "gaita", "gasto", "geada", "gelar", "gosto", "grito", "gueto", "honra", "humor", "idade",
                "ideia", "idolo", "igual", "imune", "indio", "ingua", "irado", "isola", "janta", "jovem",
                "juizo", "largo", "laser", "leite", "lento", "lerdo", "levar", "lidar", "lindo", "lirio",
                "longe", "luzes", "magro", "maior", "malte", "mamar", "manto", "marca", "matar", "meigo",
                "meios", "melao", "mesmo", "metro", "mimos", "moeda", "moita", "molho", "morno", "morro",
                "motim", "muito", "mural", "naipe", "nasci", "natal", "naval", "ninar", "nivel", "nobre",
                "noite", "norte", "nuvem", "oeste", "ombro", "ordem", "orgao", "osseo", "ossos", "outro",
                "ouvir", "palma", "pardo", "passe", "patio", "peito", "pelos", "perdo", "peril", "perto",
                "pezar", "piano", "picar", "pilar", "pingo", "pione", "pista", "poder", "porem", "prado",
                "prato", "prazo", "preço", "prima", "primo", "pular", "quero", "quota", "raiva", "rampa",
                "rango", "reais", "reino", "rezar", "risco", "roçar", "rosto", "roubo", "russo", "saber",
                "sacar", "salto", "samba", "santo", "selar", "selos", "senso", "serao", "serra", "servo",
                "sexta", "sinal", "sobra", "sobre", "socio", "sorte", "subir", "sujei", "sujos", "talao",
                "talha", "tanga", "tarde", "tempo", "tenho", "terço", "terra", "tesao", "tocar", "lacre",
                "laico", "lamba", "lambo", "largo", "larva", "lasca", "laser", "laura", "lavra", "leigo",
                "leite", "leito", "leiva", "lenho", "lento", "leque", "lerdo", "lesao", "lesma", "levar",
                "libra", "limbo", "lindo", "lineo", "lirio", "lisar", "lista", "livro", "logar", "lombo",
                "lotes", "louca", "louco", "louro", "lugar", "luzes", "macio", "maçom", "maior", "malha",
                "malte", "mamar", "mamae", "manto", "março", "maria", "marra", "marta", "matar", "medir",
                "meigo", "meios", "melao", "menta", "menti", "mesmo", "metro", "miado", "midia", "mielo",
                "mielo", "milho", "mimos", "minar", "minha", "miolo", "mirar", "missa", "mitos", "moeda",
                "moido", "moita", "molde", "molho", "monar", "monja", "moral", "morar", "morda", "morfo",
                "morte", "mosca", "mosco", "motim", "motor", "mudar", "muito", "mular", "mulas", "mumia",
                "mural", "extra", "falar", "falta", "fardo", "farol", "farto", "fatal", "feixe", "festa",
                "feudo", "fezes", "fiapo", "fibra", "ficha", "fidel", "filao", "filho", "firma", "fisco",
                "fisga", "fluir", "força", "forma", "forte", "fraco", "frade", "friso", "frito", "fugaz",
                "fugir", "fundo", "furor", "furto", "fuzil", "gabar", "gaita", "galho", "ganho", "garoa",
                "garra", "garro", "garvo", "gasto", "gaupe", "gazua", "geada", "gemer", "germe", "gigas",
                "girar", "gizar", "globo", "gosto", "graos", "graça", "grava", "grito", "grude", "haver",
                "haver", "hiato", "hidra", "hifen", "himel", "horas", "hotel", "humor", "ideal", "idolo",
                "igual", "ileso", "imune", "irado", "isola", "jarra", "jaula", "jegue", "jeito", "jogar",
                "jovem", "juiza", "juizo", "julho", "junho", "jurar", "justa"
            };

            int index = new Random().Next(0, palavras.Length);
            palavraSecreta = palavras[index].ToUpper();
        }
    }
}