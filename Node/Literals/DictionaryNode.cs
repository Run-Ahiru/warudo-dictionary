/**
 * Copyright (c) 2025 Run-Ahiru
 * Licensed under the MIT License.
 * See LICENSE file in the project root for details.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Data;

[NodeType(
  Id="97d08100-a3b2-4a55-a02e-e69dbec678df",
  Title="Dictionary",
  Category="CATEGORY_LITERALS",
  Width=2f
)]
public class DictionaryNode : Node {
  [DataInput]
  [HideLabel]
  public DictionaryData MyDictionary;

  [DataOutput]
  [Label("出力")]
  public DictionaryData OutputDictionary() {
    var dic = DictionaryData.Init(MyDictionary);
    SetDataInput(nameof(MyDictionary), dic, broadcast: true);

    return MyDictionary;
  }
}