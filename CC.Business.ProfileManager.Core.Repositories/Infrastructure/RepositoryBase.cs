namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public abstract class RepositoryBase : IRepository
	{
		protected IRepoSession session;

		public IRepoSession Session
		{
			get { return session; }
			set { session = value; }
		}
	}
}