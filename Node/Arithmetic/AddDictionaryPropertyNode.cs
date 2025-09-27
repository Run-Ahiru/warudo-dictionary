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
  Id="de09a07a-4946-4a6d-a7ea-dd1f41e41a27",
  Title="Dictionary Property 追加要素",
  Category="CATEGORY_ARITHMETIC",
  Width=2f
)]
public class AddDictionaryPropertyNode : Node {
  [DataInput]
  [Label("Dictionary")]
  public DictionaryData MyDictionary;

  [DataInput]
  [Label("Property")]
  public DictionaryPropertyData Prop;

  [DataOutput]
  [Label("出力")]
  public DictionaryData OutputDictionary() {
    var dic = AddProperty(MyDictionary, Prop);
    dic = DictionaryData.Init(MyDictionary);
    
    SetDataInput(nameof(MyDictionary), dic, broadcast: true);
  
    return MyDictionary;
  }

  private DictionaryData AddProperty(DictionaryData dic, DictionaryPropertyData prop) {
    var tempList = new List<DictionaryPropertyData>(dic.PropList) { prop };
    dic.PropList = tempList.ToArray();

    return dic;
  }
}