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

public class DictionaryPropertyData : StructuredData, ICollapsibleStructuredData {
  [DataInput]
  public string Key;

  [DataInput]
  public string Value;

  public string GetHeader() => Key + " : " + Value;
}