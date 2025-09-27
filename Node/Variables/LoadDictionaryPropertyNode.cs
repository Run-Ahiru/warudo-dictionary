/**
 * Copyright (c) 2025 Run-Ahiru
 * Licensed under the MIT License.
 * See LICENSE file in the project root for details.
 */
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Data;


[NodeType(
  Id="de33b915-f964-4727-bf93-94414fd4f717",
  Title="DictionaryをJSONから復元",
  Category="CATEGORY_VARIABLES",
  Width=2f
)]
public class LoadDictionaryNode : Node {
  [DataInput]
  [Hidden]
  public DictionaryData MyDictionary;

  [DataInput]
  [Label("JSON")]
  public string Json;

  [DataOutput]
  [Label("出力")]
  public DictionaryData OutputDictionary() {
    MyDictionary.PropList = Restore(Json);
    Broadcast();
    
    return MyDictionary;
  }

  private DictionaryPropertyData[] Restore(string json) {
    var deserializedList = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(json);
    var list = new List<DictionaryPropertyData>();
    
    foreach(var prop in deserializedList) {
      var temp = StructuredData.Create<DictionaryPropertyData>();

      temp.Key = prop.Key;
      temp.Value = prop.Value;

      list.Add(temp);
    }

    return list.ToArray();
  }
}