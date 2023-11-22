using System;
namespace ApiReseñaValoracion.Exceptions
{
	public class BadRequestException:Exception
	{
		public BadRequestException(string message):base(message)
		{
		}
	}
}

