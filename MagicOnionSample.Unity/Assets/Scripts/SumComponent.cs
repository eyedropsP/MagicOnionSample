using Grpc.Core;
using MagicOnion.Client;
using ServerShared;
using UnityEngine;
using UnityEngine.UI;

public class SumComponent : MonoBehaviour
{
	private Channel channel;
	private ISumService client;
	private int x, y;

	public InputField InputTextX;
	public InputField InputTextY;
	public Text ResultLabel;
	public Button SumButton;

	private void Start()
	{
		InitializeClient();

		SumButton.onClick.AddListener(async () =>
		{
			if (IsNumberInputText())
			{
				// async/await でサービスを呼び出す
				int result = await client.SumAsync(x, y);
				ResultLabel.text = result.ToString();
			}
			else
			{
				ResultLabel.text = "数字を入れてね";
			}
		});
	}

	private void InitializeClient()
	{
		// gRPCチャンネルを生成
		channel = new Channel("127.0.0.1", 5000, ChannelCredentials.Insecure);
		// ISumServiceと通信するクライアントを生成
		client = MagicOnionClient.Create<ISumService>(channel);
	}

	/// <summary>
	/// 入力値確認
	/// </summary>
	/// <returns></returns>
	private bool IsNumberInputText()
	{
		return int.TryParse(InputTextX.text, out x)
		       && int.TryParse(InputTextY.text, out y);
	}
}