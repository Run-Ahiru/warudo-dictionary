/**
 * Copyright (c) 2025 Run-Ahiru
 * Licensed under the MIT License.
 * See LICENSE file in the project root for details.
 */
using System;
using System.Collections.Generic;

using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Data;


[NodeType(
  Id="cab60064-5a4c-4e29-bd46-27ba4b1cea76",
  Title="Dictionary にキーが存在するか",
  Category="CATEGORY_ARITHMETIC",
  Width=2f
)]
public class HasDictionaryKeyNode : Node {
  [DataInput]
  [Label("Dictionary")]
  public DictionaryData MyDictionary;

  [DataInput]
  [Label("キー")]
  public string Key;

  [DataOutput]
  [Label("出力")]
  public bool OutputHasKey() {
    var dic = DictionaryData.Init(MyDictionary);
    SetDataInput(nameof(MyDictionary), dic, broadcast: true);

    return MyDictionary.data.ContainsKey(Key);
  }
}