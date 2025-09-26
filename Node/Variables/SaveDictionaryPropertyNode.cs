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
  Id="4cb08b6b-3f4c-4f67-894b-4ff66148e5fb",
  Title="DictionaryをJSONに変換",
  Category="CATEGORY_VARIABLES",
  Width=2f
)]
public class SaveDictionaryNode : Node {
  [DataInput]
  [Label("Dictionary")]
  public DictionaryData MyDictionary;

  [DataOutput]
  [Label("出力")]
  public string OutputDictionaryString() {
    var dic = DictionaryData.Init(MyDictionary);
    SetDataInput(nameof(MyDictionary), dic, broadcast: true);

    return JsonConvert.SerializeObject(ConvertList(MyDictionary), Formatting.None);
  }

  private List<KeyValuePair<string, string>> ConvertList(DictionaryData dic) {
    // 順序を考慮するためにリストを採用
    var list = new List<KeyValuePair<string, string>>();

    // PropListをそのままJSONに変換できなかったため、リストにKey,Valueをリストに格納
    foreach(var prop in dic.PropList) {
      list.Add(new KeyValuePair<string, string>(prop.Key, prop.Value));
    }

    return list;
  }
}