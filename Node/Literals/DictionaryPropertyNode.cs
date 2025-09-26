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
  Id="642d51df-54a2-44e0-880c-52a0e26829e0",
  Title="Dictionary Property",
  Category="CATEGORY_LITERALS"
)]
public class DictionaryPropertyNode : Node {
  [DataInput]
  public string Key;

  [DataInput]
  public string Value;

  [DataInput]
  [Hidden]
  public DictionaryPropertyData Prop;

  [DataOutput]
  [Label("出力")]
  public DictionaryPropertyData OutputProp() {
    Prop.Key = Key;
    Prop.Value = Value;
    SetDataInput(nameof(Prop), Prop, broadcast: true);

    return Prop;
  }
}