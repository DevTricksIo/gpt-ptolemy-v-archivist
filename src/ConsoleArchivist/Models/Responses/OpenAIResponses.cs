﻿using System.Text.Json.Serialization;

namespace ConsoleArchivist.Models.Responses;

public record JsonResponse([property: JsonPropertyName("id")] string Id,
                           [property: JsonPropertyName("object")] string Object,
                           [property: JsonPropertyName("created")] int Created,
                           [property: JsonPropertyName("model")] string Model,
                           [property: JsonPropertyName("choices")] Choice[] Choices,
                           [property: JsonPropertyName("usage")] Usage Usage,
                           [property: JsonPropertyName("system_fingerprint")] object SystemFingerprint);

public record Choice([property: JsonPropertyName("index")] int Index,
                     [property: JsonPropertyName("message")] Message Message,
                     [property: JsonPropertyName("logprobs")] object Logprobs,
                     [property: JsonPropertyName("finish_reason")] string FinishReason);

public record Message([property: JsonPropertyName("role")] string Role,
                      [property: JsonPropertyName("content")] string Content);

public record Usage([property: JsonPropertyName("prompt_tokens")] int PromptTokens,
                    [property: JsonPropertyName("completion_tokens")] int CompletionTokens,
                    [property: JsonPropertyName("total_tokens")] int TotalTokens);
