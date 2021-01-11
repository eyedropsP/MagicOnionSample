using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;
using ServerShared;

namespace MagicOnionSample.Server
{
	// ServiceBase<TServiceInterface>を継承、ISumServiceを実装
	public class SumService : ServiceBase<ISumService>, ISumService
	{
		// asyncを追加
		public async UnaryResult<int> SumAsync(int x, int y)
		{
			// ここはサーバーのコンソールに出てくる
			Console.WriteLine($"Received (x, y) : {x}, {y}");
			// 非同期処理で待つ(今回は特に必要ないけどそれっぽく)
			await Task.Delay(100);
			// 合計を返す
			return x + y;
		}

		// awaitを使わずにこんな風にも書ける
		// 警告 CS1998が出るから抑制する
		// public async UnaryResult<int> SumAsync(int x, int y)
		// 	=> x + y;
	}
}