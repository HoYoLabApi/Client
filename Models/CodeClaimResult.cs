using HoYoLabApi.interfaces;

namespace HoYoLabApi.Models;

public record CodeClaimResult(int Code, string Message) : ICodeClaimResult;