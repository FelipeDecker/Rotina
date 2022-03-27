using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Rotina.DomainService.Helpers
{
    public static class Helper
    {
		public static bool ValidateCpf(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf += digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito += resto.ToString();
			return cpf.EndsWith(digito);
		}

		public static bool ValidateCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj += digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito += resto.ToString();
			return cnpj.EndsWith(digito);
		}

		public static bool ValidatePis(string pis)
		{
			int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			if (pis.Trim().Length != 11)
				return false;
			pis = pis.Trim();
			pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(pis[i].ToString()) * multiplicador[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			return pis.EndsWith(resto.ToString());
		}

		public static bool ValidateEmail(string email)
		{
			try
			{
				return new MailAddress(email).Address == email;
			}
			catch
			{
				return false;
			}
		}

		public static void ExternalRequest()
		{
			WebClient webClient = new WebClient();
			webClient.DownloadStringTaskAsync("a");
			string conteudo = webClient.DownloadString("url");
			string conteudo2 = webClient.DownloadString("url");
		}

		public static string ApiSecret()
		{
			return "0a8668c28dda4e1684c6374ed3f307b9";
		}
	}
}
