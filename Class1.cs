using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace DB_Model
{
    // RealmObject を継承したクラスがテーブルになる。
    class Idea_db : RealmObject
    {
        public string theme { get; set; }
        public string hint { get; set; }
        public string idea { get; set; }
    }
    class Hint_db : RealmObject
    {
        public string category { get; set; }
        public string hint { get; set; }
    }

}