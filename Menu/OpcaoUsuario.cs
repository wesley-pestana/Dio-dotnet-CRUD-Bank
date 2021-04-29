using System;
using System.Collections.Generic;

namespace DigitalBank
{
    public class OpcaoUsuario
    {
		static List<Conta> listaContas = new List<Conta>();
		private static string[] OpcaoValida = new string[7] {"1","2","3","4","5","C","X"};
		private static string opcaoUsuario;

        public static string ObterOpcaoUsuario()
		{
		
			do			
			{
				Console.WriteLine();
				Console.WriteLine("Bem Vindo ao DigitalBank");
            	Console.WriteLine();
				Console.WriteLine("Informe a opção desejada:");

				Console.WriteLine("1- Listar contas");
				Console.WriteLine("2- Inserir nova conta");
				Console.WriteLine("3- Transferir");
				Console.WriteLine("4- Sacar");
				Console.WriteLine("5- Depositar");
            	Console.WriteLine("C- Limpar Tela");
				Console.WriteLine("X- Sair");
				Console.WriteLine();

				opcaoUsuario = Console.ReadLine().ToUpper();
				if (TeclaValida(opcaoUsuario) == false)
				{
					Console.WriteLine("Opção Invalida");
					continue;					
				}
			}while(TeclaValida(opcaoUsuario) == false );

			return opcaoUsuario;			
		}

		public static bool TeclaValida(string opcaoUsuario)
		{
			bool valido = false;

			for(int i = 0; i < OpcaoValida.Length; i++)
			{
				if(opcaoUsuario == OpcaoValida[i] && valido == false)
				{
					valido = true;
				}
			}
			return valido;			
		}


        
        public static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor do deposito: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
		}

		public static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor que deseja sacar: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
		}

		public static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
		}

		public static void InserirConta()
		{
			Console.WriteLine("Inserir uma nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listaContas.Add(novaConta);
		}

		public static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (listaContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listaContas.Count; i++)
			{
				Conta conta = listaContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}
    }
}