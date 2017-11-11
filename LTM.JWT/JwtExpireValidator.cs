using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.JWT
{
    public static class JwtExpireValidator
    {
		public static bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken token, TokenValidationParameters @params)
		{
			if (expires != null)
			{
				return expires > DateTime.UtcNow;
			}
			return false;
		}
	}
}
