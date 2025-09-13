<Query Kind="Statements">
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
</Query>

// JsonDocument and JsonNode are nicely formatted in both rich-text and data-grid mode

string json = @"{ ""Name"":""Alice"", ""Age"": 32}";

JsonDocument.Parse (json).Dump ("JsonDocument");
JsonNode    .Parse (json).Dump ("JsonNode");