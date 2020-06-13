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

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {

        Realm realm;
        public RealmConfiguration Config;
        string selected_category = "シンプル_1";
        public string daialog_message = "";

        public Form3()
        {
            InitializeComponent();
            Config = new RealmConfiguration(Path.Combine(
                Directory.GetCurrentDirectory(), "Notification.realm"));
            realm = Realm.GetInstance(Config);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                // 重複削除
                bool flag = false;
                foreach (var row in realm.All<DB_Model.Idea_db>().Where(d => d.theme == Program.f2.sendText))
                {
                    if (row.idea == textBox1.Text)
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
                            theme = label1.Text,
                            hint = "hint",
                            idea = textBox1.Text
                        });
                    });
                    listBox1.Items.Add(textBox1.Text);
                    List<string> test = new List<string>();
                    foreach (var row in realm.All<DB_Model.Hint_db>().Where(d => d.category == selected_category))
                    {
                        test.Add(row.hint);
                    }
                    Random r1 = new System.Random();
                    int r2 = r1.Next(0, test.Count);
                    label3.Text = test[r2];
                    textBox1.Text = "";
                }
            }
            else
            {
                List<string> test = new List<string>();
                foreach (var row in realm.All<DB_Model.Hint_db>().Where(d => d.category == selected_category))
                {
                    test.Add(row.hint);
                }
                Random r1 = new System.Random();
                int r2 = r1.Next(0, test.Count);
                label3.Text = test[r2];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.f3.Visible = false;
            Program.f2.Show();
            Program.f2.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form3_VisibleChanged(object sender, EventArgs e)
        {
            label1.Text = Program.f2.sendText;
            listBox1.Items.Clear();
            foreach (var row in realm.All<DB_Model.Idea_db>().Where(d => d.theme == Program.f2.sendText))
            {
                if (row.idea != null) {
                    listBox1.Items.Add(row.idea);
                }
            }
            List<string> test = new List<string>();
            foreach (var row in realm.All<DB_Model.Hint_db>().Where(d => d.category == selected_category))
            {
                test.Add(row.hint);
            }
            Random r1 = new System.Random();
            int r2 = r1.Next(0, test.Count);
            label3.Text = test[r2];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dialog2 dialog2 = new Dialog2();
            dialog2.StartPosition = FormStartPosition.CenterScreen;
            dialog2.Width = 600;
            dialog2.Height = 600;
            dialog2.ShowDialog();

            if (dialog2.listBox2.Text == "")
            {
                selected_category = "シンプル_1";
                daialog_message = "ヒントのカテゴリを選択してください。";
                Dialog7 dialog7 = new Dialog7();
                dialog7.ShowDialog();
            }
            else
            {
                selected_category = dialog2.listBox2.Text;
            }

            List<string> test = new List<string>();
            foreach (var row in realm.All<DB_Model.Hint_db>().Where(d => d.category == selected_category))
            {
                test.Add(row.hint);
            }
            Random r1 = new System.Random();
            int r2 = r1.Next(0, test.Count);
            label3.Text = test[r2];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dialog3 dialog3 = new Dialog3();
            dialog3.StartPosition = FormStartPosition.CenterScreen;
            dialog3.Width = 600;
            dialog3.Height = 600;
            dialog3.ShowDialog();

            if (dialog3.textBox3.Text == "" || dialog3.textBox4.Text == "")
            {
                daialog_message = "ヒントのカテゴリと内容の両方を入力してください";
                Dialog7 dialog7 = new Dialog7();
                dialog7.ShowDialog();
            }
            else
            {
                string[] del = { "\r\n" };
                string[] arr = dialog3.textBox3.Text.Split(del, StringSplitOptions.None);
                foreach (var one in arr)
                {
                    realm.Write(() =>
                    {
                        realm.Add(new DB_Model.Hint_db
                        {
                            category = dialog3.textBox4.Text,
                            hint = one,
                        });
                    });
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dialog4 dialog4 = new Dialog4();
            dialog4.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }

    class Dialog2 : Form
    {
        Label label;
        public ListBox listBox2;
        Button okButton;
        Realm realm;
        public RealmConfiguration Config;

        public Dialog2()
        {
            Config = new RealmConfiguration(Path.Combine(
                Directory.GetCurrentDirectory(), "Notification.realm"));
            realm = Realm.GetInstance(Config);
            label = new Label()
            {
                Location = new Point(20, 20),
                Text = "ヒントカテゴリを選択してください",
            };

            listBox2 = new ListBox()
            {
                Location = new Point(20, 40),
                Width = 540,
                Height = 450
            };

            List<string> test = new List<string>();
            foreach (var row in realm.All<DB_Model.Hint_db>())
            {
                if (row.category != "")
                {
                    test.Add(row.category);
                }
            }
            var testDistinct = test.Distinct();
            listBox2.Items.Clear();
            foreach (var one in testDistinct)
            {
                listBox2.Items.Add(one);
            }

            okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 510),
            };

            this.Controls.AddRange(new Control[]
            {
                okButton, listBox2 , label
            });

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 500;
            this.Height = 500;
            this.AcceptButton = okButton;
        }
    }

    class Dialog3 : Form
    {
        Label label;
        Label label2;
        public TextBox textBox3;
        public TextBox textBox4;
        Button okButton;

        public Dialog3()
        {
            label = new Label()
            {
                Location = new Point(20, 20),
                Text = "ヒントカテゴリを入力してください",
            };

            textBox4 = new TextBox()
            {
                Location = new Point(20, 50),
                Width = 540,
                Height = 20
            };

            label2 = new Label()
            {
                Location = new Point(20, 80),
                Text = "ヒントの内容を入力してください（1行が1項目になります）",
            };


            textBox3 = new TextBox()
            {
                Location = new Point(20, 110),
                Width = 540,
                Height = 380
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
                okButton, textBox3 , label, textBox4, label2
            });

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = okButton;
        }
    }
    class Dialog4 : Form
    {
        Label label;
        public TextBox textBox3;
        Button okButton;
        Realm realm;
        public RealmConfiguration Config;

        public Dialog4()
        {
            Config = new RealmConfiguration(Path.Combine(
                Directory.GetCurrentDirectory(), "Notification.realm"));
            realm = Realm.GetInstance(Config);
            label = new Label()
            {
                Location = new Point(20, 20),
                Text = "テキスト化したアイデア",
                Width = 200
            };


            textBox3 = new TextBox()
            {
                Location = new Point(20, 40),
                Width = 450,
                Height = 450
            };
            textBox3.Multiline = true;
            String temp = "";
            temp = temp + "theme:" + Program.f2.sendText + "\r\n";
            foreach (var row in realm.All<DB_Model.Idea_db>().Where(d => d.theme == Program.f2.sendText))
            {
                temp = temp + "・" + row.idea + "\r\n";
            }
            textBox3.Text = temp;

            okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 500),
            };

            this.Controls.AddRange(new Control[]
            {
                okButton, textBox3 , label
            });

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 500;
            this.Height = 600;
            this.AcceptButton = okButton;
        }
    }
    class Dialog7 : Form
    {
        Label label;
        public CheckBox[] checkBox = new CheckBox[3];
        Button okButton;

        public Dialog7()
        {
            label = new Label()
            {
                Location = new Point(20, 20),
                Text = Program.f3.daialog_message,
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
}
