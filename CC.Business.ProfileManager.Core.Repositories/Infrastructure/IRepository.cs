using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public interface IRepository
	{
		IRepoSession Session { get; set;}
	}
}