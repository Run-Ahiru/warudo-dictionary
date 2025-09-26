/**
 * Copyright (c) 2025 Run-Ahiru
 * Licensed under the MIT License.
 * See LICENSE file in the project root for details.
 */
using System;
using System.Collections.Generic;
using System.Linq;

using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Data;


[NodeType(
  Id="cb912ecf-018b-405b-a25d-2f899ce3633a",
  Title="Dictionary キーリストの取得",
  Category="CATEGORY_ARITHMETIC",
  Width=2f
)]
public class GetDictionaryKeysNode : Node {
  [DataInput]
  [Label("Dictionary")]
  public DictionaryData MyDictionary;

  [DataOutput]
  [Label("出力")]
  public string[] OutputKeys() {
    var dic = DictionaryData.Init(MyDictionary);
    SetDataInput(nameof(MyDictionary), dic, broadcast: true);

    return MyDictionary.data.Keys.ToArray();
  }
}