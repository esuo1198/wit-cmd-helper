# Wit Command Helper

[Wiimms ISO Tools (wit)](https://wit.wiimm.de/) を使ったディスクイメージ (WBFS / ISO形式ファイル) の操作を、手助けするための簡易的なCLIプログラムです。<br>


## 〈Features〉
- 拡張子の変換（WBFS ⇄ ISO）
- 展開（WBFS / ISO → フォルダ）
- 結合（フォルダ → WBFS / ISO）
- ゲームID、セーブデータの変更

#### ◆ 拡張子の変換（Convert）
WBFS形式からWii Scrubberが扱えるISO形式に変換する場合、容量削減のためにISO形式からWBFS形式へ変換する場合などに役立ちます。

#### ◆ 展開（Extract）
ディスクイメージ内にあるすべてのファイルが、ディレクトリのツリー状態を維持したまま出力されるため、まとまったファイルの抽出・置き換えに便利なだけでなく、ISOやWBFS形式などにしなくても、**そのままの状態でDolphin Emulatorからmain.dolを使ってゲームを起動することができます。**

#### ◆ 結合（Create）
展開してフォルダ状態になったものをWBFS形式やISO形式にし、実機で使用できるようにします。またゲームIDやセーブデータの変更をするに際して、ソースファイルがディスクイメージでなければならないため、その場合にも役立ちます。

#### ◆ ゲームIDの変更（Change Game ID）
USB LoaderやWii Flow、Dolphin Emulatorなどでチートコードを使用する場合に、コードファイルを分けて保存できるようにします。(ただしこれ以外の使い道は不明)<br>
*※英小文字は使用できませんが、英大数6文字だけでも **"2,176,782,336" 通り**の組み合わせがあるため、他のゲームを考えなければ **最低でも2,176,782,335個のコードファイルが作成できます。**(Dolphin Emulatorで検証)*

#### ◆ セーブデータの変更（Change Save Data）
デフォルトのセーブデータと別のセーブデータを作成できるようにし、ひとつのゲームで複数のセーブデータ、FCなどを持てるようにします。ようするにCTGP RevolutionでSDカードに保存しているものを、SDカードなしでできるようになります。<br>
*※英小文字は使用できませんが、英大数4文字だけでも **"1,679,616" 通り**の組み合わせがあるため、他のゲームを考えなければ **最低でも1,679,615個の追加のセーブデータが作成できます。**(Dolphin Emulatorで検証)*

## 〈Usage〉
### Windows
![Batch](https://github.com/esuo1198/wit-cmd-helper/raw/main/docs/Windows.png)<br>
zipファイルをダウンロードして、解凍後出てきたexeファイルをダブルクリックで実行するだけです。<br>
ダウンロードは右側の[Releases](https://github.com/esuo1198/wit-cmd-helper/releases)からできます。（最新バージョンは[こちら](https://github.com/esuo1198/wit-cmd-helper/releases/latest)）

### macOS / Linux
![Shell](https://github.com/esuo1198/wit-cmd-helper/raw/main/docs/Unix.png)<br>
ダウンロードは右側の[Releases](https://github.com/esuo1198/wit-cmd-helper/releases)からできます。（最新バージョンは[こちら](https://github.com/esuo1198/wit-cmd-helper/releases/latest)）

一番簡単で確実な起動方法は、ターミナルを起動し、そこにダウンロードしたスクリプトをドラッグ＆ドロップすることです。*(環境によってはダブルクリックでも起動できる場合がありますが、特定の環境に限られているためD&Dで実行するのが確実です。)*<br>
またその他にもスクリプトのあるディレクトリでターミナルを起動し、以下のコマンドを実行するという方法でも起動することが可能です。
```
./wit-cmd-helper
```

## 〈Dev / Test Environment〉
#### Windows
OS: Windows 10<br>
wit: v3.04a r8427 cygwin64

#### macOS / Linux
OS: Big Sur11.6.4 / ArchLinux (KDE Plasma)<br>
wit: v3.04a r8427 x86_64

## 〈Developer〉
<a href="https://twitter.com/esuo____">
    <img src="https://avatars.githubusercontent.com/u/73988937" width="100px">
</a>

## 〈Special Thanks〉
- Mrmk
- 果夏
