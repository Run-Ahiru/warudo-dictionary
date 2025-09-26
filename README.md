# warudo-dictionary
WarudoでDictionary型を使用できるようにするカスタムノードです。


## ノード一覧

### リテラル
- DictionaryNode (Dictionary)
- DictionaryPropertyNode (Dictionary Property)

### 計算
- AddDictionaryPropertyNode (Dictionary Property 追加要素)
- DelDictionaryPropertyNode (Dictionary Property 要素の削除)
- GetDictionaryKeysNode (Dictionary キーリストの取得)
- GetDictionaryPropertyNode (Dictionary Property 要素の取得)
- HasDictionaryKeyNode (Dictionary にキーが存在するか)

### 変量
- LoadDictionaryNode (DictionaryをJSONから復元)
- SaveDictionaryNode (DictionaryをJSONに変換)


変数にDictionary型が追加できなかったので、文字列に変換したデータをString変数に保存し、復元する場合はString変数から値を取得してDictionaryを復元する必要があります。


## 使い方
記述予定