using System;
namespace ApiReseñaValoracion.Exceptions
{
	public class KeyNotFoundException:Exception
	{
		public KeyNotFoundException(string message):base(message)
		{
		}
	}
}

