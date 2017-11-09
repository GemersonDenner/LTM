using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Entity.API
{
    public class LoginResponse
    {
		public Guid Id { get; set; }

		public string Login { get; set; }

		public string Nome { get; set; }

		public string Email { get; set; }

		public string ChaveJwt { get; set; }
	}
}
