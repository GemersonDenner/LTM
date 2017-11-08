using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Entity.DAL
{
    public class Usuario
    {
		public Guid Id { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public string Nome { get; set; }

		public string Email { get; set; }


		public Usuario()
		{
			this.Id = Guid.NewGuid();
		}
	}
}
