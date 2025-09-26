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

public class DictionaryData : StructuredData {
  
  public Dictionary<string, string> data = new Dictionary<string, string>();

  [DataInput]
  [Label("Property")]
  public DictionaryPropertyData[] PropList;

  public static DictionaryData Init(DictionaryData dic) {
    // 初期化
    dic.data = new Dictionary<string, string>();
    // データ処理
    dic = DictionaryData.DedupPropList(dic);
    dic = DictionaryData.SetDictionary(dic);
  
    return dic;
  }

  public static DictionaryData DedupPropList(DictionaryData dic) {
    var tempHash = new HashSet<string>();
    var tempList = new List<DictionaryPropertyData>(dic.PropList);

    for(int i=tempList.Count-1; i>=0; i--) {
      if (!tempHash.Add(tempList[i].Key)) {
        // すでに後方で同じキーがあれば、現在の（前方の）要素を削除
        tempList.RemoveAt(i);
      }
    }

    dic.PropList = tempList.ToArray();

    return dic;
  }

  public static DictionaryData SetDictionary(DictionaryData dic) {
    foreach(var prop in dic.PropList) {
      dic.data[prop.Key] = prop.Value;
    }

    return dic;
  }
}