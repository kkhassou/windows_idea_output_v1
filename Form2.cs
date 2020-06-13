using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Realms;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WindowsFormsApp3
{

    public partial class Form2 : Form
    {

        Realm realm;
        public RealmConfiguration Config;
        ObservableCollection<String> data = new ObservableCollection<String>();
        public string all_theme_idea_st = "";
        public string sendText;

        public Form2()
        {
            InitializeComponent();
            Config = new RealmConfiguration(Path.Combine(
                Directory.GetCurrentDirectory(), "Notification.realm"));
            realm = Realm.GetInstance(Config);
            
            listBox1.DataSource = null;
            listBox1.DataSource = data;
            var temp = realm.All<DB_Model.Hint_db>();
            if (true)
            {
                realm.Write(() =>
                {
                    realm.RemoveAll<DB_Model.Hint_db>();
                    realm.RemoveAll<DB_Model.Idea_db>();
                });
            }
            if (temp.Count() == 0)
            {
                var array = new string[] { "パンチ", "住居", "スタジアム", "交差点", "義手", "レジ", "風呂", "機関車", "ランチ", "土偶", "畑", "石器", "おにぎり", "昆虫", "ドリル", "ボトル", "フロント", "服装", "たんぽぽ", "ひとで", "スープ", "屋根裏", "手袋", "プリン", "シェア", "タイタニック", "動物園", "らくだ", "税金", "税務署", "モーター", "ミニ四駆", "ガンディスキー", "紅の豚", "ヴァイオリン", "アンモニア", "書籍", "フットサル", "怪物", "抽象画", "円", "鍬", "キャンディ", "切手", "灰皿", "バンジージャンプ", "犬と猫", "砂遊び", "ミシン", "ネズミ", "樋", "仮面ライダー", "ライター", "海", "野原", "メニュー", "敷物", "中華鍋", "太陽のコロナ", "ヒップアタック", "サンショウウオ", "銃", "インデックス", "上流", "エンディミオンシリーズ", "宇宙船", "季節", "ペスト", "バルブ", "SF", "水槽", "かき氷", "ポスター", "三角形", "辞書", "スーツケース", "金銭", "電話", "接着剤", "埃", "通路", "サーモスタット", "クリアファイル", "シナリオ", "魚拓", "かき氷", "おいしい水", "ナポレオン", "ミルクボーイ", "漫才", "ロビー", "ランダム", "とびうお", "鐘の音", "ビン", "和太鼓", "競馬", "大王イカ", "雲", "図書館", "ビデオデッキ", "ノート", "ネオン", "兆候", "潮流", "煙", "火山", "大学", "ステレオ", "サバの缶詰", "粘土", "かまいたち", "ファン", "裁判所", "板チョコ", "マッチングサイト", "恐竜", "クジラ", "ハンドル", "チップキック", "100M走", "ティーバック", "チョコレート", "ピラミッド", "十字路", "蒸気", "ヌードル", "外套", "カートリッジ", "カボチャ", "恐怖", "ネットワーク", "わさび", "イースター", "大根", "葉巻", "妖精", "配管工", "ハンバーガー", "リフティング", "傷跡", "動画編集", "装飾品", "シャトル", "方程式", "社会福祉", "錨", "ダンサー", "頭皮", "病気", "小型ジェット", "ワセリン", "カリフラワー", "ほうれん草", "掲示版", "卵の殻", "迷路", "ネズミ", "配当", "野火", "肝試し", "予報", "プラム", "平和部隊", "笑い", "病院", "漫才", "硫黄", "格子", "放物線", "鹿児島", "脇役", "透明", "ワニ皮", "牧場", "ボードゲーム", "底", "かくれんぼ", "ロボット工学", "掃除機", "ブレーキ", "コブラ", "戦士", "国土航空局", "ハワイ", "接触", "エンジニア", "いわし", "空洞", "かくれんぼ", "くまもん", "縞模様", "ゆりかご", "オリンピック", "レバー", "インコ", "カエデ", "かさぶた", "埋め立て地", "大牧場", "アルファベット", "お寿司", "盾", "沖縄", "教室", "刑事ドラマ", "賃金アップ", "アニメーター", "レタスの千切り", "ハサミ", "燃料", "排泄物", "EU", "休暇", "エメラルド", "トナカイ", "砂丘", "日本", "蔓", "統計学者", "だんご", "ダイヤル", "ダンボール", "針金工作", "エクセル", "スケート", "双眼鏡" };
                foreach (var one in array)
                {
                    realm.Write(() =>
                    {
                        realm.Add(new DB_Model.Hint_db
                        {
                            category = "関係ない_1",
                            hint = one,
                        });
                    });
                }
                var array2 = new string[] { "＋", "－", "×", "÷", "逆", "分岐" };
                foreach (var one in array2)
                {
                    realm.Write(() =>
                    {
                        realm.Add(new DB_Model.Hint_db
                        {
                            category = "シンプル_1",
                            hint = one,
                        });
                    });
                }
                var array3 = new string[] { "他に使い道は？", "応用できないか？", "修正したら？", "拡大したら？", "縮小したら？", "代用したら？", "アレンジし直したら？", "逆にしたら？", "組み合わせたら？" };
                foreach (var one in array3)
                {
                    realm.Write(() =>
                    {
                        realm.Add(new DB_Model.Hint_db
                        {
                            category = "オズボーンのチェックリスト_1",
                            hint = one,
                        });
                    });
                }
            }
            if (false)
            {
                realm.Write(() =>
                {
                    //var temp = realm.All<DB_Model.Hint_db>().Where(d => d.category == "");
                    //realm.Remove((RealmObject)temp);
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.f2.Visible = false;
            Program.f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dialog1 dialog1 = new Dialog1();
            dialog1.StartPosition = FormStartPosition.CenterScreen;
            dialog1.Width = 600;
            dialog1.Height = 200;
            dialog1.ShowDialog();
            if (dialog1.textBox.Text != "")
            {
                bool flag = false;
                foreach (var row in realm.All<DB_Model.Idea_db>())
                {
                    if (row.theme == dialog1.textBox.Text)
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("L91 one = {0}", dialog1.textBox.Text);
                    //listBox1.Items.Add(dialog1.textBox.Text);
                    data.Add(dialog1.textBox.Text);
                    listBox1.DataSource = null;
                    listBox1.DataSource = data;
                    // テーマをDBに追加
                    realm.Write(() =>
                    {
                        realm.Add(new DB_Model.Idea_db
                        {
                            theme = dialog1.textBox.Text,
                        });
                    });
                    Program.f2.sendText = dialog1.textBox.Text;
                    Program.f2.Visible = false;
                    Program.f3.Show();
                    Program.f3.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    Dialog6 dialog6 = new Dialog6();
                    dialog6.ShowDialog();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "") {
                Console.WriteLine("listBox1.Text:{0}", listBox1.Text);
                Program.f2.sendText = listBox1.Text;
                Program.f2.Visible = false;
                Program.f3.Show();
                Program.f3.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                Dialog5 dialog5 = new Dialog5();
                dialog5.ShowDialog();
            }
        }


        private void Form2_VisibleChanged(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            foreach (var row in realm.All<DB_Model.Idea_db>())
            {
                test.Add(row.theme);
            }
            var testDistinct = test.Distinct();
            //listBox1.Items.Clear();
            data.Clear();
            foreach (var one in testDistinct)
            {
                Console.WriteLine("L130 one = {0}", one);
                //listBox1.Items.Add(one);
                data.Add(one);
            }
            listBox1.DataSource = null;
            listBox1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string before_st = "";
            string temp = "";
            foreach (var row in realm.All<DB_Model.Idea_db>())
            {
                if (before_st != row.theme)
                {
                    temp = temp + "theme:" + row.theme + "\r\n";
                }
                before_st = row.theme;
                if(row.idea != null) {
                    temp = temp + "・" + row.idea + "\r\n";
                }
            }
            all_theme_idea_st = temp;

            Dialog9 dialog9 = new Dialog9();
            dialog9.StartPosition = FormStartPosition.CenterScreen;
            dialog9.Width = 600;
            dialog9.Height = 600;
            dialog9.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button4_Click");
            Dialog8 dialog8 = new Dialog8();
            dialog8.StartPosition = FormStartPosition.CenterScreen;
            dialog8.Width = 600;
            dialog8.Height = 600;
            dialog8.ShowDialog();
            string[] del = { "\r\n" };
            string[] arr = dialog8.textBox3.Text.Split(del, StringSplitOptions.None);
            foreach (var one in arr)
            {
                bool flag = false;
                foreach (var row in realm.All<DB_Model.Idea_db>())
                {
                    if (row.theme == one)
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    realm.Write(() =>
                    {
                        realm.Add(new DB_Model.Idea_db
                        {
                            theme = one,
                        });
                    });
                    Console.WriteLine("L163");
                    data.Add(one);
                }
            }
            listBox1.DataSource = null;
            listBox1.DataSource = data;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }

    // オプションダイアログ
    class Dialog1 : Form
    {
        Label label;
        public TextBox textBox;
        public CheckBox[] checkBox = new CheckBox[3];
        Button okButton;

        public Dialog1()
        {
            label = new Label()
            {
                Location = new Point(20, 20),
                Text = "新しいテーマを入力してください",
            };

            textBox = new TextBox()
            {
                Location = new Point(20, 60),
                Width = 540
            };

            okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 100),
            };

            this.Controls.AddRange(new Control[]
            {
                okButton, textBox , label
            });

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = okButton;
        }
    }
    class Dialog5 : Form
    {
        Label label;
        public CheckBox[] checkBox = new CheckBox[3];
        Button okButton;

        public Dialog5()
        {
            label = new Label()
            {
                Location = new Point(20, 20),
                Text = "リストから選択してから決定を押してください",
                Width = 400
            };


            okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 40),
            };

            this.Controls.AddRange(new Control[]
            {
                okButton, label
            });

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = okButton;
        }
    }
    class Dialog6 : Form
    {
        Label label;
        public CheckBox[] checkBox = new CheckBox[3];
        Button okButton;

        public Dialog6()
        {
            label = new Label()
            {
                Location = new Point(20, 20),
                Text = "重複したテーマは作成できません。",
                Width = 400
            };


            okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 40),
            };

            this.Controls.AddRange(new Control[]
            {
                okButton, label
            });

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = okButton;
        }
    }
    class Dialog9 : Form
    {
        Label label2;
        public TextBox textBox3;
        Button okButton;

        public Dialog9()
        {

            label2 = new Label()
            {
                Location = new Point(20, 20),
                Text = "テーマとアイデアを一括表示",
                Width = 540
            };

            textBox3 = new TextBox()
            {
                Location = new Point(20, 50),
                Width = 540,
                Height = 430
            };
            textBox3.Multiline = true;
            textBox3.Text = Program.f2.all_theme_idea_st;

            okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 510)
            };

            this.Controls.AddRange(new Control[]
            {
                okButton, textBox3 , label2
            });

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = okButton;
        }
    }

    class Dialog8 : Form
    {
        Label label2,label3;
        public TextBox textBox3;
        Button okButton;

        public Dialog8()
        {

            label2 = new Label()
            {
                Location = new Point(20, 20),
                Text = "テーマを入力してください（1行が1テーマになります）",
                Width = 540,
            };
            label3 = new Label()
            {
                Location = new Point(20, 50),
                Text = "※重複したテーマは追加されません ※改行はCrtl+Enterです",
                Width = 540
            };

            textBox3 = new TextBox()
            {
                Location = new Point(20, 80),
                Width = 540,
                Height = 400
            };
            textBox3.Multiline = true;

            okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 510)
            };

            this.Controls.AddRange(new Control[]
            {
                okButton, textBox3 , label2 , label3
            });

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = okButton;
        }
    }
}
