using HoYoLabApi.interfaces;

namespace HoYoLabApi.Models;

public record DailyClaimResult(int Code, string Message) : IDailyClaimResult;