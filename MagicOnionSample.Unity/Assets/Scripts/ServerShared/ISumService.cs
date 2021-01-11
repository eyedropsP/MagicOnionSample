using MagicOnion;

namespace ServerShared
{
	public interface ISumService : IService<ISumService>
	{
		UnaryResult<int> SumAsync(int x, int y);
	}
}