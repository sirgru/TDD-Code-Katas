using System;
using System.Runtime.Serialization;

namespace Kata_1
{
	[Serializable]
	public class InputException : Exception
	{
		public InputException()
		{
		}

		public InputException(string message) : base(message)
		{
		}

		public InputException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InputException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}