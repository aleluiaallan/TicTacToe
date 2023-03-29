using System;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        public char[] posicoes;
        private bool fimDeJogo;
        private char vez;
        private int jogadas;

        public void Tabuleiro()
        {
            fimDeJogo = false;
            posicoes = new [] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            jogadas = 0;
            Inicar();
        }

        public void Inicar()
        {
            while (!fimDeJogo)
            {
                DesenharTabela();
                Lerescolha();
                DesenharTabela();
                VerficarFimDeJogo();
                MudarVez();
            }
            Console.WriteLine("Deseja Jogar novamente? 1-sim ou 2-nao");
            var option = short.Parse(Console.ReadLine());


            if (option == 1)
                new JogoDaVelha().Tabuleiro();
            else
                return;
        }

        private void MudarVez()
        {
            if (vez == 'X')
            {
                vez = 'O';
            }
            else
                vez = 'X';
            
        }

        private void VerficarFimDeJogo()
        {
            if (jogadas < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Vitória de {vez}");
                return;
            }

            if (jogadas is 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo!!! EMPATE");
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaLinha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool vitoriaLinha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2;
        }
        #region metodo com ifs
        //private bool venceLinhas()
        //{
        //    if (posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2])
        //        return true;
        //    else if (posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5])
        //        return true;
        //        if (posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8])
        //                return true;
        //}
        //private bool venceColunas()
        //{
        //    if (posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6])
        //        return true;
        //    else if (posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7])
        //        return true;
        //    if (posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8])
        //        return true;

        //}
        //private bool venceDiagonal()
        //{
        //    if (posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8])
        //        return true;
        //    else if (posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6])
        //        return true;

        //}
        #endregion

        private void Lerescolha()
        {
            Console.WriteLine($"Agora é a vez de {vez}, entre uma posicoes que esteja disponivel.");
            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !Validarescolha(posicaoEscolhida))
            {
                Console.WriteLine("O campo é inválido, por favor digite um número entre 1 e 9 que esteja disponível na tabela");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            var indice = posicaoEscolhida - 1;
            posicoes[indice] = vez;
            jogadas++;
        }

        private bool Validarescolha(int posicaoEscolhida)
        {
            var indice = posicaoEscolhida - 1;

            return posicoes[indice] != 'O' && posicaoEscolhida != 'x';
        }

        private void DesenharTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"  {posicoes[0]}  |  {posicoes[1]}  |  {posicoes[2]}\n" +
                   $"-----+-----+-----\n" +
                   $"  {posicoes[3]}  |  {posicoes[4]}  |  {posicoes[5]}\n" +
                   $"-----+-----+-----\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }
}
