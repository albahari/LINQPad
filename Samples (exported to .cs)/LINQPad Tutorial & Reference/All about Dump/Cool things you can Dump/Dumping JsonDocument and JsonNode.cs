// LINQPad Statements

using System.Text.Json;
using System.Text.Json.Nodes;

// JsonDocument and JsonNode are nicely formatted in both rich-text and data-grid mode

string json = @"{ ""Name"":""Alice"", ""Age"": 32}";

JsonDocument.Parse (json).Dump ("JsonDocument");
JsonNode    .Parse (json).Dump ("JsonNode");