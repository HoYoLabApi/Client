using HoYoLabApi.interfaces;

namespace HoYoLabApi.Models;

public class GameResponse : IGameResponse
{
	public int Code { get; init; }
	public string Message { get; init; }
	public Data Data { get; init; }
}