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
  Id="c2f9218c-3ed2-4a47-a4b7-02ddda78486a",
  Title="Dictionary Property 要素の削除",
  Category="CATEGORY_ARITHMETIC",
  Width=2f
)]
public class DelDictionaryPropertyNode : Node {
  [DataInput]
  [Label("Dictionary")]
  public DictionaryData MyDictionary;

  [DataInput]
  [Label("キー")]
  public string Key;

  [DataOutput]
  [Label("出力")]
  public DictionaryData OutputDictionary() {
    var dic = DictionaryData.Init(DelProperty(MyDictionary, Key));
    SetDataInput(nameof(MyDictionary), dic, broadcast: true);

    return MyDictionary;
  }

  private DictionaryData DelProperty(DictionaryData dic, string key) {
    var tempList = new List<DictionaryPropertyData>(dic.PropList);
    
    for(var i=0; i<tempList.Count; i++) {
      if(tempList[i].Key == key) {
        tempList.RemoveAt(i);
      }
    }
    dic.PropList = tempList.ToArray();

    return dic;
  }
}