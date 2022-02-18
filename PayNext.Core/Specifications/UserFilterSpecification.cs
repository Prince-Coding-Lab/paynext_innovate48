using PayNext.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayNext.Core.Specifications
{
	public class UserFilterSpecification : BaseSpecification<User>
	{
		public UserFilterSpecification(string userName,string password)
			 : base(c => c.Email == userName && c.Password == password)
		{
		}
	}
}
