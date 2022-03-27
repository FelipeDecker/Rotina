using System.Text.RegularExpressions;

namespace Rotina.DomainService.Helpers
{
    public static class StringHelper
    {
		public static string RemoveSpecialCharacters(this string txt)
		{
			return Regex.Replace(txt, "[^ @.a-zA-Z0-9]", "");
		}

		public static string RemoveAccents(this string txt)
		{
			string withAccents = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
			string withoutAccents = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

			for (int i = 0; i < withAccents.Length; i++)
			{
				txt = txt.Replace(withAccents[i].ToString(), withoutAccents[i].ToString());
			}

			return txt;
		}
	}
}
