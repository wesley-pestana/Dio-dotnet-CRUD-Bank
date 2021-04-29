using System;
using System.Collections.Generic;

namespace DigitalBank
{
    class Program
    {
		static void Main(string[] args)
		{
			string opcaoUsuario = OpcaoUsuario.ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						OpcaoUsuario.ListarContas();
						break;
					case "2":
						OpcaoUsuario.InserirConta();
						break;
					case "3":
						OpcaoUsuario.Transferir();
						break;
					case "4":
						OpcaoUsuario.Sacar();
						break;
					case "5":
						OpcaoUsuario.Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = OpcaoUsuario.ObterOpcaoUsuario();
			}
			
			Console.WriteLine("DigitalBank agradece por utilizar os nossos serviços.");
			Console.WriteLine();
		}

		
    }
}
