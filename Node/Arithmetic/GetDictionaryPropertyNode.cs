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
  Id="b95be8e8-2cd9-4bed-aca1-b130d95a1dbc",
  Title="Dictionary Property 要素の取得",
  Category="CATEGORY_ARITHMETIC",
  Width=2f
)]
public class GetDictionaryPropertyNode : Node {
  [DataInput]
  [Label("Dictionary")]
  public DictionaryData MyDictionary;

  [DataInput]
  [Label("キー")]
  public string Key;

  [DataOutput]
  [Label("出力")]
  public string OutputValue() {
    var dic = DictionaryData.Init(MyDictionary);
    SetDataInput(nameof(MyDictionary), dic, broadcast: true);

    return MyDictionary.data[Key];
  }
}