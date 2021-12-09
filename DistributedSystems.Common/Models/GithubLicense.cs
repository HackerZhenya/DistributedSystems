﻿using System.Text.Json.Serialization;

namespace DistributedSystems.Entities.Models;

public class GithubLicense
{
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("node_id")]
    public string? NodeId { get; set; }

    [JsonPropertyName("spdx_id")]
    public string? SpdxId { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}